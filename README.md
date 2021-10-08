# Wordsmith inc

Monorepo for **api** and **web** belonging to Wordsmith

## Run
Run `docker-compose up` in terminal

## Deloy
Can be deployed to any cloud provider supporting containers. AWS, Google Cloud or Azure.

## Database
Postgres v9

## Api

### Tests
All tests are running i Github Actions on every commit

1. Navigate to Wordsmith.Api folder with terminal
2. Ensure .NET 6 i installed locally
3. Run `dotnet test` in terminal

### Develop
1. Navigate to Wordsmith.Api folder with terminal
2. Ensure .NET 6 i installed locally
3. Run `dotnet watch run` in terminal

### Swagger
https://localhost:7272/swagger/index.html

### Stack
- .NET 6 
- Entity framework
- Fluent Validation

### Logging
No logging are implemented but a would probably use **ApplicationInsights** or **Serilog**. Something that catches unhandled exceptions and store it somewhere accessible. With an api to log custom messages and information. 

## Web

### Integration tests
1. Navigate to Wordsmith.Web folder with terminal
2. Run `npm run cypress:run` to run tests i terminal
3. Run `npm run cypress:open` to open Cypress application

### Develop
1. Navigate to Wordsmith.Web folder with terminal
2. Ensure Node 16 is installed using NVM (Node version manager)
3. Run `nvm use` to change version in NVM
4. Run `npm run dev` in terminal

### Stack
- NextJs
- Yup
- framer-motion
- cypress
- tailwind css

### Logging
For the front-end stack i would use tool for globally catching errors like Sentry or ApplicationInsights browser package. 
