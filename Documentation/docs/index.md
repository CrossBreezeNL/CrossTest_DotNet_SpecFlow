# Introduction
This wiki contains the documentation of CrossTest.

## What is CrossTest
CrossTest is a library implementing Gherkin that can be used to easily implement test automation on a data solution, for instance on a data warehouse, using SpecFlow or Cucumber. 

### Using CrossTest with SpecFlow
CrossTest is available as a C#/SpecFlow library through NuGet. With CrossTest you can implement test scenarios that insert test data, execute processes (like stored procedures, functions and SSIS packages) and compare the actual and expected output.

Use the SpecFlow implementation if you are using the Microsoft SQL Server stack.

To get started with the C#/SpecFlow version of CrossTest go to [Getting Started](./GettingStarted).

### Using CrossTest with Cucumber
CrossTest is available as a Java library through Maven. With the Java/Cucumber implementation you can perform database actions on databases that are accessible via JDBC and run processes by using our Informatica PowerCenter process executor or implement your own custom process executor.

Use the Java/Cucumber implementation of CrossTest if you are using a technology stack other than Microsft SQL Server or if you are more comfortable with Java instead of C#.

To get started with the Java/Cucumber version of CrossTest include the CrossTest packages in a Java Maven project. The packages can be found in the [Central Maven repository](https://mvnrepository.com/artifact/com.x-breeze.test). Step and configuration documentation can be found [here](../Java)

## Documentation Shortkeys

| Shortkey | Description |
|:---      |:---         |
|<kbd>F</kbd> or <kbd>S</kbd> | Press the <kbd>F</kbd> or <kbd>S</kbd> key to start searching. |
| <kbd>Shift</kbd> + mouse scroll[^1] | Press the <kbd>Shift</kbd> key while scrolling to scroll horizontally. |

[comment]: Footnotes
[^1]: This can be handy when a code example is wide and doesn't fit within the boundaries of the page.