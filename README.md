Use these instructions to get the project up and running.

* Prerequisites
  => You will need the following tools:
    - Visual Studio Code or Visual Studio 2022
    - .NET Core SDK 6.0
* Setup sln
  - Clone the repository
  - change the connectionstring with your server name, user Id and password in Services.Catalog.Catalog.API => appsettings.Development.json

  => Setup database
    - Set the Catalog.API as a startup project
    - In Package manager console select Catalog.Infrastructure as default project
    - Write this command => update-database 
 => Launch Services
  - https://localhost:7247/swagger/index.html to view the API Gateway

  - https://localhost:7264/swagger/index.html  to view Catalog APIs

  - http://localhost:15672/  to view RabbitMq dashboard

* Technologies

.NET Core 6.0

Entity Framework Core 6.0

RabbitMq

CQRS

Ocelot gateway
