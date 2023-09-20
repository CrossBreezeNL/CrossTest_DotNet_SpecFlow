#language: nl
Functionaliteit: Database function test steps (NL)

Achtergrond: 
	Gegeven de ExampleMsSqlServer database server wordt gebruikt
	En de ExampleDatabase database wordt gebruikt
	En dat de tabel [dbo].[ExampleStagingTable] leeg is

Scenario: Functie uitvoeren
	Gegeven de staging-storage tabel [dbo].[ExampleStagingTable] met de volgende data geladen wordt:
			| ExampleColumn |
			| Some data     |
			| Some data2    |
	Als ik de functie [dbo].[GetExampleStagingTable] uitvoer
	Dan verwacht ik het volgende resultaat:
		| ExampleColumn | StageDateTime          |
		| Some data     | 2000-01-01 00:00:00.00 |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Functie met template uitvoeren
	Gegeven de staging-storage tabel [dbo].[ExampleStagingTable] met de volgende data geladen wordt:
			| ExampleColumn |
			| Some data     |
			| Some data2    |
	Als ik de GetExampleStagingTable dbo functie uitvoer
	Dan verwacht ik het volgende resultaat:
		| ExampleColumn | StageDateTime          |
		| Some data     | 2000-01-01 00:00:00.00 |
		| Some data2    | 2000-01-01 00:00:00.00 |
		
Scenario: Functie met parameters uitvoeren
	Gegeven de staging-storage tabel [dbo].[ExampleStagingTable] met de volgende data geladen wordt:
			| ExampleColumn |
			| Some data2    |
	Als ik de functie [dbo].[GetExampleStagingTableWithParameter] uitvoer met de volgende parameter:
		| Parameter     | Value        |
		| ExampleColumn | 'Some data2' |
	Dan verwacht ik het volgende resultaat:
		| ExampleColumn | StageDateTime          |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Functie met template en parameters uitvoeren
	Gegeven de staging-storage tabel [dbo].[ExampleStagingTable] met de volgende data geladen wordt:
			| ExampleColumn |
			| Some data2    |
	Als ik de GetExampleStagingTableWithParameter dbo2 functie uitvoer met de volgende parameter:
		| Parameter     | Value        |
		| ExampleColumn | 'Some data2' |
	Dan verwacht ik het volgende resultaat:
		| ExampleColumn | StageDateTime          |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Functie met parameters uit template uitvoeren
	Gegeven de staging-storage tabel [dbo].[ExampleStagingTable] met de volgende data geladen wordt:
			| ExampleColumn |
			| Some data2    |
	Als ik de GetExampleStagingTableWithParameter dbo2 functie uitvoer
	Dan verwacht ik het volgende resultaat:
		| ExampleColumn | StageDateTime          |
		| Some data2    | 2000-01-01 00:00:00.00 |