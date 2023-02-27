# Config documentation for AdfProcessProjectConfig

## Process configuration
A configuration for a type of process.

### Example
```xml
<AdfProcessProject 
  name="..." 
  tenantID="..." 
  subscriptionId="..." 
  applicationId="..." 
  clientSecret="..." 
  resourceGroupName="..." 
  dataFactoryName="..." 
  parameters="..." 
  processType="..."
/>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | Name of the process configuration, used to refer to this configuration from test scenario's.               |
| tenantID | String | The tenantID of the Azure environment should be specified               |
| subscriptionId | String | The subscriptionId of the Azure environment should be specified               |
| applicationId | String | The applicationId of the application that has been registered on Azure AD should be specified               |
| clientSecret | String | The clientSecret of the application should be specified               |
| resourceGroupName | String | The resourceGroupName where the datafactory has been made should be specified               |
| dataFactoryName | String | The dataFactoryName where the pipeline has been created should be specified               |
| parameters | IDictionary`2 | In case of a pipeline with parameters, The parameters of the pipeline need be specified               |
| processType      | AdfProcessType      |  See [AdfProcessType](../AdfProcessType) for allowed values. |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
