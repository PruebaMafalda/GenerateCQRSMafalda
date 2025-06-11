using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateGetByFilterQueryContent : GenerateBase
{
    public string GetGenerateGetByFilterDtoQuery(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoMapper;{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using Unir.Framework.ApplicationSuperTypes.Mappings;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.PluralName}ByFilter{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>DTO for {model.SingularName}ListItem, used to encapsulate course data for transfer.</summary>{_singlelb}";
        content += $"{_space}public class {model.SingularName}ListItemDto : IMapFrom<{model.SingularName}>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in model.Fields)
        {
            var charNullable = GetCharNullable(field);
            //content += GetSummaryField(field.Description, 2);
            var asignStringEmpty = GetAsignStringEmpty(field);
            content += $"{_space}{_space}public {field.TypeToString}{charNullable} {field.Name} {{ get; set; }}{asignStringEmpty}{_singlelb}";
            //content += $"{_singlelb}";
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
        content += $"{_space}{_space}{_space}profile.CreateMap<{model.SingularName}, {model.SingularName}ListItemDto>();{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateGetByFilterQuery(GenerateParams model)
    {
        var fieldsSpecification = model.Fields.Where(e => e.IsEspecification).ToList();
        var content = $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Request;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_doublelb}";

        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.PluralName}ByFilter{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Query to get a filtered list of {model.PluralName}.</summary>{_singlelb}";
        content += $"{_space}public class Get{model.PluralName}ByFilterQuery : BaseRequest, IRequest<Response<{model.SingularName}ListItemDto>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in fieldsSpecification)
        {
            var charNullable = GetCharNullable(field);
            //content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString}? {field.Name} {{ get; set; }}{_singlelb}";
            //content += $"{_singlelb}";
        }
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }
    public string GetGenerateGetByFilterQueryHandler(GenerateParams model)
    {
        var content = $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using AutoMapper;{_singlelb}";
        content += $"using AutoMapper.QueryableExtensions;{_singlelb}";
        content += $"using MediatR;{_singlelb}";
        content += $"using Microsoft.EntityFrameworkCore;{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainSpecifications.NameSpace}.{model.PluralName};{_doublelb}";

        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.PluralName}ByFilter{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Handler for the query to get a filtered list of {model.PluralName}.</summary>{_singlelb}";
        content += $"{_space}public class Get{model.PluralName}ByFilterQueryHandler : IRequestHandler<Get{model.PluralName}ByFilterQuery, Response<{model.SingularName}ListItemDto>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly I{model.PluralName}Repository _{model.PluralNameCamelCase}Repository;{_singlelb}";
        content += $"{_space}{_space}private readonly IMapper _mapper;{_doublelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"{model.PluralNameCamelCase}Repository\">Repository of {model.PluralName}.</param>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"mapper\">Mapper.</param>{_singlelb}";
        content += $"{_space}{_space}public Get{model.PluralName}ByFilterQueryHandler(I{model.PluralName}Repository {model.PluralNameCamelCase}Repository, IMapper mapper){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository = {model.PluralNameCamelCase}Repository;{_singlelb}";
        content += $"{_space}{_space}{_space}_mapper = mapper;{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";
        content += $"{_space}{_space}/// <inheritdoc/>{_singlelb}";
        content += $"{_space}{_space}public async Task<Response<{model.SingularName}ListItemDto>> Handle(Get{model.PluralName}ByFilterQuery request, CancellationToken cancellationToken){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}var query = await _{model.PluralNameCamelCase}Repository.GetAsync(new {model.PluralName}QuerySpecification(request), request);{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await query.Item1.ProjectTo<{model.SingularName}ListItemDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);{_singlelb}";
        content += $"{_space}{_space}{_space}return new Response<{model.SingularName}ListItemDto>(result, request.Page, request.PageSize, query.Item2);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }

}