# Config documentation for ObjectTemplateConfig

## ObjectTemplate
A object template definition.

### Example
```xml
<ObjectTemplate 
  name="..." 
  parentTemplate="..." 
  prefix="..." 
  suffix="..." 
  appendPrefix="...">
    <attributes>
        <attribute>...</attribute>
    </attributes>
</ObjectTemplate>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | Name of the template, used to refer to it in a test scenario.               |
| parentTemplate | String | Parent template, if a template has a parent defined, everything that is specified in the parent template is (recursively) inherited unless overwritten in the child template.               |
| prefix | String | Specifies the prefix that has to be prepended to the object name of the object the template is applied to.               |
| suffix | String | Specifies the suffix that has to be apppended to the object name of the object the template is applied to.               |
| appendPrefix | String | Specifies an additional prefix if one is also inherited from the parent.               |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| attributes | [ObjectTemplateAttributeConfig](../ObjectTemplateAttributeConfig) | A collection of default attributes. | Yes        | attribute |
