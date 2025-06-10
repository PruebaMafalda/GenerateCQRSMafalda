using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateDomain;
public class GenerateAgregateModelEntityContent : GenerateBase
{
    public string GetGenerateAgregateModelEntityContent(GenerateParams model)
    {
        var entityAuditable = model.auditable == Auditable.Full
            ? "EntityFullAuditable" :
             model.auditable == Auditable.Create
                ? "EntityCreateAuditable"
                : "Entity";

        var content = "";
        var fkFields = model.Fields.Where(e => e.IsForeignKey);
        foreach (var fkField in fkFields)
        {
            content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{fkField.ForeignKeyTable};{_singlelb}";    
        }
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.Shared;{_singlelb}";
        content += $"using Unir.Framework.DomainSuperTypes;{_doublelb}";
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        content += $"namespace {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Root aggregate {model.SingularName.ToLower()}.</summary>{_singlelb}";
        content += $"{_space}public class {model.SingularName} : {entityAuditable}<int>, IAggregateRoot{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in model.Fields)
        {
            if (field.IsPrimaryKey)
            {
                continue;
            }
            var charNullable = GetCharNullable(field);
            var asignStringEmpty = GetAsignStringEmpty(field);
            // content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString}{charNullable} {field.Name} {{ get; set; }}{asignStringEmpty}{_singlelb}";
            // content += $"{_singlelb}";
            if (field.IsForeignKey)
            {
                // content += GetSummaryField(field.ForeignKeyObject, 2);
                var fkEntity = !string.IsNullOrEmpty(field.ForeignKeyEntity) ? field.ForeignKeyEntity : field.ForeignKeyObject;
                content += $"{_space}{_space}public {fkEntity} {field.ForeignKeyObject} {{ get; set; }}{_singlelb}";
                // content += $"{_singlelb}";
            }
        }
        content += $"{_singlelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}public {model.SingularName}() {{ }}{_doublelb}";

        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        foreach (var field in model.Fields)
        {
            if (field.IsPrimaryKey)
            {
                continue;
            }
            content += $"{_space}{_space}/// <param name=\"{field.NameCamelCase}\">{field.Description}.</param>{_singlelb}";
        }
        content += $"{_space}{_space}public {model.SingularName}({_singlelb}";
        var lastField = model.Fields.Last();
        foreach (var field in model.Fields)
        {
            if (field.IsPrimaryKey)
            {
                continue;
            }
            var charNullable = GetCharNullable(field);
            content += $"{_space}{_space}{_space}{field.TypeToString}{charNullable} {field.NameCamelCase}";
            if (field != lastField)
            {
                content += $",{_singlelb}";
            }
            else
            {
                content += $"){_singlelb}";
            }
        }
        content += $"{_space}{_space}{{{_singlelb}";
        foreach (var field in model.Fields)
        {
            if (field.IsPrimaryKey)
            {
                continue;
            }
            content += $"{_space}{_space}{_space}{field.Name} = {field.NameCamelCase};{_singlelb}";
        }
        content += $"{_space}{_space}}}{_singlelb}";

        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }
}