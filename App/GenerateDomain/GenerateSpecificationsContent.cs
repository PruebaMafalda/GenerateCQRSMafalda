using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateDomain;
public class GenerateSpecificationsContent : GenerateBase
{
    public string GetGenerateSpecificationsContent(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var fieldsSpecification = model.Fields.Where(e => e.IsEspecification).ToList();
        var content = $"using {NameSpaceProject}.{PathProject.Application}.AppContext.{model.PluralName}.Queries.Get{model.PluralName}ByFilter;{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using System.Linq.Expressions;{_doublelb}";

        content += $"namespace {PathApplication.DomainSpecifications.NameSpace}.{model.PluralName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Filter that filters the list of {model.PluralName.ToLower()} by a value that can be contained within a {model.SingularName.ToLower()}'s properties.</summary>{_singlelb}";
        content += $"{_space}public class {model.PluralName}QuerySpecification : Specification<{model.SingularName}>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly Get{model.PluralName}ByFilterQuery _filter;{_doublelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"filter\">Get{model.PluralName}ByFilterQuery.</param>{_singlelb}";
        content += $"{_space}{_space}public {model.PluralName}QuerySpecification(Get{model.PluralName}ByFilterQuery filter){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_filter = filter;{_singlelb}";
        content += $"{_space}{_space}{_space}_predicate = SetPredicate();{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}/// <inheritdoc/>{_singlelb}";
        content += $"{_space}{_space}protected override Expression<Func<{model.SingularName}, bool>> SetPredicate(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        foreach (var field in fieldsSpecification)
        {
            content += $"{_space}{_space}{_space}var {field.NameCamelCase}Specification = Get{field.Name}Specification();{_singlelb}";
        }
        content += $"{_space}{_space}{_space}{_singlelb}";
        content += $"{_space}{_space}{_space}return ({_singlelb}";
        foreach (var field in fieldsSpecification)
        {
            content += $"{_space}{_space}{_space}{_space}{field.NameCamelCase}Specification &{_singlelb}";
        }
        content = content.Remove(content.Length - 3);
        content += $"{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}).Criteria();{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        foreach (var field in fieldsSpecification)
        {
            content += $"{_space}{_space}private Specification<{model.SingularName}> Get{field.Name}Specification(){_singlelb}";
            content += GetGenerateSpecificationHasValue(field);
            content += GetGenerateSpecificationCondition(model, field);
            content += $"{_space}{_space}{_space}{_space}: new TrueSpecification<{model.SingularName}>();{_singlelb}";
            content += $"{_space}{_space}{_singlelb}";
        }
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateSpecificationHasValue(EntityField field)
    {
        var content = string.Empty;
        if (field.Type == FieldType.String)
        {
            content += $"{_space}{_space}{_space}=> !string.IsNullOrEmpty(_filter.{field.Name}){_singlelb}";
        }
        else if (field.Type == FieldType.Int || field.Type == FieldType.BigInt || field.Type == FieldType.Decimal || field.Type == FieldType.Double || field.Type == FieldType.Float)
        {
            content += $"{_space}{_space}{_space}=> _filter.{field.Name}.HasValue && _filter.{field.Name}.Value > 0{_singlelb}";
        }
        else if ( field.Type == FieldType.Bool || field.Type == FieldType.DateTime)
        {
            content += $"{_space}{_space}{_space}=> _filter.{field.Name}.HasValue{_singlelb}";
        }
        else
        {
            content += $"{_space}{_space}{_space}=> _filter.{field.Name} != null{_singlelb}";
        }
        return content;
    }
    public string GetGenerateSpecificationCondition(GenerateParams model, EntityField field)
    {
        var listTypesForEquals = new List<FieldType> { FieldType.String, FieldType.DateTime, FieldType.Int, FieldType.BigInt, FieldType.Decimal, FieldType.Double, FieldType.Float };
        var content = string.Empty;
        if (field.EspecificationType == EspecificationType.Contains)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name}.Contains(_filter.{field.Name})){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.StartsWith)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name}.StartsWith(_filter.{field.Name})){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.Equal)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name} == _filter.{field.Name}){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.NotEqual)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name} != _filter.{field.Name}){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.GreaterThan)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name} > _filter.{field.Name}){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.LessThan)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name} < _filter.{field.Name}){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.GreaterThanOrEqual)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name} >= _filter.{field.Name}){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.LessThanOrEqual)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => x.{field.Name} <= _filter.{field.Name}){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.In)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => _filter.{field.Name}.Contains(x.{field.Name})){_singlelb}";
        }
        else if (field.EspecificationType == EspecificationType.NotIn)
        {
            content += $"{_space}{_space}{_space}{_space}? new Specification<{model.SingularName}>(x => !_filter.{field.Name}.Contains(x.{field.Name})){_singlelb}";
        }
        return content;
    }
}