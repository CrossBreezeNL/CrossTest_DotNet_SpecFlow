# Config documentation for ProcessConfig

## Process
A collection of process configurations.

### Example
```xml
<Process>
    <projects>
        <project>...</project>
    </projects>
</Process>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| projects | [ProcessProjectConfig](../ProcessProjectConfig) | A list of process configurations that can be used in test scenario's. | Yes        | project |
