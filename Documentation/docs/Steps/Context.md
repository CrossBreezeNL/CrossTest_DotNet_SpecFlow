# Context
This page describes the Context steps.

## Specify target database server
Specify the database against which the database test steps are to be executed.

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#]+) database server is used |
| When | en | the ([a-zA-Z0-9_@$#]+) database server is being used |
| Given | nl | de ([a-zA-Z0-9_@$#]+) database server wordt gebruikt |
| When | nl | de ([a-zA-Z0-9_@$#]+) database server gebruikt wordt |


### Arguments
The details of every argument of the step are listed below.

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

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#\s]+) database is used |
| When | en | the ([a-zA-Z0-9_@$#\s]+) database is being used |
| Given | nl | de ([a-zA-Z0-9_@$#\s]+) database wordt gebruikt |
| When | nl | de ([a-zA-Z0-9_@$#\s]+) database gebruikt wordt |


### Arguments
The details of every argument of the step are listed below.

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

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the test has been executed within a transaction |
| When | en | the test is being executed within a transaction |
| Given | nl | de test binnen een transactie wordt uitgevoerd |
| When | nl | de test binnen een transactie uitgevoerd wordt |


### Arguments
The details of every argument of the step are listed below.

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


