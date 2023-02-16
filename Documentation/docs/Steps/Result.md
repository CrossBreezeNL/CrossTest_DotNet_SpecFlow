# Result
This page describes the Result steps.

## Compare expected and actual result
Compare expected and actual result

### Hooks
Below the hooks are given which are configured for this step. This means if you add the specified tag(s) on a scenario, the step will be executed automatically before or after (see Type) the scenario.

| Type          | Tag(s)         | Description      |
|:---           |:---              |:---           |
| Hook_type | @Tag_code | Hook_description |

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Then | en | I expect the following results: |
| Then | nl | verwacht ik het volgende resultaat: |
| Then | en | I expect the following result: |


### Arguments
The details of every argument of the step are listed below.

| Parameter    | Datatype          | Description          |
|:---          |:---               |:---                  |
|expected results | Table | The table with the expected results. See [TestDataTable](../Tables#testdatatable). |

### Examples


```gherkin
 Then I expect the following results:
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```


```gherkin
 Dan verwacht ik het volgende resultaat:         
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```


```gherkin
 Then I expect the following result:
  | Id | Description    |
  | 1  | 'FirstRow'       |
  | 2  | 'SecondRow' |
```


