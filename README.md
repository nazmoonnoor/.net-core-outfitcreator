# Outfit Creator - RESTful API, built with .Net Core Sqlite-db/SQLServer-db

## Tools
- Using docker, so that the project can be run in any machine with little effort.
- Postman to execute and test the endpoints
- NUnit to unit tests

## Requirements
- Asp.Net Core 5
- Git
- Docker (optional)

Notes
- Note 1: This repository includes the postman collection for the finished API
- Note 2: Application will run with docker-compose up -d --build.
- Note 3: Docker compose should work as expected. But incase it has issue, run the project without docker. 
- Note 4: NUnit to tests 

## Git clone
Clone the repo and install the dependencies.

git clone https://github.com/nazmoonnoor/OutfitCreator
cd OutfitCreator


## Project Structure
Project is built using Clean architecture having in mind. Benefit is to build a scalable, testable and maintainable application. The objective is to have the Separation of concerns. To achieve it, the Application have layers.

Clean architechture provides a domain centric approach to organizing dependencies. It has the domains be the have everything that depends on it.
Insfructure is responsible for persistance and talking to the database.
Services is a layer to bridge between Infrastucture and APIs. Also handles exceptions and validate inputs.


## Task breakdown
- [x] Project setup with .Net Core 5
- [x] Separate the projects to API, Core, Infrastructure and Shared tools
- [x] Write Tests for API and Services
- [x] Setting up Asp.Net Core Identity on the Project
- [x] Design db and setting up the ef-migration
- [x] Identify the domains and separate db-infrastucture as per Clean Architecture
- [x] Write Repositories and write related test cases
- [x] Write Controller Api and write test cases for Api
- [x] Add validations and handle exceptions
- [x] Run solution on docker
- [ ] Break down Identity and Api as separate microservices
- [ ] Write Clients for microservices
- [ ] Use dapr for service invocation and event handling

The solution was targetted to built using Microservice architechture.

## Run the project

### DB setup
Project is built as an application which is database independent. It is using entity-framework and it is easy to switch among db vendors that is supported by entity-framework and they are relational databases like SQL-Server, Postgres, MySql, SQLite etc.
This is tested with SQLite and SQLite. And primarily it is setup with SQLite. But you can easily test with SQL-Server by changing few configs. They are:
- Add your SQL-Server ConnectionString at appsettings.json
- Open Startup class, goto ConfigureServices method and uncomment `services.ConfigureSqlServer(Configuration)` and commented out `services.ConfigureSQLite(Configuration)`.
- Remove existing Migration classes from OutfitCreator.Ingrastructure project and run command `add-migration Init` on Package-Manager console.

When testing with Sqlite db, it will be created at root folder when project is run for the first time and there is no database available initially.

### Postman collection
The solution is provided with a Postman collection which included all the endpoints to test the api. Environment variable collection is also shared.
- `/csp/products/public/product/06.04.101.1636?country=de` to get product by id(code).
	Samples:
	https://localhost:44306/csp/products/public/product/06.04.101.1636?country=de
	https://localhost:44306/csp/products/public/product/32.04.101.1242?country=de
	https://localhost:44306/csp/products/public/product/46.04.101.4566?country=de

- `/csp/products/public/query?filters[country]=de&filters[gender]=MALE&filters[web_category]=Accessoires, WCA01156, WCA01159, WCA01155, WCA01152, WCA01158, WCA01153, WCA01157, WCA01154` 
to filter product by groups, gender and country
	Samples:
	https://localhost:44306/csp/products/public/query?filters[country]=de&filters[gender]=MALE&filters[web_category]=Accessoires, WCA01156, WCA01159, WCA01155, WCA01152, WCA01158, WCA01153, WCA01157, WCA01154
	https://localhost:44306/csp/products/public/query?filters[country]=de&filters[gender]=FEMALE&filters[web_category]=Pants,WCA00172,WCA00173,WCA00171

- `https://localhost:44306/csp/images/image/public/F408AD8C-1740-439C-A61B-A2D5ACD30022.png?res=higher&frame=9_16`	to get image 
