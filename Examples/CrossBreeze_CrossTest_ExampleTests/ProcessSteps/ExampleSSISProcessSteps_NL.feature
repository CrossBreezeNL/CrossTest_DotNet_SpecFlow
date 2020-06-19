#language: nl
@SSIS
Functionaliteit: Run Example SSIS proces (NL)

Achtergrond:
	Gegeven de ExampleMsSqlServer database server wordt gebruikt
	En de tempdb database wordt gebruikt
	Als ik de volgende SQL query uitvoer:
        """
        IF (object_ID('testTable') IS NOT NULL)
		BEGIN
			DROP TABLE testTable
		END

		CREATE TABLE testTable (id INT, description VARCHAR(50))
         """

Scenario: Voer SSIS proces uit
	Als het ExamplePackage SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer getypeerd SSIS proces uit
	Als het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer SSIS proces uit met parameters
	Als het ExamplePackage SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd met de volgende parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer getypeerd SSIS proces uit met parameters
	Als het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project op dit moment wordt uitgevoerd met de volgende parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer SSIS proces uit als rol
	Als de developer het ExamplePackage SSIS proces in het ExampleSsisISPacProject project uitvoert
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer getypeerd SSIS proces uit als rol
	Als de developer het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project uitvoert
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer SSIS proces uit met parameters als rol
	Als de developer het ExamplePackage SSIS proces in het ExampleSsisISPacProject project uitvoert met de volgende parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Voer getypeerd SSIS proces uit met parameters als rol
	Als de developer het ExamplePackage dwh SSIS proces in het ExampleSsisISPacProject project uitvoert met de volgende parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	En ik de inhoud van de tabel [dbo].[testTable] ophaal
	Dan verwacht ik het volgende resultaat:
        | id | description |
		| 1  | 'FirstRow'  |