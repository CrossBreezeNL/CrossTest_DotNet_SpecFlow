#language: nl
Functionaliteit: Database table test steps (NL)

Achtergrond: 
	Gegeven de ExampleMsSqlServer database server wordt gebruikt
	En de ExampleDatabase database wordt gebruikt
	Als ik de volgende SQL query uitvoer:
		"""
		CREATE TABLE [#testTable] (
			[Id] int,
			[Description] varchar(50),
			[StageDateTime] datetime2(2)
		)
		"""

Scenario: Laad data naar tabel
	Gegeven de tabel [dbo].[#testTable] met de volgende data geladen wordt:
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |
	Als ik de inhoud van de tabel [dbo].[#testTable] ophaal
	Dan verwacht ik het volgende resultaat:         
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |

Scenario: Laad data naar template tabel
	Gegeven de staging-storage tabel [dbo].[#testTable] met de volgende data geladen wordt:
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |
	Als ik de inhoud van de tabel [dbo].[#testTable] ophaal
	Dan verwacht ik het volgende resultaat:         
		| Id | Description | StageDateTime          |
		| 1  | 'FirstRow'  | 2000-01-01 00:00:00.00 |
		| 2  | 'SecondRow' | 2000-01-01 00:00:00.00 |

Scenario: Maak de table leeg
	Gegeven dat de tabel [dbo].[#testTable] leeg is
	Als ik de inhoud van de tabel [dbo].[#testTable] ophaal
	Dan verwacht ik het volgende resultaat:  
		| Id | Description | StageDateTime |