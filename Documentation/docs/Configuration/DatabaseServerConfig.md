# Config documentation for DatabaseServerConfig

## Database server configuration
A configuration for a database server

### Example
```xml
<DatabaseServer 
  name="..." 
  connectionName="..." 
  type="..."
/>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | The connection name that can be used in test scenario's to refer to this connection               |
| connectionName | String | The name of the connection string defined in the config, that this database server config refers to.               |
| type      | DatabaseServerType      |  See [DatabaseServerType](../DatabaseServerType) for allowed values. |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
