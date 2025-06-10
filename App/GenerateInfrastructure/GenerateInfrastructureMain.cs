using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateInfrastructure;
public class GenerateInfrastructureMain
{
    private GenerateEntityConfigurationContent _generateEntityConfigurationContent = new GenerateEntityConfigurationContent();
    private GenerateContextRepositoryContent _generateContextRepositoryContent = new GenerateContextRepositoryContent();
    public void Generate(GenerateParams model)
    {
        // generate context entity configurations
        GenerateContextEntityConfigurationsFiles(model);
        if (!model.GenerateOnlyModel)
        { 
            // generate repository
            GenerateContextRepositoryFiles(model);
        }
    }
    public void GenerateContextEntityConfigurationsFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams{
            Path = PathApplication.InfrastructureEntityConfiguration.FullPath,
            FileName = $"{model.SingularName}EntityConfiguration.cs",
            Content = _generateEntityConfigurationContent.GetGenerateEntityConfigurations(model)
        });
    }
    public void GenerateContextRepositoryFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams{
            Path = PathApplication.InfrastructureRepositories.FullPath,
            //Path = Path.Combine(PathProject.Root, PathProject.Infrastructure, "Context", "Repositories"),
            FileName = $"{model.PluralName}Repository.cs",
            Content = _generateContextRepositoryContent.GetGenerateContextRepository(model)
        });
    }
}