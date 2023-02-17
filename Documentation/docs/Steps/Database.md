# Database
This page describes the Database steps.

## Execute SQL agent job
Executes a SQL Agent job


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | The SQL agent job ([a-zA-Z0-9_@$#\s]+) has just been executed |
| When | en | The SQL agent job ([a-zA-Z0-9_@$#\s]+) is being executed |
| Given | nl | Dat de SQL agent job ([a-zA-Z0-9_@$#\s]+) zojuist is uitgevoerd |
| When | nl | De SQL agent job ([a-zA-Z0-9_@$#\s]+) op dit moment wordt uitgevoerd |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|job name | string | The name of the job |

### Examples


```gherkin
 Given the SQL agent job ExampleSqlJob has just been executed
```


```gherkin
 When the SQL agent job ExampleSqlJob is being executed
```


```gherkin
 Gegeven dat de SQL agent job ExampleSqlJob zojuist is uitgevoerd
```


```gherkin
 Als de SQL agent job ExampleSqlJob op dit moment wordt uitgevoerd
```

## Execute SQL agent job as role
Executes a SQL Agent job as a specific role


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | (?:the|a|an) ([a-zA-Z\s]+) executes the ([a-zA-Z0-9_@$#.]+) SQL agent job |
| When | nl | (?:de|het|een) ([a-zA-Z\s]+) de ([a-zA-Z0-9_@$#.]+) SQL agent job uitvoert |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|role name | string | The name of the role |
|job name | string | The name of the job |

### Examples


```gherkin
 When the developer executes the ExampleSqlJob SQL agent job
```


```gherkin
 Als de developer de ExampleSqlJob SQL agent job uitvoert
```


