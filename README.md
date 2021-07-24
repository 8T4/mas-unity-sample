# MAS Unity Sample
This repository has a sample of the application of [MAS Unity](https://github.com/8T4/mas-unity). This code presents an example of an agent that performs the credit analysis after purchase. The following steps show the implementation of the sample project.

## Create the project
The first step is create a web API with ASP.NET Core and install the [MAS Unity](https://github.com/8T4/mas-unity) dependencies:

```
Install-Package MasUnity
Install-Package MasUnity.HostedService
Install-Package MasUnity.HealthCheck
```

[Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio)

## Modeling the Agent Software
It's important to keep your Agent code organized and easy to maintain. This section will provide a modeling tactical approach to achieve a satisfactory maintainability level. For this, it's recommended to use a domain-model approach to approximate the Agent of own acting environment. In this sense, we propose this modeling structure:

```
Project/
│  
├─ Use cases/
│  │  
│  ├─ Agents/
│  │  │
│  │  ├─ Actions/
│  │  │  ├─ Action.cs
│  │  │  │
│  │  ├─ Environments/
│  │  │  ├─ Environment.cs
│  │  │  │
│  │  ├─ Knowledges/
│  │  │  ├─ Knowledge.cs
│  │  │  │
│  │  ├─ Agent.cs
│  │  ├─ AgentSchedule.cs
│  │    
├─ Startup.cs
├─ Project.csproj
├─ Appsettings.json

```

## Use the domain language
