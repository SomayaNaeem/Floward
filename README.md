Use these instructions to get the project up and running.

Prerequisites
You will need the following tools:

Visual Studio Code or Visual Studio 2022
.NET Core SDK 6.0
Setup
Follow these steps to get your development environment set up:

Clone the repository

At the root directory, restore required packages by running:

dotnet restore
Next, build the solution by running:

dotnet build
change the connectionstring with your server name, user Id and password in the following

Services.Catalog.Catalog.API
appsettings.Development.json
dotnet run
Launch (https://localhost:7247/swagger/index.html) in your browser to view the API Gateway

Launch (https://localhost:7264/swagger/index.html) in your browser to view Catalog APIs

Launch http://localhost:15672/ in your browser to view RabbitMq dashboard

Technologies

.NET Core 6.0

Entity Framework Core 6.0

RabbitMq

CQRS

Ocelot gateway
