# Step documentation for Function

## Execute database function
Execute a table valued database function without parameters

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the \[([a-zA-Z0-9_@$#]+)\]\.\[([a-zA-Z0-9_@$#]+)\] function |
| When | nl | ik de functie \[([a-zA-Z0-9_@$#]+)\]\.\[([a-zA-Z0-9_@$#]+)\] uitvoer |
| When | en | I execute the ([a-zA-Z0-9_@$#]+)\.([a-zA-Z0-9_@$#]+) function |
| When | nl | ik de functie ([a-zA-Z0-9_@$#]+)\.([a-zA-Z0-9_@$#]+) uitvoer |

### Arguments
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

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the \[([a-zA-Z0-9_@$#]+)\]\.\[([a-zA-Z0-9_@$#]+)\] function with the following parameters?: |
| When | nl | ik de functie \[([a-zA-Z0-9_@$#]+)\]\.\[([a-zA-Z0-9_@$#]+)\] uitvoer met de volgende parameters?: |
| When | en | I execute the ([a-zA-Z0-9_@$#]+)\.([a-zA-Z0-9_@$#]+) function with the following parameters?: |
| When | nl | ik de functie ([a-zA-Z0-9_@$#]+)\.([a-zA-Z0-9_@$#]+) uitvoer met de volgende parameters?: |

### Arguments
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

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the ([a-zA-Z0-9_@$#]+) ([a-zA-Z0-9_@$#-]+) function |
| When | nl | ik de ([a-zA-Z0-9_@$#]+) ([a-zA-Z0-9_@$#-]+) functie uitvoer |

### Arguments
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

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I execute the ([a-zA-Z0-9_@$#]+) ([a-zA-Z0-9_@$#-]+) function with the following parameters?: |
| When | nl | ik de ([a-zA-Z0-9_@$#]+) ([a-zA-Z0-9_@$#-]+) functie uitvoer met de volgende parameters?: |

### Arguments
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
