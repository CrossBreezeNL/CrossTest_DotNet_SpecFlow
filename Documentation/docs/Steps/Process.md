# Process
This page describes the Process steps.

## Execute process
Execute a package without parameters. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project have just been executed |
| When | en | the ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project is being executed |
| Given | nl | het ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project is zojuist uitgevoerd |
| When | nl | het ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project op dit moment wordt uitgevoerd |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|process name | string | Name of the process |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |

### Examples


```gherkin
 When the ExamplePackage SSIS process in the ExampleSsisISPacProject project is being executed
```


```gherkin
 Als het ExamplePackage SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd
```

## Execute process with parameters
Execute a package with specific parameters. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project have just been executed with the following parameters?: |
| When | en | the ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project is being executed with the following parameters?: |
| Given | nl | het ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project zojuist is uitgevoerd met de volgende parameters?: |
| When | nl | het ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project op dit moment wordt uitgevoerd met de volgende parameters?: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|process name | string | Name of the process |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |
|parameter table | Table | A table with the process parameters, structured as \| Parameter \| Value \|. See [ParameterTable](../Tables#parametertable). |

### Examples


```gherkin
 When the ExamplePackage SSIS process in the ExampleSsisISPacProject project is being executed with the following parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```


```gherkin
 Als het ExamplePackage SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd met de volgende parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```

## Execute templated process
Execute a package with default parameters and naming convention from a template. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project have just been executed |
| When | en | the ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project is being executed |
| Given | nl | het ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project is zojuist uitgevoerd |
| When | nl | het ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project op dit moment wordt uitgevoerd |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|process name | string | Name of the process |
|process template | string | Refers to a object template configured in the config's test section |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |

### Examples


```gherkin
 When the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project is being executed
```


```gherkin
 Als het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd
```

## Execute templated process with parameters
Execute a package with default parameters from a template and specific parameters. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project have just been executed with the following parameters?: |
| When | en | the ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project is being executed with the following parameters?: |
| Given | nl | het ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project zojuist is uitgevoerd met de volgende parameters?: |
| When | nl | het ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project op dit moment wordt uitgevoerd met de volgende parameters?: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|process name | string | Name of the proces |
|process template | string | Refers to a object template configured in the config's test section |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |
|parameter table | Table | A table with the process parameters, structured as \| Parameter \| Value \|. See [ParameterTable](../Tables#parametertable). |

### Examples


```gherkin
 When the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project is being executed with the following parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```


```gherkin
 Als het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd met de volgende parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```

## Execute process as role
Execute a package as a specific user role. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | (?:the|a|an) ([a-zA-Z\s]+) executes the ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project |
| When | nl | (?:de|het|een) ([a-zA-Z\s]+) het ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project uitvoert |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|role name | string | Role under which the process is executed |
|process name | string | Name of the process |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |

### Examples


```gherkin
 When the developer executes the ExamplePackage SSIS process in the ExampleSsisISPacProject project
```


```gherkin
 Als de developer het ExamplePackage SSIS proces in het ExampleSsisISPacProject project uitvoert
```

## Execute templated process as role
Execute a templated package as a specific user role. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | (?:the|a|an) ([a-zA-Z\s]+) executes the ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#-]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project |
| When | nl | (?:de|het|een) ([a-zA-Z\s]+) het ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#-]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project uitvoert |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|role name | string | Role under which the process is executed |
|process name | string | Name of the process |
|object template name | string | Refers to a object template configured in the config's test section |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |

### Examples


```gherkin
 When the developer executes the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project
```


```gherkin
 Als de developer het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project uitvoert
```

## Execute templated process as role with parameters
Execute a templated package as a specific user role and with parameters. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | (?:the|a|an) ([a-zA-Z\s]+) executes the ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#-]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project with the following parameters?: |
| When | nl | (?:de|het|een) ([a-zA-Z\s]+) het ([a-zA-Z0-9_@$#.]+) ([a-zA-Z0-9_@$#-]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project uitvoert met de volgende parameters?: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|role name | string | Role under which the process is executed |
|process name | string | Name of the process |
|object template name | string | Refers to a object template configured in the config's test section |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |
|parameter table | Table | A table with the process parameters, structured as \| Parameter \| Value \|. See [ParameterTable](../Tables#parametertable). |

### Examples


```gherkin
 When the developer executes the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project with the following parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```


```gherkin
 Als de developer het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project uitvoert met de volgende parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```

## Execute process with parameters as role
Execute a package with parameters as a specific user role. A package can be either SSIS or ADF package. 


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | (?:the|a|an) ([a-zA-Z\s]+) executes the ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) process in the ([a-zA-Z0-9_]+) project with the following parameters?: |
| When | nl | (?:de|het|een) ([a-zA-Z\s]+) het ([a-zA-Z0-9_@$#.]+) (SSIS|ADF) proces in het ([a-zA-Z0-9_]+) project uitvoert met de volgende parameters?: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|role name | string | Role under which the process is executed |
|process name | string | Name of the process |
|process type | string | Type of process to run |
|project name | string | Refers to a project configured in the config's process section |
|parameter table | Table | A table with the process parameters, structured as \| Parameter \| Value \|. See [ParameterTable](../Tables#parametertable). |

### Examples


```gherkin
 When the developer executes the ExamplePackage SSIS process in the ExampleSsisISPacProject project with the following parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```


```gherkin
 Als de developer het ExamplePackage SSIS proces in het ExampleSsisISPacProject project uitvoert met de volgende parameter:
  | Parameter                 | Value                              |
  | ExampleParameter | SomeParameterValue |
```


