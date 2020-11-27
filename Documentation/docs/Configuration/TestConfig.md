# Config documentation for TestConfig

## Test
Test configuration

### Example
```xml
<Test>
    <namingConvention>...</namingConvention>
    <objectTemplates>
        <objectTemplate>...</objectTemplate>
    </objectTemplates>
</Test>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| namingConvention    | [TestNamingConvention](../TestNamingConvention)               | Naming conventions used in the tests    | No         |                           |
| objectTemplates | [ObjectTemplateConfig](../ObjectTemplateConfig) | A collection of object templates that are applied on the test scenario's if applicable. | Yes        | objectTemplate |
