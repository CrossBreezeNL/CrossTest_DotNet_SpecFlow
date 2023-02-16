# DbTable
This page describes the DbTable steps.

## Load data into templated table
Loads data into a table that conforms to a configured table template

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the ([a-zA-Z0-9_@$#-]+) table (.+) is loaded with the following data: |
| Given | nl | de ([a-zA-Z0-9_@$#-]+) tabel (.+) met de volgende data geladen wordt: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|table template | string | The name of the object template, referring to an object template from the config |
|table name | string | The name of the table to write the data to |
|data to insert | Table | The data to write to the table, formatted as a table with the appropriate column names. See [TestDataTable](../Tables#testdatatable). |

### Examples


```gherkin
 Given the staging table [dbo].[#testTable] is loaded with the following data:
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```


```gherkin
 Gegeven de staging tabel [dbo].[#testTable] met de volgende data geladen wordt:
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```

## Load data into table
Loads data into a table

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the table (.+) is loaded with the following data: |
| Given | nl | de tabel (.+) met de volgende data geladen wordt: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|table name | string | The name of the table to write the data to |
|data to insert | Table | The data to write to the table, formatted as a table with the appropriate column names. See [TestDataTable](../Tables#testdatatable). |

### Examples


```gherkin
 Given the table [dbo].[#testTable] is loaded with the following data:
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```


```gherkin
 Gegeven de tabel [dbo].[#testTable] met de volgende data geladen wordt:
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```

## Retrieve data from table
Retrieves data from a table

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code and  | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| When | en | I retrieve the contents of the \[([a-zA-Z0-9_@$#\s]+)\].\[([a-zA-Z0-9_@$#\s]+)\] (?:table|view) |
| When | en | I retrieve the contents of the ([a-zA-Z0-9_@$#\s]+).([a-zA-Z0-9_@$#\s]+) (?:table|view) |
| When | nl | ik de inhoud van de (?:tabel|view) ([a-zA-Z0-9_@$#\s]+).([a-zA-Z0-9_@$#\s]+) ophaal |
| When | nl | ik de inhoud van de (?:tabel|view) \[([a-zA-Z0-9_@$#\s]+)\].\[([a-zA-Z0-9_@$#\s]+)\] ophaal |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|schema name | string | The name of the table or view's schema |
|table name | string | The name of the table or view to get the data from |

### Examples


```gherkin
 When I retrieve the contents of the [dbo].[#testTable] table
```


```gherkin
 When I retrieve the contents of the dbo.#testTable table
```


```gherkin
 Als ik de inhoud van de tabel dbo.#testTable ophaal
```


```gherkin
 Als ik de inhoud van de tabel [dbo].[#testTable] ophaal
```

## Delete data from table
Deletes data from a table

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Given | en | the table \[([a-zA-Z0-9_@$#\s]+)\].\[([a-zA-Z0-9_@$#\s]+)\] is empty |
| Given | nl | dat de tabel \[([a-zA-Z0-9_@$#\s]+)\].\[([a-zA-Z0-9_@$#\s]+)\] leeg is |
| Given | en | the table ([a-zA-Z0-9_@$#\s]+).([a-zA-Z0-9_@$#\s]+) is empty |
| Given | nl | dat de tabel ([a-zA-Z0-9_@$#\s]+).([a-zA-Z0-9_@$#\s]+) leeg is |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|schema name | string | The name of the table schema |
|table name | string | The name of the table to delete the data from |

### Examples


```gherkin
 Given the table [dbo].[#testTable] is empty
```


```gherkin
 Gegeven dat de tabel [dbo].[#testTable] leeg is
```


```gherkin
 Given the table [dbo].[#testTable] is empty
```


```gherkin
 Gegeven dat de tabel [dbo].[#testTable] leeg is
```


