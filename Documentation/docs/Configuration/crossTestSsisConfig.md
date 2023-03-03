# Config documentation for crossTestSsisConfig

## crossTestSsis


### Example
```xml
<crossTestSsis>
    <SsisProcesses>
        <SsisProcess>...</SsisProcess>
    </SsisProcesses>
</crossTestSsis>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| SsisProcesses | [SsisProcessConfig](../SsisProcessConfig) | A list of process configurations that can be used in test scenarios. | Yes        | SsisProcess |
