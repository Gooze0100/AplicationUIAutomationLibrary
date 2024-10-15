using System.Data;

namespace SQLLibrary.Dapper;

public class GetData
{
    // So plug in can be greated and used in library, so we can create certain hooks in library and use as compiled dll in our application or user interface dynamically.
    // Your application/user interface should know about library, but library should not know about UI, direction should be important.
    // Except user interface library like WPF or something like that can know about it.
    // Nuget packages adds libraries to your project, but also you can have private nuget packages feed by added new package source from specific place
    // but for versioning you need to add to nuget package of your project.
    // circular dependency is not good that because of the build process if goes in sequence and libraray says that it is depending on console app and then console app says that it is depending on library
    // either one cannot be built because of this conflict of dependencies



}
