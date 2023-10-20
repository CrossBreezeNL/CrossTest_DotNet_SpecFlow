# Release notes

Here you can find the release notes of all CrossTest releases up till the release this documentation applies to.
Click on the header of a version number to go to the documentation of that specific version.

[//]: # (Use the following example to create the release notes for a new release.)
[//]: # ()
[//]: # (## Version X.X <sup>[docs](../X.X/)</sup>)
[//]: # ()
[//]: # (- [ ] x.x.x <sup>xx-xx-xxxx</sup>)
[//]: # (>)
[//]: # (> !!! success "New features")
[//]: # (>     * [ ] Template)
[//]: # (>         * [ ] XML Template)
[//]: # (>             - [X] Some new feature...)
[//]: # (> !!! "Enhanced features")
[//]: # (>     * [ ] Model)
[//]: # (>         - [X] Some enhanced feature...)
[//]: # (> !!! warning "Bug fixes")
[//]: # (>     * [ ] Binding)
[//]: # (>         * [X] Some issue...)

## [Version 1.1](../1.1/)
- [ ] 1.1.2.0 <sup>20-10-2023</sup>
> !!! success "Enhanced features"
>     * [ ] Database steps
>           - [X] Added support for more SQL data types (Bit & DateTimeOffset).

- [ ] 1.1.1.0 <sup>07-06-2023</sup>
> !!! success "Enhanced features"
>     * [ ] Configuration
>         * [ ] Microsoft SQL Server Database
>             - Set access token for SqlConnection.

- [ ] 1.1.0.0 <sup>10-03-2023</sup>
> !!! success "New features"
>     * [ ] Configuration
>         * [ ] Azure Data Factory
>             - [X] Specify data factory connections (TenantID, SubscriptionID, ApplicationID, Application Secret, ResourceGroup, DataFactory)
>             - [X] Specify pipeline parameters
>     * [ ] Process steps
>         * [ ] Azure Data Factory
>             - [X] Execute a ADF pipeline
>             - [X] Execute a ADF pipeline with parameters
>             - [X] Execute a ADF pipeline with template parameters
>             - [X] Execute a ADF pipeline with template parameters and its own parameters
> !!! success "Enhanced features"
>     * [ ] Configuration
>         * [ ] SpecFlow
>             - [X] Upgrade package to version 3.9.74 and upgraded all other dependencies.
>         * [ ] Process
>             - [X] Process configuration removed
>         * [ ] Microsoft SQL Server Integration Services
>             - [X] Moved SSIS process configuration to a seperated section
>     * [ ] Process
>         * [ ] Microsoft SQL Server Integration Services
>             - [X] Moved implementation to a seperated NuGet package

## [Version 1.0](../1.0/)
- [ ] 1.0.2.3 <sup>18-03-2022</sup>
> !!! success "Enhanced features"
>     * [ ] Process steps
>         * [ ] Microsoft SQL Server Integration Services
>             - [X] Updated SQL Server client tools dependency from SQL Server 2017 to SQL Server 2019, this means running SSIS tasks now requires SQL Server 2019 be installed on the system running the tests.

- [ ] 1.0.2.2 <sup>23-07-2021</sup>
> !!! success "Enhanced features"
>     * [ ] Database steps
>           - [X] Support dots in SQL agent job names
>     * [ ] Process steps
>           - [X] Support dots in process names
> !!! warning "Bug fixes"
>     * [ ] Binding
>           - [X] Fixed issue with new step binding which occured as of 1.0.2.

- [ ] 1.0.2.1 <sup>13-07-2021</sup>
> !!! warning "Bug fixes"
>     * [ ] Process steps
>         * [ ] Microsoft SQL Server Integration Services
>             - [X] Fixed execution of SSAS task in SSIS package

- [ ] 1.0.2 <sup>09-06-2021</sup>
> !!! success "Enhanced features"
>     * [ ] Database steps
>           - [X] Support spaces in SQL agent job names
>           - [X] Support spaces in database object names (tables, schemas, functions)

- [ ] 1.0.1 <sup>27-11-2020</sup>
> !!! success "New features"
>     * [ ] Configuration
>         * [ ] Microsoft SQL Server Database
>             - Set command timeout in seconds on database server

- [ ] 1.0 <sup>24-05-2019</sup>
> Initial release
> !!! success "New features"
>     * [ ] Database steps
>         * [ ] Microsoft SQL Server Database
>             - [X] Execute a test within a transaction (automatic rollback at the end)
>             - [X] Insert data into a table
>             - [X] Execute a SQL query (and get the results)
>             - [X] Get data from a table, view or function
>         * [ ] Microsoft SQL Server Analysis Services
>             - [X] Execute a MDX query (and get the results)
>     * [ ] Process steps
>         * [ ] Microsoft SQL Server Integration Services
>             - [X] Execute a SSIS package
>             - [X] Specify package parameters
>         * [ ] Microsoft SQL Agent Job
>             - [X] Execute a job
>     * [ ] Result steps
>         * [ ] Result verification
>             - [X] Compare expected and actual results
>     * [ ] Configuration
>         * [ ] Test
>             - [X] Specify object templates (naming convention and predefined set of attributes with values)
>         * [ ] Database
>             - [X] Configure database connections
>         * [ ] Process
>             - [X] Specify project configuration (ISServer, ISPac, SqlServer, SsisPackageStore & FileSystem)
>             - [X] Specify project connections
>             - [X] Specify project parameters