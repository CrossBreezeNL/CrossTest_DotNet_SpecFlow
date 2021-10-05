#language: nl
Functionaliteit: Database query test steps (NL)

Achtergrond: 
Gegeven de ExampleMsSqlServer database server wordt gebruikt
En de ExampleDatabase database wordt gebruikt

Scenario: Inline SQL Query
Gegeven ik de SQL query 'Select 1 as ExampleColumn' uitvoer
Dan verwacht ik het volgende resultaat:
         | ExampleColumn |
         | 1             |
		 
Scenario: Non-inline SQL Query
Als ik de volgende SQL query uitvoer:
	"""
	Select 1 as ExampleColumn
	"""

Dan verwacht ik het volgende resultaat:
         | ExampleColumn |
         | 1             |

Scenario:  Executing a SQL query from file
Gegeven ik het SQL query bestand '.\DatabaseSteps\SupportFiles\testQueryFile.sql' uitvoer

Dan verwacht ik het volgende resultaat:
         | ExampleColumn | 
         | 1             |	

@ExectedToFail
Scenario: Test command timeout failure
Als ik de volgende SQL query uitvoer:
    """
        	WAITFOR DELAY '00:00:11'
			SELECT 1 as ExampleColumn
			
    """

Dan verwacht ik het volgende resultaat:
         | ExampleColumn | 
         | 1             |	

Scenario: Test command timeout success
Als ik de volgende SQL query uitvoer:
    """
        	WAITFOR DELAY '00:00:09'
			SELECT 1 as ExampleColumn
			
    """

Dan verwacht ik het volgende resultaat:
         | ExampleColumn | 
         | 1             |	
