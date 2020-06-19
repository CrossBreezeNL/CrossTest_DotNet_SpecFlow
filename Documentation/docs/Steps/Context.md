# Step documentation for Context

## Specify target database server
Specify the database against which the database test steps are to be executed.

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#]+) database server is used |
| When | en | the ([a-zA-Z0-9_@$#]+) database server is being used |
| Given | nl | de ([a-zA-Z0-9_@$#]+) database server wordt gebruikt |
| When | nl | de ([a-zA-Z0-9_@$#]+) database server gebruikt wordt |

### Arguments
| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|database server name | string | The database, referring to a database name specified in the config |

### Examples


```gherkin
 Given the ExampleDatabase database is used
```


```gherkin
 When the ExampleDatabase database is being used
```


```gherkin
 Gegeven de ExampleMsSqlServer database server wordt gebruikt
```


```gherkin
 Als de ExampleMsSqlServer database server gebruikt wordt
```
## Specify target database
Specify the server against which the database test steps are to be executed

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#]+) database is used |
| When | en | the ([a-zA-Z0-9_@$#]+) database is being used |
| Given | nl | de ([a-zA-Z0-9_@$#]+) database wordt gebruikt |
| When | nl | de ([a-zA-Z0-9_@$#]+) database gebruikt wordt |

### Arguments
| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|database name | string | The database server, referring to a databaseserver name specified in the config. |

### Examples


```gherkin
 Given the ExampleMsSqlServer database server is used
```


```gherkin
 When the ExampleMsSqlServer database server is being used
```


```gherkin
 Gegeven de ExampleMsSqlServer database server wordt gebruikt
```


```gherkin
 Als de ExampleMsSqlServer database server gebruikt wordt
```
## Specify test transaction
Specify wether test steps should be executed within a transaction and rolled back afterwards

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the test has been executed within a transaction |
| When | en | the test is being executed within a transaction |
| Given | nl | de test binnen een transactie wordt uitgevoerd |
| When | nl | de test binnen een transactie uitgevoerd wordt |

### Arguments
| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |

### Examples


```gherkin
 Given the test has been executed within a transaction
```


```gherkin
 When the test is being executed within a transaction
```


```gherkin
 Gegeven de test binnen een transactie wordt uitgevoerd
```


```gherkin
 Als de test binnen een transactie uitgevoerd wordt
```
