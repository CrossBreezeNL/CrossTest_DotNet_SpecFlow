# Config documentation for SsisProjectConnection

## Connection
Connection used in an SSIS package.

### Example
```xml
<SsisProjectConnection 
  name="..." 
  connectionName="..."
/>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | The name of the connection.               |
| connectionName | String | Name of connection that this SSIS connection refers to, should be an existing connectionstring defined in the configuration.               |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
