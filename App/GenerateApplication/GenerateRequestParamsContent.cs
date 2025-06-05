using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateRequestParamsContent : GenerateBase
{
    public string GetGenerateCreateRequestParams(GenerateParams model)
    {
        var content = $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Requests{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Request parameters for creating a {model.SingularName}.</summary>{_singlelb}";
        content += $"{_space}public class {model.SingularName}CreateRequestParams{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in model.Fields.Where(e => !e.IsAuditField))
        {
            if (field.IsPrimaryKey) continue;
            var charNullable = GetCharNullable(field);
            // content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString}{charNullable} {field.Name} {{ get; set; }}{_singlelb}";
            // content += $"{_singlelb}";
        }
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateUpdateRequestParams(GenerateParams model)
    {
        var content = $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Requests{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Request parameters for updating a {model.SingularName}.</summary>{_singlelb}";
        content += $"{_space}public class {model.SingularName}UpdateRequestParams{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in model.Fields.Where(e => !e.IsAuditField))
        {
            if (field.IsPrimaryKey) continue;
            var charNullable = GetCharNullable(field);
            // content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString}{charNullable} {field.Name} {{ get; set; }}{_singlelb}";
            // content += $"{_singlelb}";
        }
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    
}