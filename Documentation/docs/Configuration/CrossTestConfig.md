# Config documentation for CrossTestConfig

## CrossTest
The CrossTest configuration to configure all information needed for the steps to execute.

### Example
```xml
<CrossTest>
    <test>...</test>
    <database>...</database>
    <process>...</process>
</CrossTest>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| test    | [TestConfig](../TestConfig)               | Configuration of test specifics such as default values, naming conventions etc    | No         |                           |
| database    | [DatabaseConfig](../DatabaseConfig)               | Database configurations    | No         |                           |
| process    | [ProcessConfig](../ProcessConfig)               | Process configurations    | No         |                           |
