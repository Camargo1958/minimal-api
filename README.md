# Projeto: minima-api
# Criando o projeto:
>dotnet new web -o minimal-api --framework net7.0

# Inicializar repositorio local

# Criar repositório no Github

# Criar .gitignore
    - gitignore.io

# Criar rota login com validação em memória

# Configurar Entity Framework no projeto e tabela de admnistradores
 - nuget.org -> entity framework -> Microsoft.EntityFrameworkCore -> Versions -> 7.0.20 : copia comando
 - >dotnet add package Microsoft.EntityFrameworkCore --version 7.0.20
 - nuget.org -> entity framework -> Microsoft.EntityFrameworkCore.Design -> Versions -> 7.0.20 : copia comando
 - >dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.20
 - nuget.org -> entity framework -> Microsoft.EntityFrameworkCore.Tools -> Versions -> 7.0.20 : copia comando
 - >dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.20
 - nuget.org -> entity framework -> Pomelo.EntityFrameworkCore.MySql - Versions -> 7.0.0 : copia comando
 - >dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
 - Usar uma arquitetura d projeto misto de clean e Onion:
   - pasta Infraestrutura (conexão com banco de dados, etc.)
   - pasta Dominio (algumas regras de negocio)
   - pasta Dominio/Entidades
   - pasta Dominio/Servicos
   - pasta Dominio/DTOs
   - Mover LoginDTO para local correto
   - pasta Ifraestrutura/Db
   - classe Ifraestrutura/Db/DbContexto.cs
   - classe Dominio/Entidades/Administrador.cs
 - Modificar appsettings.json
   - ConnectionStrings
 - Incluir referencia à string de conexão em DbContexto.cs
 - Recuperar a string de conexão no Program.cs
 - Refeletir a modificação de optionsBuilder em DbContexto.cs
 - Gerar migrate:
   - >dotnet ef --version
   - Instalar Entity Framework:
     - >dotnet tool install --global dotnet-ef --version 7.0.20
   - >dotnet ef migrations add AdministradorMigration
   - >dotnet ef database update
   - >mysql -uroot -p'root' (MySQL Command Line Client)
   - mysql>use minimal_api
   - Database changed
   - >mysql>show tables;
   - +-----------------------+
    | Tables_in_minimal_api |
    +-----------------------+
    | __efmigrationshistory |
    | administradores       |
    +-----------------------+
    2 rows in set (0.01 sec)

  - >mysql>desc Administradores;
    +--------+--------------+------+-----+---------+----------------+
    | Field  | Type         | Null | Key | Default | Extra          |
    +--------+--------------+------+-----+---------+----------------+
    | Id     | int          | NO   | PRI | NULL    | auto_increment |
    | Email  | varchar(255) | NO   |     | NULL    |                |
    | Senha  | varchar(50)  | NO   |     | NULL    |                |
    | Perfil | varchar(10)  | NO   |     | NULL    |                |
    +--------+--------------+------+-----+---------+----------------+
    4 rows in set (0.01 sec) 

- Validar usuário no BD
  - Seed em DbContexto.cs:
    - >dotnet ef migrations SeedAdministrador
    - >dotnet ef database update
- Incluir novo contexto de Login com BD em Program.cs
  - Criar serviço AdministradorServico.cs
  - Criar interface IAdministradorServico (iAdministradorServico.cs)
- Criar entidade Veiculo:
  - Atualizar DbContexto
  - Gerar migration
  - >dotnet ef migrations add VeiculosMigration
  - >dotnet ef database update
- Criar interface IVeiculoServico
- Criar servico VeiculoServico
- Configurar swagger na aplicação
  - nuget.org -> Swashbuckle.AspNetCore
  - >dotnet add package Swashbuckle.AspNetCore --version 7.0.0
  - >dotnet build
  - Alterar Program.cs para incluir swagger
- Configurar a nova Home
  - Criar past Dominio/ModelViews
  - Criar ModelViews/Home.cs
- Configurar POST para criar veículo:
  - Criar #region/#endregion em Program.cs
  - Criar DTOs/VeiculoDTO.cs
- Configurar GET para listar todos os veículos
- Organizar rotas por contexto no swagger
- Configurar GET para obter veículo