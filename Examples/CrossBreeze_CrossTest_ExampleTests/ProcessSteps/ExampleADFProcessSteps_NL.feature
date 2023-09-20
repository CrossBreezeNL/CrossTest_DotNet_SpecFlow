#language: nl
@ADF
Functionaliteit: Run Example ADF proces (NL)

Achtergrond:
	Gegeven de ExampleMsSqlServer database server wordt gebruikt
	En de ExampleDatabase database wordt gebruikt
	Als ik de volgende SQL query uitvoer:
        """
        IF (object_ID('testTable') IS NOT NULL)
		BEGIN
			DROP TABLE testTable
		END

		CREATE TABLE testTable (id INT, description VARCHAR(50))
		
		insert into  [dbo].[testTable] values (1, 'FirstRow')
        """

Scenario: Voer ADF proces uit
	Als het CrossTestPipeline ADF proces in het ExampleAdfPipeline project op dit moment wordt uitgevoerd
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer getypeerd ADF proces uit
	Als het CrossTestPipelineWithParameters adfTemplate ADF proces in het ExampleAdfPipeline project op dit moment wordt uitgevoerd
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer ADF proces uit met parameters
	Als het CrossTestPipelineWithParameters ADF proces in het ExampleAdfPipeline project op dit moment wordt uitgevoerd met de volgende parameter:
		| Parameter     | Value						|
		| baseUrl		| https://x-breeze.com/		|
		| uri			| crossgenerate					|
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer getypeerd ADF proces uit met parameters
	Als het CrossTestPipelineWithParameters adfTemplate ADF proces in het ExampleAdfPipeline project op dit moment wordt uitgevoerd met de volgende parameter:
		| Parameter     | Value		|
		| uri			| crossgenerate		|
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |