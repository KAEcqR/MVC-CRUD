# ASP.NET MVC CRUD Application

A simple web application built using ASP.NET MVC that demonstrates CRUD operations (Create, Read, Update, Delete).  
The application allows users to manage data stored in a database through a web interface.

## Requirements
.NET SDK
MySQL Server
Entity Framework CLI

## Technologies
- C#
- ASP.NET MVC
- .NET
- SQL Database
- HTML / CSS
- Entity Framework (if used)

## Features
- create new records
- view list of records
- edit existing records
- delete records
- MVC architecture

## Screenshots

![Application](screenshots/app.png)

## How to run the project locally

### 1. Clone the repository

```
git clone https://github.com/KAEcqR/MVC-CRUD.git
```

### 2. Open the project

Open the solution in **Visual Studio** or another IDE that supports .NET.

### 3. Install MySQL

Make sure **MySQL Server** is installed and running on your system.

Create an empty database:

```
mvc-tickets
```

### 4. Configure database connection

Open the file:

```
appsettings.json
```

Update the connection string if needed:

```
"ConnectionStrings": {
  "MySql": "server=127.0.0.1;database=mvc-tickets;user=root;password=;"
}
```

Set your MySQL username and password.

### 5. Apply Entity Framework migrations

Open a terminal in the project directory and run:

```
dotnet ef database update
```

This command will create all tables using the migrations included in the repository.

### 6. Run the application

Run the project using:

```
dotnet run
```

or start the project from **Visual Studio**.

The application should now be available locally in the browser.


## Purpose of the project

The goal of this project was to learn:

- ASP.NET MVC architecture
- CRUD operations
- database integration using entity framework core
- basic web application development
