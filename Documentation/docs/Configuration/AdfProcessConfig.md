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
  processType="...">
</AdfProcess>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | Name of the process configuration, used to refer to this configuration from test scenario's.               |
| tenantId | String | The ID of the azure environment you want to connect with.               |
| subscriptionId | String | The ID of the azure subscription on which the datafactory is located
| applicationId | String | The ID of the app that got registered to Azure AD and has access to the datafactory on which the pipeline is located        |
| clientSecret | String | The secret of the application               |
| resourceGroupName | String | The resourceGroup on which the datafactory is located               |
| dataFactoryName | String | The datafactory on which the pipeline is located               |
| processType      | AdfProcessType      |  Only "AdfPipeline" is allowed at this moment. |

### Template
In Order to use a template you must edit the crossTest node in your app.config. Under the test childnode add the following:
```xml
<objectTemplates>
    <!-- The following objectTemplate can, for example, be applied on a T-SQL procedure, a SSIS process or a ADF pipeline. -->
    <objectTemplate name="..." appendPrefix="...">
        <attributes>
            <attribute name="..." value="..." />
        </attributes>
    </objectTemplate>
</objectTemplates>
```