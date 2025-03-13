## **🚀 Shop Public API – Scalable & Secure E-Commerce API**  

![.NET 10](https://img.shields.io/badge/.NET%2010-blue?style=for-the-badge)  
![E-Commerce](https://img.shields.io/badge/E--Commerce%20API-%F0%9F%9A%80-green?style=for-the-badge)  
![Secure API](https://img.shields.io/badge/Secure%20API-%E2%9C%85-red?style=for-the-badge)  
![Docker](https://img.shields.io/badge/Docker-%F0%9F%90%A6-blue?style=for-the-badge)  
![API Versioning](https://img.shields.io/badge/API%20Versioning-%F0%9F%94%A5-orange?style=for-the-badge)  
![Performance Monitoring](https://img.shields.io/badge/Performance%20Monitoring-%F0%9F%9A%A7-purple?style=for-the-badge)  

Welcome to the **Shop Public API**, a **high-performance, scalable** e-commerce API designed to **efficiently handle online shopping operations**. Built with **ASP.NET Core and .NET 10**, this API follows **modern best practices**, making it **secure, optimized, and production-ready**.  

### **🔹 Why Choose Shop Public API?**  
✅ **Built for Scalability** – Handles large product catalogs and high transaction volumes.  
✅ **Optimized for Performance** – Uses **MiniProfiler, caching, and response compression**.  
✅ **Secure by Design** – Implements **secure headers, FluentValidation, and correlation IDs**.  
✅ **Docker & Cloud-Ready** – Easily deploy with **Docker Compose**.  

---

## **🌟 Features**  

🔹 **API Versioning** – Easily manage API upgrades.  
🔹 **Health Checks** – Monitor system health in real-time.  
🔹 **MiniProfiler** – Track API performance for optimizations.  
🔹 **Response Compression** – Improves speed with **Gzip & Brotli**.  
🔹 **Secure Headers** – Protects against security vulnerabilities.  
🔹 **FluentValidation** – Ensures clean, validated requests.  
🔹 **Correlation ID** – Tracks requests across microservices.  

---

## **📂 Project Structure**  

📌 **src/Presentation/Shop.PublicApi** – API controllers and request handling.  
📌 **src/Application** – Business logic and validation rules.  
📌 **src/Infrastructure** – Database, caching, and external service integrations.  
📌 **tests/Shop.PublicApi.Tests** – Unit and integration tests.  

---

## **🚀 Getting Started**  

### **📌 Prerequisites**  
✅ [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)  
✅ [Docker](https://www.docker.com/get-started)  

### **Step 1: Clone the Repository**  
```bash
git clone https://github.com/your-repo/shop-publicapi.git
cd shop-publicapi
```

### **Step 2: Install Dependencies**  
```bash
dotnet restore
```

### **Step 3: Run the Application Locally**  
```bash
dotnet run --project src/Presentation/Shop.PublicApi
```

---

## **🐳 Running with Docker**  

### **Step 1: Build & Run with Docker Compose**  
```bash
docker-compose up --build
```

### **Step 2: Access API & Documentation**  
🔹 **Swagger UI** – [http://localhost:5000/swagger](http://localhost:5000/swagger)  
🔹 **Health Checks** – [http://localhost:5000/health](http://localhost:5000/health)  

---

## **📡 API Endpoints**  

### **🛍️ Products API**  
| Method | Endpoint              | Description |
|--------|----------------------|-------------|
| **GET** | `/api/v1/products`   | Get all products |
| **GET** | `/api/v1/products/{id}` | Get product details |
| **POST** | `/api/v1/products`  | Add a new product |
| **PUT** | `/api/v1/products/{id}` | Update a product |
| **DELETE** | `/api/v1/products/{id}` | Delete a product |

### **📦 Orders API**  
| Method | Endpoint             | Description |
|--------|---------------------|-------------|
| **GET** | `/api/v1/orders`   | Get all orders |
| **GET** | `/api/v1/orders/{id}` | Get order details |
| **POST** | `/api/v1/orders`  | Create a new order |

### **👥 Customers API**  
| Method | Endpoint               | Description |
|--------|-----------------------|-------------|
| **GET** | `/api/v1/customers`  | Get all customers |
| **GET** | `/api/v1/customers/{id}` | Get customer details |

---

## **🛠 Configuration**  

Ensure the following **environment variables** are set in `docker-compose.yml`:  

```yaml
services:
  shop.publicapi:
    environment:
      - ConnectionStrings__SqlConnection=your-sql-connection-string
      - ConnectionStrings__NoSqlConnection=your-nosql-connection-string
      - ConnectionStrings__CacheConnection=your-cache-connection-string
```

---

## **🧪 Testing**  

### **Run Unit & Integration Tests**  
```bash
dotnet test
```

### **Manual API Testing**  
📌 **Use Postman or Swagger UI** to:  
✅ **Fetch products** → `/api/v1/products`  
✅ **Create an order** → `/api/v1/orders`  

---

## **🎯 Why Use This Project?**  

✅ **Enterprise-Grade E-Commerce API** – Built with modern **.NET 10 best practices**.  
✅ **Optimized for High Traffic** – Uses **performance monitoring and caching**.  
✅ **Secure & Reliable** – Implements **validation, security headers, and request tracking**.  
✅ **Scalable & Cloud-Ready** – Easily deployable via **Docker & Kubernetes**.  

---

## **📜 License**  

This project is licensed under the **MIT License**. See [LICENSE](LICENSE) for details.  

---

## **📞 Contact**  

For feedback, contributions, or inquiries:  
📧 **Email**: [mreshboboyev@gmail.com](mailto:mreshboboyev@gmail.com)  
💻 **GitHub**: [MrEshboboyev](https://github.com/MrEshboboyev/Shop)  

---

🚀 **Scale your e-commerce platform with Shop Public API!** Clone the repo & start now!  
