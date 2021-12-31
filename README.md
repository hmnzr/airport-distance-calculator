# Airport Great Circle Distance calculator API
This project contains a .NET 6 API that exposes a single endpoint to retreive a distance between two airports.

## Architecture
This project was built using Minimal API Project introduced in .NET 6.  
The solution represents a feature-sliced (or vertically sliced) architecture, where single feature has it's separate namespace. Services would be created for different bounded contexts.  
Every feature has a module with endpoint registrations, every endpoint represents a single use case within a system. A `UseCase` suffixed classes used to represent them.
Other folders are used for common **models**, **services**, and other building blocks specific for this particular feature.

Used libraries and technologies:
- **.NET6** with Minimal API - main structure.
- **Carter** - helpers for working with Minimal APIs and mapping handlers.
- **FluentValidation** - validation layer.
- **NUnit and Moq** - unit testing suite.


## Limitations
This project has only a single API service. In case of multiple services, common infrastructure code (exceptions, middlewares, other functionality) needs to be move to some core library consumed by multiple services.
