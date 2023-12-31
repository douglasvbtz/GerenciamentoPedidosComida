﻿using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;
using AplicativoDeComida.Services;
using static AplicativoDeComida.Services.GerenciamentoDeCliente;
using static AplicativoDeComida.Services.GerenciamentoDeRestaurante;
using Spectre.Console;

namespace AplicativoDeComida
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                var gerenciamentoDeCliente = new GerenciamentoDeCliente(context);
                var gerenciamentoDeRestaurante = new GerenciamentoDeRestaurante(context);
                var gerenciamenoDeItemMenu = new GerenciamentoDeItemMenu(context);
                var gerenciamentoDePedido = new GerenciamentoDePedidos(context);
                var autenticacaoCliente = new AutenticacaoCliente(context);
                var autenticacaoRestaurate = new AutenticacaoRestaurante(context);
                var autenticacaoRestaurante = new AutenticacaoRestaurante(context);
                GerenciamentoDePedidos gerenciamentoDePedidos = new GerenciamentoDePedidos(context);

                int opcao = -1;

                while (opcao != 0)
                {
                    Console.WriteLine("Bem-vindo ao Food Delivery App!");
                    Console.WriteLine("Por favor, selecione o tipo de usuário:");
                    Console.WriteLine("1 - Cliente");
                    Console.WriteLine("2 - Restaurante");
                    Console.WriteLine("0 - Sair");

                    if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 2)
                    {
                        Console.WriteLine("Opção inválida! Por favor, selecione 1 para Cliente, 2 para Restaurante, ou 0 para Sair.");
                    }
                    else if (opcao == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Você selecionou Cliente!");
                        Console.WriteLine("Por favor, escolha uma opção:");
                        Console.WriteLine("1 - Fazer Login");
                        Console.WriteLine("2 - Criar Nova Conta");
                        Console.WriteLine("0 - Voltar");

                        int opcaoCliente = -1;

                        if (!int.TryParse(Console.ReadLine(), out opcaoCliente) || opcaoCliente < 0 || opcaoCliente > 2)
                        {
                            Console.WriteLine("Opção inválida! Por favor, selecione 1 para Fazer Login, 2 para Criar Nova Conta ou 0 para Voltar.");
                        }
                        else
                        {
                            switch (opcaoCliente)
                            {
                                case 0:
                                    Console.WriteLine("Voltando...");
                                    break;
                                case 1:
                                    Cliente clienteLogado = autenticacaoCliente.ValidarCliente();
                                    if (clienteLogado != null)
                                    {
                                        Console.Clear();
                                        // Faça o que precisar com o cliente logado
                                        Console.WriteLine($"Bem-vindo, {clienteLogado.Nome}!");
                                        List<Restaurante> restaurantes = gerenciamentoDeRestaurante.ObterTodosRestaurantes();
                                        if (restaurantes != null && restaurantes.Any())
                                        {
                                            Console.Write("Digite o ID do restaurante desejado: ");
                                            if (int.TryParse(Console.ReadLine(), out int restauranteId))
                                            {
                                                Restaurante restauranteEscolhido = gerenciamentoDeRestaurante.ObterRestaurantePorId(restauranteId);

                                                if (restauranteEscolhido != null)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine($"Restaurante escolhido: {restauranteEscolhido.Nome}");
                                                    // Utilize o restaurante escolhido conforme necessário
                                                    List<ItemMenu> itensDoRestaurante = gerenciamenoDeItemMenu.ObterTodosItensMenu(restauranteId);
                                                    if (itensDoRestaurante != null && itensDoRestaurante.Any())
                                                    {
                                                        Console.WriteLine("Itens do menu disponíveis:");
                                                        foreach (var itemMenu in itensDoRestaurante)
                                                        {
                                                            string precoFormatado = itemMenu.Preco.ToString("F2");
                                                            Console.WriteLine($"ID: {itemMenu.ItemMenuId} - Nome: {itemMenu.Nome} - Descrição: {itemMenu.Descricao} - Preço: {precoFormatado}");
                                                            // Mostrar outros detalhes do item do menu, se necessário
                                                        }
                                                        // Permitir ao cliente selecionar itens para fazer um pedido
                                                        Console.WriteLine("Selecione os IDs dos itens que deseja pedir (separados por vírgula):");
                                                        string inputItens = Console.ReadLine();
                                                        List<int> itensSelecionados = inputItens.Split(',').Select(int.Parse).ToList();
                                                        // Verificação se existem itens selecionados
                                                        if (itensSelecionados.Any())
                                                        {
                                                            Console.WriteLine("Digite o endereço para entrega do pedido:");
                                                            string enderecoDoCliente = Console.ReadLine();

                                                            Console.WriteLine("Aguardando pedido ser confirmado no restaurante...");

                                                            // Timer para o pedido ser aceito após 5 segundos
                                                            Timer timerPedidoAceito = new Timer((state) =>
                                                            {
                                                                Console.WriteLine("Pedido aceito!");
                                                            }, null, TimeSpan.FromSeconds(5), Timeout.InfiniteTimeSpan);

                                                            // Timer para o pedido pronto para entrega após 15 segundos
                                                            Timer timerPedidoPronto = new Timer((state) =>
                                                            {
                                                                Console.WriteLine("Pedido pronto, saiu para entrega!");
                                                            }, null, TimeSpan.FromSeconds(10), Timeout.InfiniteTimeSpan);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Nenhum item selecionado. Pedido não realizado.");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nenhum item de menu disponível para este restaurante.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("ID do restaurante não encontrado.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Entrada inválida. Insira um número válido.");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Falha no login!");
                                        // Lógica para lidar com a falha de login
                                    }
                                    break;
                                case 2:
                                    Cliente novoCliente = new Cliente();
                                    gerenciamentoDeCliente.inserirNovoCliente(novoCliente);
                                    break;
                            }
                        }
                    }
                    else if (opcao == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Você selecionou Restaurante!");
                        Console.WriteLine("Por favor, escolha uma opção:");
                        Console.WriteLine("1 - Fazer Login");
                        Console.WriteLine("2 - Criar Nova Conta");
                        Console.WriteLine("0 - Voltar");

                        int opcaoRestaurante = -1;

                        if (!int.TryParse(Console.ReadLine(), out opcaoRestaurante) || opcaoRestaurante < 0 || opcaoRestaurante > 2)
                        {
                            Console.WriteLine("Opção inválida! Por favor, selecione 1 para Fazer Login, 2 para Criar Nova Conta ou 0 para Voltar.");
                        }
                        else
                        {
                            switch (opcaoRestaurante)
                            {
                                case 0:
                                    Console.WriteLine("Voltando...");
                                    break;
                                case 1:
                                    // Restaurante selecionou Fazer Login
                                    Restaurante restauranteLogado = autenticacaoRestaurante.ValidarRestaurante();
                                    if (restauranteLogado != null)
                                    {
                                        List<ItemMenu> itensDoRestaurante = gerenciamenoDeItemMenu.ObterTodosItensMenu(restauranteLogado.RestauranteId);
                                        if (itensDoRestaurante != null && itensDoRestaurante.Any())
                                        {
                                            Console.WriteLine("Itens do menu disponíveis:");
                                            foreach (var itemMenu in itensDoRestaurante)
                                            {
                                                string precoFormatado = itemMenu.Preco.ToString("F2");
                                                Console.WriteLine($"ID: {itemMenu.ItemMenuId} - Nome: {itemMenu.Nome} - Descrição: {itemMenu.Descricao} - Preço: {precoFormatado}");
                                                // Mostrar outros detalhes do item do menu, se necessário
                                            }
                                        }
                                        
                                        Console.WriteLine("Selecione a opção:");
                                        Console.WriteLine("1 - Adicionar Item no Menu");
                                        Console.WriteLine("2 - Alterar Item no Menu");
                                        Console.WriteLine("3 - Excluir Item do Menu");
                                        Console.WriteLine("0 - Voltar");

                                        if (int.TryParse(Console.ReadLine(), out int opcaoRestauranteMenu))
                                        {
                                            switch (opcaoRestauranteMenu)
                                            {
                                                case 1:
                                                    gerenciamenoDeItemMenu.AdicionarItemMenu(restauranteLogado.RestauranteId);
                                                    break;
                                                case 2:
                                                    // Lógica para alterar um item do menu
                                                    gerenciamenoDeItemMenu.AtualizarItemMenu();
                                                    break;
                                                case 3:
                                                    // Lógica para excluir um item do menu
                                                    gerenciamenoDeItemMenu.RemoverItemMenu();
                                                    break;
                                                case 0:
                                                    Console.WriteLine("Voltando...");
                                                    break;
                                                default:
                                                    Console.WriteLine("Opção inválida!");
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opção inválida!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falha na autenticação do restaurante.");
                                        // Lógica para lidar com a falha de login
                                    }
                                    break;
                                case 2:
                                    Restaurante novoRestaurante = new Restaurante();
                                    gerenciamentoDeRestaurante.CriarRestaurante(novoRestaurante);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
