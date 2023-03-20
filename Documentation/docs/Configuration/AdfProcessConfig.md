# Config documentation for AdfProcessConfig

## Process configuration
A configuration for a type of process.

### Example
```xml
<AdfProcess 
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
| tenantID | String | The ID of the azure environment you want to connect with.               |
| subscriptionId | String | The ID of the azure subscription on which the datafactory is located               |
| applicationId | String | The ID of the app that got registered to Azure AD and has access to the datafactory on which the pipeline is located               |
| clientSecret | String | The secret of the application               |
| resourceGroupName | String | The resourceGroup on which the datafactory is located               |
| dataFactoryName | String | The datafactory on which the pipeline is located               |
| parameters | IDictionary`2 | In case of a pipeline with parameters, The parameters of the pipeline need be specified               |
| processType      | AdfProcessType      | Only "AdfPipeline" is allowed at this moment. See [AdfProcessType](../AdfProcessType) for allowed values. |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
