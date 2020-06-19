# Config documentation for DatabaseConfig

## Database
A collection of database server configurations.

### Example
```xml
<Database>
    <servers>
        <server>...</server>
    </servers>
</Database>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| servers | [DatabaseServerConfig](../DatabaseServerConfig) | A list of database servers that are used in test scenario's. | Yes        | server |
