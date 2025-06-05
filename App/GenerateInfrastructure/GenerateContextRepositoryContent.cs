using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateInfrastructure;
public class GenerateContextRepositoryContent : GenerateBase
{
    public string GetGenerateContextRepository(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsPersistance.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_doublelb}";
        content += $"namespace {PathApplication.InfrastructureRepositories.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Repository of {model.PluralName}.</summary>{_singlelb}";
        content += $"{_space}public class {model.PluralName}Repository : BaseRepository<{model.SingularName}>, I{model.PluralName}Repository{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"context\">Db context.</param>{_singlelb}";
        content += $"{_space}{_space}public {model.PluralName}Repository({PathProject.ApplicationContext} context) : base(context) {{ }}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}