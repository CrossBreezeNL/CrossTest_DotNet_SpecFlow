#language: en
Feature: Database function test steps (EN)

Background: 
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used

Scenario: Execute function
	When I execute the [sys].[fn_servershareddrives] function
	Then I expect the following results:
		| DriveName |

Scenario: Execute templated function
	When I execute the fn_servershareddrives sys function
	Then I expect the following results:
		| DriveName |

Scenario: Execute function with parameters
	When I execute the [sys].[dm_os_file_exists] function with the following parameter:
		| Parameter         | Value                 |
		| file_or_directory | 'C:\\Not_a_real_file' |
	Then I expect the following results:
		| file_exists | file_is_a_directory | parent_directory_exists |
		| 0           | 0                   | 1                       |

Scenario: Execute function with convention and parameters
	When I execute the dm_os_file_exists sys function with the following parameter:
		| Parameter         | Value                 |
		| file_or_directory | 'C:\\Not_a_real_file' |
	Then I expect the following results:
		| file_exists | file_is_a_directory | parent_directory_exists |
		| 0           | 0                   | 1                       |

Scenario: Execute function with parameters from template
	When I execute the dm_os_file_exists sys2 function
	Then I expect the following results:
		| file_exists | file_is_a_directory | parent_directory_exists |
		| 0           | 0                   | 1                       |