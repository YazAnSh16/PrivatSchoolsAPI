# 🏫 PrivateSchoolAPI

A modern ASP.NET Core Web API built using **Clean Architecture + CQRS + MediatR**, designed to manage school operations such as students, payments, and absences with scalability and performance in mind.

---

# 🚀 Overview

PrivateSchoolAPI is a layered backend system that separates concerns clearly across **API, Application, Domain, and Infrastructure** layers.
The project demonstrates real-world backend practices used in production environments.

---

# 🧱 Architecture

The project follows **Clean Architecture** principles:

```
API → Application → Domain
             ↓
       Infrastructure
```

### Layers:

* **API**

  * Controllers
  * Request Models (DTOs)
  * Entry point (Program.cs)

* **Application**

  * CQRS (Commands & Queries)
  * MediatR Handlers
  * DTOs
  * Business orchestration

* **Domain**

  * Core Entities (Student, Payment, Absence)
  * Business rules (partially implemented)

* **Infrastructure**

  * Entity Framework Core (DbContext)
  * Database access
  * Migrations
  * External services (e.g., caching)

---

# ⚙️ Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* MediatR
* CQRS Pattern
* SQL Server
* Redis (Distributed Caching)

---

# 🔥 Features

## 📌 Core Features

* ✅ Student Management (CRUD)
* ✅ Payment Management
* ✅ Absence Tracking
* ✅ Clean API endpoints with proper HTTP responses

---

## 🧠 Architecture Features

* ✅ Clean Architecture (layered separation)
* ✅ CQRS (Command Query Responsibility Segregation)
* ✅ MediatR for decoupled request handling
* ✅ Separation of concerns across layers

---

## ⚡ Performance Features

* ✅ Redis Distributed Caching

  * Caches read-heavy endpoints (e.g., GetAllStudents)
  * Reduces database load
  * Improves response time

* ✅ Cache Invalidation Strategy

  * Cache is cleared on:

    * Create
    * Update
    * Delete

---

## 🖼️ File Handling

* ✅ Image Upload Support

  * Student profile images
  * Stored in `wwwroot/images`
  * Unique file naming using GUID

---

## Validation
* ✅ FluentValidation integration
* Centralized validation for Commands (e.g., AddStudent, UpdateStudent)
* Clean separation from Controllers and Handlers
* Automatic validation before handler execution (via MediatR pipeline or manual trigger

---

## 🛡️ Code Quality & Design

* ✅ DTO-based communication
* ✅ Strong separation between API and business logic
* ✅ Scalable structure for future enhancements
* ✅ Ready for extension (Validation, Logging, etc.)

---

# 📂 Project Structure

```
PrivateSchoolAPI
│
├── API
│   ├── Controllers
│   ├── Requests
│   └── Program.cs
│
├── Application
│   └── Features
│       └── Students
│           ├── Commands
│           ├── Queries
│           └── Handlers
│
├── Domain
│   └── Entities
│
├── Infrastructure
│   ├── Data
│   └── Migrations
```

---

# 🧪 Example Flow (CQRS)

### 🔹 Get Students

1. Controller receives request
2. Sends `GetAllStudentsQuery` via MediatR
3. Handler:

   * Checks Redis Cache
   * If exists → returns cached data
   * If not → fetches from DB → caches → returns

---

# 🧨 Cache Strategy

| Operation | Behavior         |
| --------- | ---------------- |
| GET       | Uses Redis Cache |
| POST      | Clears Cache     |
| PUT       | Clears Cache     |
| DELETE    | Clears Cache     |

---

# 🚀 Future Improvements

* 🔲 Domain Events
* 🔲 Advanced DDD patterns (Value Objects, Aggregates)
* 🔲 Authentication & Authorization (JWT)

---

# 💡 Key Learnings

* Applying Clean Architecture in real projects
* Using CQRS for better separation
* Improving performance using Redis caching
* Structuring scalable backend systems

---

# 👨‍💻 Author

Developed as a backend engineering practice project focusing on real-world architecture and performance optimization.

---
