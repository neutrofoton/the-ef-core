## Installing dotnet tool EF (dotnet-ef)

``` bash
$ dotnet tool install --global dotnet-ef
```

``` bash
$ dotnet tool update --global dotnet-ef
```

The location will be in :
#### Macos
``` bash
$HOME/.dotnet/tools/"
```

### Windows
``` bash
%USERPROFILE%\.dotnet\tools
```

The dotnet tool directory should be registered in shell configuration or environment variable path
``` bash
export PATH="$PATH:$HOME/.dotnet/tools/"
```


## Generating model from database table

``` bash
$ dotnet-ef dbcontext scaffold "Server=SERVER;Port=5412;Database=DB_NAME;User Id=USERNAME;Password=PASSWORD;Pooling=true;MinPoolSize=1;MaxPoolSize=100;" Npgsql.EntityFrameworkCore.PostgreSQL -o DIR_OUTPUT -t TABLE_NAME -f
```

## Generating database tables from models
1. Change to the solution directory
   ```
   $ cd TheEFCore
   ``` 

2. Run command generate migration script
   ```
   $ dotnet ef migrations add InitialCreate --project TheEFCore.Repository --startup-project TheEFCore.PresentationApp
   ```

3. Change to start up project directory
   ```
   $ cd TheEFCore/TheEFCore.PresentationApp
   ```

4. Run command execute migration script
   ```
   $ dotnet ef database update
   ```
   

## References
1. https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
2. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
3. https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx
4. https://stackoverflow.com/questions/65564889/established-dependency-injection-in-net-core-console-application-for-ef-core-db
5. https://stackoverflow.com/questions/45382536/how-to-enable-migrations-in-visual-studio-for-mac
