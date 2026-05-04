# DrinkAndGo
# 🥤 DrinkAndGo — ASP.NET MVC E-Commerce App

A full-stack drink ordering web application built with ASP.NET MVC and Entity Framework Core.

## 🛠 Tech Stack
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- C#
- Repository Pattern + Dependency Injection

## 📦 Features
- Browse drinks by category
- Add items to shopping cart
- Place and manage orders
- Repository pattern with interface-based design
- Mock repositories for unit testing

## 🏗 Architecture
Controller → ViewModel → Repository (Interface) → DbContext → SQL Server

## 🚀 How to Run
1. Clone the repo
2. Update connection string in appsettings.json
3. Run `dotnet ef database update`
4. Run `dotnet run`
