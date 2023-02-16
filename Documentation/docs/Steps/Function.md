# Function
This page describes the Function steps.

## Execute database function
Execute a table valued database function without parameters

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the \[([a-zA-Z0-9_@$#\s]+)\]\.\[([a-zA-Z0-9_@$#\s]+)\] function |
| When | nl | ik de functie \[([a-zA-Z0-9_@$#\s]+)\]\.\[([a-zA-Z0-9_@$#\s]+)\] uitvoer |
| When | en | I execute the ([a-zA-Z0-9_@$#\s]+)\.([a-zA-Z0-9_@$#\s]+) function |
| When | nl | ik de functie ([a-zA-Z0-9_@$#\s]+)\.([a-zA-Z0-9_@$#\s]+) uitvoer |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|schema name | string | The schema owning the function |
|function name | string | The name of the function |

### Examples


```gherkin
 When I execute the [sys].[fn_servershareddrives] function
 

```


```gherkin
 Als ik de functie [sys].[fn_servershareddrives] uitvoer
```


```gherkin
 When I execute the sys.fn_servershareddrives function
 

```


```gherkin
 Als ik de functie sys.fn_servershareddrives uitvoer
```

## Execute database function with parameters
Execute a table valued database function with parameters

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the \[([a-zA-Z0-9_@$#\s]+)\]\.\[([a-zA-Z0-9_@$#\s]+)\] function with the following parameters?: |
| When | nl | ik de functie \[([a-zA-Z0-9_@$#\s]+)\]\.\[([a-zA-Z0-9_@$#\s]+)\] uitvoer met de volgende parameters?: |
| When | en | I execute the ([a-zA-Z0-9_@$#\s]+)\.([a-zA-Z0-9_@$#\s]+) function with the following parameters?: |
| When | nl | ik de functie ([a-zA-Z0-9_@$#\s]+)\.([a-zA-Z0-9_@$#\s]+) uitvoer met de volgende parameters?: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|schema name | string | The schema owning the function |
|function name | string | The name of the function |
|parameter table | Table | A table with the function parameter(s), structured as \| Parameter \| Value \|. See [ParameterTable](../Tables#parametertable). |

### Examples


```gherkin
 When I execute the [sys].[dm_os_file_exists] function with the following parameters:
     | Parameter           | Value                           |
     | file_or_directory | 'C:\\Not_a_real_file'  |
```


```gherkin
 Als ik de functie [sys].[dm_os_file_exists] uitvoer met de volgende parameters:
     | Parameter         | Value                           |
     | file_or_directory | 'C:\\Not_a_real_file' |
```


```gherkin
 When I execute the sys.dm_os_file_exists function with the following parameters:
     | Parameter           | Value                           |
     | file_or_directory | 'C:\\Not_a_real_file'  |
```


```gherkin
 Als ik de functie sys.dm_os_file_exists uitvoer met de volgende parameters:
     | Parameter         | Value                           |
     | file_or_directory | 'C:\\Not_a_real_file' |
```

## Execute templated function
Execute a table valued database function using an object template

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the ([a-zA-Z0-9_@$#\s]+) ([a-zA-Z0-9_@$#-]+) function |
| When | nl | ik de ([a-zA-Z0-9_@$#\s]+) ([a-zA-Z0-9_@$#-]+) functie uitvoer |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|function name | string | Then name of the function |
|object template name | string | The object template name for the function |

### Examples


```gherkin
 When I execute the fn_servershareddrives sys function
```


```gherkin
 Als ik de fn_servershareddrives sys functie uitvoer
```

## Execute templated function with parameters
Execute a table valued database function using an object template and with parameters

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the ([a-zA-Z0-9_@$#\s]+) ([a-zA-Z0-9_@$#-]+) function with the following parameters?: |
| When | nl | ik de ([a-zA-Z0-9_@$#\s]+) ([a-zA-Z0-9_@$#-]+) functie uitvoer met de volgende parameters?: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|function name | string | The name of the function |
|object template name | string | The object template name for the function. |
|parameter table | Table | A table with the function parameter(s), structured as \| Parameter \| Value \|. See [ParameterTable](../Tables#parametertable). |

### Examples


```gherkin
 When I execute the dm_os_file_exists sys function with the following parameter:
     | Parameter         | Value                           |
     | file_or_directory | 'C:\\Not_a_real_file' |
```


```gherkin
 Als ik de dm_os_file_exists sys functie uitvoer met de volgende parameter:
     | Parameter         | Value                           |
     | file_or_directory | 'C:\\Not_a_real_file' |
```


