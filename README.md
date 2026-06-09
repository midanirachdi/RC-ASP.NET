# 🏕️ Refugee Camp Management System

An ASP.NET MVC web application for managing refugee camps, residents, volunteers, donations, medical records, inventory, and community activities. The solution follows a layered architecture and integrates with a Java REST API for authentication and several business operations.

## 📋 Overview

This project provides a centralized platform for coordinating humanitarian operations at refugee camps. Staff and volunteers can track refugees, manage medical folders, monitor stock levels, process donations, organize events and tasks, and facilitate community discussions through topics, comments, and tags.

The application is built on **.NET Framework 4.5.1** and uses **Entity Framework 6** with a **MySQL** database. Real-time notifications are delivered through **SignalR**.

## ✨ Features

- **Camp management** — Create and manage camps, capacity, and assigned staff
- **Refugee records** — Store personal, professional, and language information for camp residents
- **Medical folders** — Maintain health records linked to individual refugees
- **Donations** — Record monetary donations and assign them to specific camps
- **Inventory & orders** — Track stock, products, providers, and purchase orders
- **Tasks & events** — Assign and monitor volunteer tasks and camp events
- **Community forum** — Topics, comments, tags, news, and ratings
- **Job offers & courses** — Post opportunities and educational content
- **User accounts** — Role-based access for admins, camp chefs, district chefs, and volunteers
- **Real-time notifications** — SignalR hub for live updates
- **PDF generation** — Export documents using iTextSharp

## 🏗️ Architecture

The solution is organized into five projects that follow a classic layered pattern:

| Layer | Project | Responsibility |
|-------|---------|----------------|
| Presentation | `RefugeeCamp.Web` | MVC controllers, views, SignalR hubs, and client assets |
| Business logic | `RefugeeCamp.Service` | Service classes for domain operations and external API calls |
| Domain | `RefugeeCamp.Domain` | Entity models and factories |
| Data access | `RefugeeCamp.Data` | Entity Framework context, mappings, repositories, and unit of work |
| Shared | `Service.Pattern` | Generic service base class used across business services |

Authentication and several write operations delegate to a separate Java backend REST API running at `http://localhost:18080/refugeesCamp-web/api/`.

## 📁 Project Structure

```
RC-ASP.NET/
├── RefugeeCamp.sln
├── RefugeeCamp.Web/          # ASP.NET MVC web application
├── RefugeeCamp.Service/      # Business logic and API integration
├── RefugeeCamp.Domain/       # Domain models and factories
├── RefugeeCamp.Data/         # EF6 data access layer
└── Service.Pattern/          # Shared service abstractions
```

## 🛠️ Technologies

- **ASP.NET MVC 5** — Web framework
- **Entity Framework 6** — ORM and database access
- **MySQL** — Relational database
- **SignalR 2** — Real-time communication
- **Newtonsoft.Json** — JSON serialization
- **iTextSharp** — PDF generation
- **Bootstrap / jQuery** — Front-end UI
- **Application Insights** — Telemetry and monitoring

## 📦 Prerequisites

Before running the application locally, ensure you have the following installed:

- **Visual Studio 2015** or later (or MSBuild tools for .NET Framework 4.5.1)
- **.NET Framework 4.5.1**
- **MySQL Server** (with a database named `refugeescamp`)
- **IIS Express** (included with Visual Studio)
- **Java backend API** — The companion `refugeesCamp-web` service must be running on port `18080` for login, registration, and certain API-driven features

## 🚀 Getting Started

### 📥 Clone the Repository

```bash
git clone git@github.com:midanirachdi/RC-ASP.NET.git
cd RC-ASP.NET
```

### 📦 Restore NuGet Packages

Open `RefugeeCamp.sln` in Visual Studio and restore NuGet packages, or run the following from the solution directory:

```bash
nuget restore RefugeeCamp.sln
```

### 🗄️ Set Up the Database

1. Create a MySQL database named `refugeescamp`.
2. Import or create the required schema and seed data for the application tables.
3. Update the connection string in `RefugeeCamp.Web/Web.config` if your MySQL credentials differ from the defaults.

## ⚙️ Configuration

The primary database connection string is defined in `RefugeeCamp.Web/Web.config`:

```xml
<connectionStrings>
  <add name="refugeescampContext"
       connectionString="server=localhost;user id=root;database=refugeescamp"
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

Adjust the `server`, `user id`, and `password` values to match your local MySQL instance.

The Java REST API base URL is hard-coded in the service layer (`http://localhost:18080/refugeesCamp-web/api/`). Ensure that service is running before testing login, registration, or donation workflows.

## ▶️ Running the Application

1. Open `RefugeeCamp.sln` in Visual Studio.
2. Set **RefugeeCamp.Web** as the startup project.
3. Start the Java backend API on port `18080`.
4. Press **F5** (or **Ctrl+F5**) to launch the site with IIS Express.

The application will build all dependent projects (`RefugeeCamp.Data`, `RefugeeCamp.Domain`, `RefugeeCamp.Service`, and `Service.Pattern`) automatically.

## 👥 User Roles

The application supports several user types, created through the registration factory:

| Role | Description |
|------|-------------|
| **Admin** | Full system administration |
| **Camp Chef** | Manages a specific camp and its operations |
| **District Chef** | Oversees multiple camps within a district |
| **Volunteer** | Performs assigned tasks and participates in camp activities |

Refugees are managed as domain entities and are associated with camps and medical folders rather than as login accounts.

## 🔗 API Integration

Several controllers and services communicate with the Java backend over HTTP:

- **Authentication** — Login and registration via Basic/Bearer token exchange
- **Donations** — Submitting donations to camps through the REST API
- **Stock consumption** — Inventory operations delegated to the backend

When developing locally, both the ASP.NET web app and the Java API must be running concurrently.

## 📄 License

No license file is included in this repository. Contact the repository owner for usage terms.
