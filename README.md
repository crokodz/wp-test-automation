#### wp-test-automation
### Test automation project for Buggy Cars Rating
### Test Approach
1. Break the test into smaller scenarious for datailed and efficient coverage.
2. For the manual test it will be done in guidance of the test cases which I assume its already created before starting the project, if none I preffer to build it first. 
3. For the UI automation test,  I will create a per page scenarious then create an end to end scenarious, I will also include checking of security feature. I will use BDD approach as it can be aligned with the testcases, In this project I will use the tools C# with specflow, selenium, and shouldy. I will set a per environment config and can be run in the pipeline after deployment.
4. For the API Automation test, I will use BDD approach as it can be aligned with the testcases.  I will use the tools C# with specflow, restsharp. I will set a per environment config and can be run in the pipeline after deployment.


### Features
- UI Automation testing
 - Login
 - Voting/Adding comment
 - Check overall ranking
- API Automation testing
 - Determin if the overall ranking is in proper order
 - Getting the token which you can use in various scenarious


### You need
- Visual Studio 2022
- .Net 6.0
- Selenium
- Speckflow

### How to run in your local machine
- Clone the repository to your local machine
- Restore all Nuget Packages
- Build
- Set the test runsetting according to the environment you want to test.
- runsettings is located in Properties folder

### How to run in azure pipeline
- Create a pipeline
- Create a release
- Set the variables according to the environment
- Add Visual Studio test platform installer
- Add Visual Studio Test
- Make sure to set those variable as environment variebles in Visual Studio Test
