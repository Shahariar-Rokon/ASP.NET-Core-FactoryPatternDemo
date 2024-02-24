# ASP.NET CORE FactoryPattern - AnimalType


## Description

This is a simple project that I created to demonstrate **Factory Pattern** in ASP.NET Core MVC. This project also includes autentication and authorization using Microsoft Identity database.

This project is a showcase of ASP.NET Core MVC and a popular pattern that is used by the software industry. Dive in and explore the potential of efficient data management!"

## Installation
To install and run this project, follow these steps:

1. **Clone the repository**: Clone the repository to your local machine using the GitHub CLI command:

   ```shell
   gh repo clone Shahariar-Rokon/ASP.NET-Core-FactoryPatternDemo
   
Alternatively, you can download the ZIP file from the GitHub repository page: https://github.com/Shahariar-Rokon/ASP.NET-Core-FactoryPatternDemo.git
  
2. Open the project in Visual Studio 2022: Open Visual Studio 2022 and select “Open a project or solution”. Navigate to the folder where you cloned or downloaded the repository and select the .sln file.
3. Restore the NuGet packages: Right-click on the solution in the Solution Explorer and select “Restore NuGet Packages”. This will install the required dependencies for the project. Alternatively you can wait for the Visual Studio to auto restores the packages.
4. Update the database connection string: In the appsettings.json file, update the DefaultConnection value with your database connection string. Make sure the database server is running and accessible.
5. Apply the database migrations: In the Package Manager Console, run the following command to apply the code first migrations and create the database schema:
`Update-Database`
6. Run the project: Press F5 or click the “Run” button to launch the project in your browser.
   
## Usage

To use this project, follow these steps:

1. **Navigate to the app**: Open your browser and go to the URL where the app is hosted. For example, `https://localhost:44302/`.
2. **Interact with the app**: When running the app. You will be greated with a Login/register form. You can input the following data in the form
   - Login
   - Register
3. **After login**: You can navigare to create tab to create new animal type.     
4. **Explore the code**: You can open the project in Visual Studio 2022 and explore the code. The project consists of javascript, jquery and C#.

## Contributing

We welcome contributions from anyone who is interested in improving this project. Here are some ways you can contribute:

- Report bugs or suggest features by opening an issue.
- Fix bugs or implement features by submitting a pull request.
- Review pull requests and provide feedback.
- Write or update documentation, tests, or examples.
- Share your experience or feedback with the project.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
