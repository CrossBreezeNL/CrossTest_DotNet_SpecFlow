# Config documentation for CrossTestConfig

## CrossTest
The CrossTest configuration to configure all information needed for the steps to execute.

### Example
```xml
<CrossTest>
    <test>...</test>
    <database>...</database>
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

## CrossTestSsis
The CrossTestSsis configuration to configure all information needed for the steps to execute.

### Example
```xml
<CrossTestSsis>
    <SsisProcesses>...</SsisProcesses>
</CrossTestSsis>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| SsisProcesses    | [SsisProcessProjectConfig](../SsisProcessConfig)               | A list of process configurations that can be used in test scenario's.    | Yes         |                           |


## CrossTestAdf
The CrossTestAdf configuration to configure all information needed for the steps to execute.

### Example
```xml
<CrossTestAdf>
    <AdfProcesses>...</AdfProcesses>
</CrossTestAdf>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| AdfProcesses    | [AdfProcessConfig](../AdfProcessConfig)               | A list of process configurations that can be used in test scenario's.    | Yes         |                           |