# Query
This page describes the Query steps.

## Execute query
Executes a query against a database


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | I execute the ([a-zA-Z]+) query '(.*)' |
| When | en | I execute the following ([a-zA-Z]+) query: |
| Given | nl | ik de ([a-zA-Z]+) query '(.*)' uitvoer |
| When | nl | ik de volgende ([a-zA-Z]+) query uitvoer: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|query language name | string | The query language used (SQL\|MDX) |
|query text | string | The query to be executed |

### Examples


```gherkin
 Given I execute the SQL query 'Select 1 as ExampleColumn'
```


```gherkin
 When I execute the following SQL query:
  """
  Select 1 as ExampleColumn
  """
```


```gherkin
 Gegeven ik de SQL query 'Select 1 as ExampleColumn' uitvoer
```


```gherkin
 Als ik de volgende SQL query uitvoer:
  """
  Select 1 as ExampleColumn
  """
```

## Execute query from file
Executes queries from a file against a database


### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | I execute the ([a-zA-Z]+) query file '(.*)' |
| Given | nl | ik het ([a-zA-Z]+) query bestand '(.*)' uitvoer |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|query language name | string | The query language used (SQL\|MDX) |
|file path | string | The file containing the query to be executed |

### Examples


```gherkin
 Given I execute the SQL query file '.\DatabaseSteps\SupportFiles\testQueryFile.sql'
```


```gherkin
 Gegeven ik het SQL query bestand '.\DatabaseSteps\SupportFiles\testQueryFile.sql' uitvoer
```


