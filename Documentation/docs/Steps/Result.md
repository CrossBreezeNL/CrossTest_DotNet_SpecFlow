# Step documentation for Result

## Compare expected and actual result
Compare expected and actual result

### Sentences
| Type          | Language         | Sentence      |
|:---           |:---              |:---           |
| Then | en | I expect the following results: |
| Then | nl | verwacht ik het volgende resultaat: |
| Then | en | I expect the following result: |

### Arguments
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
