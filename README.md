# GMV Coding Test

## Introduction

This is my submission for the coding challenge. I have used the following technologies:

- Microsoft.EntityFrameworkCore.Sqlite - For Database Access
- Cypress - For End to End Testing
- xUnit
- Moq


### UI
It was asked for a minimal UI, so I decided to create a single html page using jQuery to handle the requests to the API.


### Design Patterns
The project was going to use a Repostiory and Service pattern, but the project was small enough that it was decided that the 
Repository pattern was not needed and left it out in leu of the DbContext.


---

## Testing

---

Tests were created for the Service layer and Controller.

    dotnet test
---

End-to-End Tests

e2e tests are run using [Cypress](https://www.cypress.io/). To run the tests, run the following command:

From the root of the project run the project with the following command:

    dotnet run --project ./GMV/GMV.csproj

Then run the tests with the following command:

    npm run e2e



---
