# Clean Architecture with CQRS Pattern

### This is template and sample, and used pure .NET. I tried to biuld a simple structure.

This project is an implementation of the Clean Architecture with CQRS Pattern using .NET 8. 
The Clean Architecture provides a robust and flexible software design that can easily adapt to changes and maintainability. 
CQRS (Command Query Responsibility Segregation) pattern separates the application into two parts: Commands and Queries. 
Commands are responsible for modifying the state of the application while Queries are responsible for retrieving data from the application. The separation of concerns enables scalability and performance optimization for the application.
 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET 8 SDK
* Visual Studio 2019 or Visual Studio Code

### Installing

1. Clone the repository:

```bash 
git clone https://github.com/Rezakazemi890/Clean-Architecture-CQRS.git
```


2. Open the solution file CleanArchitectureCQRS.sln in Visual Studio.

3. Build the solution by pressing Ctrl + Shift + B or by navigating to Build -> Build Solution.

4. Run the application by pressing F5 or by navigating to Debug -> Start Debugging.

### Running the Tests

The project includes unit tests that can be run using the Test Explorer in Visual Studio or by running the following command in the terminal:


```bash 
dotnet test
```


## Architecture

The Clean Architecture with CQRS Pattern consists of the following layers:

* Api Layer: This layer contains the user interface components of the application. It is responsible for handling user input and displaying output. The presentation layer communicates with the Application Layer using DTOs (Data Transfer Objects).

* Application Layer: This layer contains the business logic of the application. It is responsible for coordinating the use cases of the application. The Application Layer communicates with the Domain Layer using commands and queries.

* Domain Layer: This layer contains the core entities and business logic of the application. It is responsible for defining the rules and behaviors of the application.

* Infrastructure Layer: This layer contains the implementation details of the application. It is responsible for communicating with external systems and services. The Infrastructure Layer communicates with the Application Layer using repositories and data access objects.

* Shared Layer: This layer contains the implementation of common and share abstraction or details that could used by other layers.

## Technologies Used

* .NET 8
* ASP.NET Core
* Entity Framework Core
* xUnit

## License

This project is licensed under the MIT License - see the [License.md](License.md) file for details.
