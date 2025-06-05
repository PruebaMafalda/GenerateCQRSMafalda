using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateGetByIdQueryContent : GenerateBase
{
    public string GetGenerateGetByIdDtoQuery(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoMapper;{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using Unir.Framework.ApplicationSuperTypes.Mappings;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.SingularName}ById{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>DTO for {model.SingularName}, used to encapsulate course data for transfer.</summary>{_singlelb}";
        content += $"{_space}public class {model.SingularName}Dto : IMapFrom<{model.SingularName}>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in model.Fields)
        {
            var charNullable = GetCharNullable(field);
            // content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString}{charNullable} {field.Name} {{ get; set; }}{_singlelb}";
            // content += $"{_singlelb}";
        }
        if (model.auditable == Auditable.Full)
        {
            content += $"{_space}{_space}public int? CreatedBy {{ get; set; }}{_singlelb}";
            content += $"{_space}{_space}public DateTime? CreatedAt {{ get; set; }}{_singlelb}";
            content += $"{_space}{_space}public int? UpdatedBy {{ get; set; }}{_singlelb}";
            content += $"{_space}{_space}public DateTime? UpdatedAt {{ get; set; }}{_singlelb}";
        }
        if (model.auditable == Auditable.Create)
        {
            content += $"{_space}{_space}public int? CreatedBy {{ get; set; }}{_singlelb}";
            content += $"{_space}{_space}public DateTime? CreatedAt {{ get; set; }}{_singlelb}";
        }
        content += $"{_singlelb}";
        content += $"{_space}{_space}/// <summary>Configures the different mappings that need to be carried out for a given profile.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"profile\">Automapper profile.</param>{_singlelb}";
        content += $"{_space}{_space}public void Mapping(Profile profile){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}profile.CreateMap<{model.SingularName}, {model.SingularName}Dto>();{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateGetByIdQuery(GenerateParams model)
    {
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var content = $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.SingularName}ById{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Query to get a {model.SingularName} by id.</summary>{_singlelb}";
        content += $"{_space}public class Get{model.SingularName}ByIdQuery : IRequest<Response<{model.SingularName}Dto>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}/// <summary>{pkField.Description}.</summary>{_singlelb}";
        content += $"{_space}{_space}public {pkField.TypeToString} {pkField.Name} {{ get; set; }}{_doublelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"{pkField.NameCamelCase}\">Identifier.</param>{_singlelb}";
        content += $"{_space}{_space}public Get{model.SingularName}ByIdQuery({pkField.TypeToString} {pkField.NameCamelCase}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{pkField.Name} = {pkField.NameCamelCase};{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateGetByIdQueryHandler(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var content = $"using AutoMapper;{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.SingularName}ById{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Handler for the Get{model.SingularName}ById query.</summary>{_singlelb}";
        content += $"{_space}public class Get{model.SingularName}ByIdQueryHandler : IRequestHandler<Get{model.SingularName}ByIdQuery, Response<{model.SingularName}Dto>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly I{model.PluralName}Repository _{model.PluralNameCamelCase}Repository;{_singlelb}";
        content += $"{_space}{_space}private readonly IMapper _mapper;{_doublelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"{model.PluralNameCamelCase}Repository\">Repository of {model.PluralName}.</param>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"mapper\">Mapper.</param>{_singlelb}";
        content += $"{_space}{_space}public Get{model.SingularName}ByIdQueryHandler(I{model.PluralName}Repository {model.PluralNameCamelCase}Repository, IMapper mapper){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository = {model.PluralNameCamelCase}Repository;{_singlelb}";
        content += $"{_space}{_space}{_space}_mapper = mapper;{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";
        content += $"{_space}{_space}/// <inheritdoc/>{_singlelb}";
        content += $"{_space}{_space}public async Task<Response<{model.SingularName}Dto>> Handle(Get{model.SingularName}ByIdQuery request, CancellationToken cancellationToken){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}var {model.SingularNameCamelCase} = await _{model.PluralNameCamelCase}Repository.GetAsync(request.{pkField.Name}){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}?? throw new NoDbRecordException(nameof({model.SingularName}), nameof(request.{pkField.Name}), request.{pkField.Name}.ToString());{_singlelb}";
        content += $"{_space}{_space}{_space}return new Response<{model.SingularName}Dto>(_mapper.Map<{model.SingularName}, {model.SingularName}Dto>({model.SingularNameCamelCase}));{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }
    
}