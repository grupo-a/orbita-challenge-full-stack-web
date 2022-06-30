# Workshop API

### Always remember that you have to create migrations!!

To create:
```
cd src/OrbitaChallengeApi.Application
dotnet ef migrations add MigrationName -o Data/Migrations
```
To update the database:
```
cd src/OrbitaChallengeApi.Application
dotnet ef database update
```
