#language: nl
Functionaliteit: Database function test steps (NL)

Achtergrond: 
	Gegeven de ExampleMsSqlServer database server wordt gebruikt
	En de ExampleDatabase database wordt gebruikt

Scenario: Functie uitvoeren
	Als ik de functie [sys].[fn_servershareddrives] uitvoer
	Dan verwacht ik het volgende resultaat:
		| DriveName |

Scenario: Functie met template uitvoeren
	Als ik de fn_servershareddrives sys functie uitvoer
	Dan verwacht ik het volgende resultaat:
		| DriveName |
		
Scenario: Functie met parameters uitvoeren
	Als ik de functie [sys].[dm_os_file_exists] uitvoer met de volgende parameters:
		| Parameter         | Value                 |
		| file_or_directory | 'C:\\Not_a_real_file' |
	Dan verwacht ik het volgende resultaat:
		| file_exists | file_is_a_directory | parent_directory_exists |
		| 0           | 0                   | 1                       |

Scenario: Functie met template en parameters uitvoeren
	Als ik de dm_os_file_exists sys functie uitvoer met de volgende parameter:
		| Parameter         | Value                 |
		| file_or_directory | 'C:\\Not_a_real_file' |
	Dan verwacht ik het volgende resultaat:
		| file_exists | file_is_a_directory | parent_directory_exists |
		| 0           | 0                   | 1                       |

Scenario: Functie met parameters uit template uitvoeren
	Als ik de dm_os_file_exists sys2 functie uitvoer
	Dan verwacht ik het volgende resultaat:
		| file_exists | file_is_a_directory | parent_directory_exists |
		| 0           | 0                   | 1                       |