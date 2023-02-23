# Config documentation for DatabaseConfig

## Database
A collection of database server configurations.

### Example
```xml
<database>
    <!--Add-->
    <servers>
        <server>...</server>
    </servers>
</database>
<!--Add-->
<connectionStrings>
	<!-- Define the database servers to use. The name is the name of the server and the connection string should be without a database. -->
	<add name="{connectionName}" connectionString="Data Source={source};User Id={username};Password={password};" />
</connectionStrings>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| servers | [DatabaseServerConfig](../DatabaseServerConfig) | A list of database servers that are used in test scenario's. | Yes        | server |
