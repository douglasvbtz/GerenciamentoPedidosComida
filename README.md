# Aplicativo de Gerenciamento de Pedidos de Comida

A proposta visa desenvolver um aplicativo de gerenciamento de pedidos de comida, que conectará restaurantes e clientes de forma eficiente e conveniente. O aplicativo proporcionará uma experiência aprimorada para fazer pedidos, acompanhar o status dos pedidos em tempo real e facilitar a comunicação entre os restaurantes e os clientes.

Neste projeto, utilizaremos C# e os princípios da programação orientada a objetos para criar um aplicativo de gerenciamento de pedidos de comida. Serão desenvolvidas classes como "Restaurante", "Cliente" e "Pedido", explorando conceitos como relacionamentos, herança, polimorfismo e encapsulamento. O aplicativo também implementará funcionalidades realistas, como efetuar pedidos, gerenciar menus e rastrear o status dos pedidos.

## Instalação

- Instale a versão 8 do [MySql Server] (https://dev.mysql.com/downloads/mysql/)
- Siga o tutorial de configuração do MySql Server.
- Crie o usuário `root` com senha `1234`.

- Faça um fork do sistema pelo github
- Entre no diretório que o arquivo `Program.cs` está localizado.
- Abra o terminal e execute as seguintes linhas de código.
- `dotnet build`
- `dotnet ef migrations add Initial`
- `dotnet ef database update`
- Agora execute o comando `dotnet run` e pronto!