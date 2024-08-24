# SignalR Live Chat with ASP.NET Core API

This project is a live chat application using SignalR with an ASP.NET Core API backend. It allows users to send and receive messages in real-time, providing a seamless and interactive chat experience.

## Table of Contents
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
- [Run the Application](#run-the-application)

## Features

- **Real-Time Chat**: Send and receive messages instantly.
- **Group Chat**: Support for group conversations with multiple users.
- **Authentication and Authorization**: Manage users with different access rights.
- **Message History**: Storing and displaying chat message history.

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## Setup

1. **Clone the repository**:
    ```bash
    git clone https://github.com/Torri04/Live-Chat-Backend.git
    ```

2. **Restore the dependencies**:
    ```bash
    dotnet restore
    ```

3. **Build the project**:
    ```bash
    dotnet build
    ```
   
### **Docker**

Change to the Docker directory where your Docker configuration files are located:

```bash
cd Docker
```

Run docker Compose

```bash
docker-compose up -d
```

### **Configuration**
   
Create a appsettings.json file in the root of the project with the following content:

```json
{
  "ConnectionStrings": {
  "MyDatabase": "<Your-Database-ConnectionString>"
  },
  "JWT": {
    "Issuer": "<Your-WebIssuer>",
    "Audience": "<Your-WebAudience>",
    "SigningKey": "<Your-WebSigningKey>"
  },
}
```

## Run the Application

To run the Application locally, use the following command:

```bash
dotnet run
```

To run the Application locally and automatically rebuild on changes, use the following command:
```bash
dotnet watch run
```




 

