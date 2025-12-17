## 1️⃣ Create Project

- Project type: **ASP.NET Core Web API**  
- Framework: **.NET 8.0**  
- Settings:
  - Use Controllers  
  - Enable HTTPS  
  - Enable Open API (Swagger)  

---

## 2️⃣ Create Database (SQL Server)

1. Open **SQL Server Object Explorer → New Query**.  
2. Run the following SQL command:

```sql
-- CREATE DATABASE nascardb;
-- USE nascardb;

CREATE TABLE [cup series] (
    id INT IDENTITY PRIMARY KEY,
    season INT,
    races INT,
    champion VARCHAR(50),
    manufacturer VARCHAR(50)
);

INSERT INTO [cup series] VALUES
(1955, 45, 'Tim Flock', 'Oldsmobile'),
(1956, 56, 'Buck Baker', 'Ford'),
(1957, 53, 'Buck Baker', 'Ford'),
(1958, 51, 'Lee Petty', 'Chevrolet'),
(1959, 44, 'Lee Petty', 'Chevrolet'),
(1960, 44, 'Rex White', 'Chevrolet'),
(1961, 52, 'Ned Jarrett', 'Chevrolet'),
(1962, 53, 'Joe Weatherly', 'Pontiac'),
(1963, 55, 'Joe Weatherly', 'Ford'),
(1964, 62, 'Richard Petty', 'Plymouth'),
(1965, 55, 'Ned Jarrett', 'Ford'),
(1966, 49, 'David Pearson', 'Ford'),
(1967, 49, 'Richard Petty', 'Ford'),
(1968, 49, 'David Pearson', 'Ford'),
(1969, 54, 'David Pearson', 'Ford'),
(1970, 48, 'Bobby Isaac', 'Dodge'),
(1971, 48, 'Richard Petty', 'Plymouth'),
(1972, 31, 'Richard Petty', 'Dodge'),
(1973, 28, 'Benny Parsons', 'Chevrolet'),
(1974, 30, 'Richard Petty', 'Dodge'),
(1975, 30, 'Richard Petty', 'Dodge'),
(1976, 30, 'Cale Yarborough', 'Chevrolet'),
(1977, 30, 'Cale Yarborough', 'Chevrolet'),
(1978, 30, 'Cale Yarborough', 'Chevrolet'),
(1979, 31, 'Richard Petty', 'Oldsmobile'),
(1980, 31, 'Dale Earnhardt', 'Chevrolet'),
(1981, 31, 'Darrell Waltrip', 'Buick'),
(1982, 30, 'Darrell Waltrip', 'Buick'),
(1983, 30, 'Bobby Allison', 'Chevrolet'),
(1984, 30, 'Terry Labonte', 'Chevrolet'),
(1985, 28, 'Darrell Waltrip', 'Chevrolet'),
(1986, 29, 'Dale Earnhardt', 'Chevrolet'),
(1987, 29, 'Dale Earnhardt', 'Chevrolet'),
(1988, 29, 'Bill Elliott', 'Ford'),
(1989, 29, 'Rusty Wallace', 'Pontiac'),
(1990, 29, 'Dale Earnhardt', 'Chevrolet'),
(1991, 29, 'Dale Earnhardt', 'Chevrolet'),
(1992, 29, 'Alan Kulwicki', 'Ford'),
(1993, 30, 'Dale Earnhardt', 'Chevrolet'),
(1994, 31, 'Dale Earnhardt', 'Chevrolet'),
(1995, 31, 'Jeff Gordon', 'Chevrolet'),
(1996, 31, 'Terry Labonte', 'Chevrolet'),
(1997, 32, 'Jeff Gordon', 'Chevrolet'),
(1998, 33, 'Jeff Gordon', 'Chevrolet'),
(1999, 34, 'Dale Jarrett', 'Ford'),
(2000, 34, 'Bobby Labonte', 'Pontiac'),
(2001, 36, 'Jeff Gordon', 'Chevrolet'),
(2002, 36, 'Tony Stewart', 'Pontiac'),
(2003, 36, 'Matt Kenseth', 'Ford'),
(2004, 36, 'Kurt Busch', 'Ford'),
(2005, 36, 'Tony Stewart', 'Chevrolet'),
(2006, 36, 'Jimmie Johnson', 'Chevrolet'),
(2007, 36, 'Jimmie Johnson', 'Chevrolet'),
(2008, 36, 'Jimmie Johnson', 'Chevrolet'),
(2009, 36, 'Jimmie Johnson', 'Chevrolet'),
(2010, 36, 'Jimmie Johnson', 'Chevrolet'),
(2011, 36, 'Tony Stewart', 'Chevrolet'),
(2012, 36, 'Brad Keselowski', 'Dodge'),
(2013, 36, 'Jimmie Johnson', 'Chevrolet'),
(2014, 36, 'Kevin Harvick', 'Chevrolet'),
(2015, 36, 'Kyle Busch', 'Toyota'),
(2016, 36, 'Jimmie Johnson', 'Chevrolet'),
(2017, 36, 'Martin Truex Jr.', 'Toyota'),
(2018, 36, 'Joey Logano', 'Ford'),
(2019, 36, 'Kyle Busch', 'Toyota'),
(2020, 36, 'Chase Elliott', 'Chevrolet'),
(2021, 36, 'Kyle Larson', 'Chevrolet'),
(2022, 36, 'Joey Logano', 'Ford'),
(2023, 36, 'Ryan Blaney', 'Ford'),
(2024, 36, 'Joey Logano', 'Ford');
```

## 3️⃣ Install NuGet Packages (Package Manager Console)
- Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.22
- Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.22
- Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.22

## 4️⃣ Scaffold Database (from existing DB - Package Manager Console)
```
Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=nascardb;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context NascarDBContext -DataAnnotations
```
-OutputDir Models → folder for generated models<br>
-Context NascarDBContext → name of the DbContext<br>
-DataAnnotations → use annotations in models

## 5️⃣ Configure Connection String (appsettings.json)
```
{
  "ConnectionStrings": {
    "DefaultConnectionString": "SERVER=(localdb)\\MSSQLLocalDB;DATABASE=nascardb;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 6️⃣ Register DbContext in Program.cs
## 📍 Where to add `AddDbContext` in `Program.cs`

Open **Program.cs** and add the following code **INSIDE the service configuration section**,  
**after** `var builder = WebApplication.CreateBuilder(args);`  
and **before** `builder.Services.AddControllers();`

---

### ✅ Correct placement

```csharp
var builder = WebApplication.CreateBuilder(args);

// 👇 ADD THIS HERE
builder.Services.AddDbContext<NascarDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// 👇 Already existing code
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

## 7️⃣ Create Controller (Scaffolded API Controller – EntityFramework)

---

### 📁 Steps in Visual Studio

1. Open **Solution Explorer**
2. Right-click on the **Controllers** folder
3. Select:
   **Add** → **New Scaffolded Item…**
4. Choose:
   **API Controller with actions, using Entity Framework**
5. Click **Add**

---

### ⚙️ Scaffold Configuration

Fill in the fields as follows:

| Field | Value |
|---------------------|-----------------------|
| **Model class**     | `CupSeries`           |
| **DbContext class** | `NascarDBContext`     |
| **Controller name** | `CupSeriesController` |

Then click **Add**.

---
