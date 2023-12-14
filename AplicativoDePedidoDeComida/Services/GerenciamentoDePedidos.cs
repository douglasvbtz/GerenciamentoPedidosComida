using AplicativoDeComida.Controller;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;
using System;
using System.Collections.Generic;

namespace AplicativoDeComida.Services
{
    public class GerenciamentoDePedidos
    {
        private AppDbContext _context;
        private PedidoRepositoryMySQL _pedidoRepositoryMySQL;
        private ClienteRepositoryMySQL _clienteRepository;
        private ItemMenuRepositoryMySQL _itemMenuRepositoryMySQL;

        public GerenciamentoDePedidos(AppDbContext context)
        {
            _context = context;
            _pedidoRepositoryMySQL = new PedidoRepositoryMySQL(_context);
            _itemMenuRepositoryMySQL = new ItemMenuRepositoryMySQL(_context);
        }

        public void CriarPedido(string clienteId, List<int> itensMenuIds, string endereco)
        {
            // Obtém os itens de menu selecionados
            List<ItemMenu> itensMenu = new List<ItemMenu>();
            foreach (int itemId in itensMenuIds)
            {
                ItemMenu item = _itemMenuRepositoryMySQL.ObterPorId(itemId);
                if (item != null)
                {
                    itensMenu.Add(item);
                }
            }

            // Calcula o total do pedido com base nos itens de menu selecionados
            decimal total = 0;
            foreach (var item in itensMenu)
            {
                total += item.Preco; // Supondo que cada item de menu tenha um atributo 'Preco'
            }

            // Cria um novo pedido e atribui valores aos seus atributos
            Pedido novoPedido = new Pedido
            {
                ClienteId = int.Parse(clienteId),
                Endereco = endereco,
                Total = total,
                Data = DateTime.Now,
                Status = "Novo"
            };

            _pedidoRepositoryMySQL.Inserir(novoPedido);
        }

        public List<ItemMenu> ObterItensDisponiveisNoRestaurante(int restauranteId)
        {
            return _itemMenuRepositoryMySQL.ObterTodosItensMenu(restauranteId);
        }
    }
}
