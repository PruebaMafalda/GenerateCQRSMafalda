using System.IO;

namespace GenerateCQRSMafalda.Utils;
public class ProjectFile
{
    public static bool CreateIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return true;
    }

    public static bool CreateFile(string path, string fileName, string content)
    {
        CreateIfNotExists(path);
        string fullPath = Path.Combine(path, fileName);
        File.WriteAllText(fullPath, content);
        return true;
    }
    public static bool CreateFile(CreateFileParams parameters)
    {
        CreateIfNotExists(parameters.Path);
        string fullPath = Path.Combine(parameters.Path, parameters.FileName);
        File.WriteAllText(fullPath, parameters.Content);
        return true;
    }
}

public class CreateFileParams
{
    public string Path { get; set; }
    public string FileName { get; set; }
    public string Content { get; set; }

}


public class SpaceProject{
    public string Location { get; set; }
    public bool IsTest { get; set; } = false;
    public string FullPath { get{
        var parts = Location.Split('.');
        return !IsTest
                ? Path.Combine(PathProject.Root, Path.Combine(parts)) 
                : Path.Combine(PathProject.RootTest, Path.Combine(parts));
    } }
    public string NameSpace { get{
        return IsTest
                ? $"{PathProject.NameSpaceProject}.Tests.{Location}"
                : $"{PathProject.NameSpaceProject}.{Location}";
    } }
    public SpaceProject(string location){
        Location = location;
    }
    public SpaceProject(string location, bool isTest){
        Location = location;
        IsTest = isTest;
    }
}

public class PathApplication
{
    public static SpaceProject DomainAggregateModel = new SpaceProject($"{PathProject.Domain}.AggregateModel");
    public static SpaceProject DomainContractsRepositories = new SpaceProject($"{PathProject.Domain}.Contracts.Infrastructure.Persistance.Repositories");
    public static SpaceProject DomainContractsPersistance = new SpaceProject($"{PathProject.Domain}.Contracts.Infrastructure.Persistance");
    public static SpaceProject DomainSpecifications = new SpaceProject($"{PathProject.Domain}.Specifications.EF");
    public static SpaceProject InfrastructureEntityConfiguration = new SpaceProject($"{PathProject.Infrastructure}.Context.Persistance.EntityConfigurations");
    public static SpaceProject InfrastructureRepositories = new SpaceProject($"{PathProject.Infrastructure}.Context.Persistance.Repositories");
    public static SpaceProject ApplicationAppContext = new SpaceProject($"{PathProject.Application}.AppContext");
    public static SpaceProject ApplicationServicesInterfaces = new SpaceProject($"{PathProject.Application}.Services.Interfaces");
    public static SpaceProject ApplicationServices = new SpaceProject($"{PathProject.Application}.Services");
    public static SpaceProject ApplicationControllers = new SpaceProject($"{PathProject.Application}.Controllers");
    public static SpaceProject ApplicationLocalizationResources = new SpaceProject($"{PathProject.Application}.Localization.Resources");
    public static SpaceProject ApplicationLocalizationEnums = new SpaceProject($"{PathProject.Application}.Localization.Enums");

    public static SpaceProject TestApplicationAppContext = new SpaceProject($"{PathProject.Application}.AppContext",true);
    public static SpaceProject TestApplicationControllers = new SpaceProject($"{PathProject.Application}.Controllers",true);
    public static SpaceProject TestDomainAggregateModel = new SpaceProject($"{PathProject.Domain}.AggregateModel",true);
    public static SpaceProject TestInfrastructureEntityConfiguration = new SpaceProject($"{PathProject.Infrastructure}.Context.EntityConfigurations",true);
    public static SpaceProject TestInfrastructureRepositories = new SpaceProject($"{PathProject.Infrastructure}.Context.Repositories",true);


}