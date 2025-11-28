### Migrate to DB
1. Add migrations in Windows Environment
```
dotnet ef migrations add init_db_schema --project src/Marketplace.Infrastructure --startup-project src/Marketplace.Api
```
2. Update DB from Docker containe in Docker Environment
```
docker-compose run --rm api dotnet Marketplace.Api.dll --migrate-only
```
