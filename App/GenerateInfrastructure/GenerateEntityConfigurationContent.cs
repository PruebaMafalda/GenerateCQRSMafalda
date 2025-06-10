using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateInfrastructure;

public class GenerateEntityConfigurationContent : GenerateBase
{
    public string GetGenerateEntityConfigurations(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        var fkFields = model.Fields.Where(x => x.IsForeignKey).ToList();
        foreach (var fkField in fkFields)
        {
            content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{fkField.ForeignKeyTable};{_singlelb}";
        }
        content += $"using Microsoft.EntityFrameworkCore;{_singlelb}";
        content += $"using Microsoft.EntityFrameworkCore.Metadata.Builders;{_doublelb}";

        content += $"namespace {PathApplication.InfrastructureEntityConfiguration.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>EF configuration for the {model.SingularName} entity.</summary>{_singlelb}";
        content += $"{_space}public class {model.SingularName}EntityConfiguration : IEntityTypeConfiguration<{model.SingularName}>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}/// <summary>Configures the entity of type TEntity.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"builder\">Builder used to configure the entity type.</param>{_singlelb}";
        content += $"{_space}{_space}public void Configure(EntityTypeBuilder<{model.SingularName}> builder){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}builder.ToTable(\"{model.PluralName}\");{_singlelb}";
        content += $"{_space}{_space}{_space}builder.HasKey(e => e.Id);{_singlelb}";

        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        if (pkField != null && !pkField.IsAutoIncrement)
        {
            content += $"{_space}{_space}{_space}builder.Property(a => a.{pkField.Name}).ValueGeneratedNever().IsRequired();{_singlelb}";
        }

        foreach (var field in model.Fields)
        {
            if (field.IsPrimaryKey)
            {
                continue;
            }
            var fieldContent = new List<string>();
            fieldContent.Add($"{_space}{_space}{_space}builder");
            
            if (field.IsForeignKey)
            {
                fieldContent.Add($"{_space}{_space}{_space}{_space}.HasOne(a => a.{field.ForeignKeyObject})");
                //fieldContent.Add($"{_space}{_space}{_space}{_space}.WithMany(b => b.{model.PluralName})");
                fieldContent.Add($"{_space}{_space}{_space}{_space}.WithMany(e => e.{model.PluralName})");
                fieldContent.Add($"{_space}{_space}{_space}{_space}.HasForeignKey(a => a.{field.Name})");
                fieldContent.Add($"{_space}{_space}{_space}{_space}.HasPrincipalKey(p => p.Id)");
            }
            else
            {
                fieldContent.Add($"{_space}{_space}{_space}{_space}.Property(a => a.{field.Name})");
            }
            if (field.Length > 0)
            {
                fieldContent.Add($"{_space}{_space}{_space}{_space}.HasMaxLength({field.Length})");
            }
            if (field.IsRequired)
            {
                fieldContent.Add($"{_space}{_space}{_space}{_space}.IsRequired()");
            }
            content += string.Join($"{_singlelb}", fieldContent) + $";{_doublelb}";
        }
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}