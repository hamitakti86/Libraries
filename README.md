Hello, 

The project I designed, using the Domain-Driven Design (DDD) architecture consists of several layers: the API layer, the application layer, the domain layer, and the persistence layer. The Domain layer is where entities reside, and the Persistence layer contains my migration files and repositories. In addition, I also applied Mediator and CQRS pattern techniques in this project.

Following this, in the application layer, business operations have been implemented. As for the dependency injection structure, I used a Service interface structure for business components, and a repository infrastructure for operations within the context.

My dependency injection approach is as follows: I inject the repository in the Service structure, and then inject the Service in the application layer. I built the client as the API layer. When you run the project, you will be presented with a Swagger environment where you can trigger services.

I also created a test project where I wrote simple test cases for various conditions. I used PostgreSQL as the database, but you can configure it to use SQLite in the 'appsettings.Development.json' file if you prefer:

json:
"ConnectionStrings": {
    "DataSource": "Server=library.db"
} 
and switch database in Startup Configuration side as  sqlite or any of database whatever you would like. 
Afterward, you can simply run the project using 'dotnet run' from the API directory. 

In the limited time , i could do such the project, Hoping,this gives you an idea and if anything comes up, feel free to contact with me please.

Have a good day.

Best.

Hamit 
