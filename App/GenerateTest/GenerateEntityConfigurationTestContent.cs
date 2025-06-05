using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateEntityConfigurationTestContent : GenerateBase
{
    public string GetGenerateEntityConfigurationTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var content = $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.InfrastructureEntityConfiguration.NameSpace};{_singlelb}";
        content += $"using Microsoft.EntityFrameworkCore;{_singlelb}";
        content += $"using Microsoft.EntityFrameworkCore.Metadata.Conventions;{_singlelb}";
        content += $"using Xunit;{_doublelb}";
        content += $"namespace {PathApplication.TestInfrastructureEntityConfiguration.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class {model.SingularName}EntityConfigurationTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}[Fact]{_singlelb}";
        content += $"{_space}{_space}public void {model.SingularName}EntityConfiguration_ShouldConfigureEntityCorrectly(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var modelBuilder = new ModelBuilder(new ConventionSet());{_singlelb}";
        content += $"{_space}{_space}{_space}var configuration = new {model.SingularName}EntityConfiguration();{_singlelb}";
        content += $"{_space}{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}configuration.Configure(modelBuilder.Entity<{model.SingularName}>());{_singlelb}";
        content += $"{_space}{_space}{_space}var entityType = modelBuilder.Model.FindEntityType(typeof({model.SingularName}));{_singlelb}";
        content += $"{_space}{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}Assert.NotNull(entityType);{_singlelb}";
        content += $"{_space}{_singlelb}";
        content += $"{_space}{_space}{_space}// Table Name{_singlelb}";
        content += $"{_space}{_space}{_space}Assert.Equal(\"{model.PluralName}\", entityType.GetTableName());{_singlelb}";
        content += $"{_space}{_singlelb}";

        if (pkField != null)
        {
            content += $"{_space}{_space}{_space}// Primary Key{_singlelb}";
            content += $"{_space}{_space}{_space}Assert.Equal(\"{pkField.Name}\", entityType.FindPrimaryKey().Properties[0].Name);{_singlelb}";
            content += $"{_space}{_singlelb}";    
        }
        
        content += $"{_space}{_space}{_space}// Properties{_singlelb}";
        foreach (var field in model.Fields.Where(x => !x.IsForeignKey && !x.IsPrimaryKey))
        {   
            content += $"{_space}{_space}{_space}var {field.Name}Property = entityType.FindProperty(nameof({model.SingularName}.{field.Name}));{_singlelb}";
            content += $"{_space}{_space}{_space}Assert.NotNull({field.Name}Property);{_singlelb}";
            // if (field.IsNullable || !field.IsRequired)
            // {
            //     content += $"{_space}{_space}{_space}Assert.True({field.Name}Property.IsNullable);{_singlelb}";
            // }
            // else
            // {
            //     content += $"{_space}{_space}{_space}Assert.True({field.Name}Property.IsNullable == false);{_singlelb}";
            // }

            if (field.Type == FieldType.String && field.Length > 0)
            {
                content += $"{_space}{_space}{_space}Assert.Equal({field.Length}, {field.Name}Property.GetMaxLength());{_singlelb}";
            }
            content += $"{_space}{_space}{_singlelb}";
        }
        var fkFields = model.Fields.Where(x => x.IsForeignKey).ToList();
        foreach(var fkField in fkFields)
        {
            content += $"{_space}{_space}{_space}// Relationships{_singlelb}";
            content += $"{_space}{_space}{_space}var {fkField.NameCamelCase}Navigation = entityType.FindNavigation(nameof({model.SingularName}.{fkField.ForeignKeyObject}));{_singlelb}";
            content += $"{_space}{_space}{_space}Assert.NotNull({fkField.NameCamelCase}Navigation);{_singlelb}";
            content += $"{_space}{_space}{_space}Assert.True({fkField.NameCamelCase}Navigation.IsCollection == false);{_singlelb}";
            content += $"{_space}{_space}{_space}Assert.True({fkField.NameCamelCase}Navigation.ForeignKey.IsRequired);{_singlelb}";
        }
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}