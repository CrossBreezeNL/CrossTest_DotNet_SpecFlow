# Config documentation for SsisProcessConfig

## Process configuration
A configuration for a type of process.

### Example
```xml
<SsisProcess 
  name="..." 
  isPacFileLocation="..." 
  ssisConnectionName="..." 
  ssisFolder="..." 
  ssisProject="..." 
  ssisEnvironmentFolder="..." 
  ssisEnvironmentName="..." 
  use32RuntimeOn64="..." 
  ssisFilePath="..." 
  processType="...">
    <connections>
        <connection>...</connection>
    </connections>
</SsisProcess>
```

### Attributes
| Attribute            | Type                 | Description                               |
|:---                  |:---                  |:---                                       |
| name | String | Name of the process configuration, used to refer to this configuration from test scenario's.               |
| isPacFileLocation | String | In case of a process configuration where processType is ISPac, the isPacFileLocation needs to be specified.               |
| ssisConnectionName | String | In case of a process configuration where processType is SqlServer or ISServer, the ssisConnectionName needs to be specified, referring to a connectionstring that is defined in the config elsewhere.               |
| ssisFolder | String | In case of a process configuration where processType is SqlServer the ssisFolder needs to be specified.               |
| ssisProject | String | In case of a process configuration where processType is SqlServer the ssisProject needs to be specified.               |
| ssisEnvironmentFolder | String | In case of a process configuration where processType is SqlServer the ssisEnvironmentFolder needs to be specified.               |
| ssisEnvironmentName | String | In case of a process configuration where processType is SqlServer the ssisEnvironmentName needs to be specified.               |
| use32RuntimeOn64 | Nullable`1 | In case of a process configuration where a SSIS processType is used (ISPac, ISServer) this property can be used to use the 32 bits runtime on 64 bits servers.               |
| ssisFilePath | String | In case of a process configuration where processType is FileSystem the ssisFilePath needs to be specified.               |
| processType      | SsisProcessType      |  See [SsisProcessType](../SsisProcessType) for allowed values. |

### Config elements
| Config element        | Type                                                     | Description                  | Collection | Item name                 |
|:---                   |:---                                                      |:---                          |:---        |:---                       |
| connections | [SsisProjectConnection](../SsisProjectConnection) | A collection of connections used in the process configuration, for example source/target connections for SSIS packages. | Yes        | connection |
