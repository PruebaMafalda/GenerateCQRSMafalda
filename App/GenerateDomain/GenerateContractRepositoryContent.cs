using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateDomain;
public class GenerateContractRepositoryContent : GenerateBase
{
    public string GetGenerateContractRepositoryContent(GenerateParams model)
    {
        //var content = $"using {NameSpaceProject}.{PathProject.Domain}.AggregateModel.{model.PluralName};{_doublelb}";
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_doublelb}";
        //content += $"namespace {NameSpaceProject}.{PathProject.Domain}.Contracts.Repositories{_singlelb}";
        content += $"namespace {PathApplication.DomainContractsRepositories.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Repository interfaz of {model.SingularName}.</summary>{_singlelb}";
        content += $"{_space}public interface I{model.PluralName}Repository : IRepository<{model.SingularName}>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}