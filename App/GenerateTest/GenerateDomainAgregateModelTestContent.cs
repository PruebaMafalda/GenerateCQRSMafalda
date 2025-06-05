using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateDomainAgregateModelTestContent : GenerateBase
{
    public string GetGenerateDomainAgregateModelTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Xunit;{_doublelb}";        
        content += $"namespace {PathApplication.TestDomainAggregateModel.NameSpace}.{agregateModelSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class {model.SingularName}Tests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}[Theory(DisplayName = \"It should properly initialize the {model.SingularName} object\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public void {model.SingularName}_ShouldInitializeWithGivenParameters({_singlelb}";
        foreach (var field in model.Fields)
        {
            content += $"{_space}{_space}{_space}{field.TypeToString} {field.NameCamelCase},{_singlelb}";
        }
        content = content.Substring(0, content.Length - 2);
        content += $"{_singlelb}";
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var {model.SingularNameCamelCase} = new {model.SingularName}({_singlelb}";
        foreach (var field in model.Fields.Where(e => !e.IsPrimaryKey))
        {
            content += $"{_space}{_space}{_space}{_space}{field.NameCamelCase},{_singlelb}";
        }
        content = content.Substring(0, content.Length - 2);
        content += $"{_singlelb}";
        content += $"{_space}{_space}{_space});{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        foreach (var field in model.Fields.Where(e => !e.IsPrimaryKey))
        {
            content += $"{_space}{_space}{_space}{model.SingularNameCamelCase}.{field.Name}.Should().Be({field.NameCamelCase});{_singlelb}";
        }
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}