# Config documentation for DatabaseServerConfig

## Database server configuration
A configuration for a database server

### Example
```xml
<DatabaseServer 
  name="..." 
  accessToken="..." 
  commandTimeout="..." 
  connectionName="..." 
  isolationLevel="..." 
  type="..."
/>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | The connection name that can be used in test scenario's to refer to this connection               |
| accessToken | String | The access token to use for the connection.               |
| commandTimeout | Int32 | Timeout on queries and statements in seconds.               |
| connectionName | String | The name of the connection string defined in the config, that this database server config refers to.               |
| isolationLevel | String | The type of isolation level that is applied when running tests in a transaction. The default value is Serializable.               |
| type      | DatabaseServerType      |  See [DatabaseServerType](../DatabaseServerType) for allowed values. |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
