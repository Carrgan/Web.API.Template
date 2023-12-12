Add Migration

`dotnet ef migrations add Init -p "Infrastructure.Persistence" -s "WebApi" --context AppDbContext`

Update database

`dotnet ef database update -p "Infrastructure.Persistence" -s "WebApi" -- context AppDbContext`