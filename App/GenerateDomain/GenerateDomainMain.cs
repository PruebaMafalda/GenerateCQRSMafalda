
using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateDomain;
public class GenerateDomainMain
{
    private GenerateAgregateModelEntityContent _generateAgregateModelEntityContent = new GenerateAgregateModelEntityContent();
    private GenerateContractRepositoryContent _generateContractRepositoryContent = new GenerateContractRepositoryContent();
    private GenerateSpecificationsContent _generateSpecificationsContent = new GenerateSpecificationsContent();
    public void Generate(GenerateParams model)
    {
        // generate agregate model
        GenerateAgregateModelFiles(model);
        // generate Contracts
        GenerateContractsRepositoryFiles(model);
        if(!model.GenerateOnlyModel)
        {
            // generate specifications
            GenerateSpecificationsFiles(model);
        }
    }
    public void GenerateAgregateModelFiles(GenerateParams model)
    {
        var agregateModelPath = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        ProjectFile.CreateFile(new CreateFileParams{
            Path = Path.Combine(PathApplication.DomainAggregateModel.FullPath, agregateModelPath),
            FileName = $"{model.SingularName}.cs",
            Content = _generateAgregateModelEntityContent.GetGenerateAgregateModelEntityContent(model)
        });
    }
    public void GenerateContractsRepositoryFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams{
            Path = PathApplication.DomainContractsRepositories.FullPath,
            FileName = $"I{model.PluralName}Repository.cs",
            Content = _generateContractRepositoryContent.GetGenerateContractRepositoryContent(model)
        });
    }

    public void GenerateSpecificationsFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams{
            Path = Path.Combine(PathApplication.DomainSpecifications.FullPath, model.PluralName),
            FileName = $"{model.PluralName}QuerySpecification.cs",
            Content = _generateSpecificationsContent.GetGenerateSpecificationsContent(model)
        });
    }
}