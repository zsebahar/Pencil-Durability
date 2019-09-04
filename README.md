# Pencil-Durability
Solution for the Pencil Durability Kata

This solution was written in C#, and the test framework used was xUnit.

As a prerequisite to run the tests, Microsoft .NET Core 2.2 must be downloaded. When running tests on my machine, I used SDK 2.2.108 for 
Windows. The link to download the SDK can be found below. Once this has been downloaded, the tests can then be run.

Link to SDK Download: https://dotnet.microsoft.com/download/dotnet-core/2.2

To run the tests, the solution must first be downloaded and unzipped. Once unzipped, navigate to 
Pencil-Durability-master\Pencil-Durability-master\Pencil Durability Kata

Once you are navigated to this directory, run the following command to build the solution
dotnet build

After a successful build, run the following command
dotnet test "Pencil Durability Kata\Pencil Durability Kata.csproj"

This will run all the tests within the solution and output the number of tests that passed, failed, and skipped
