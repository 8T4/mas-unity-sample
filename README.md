                                                                                               
<p align='center'>
    <img width=192" src="https://raw.githubusercontent.com/8T4/mas-unity/main/docs/imgs/logo.png" />
    <br/>It is a dotnet framework that helps in the development of MAS (Multi-agent systems) applied to integrative business information systems (IBIS). MAS Unity will assist in the construction, deployment and monitoring of a cluster of autonomous agents.
</p>

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
│  │  ├─ Schedule.cs


```

- [**Use case**](https://en.wikipedia.org/wiki/Use_case): is a list of actions or event steps typically defining the interactions between a Agent and a system to achieve a goal. 
                                                                                                 
- [**Agents**](https://www.researchgate.net/publication/222827222): an agent is a computer system that is situated in some environment, and that is capable of autonomous action in this environment in order to meet its design objectives.
                                                                                                 
- [**Actions**](https://www.researchgate.net/publication/222827222): each agent is responsible for performing tasks to solve partial problems. MAS supports task synchronization, task allocation, task sharing, and result sharing
                                                                                                 
- [**Knowledge**](https://www.researchgate.net/publication/222827222): is an integral part of the intelligent agent and multi-agent systems paradigm. Agents possess knowledge and act based on their own knowledge, beliefs, desires, and intentions.

- [**Environment**](https://www.researchgate.net/publication/222827222): system operates in an environment which is similar to the notion of the environment of an organization and that of a multi-agent system.
                                                                                                 
  

## Use the domain language
