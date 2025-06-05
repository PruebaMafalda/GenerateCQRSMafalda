using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateDeleteCommandContent : GenerateBase
{
    public string GetGenerateDeleteCommand(GenerateParams model)
    {
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var pkFields = model.Fields.Where(x => x.IsPrimaryKey);
        var content = $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Delete{model.SingularName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Command to delete a {model.SingularName}.</summary>{_singlelb}";
        content += $"{_space}public class Delete{model.SingularName}Command : IRequest<Response<{pkField.TypeToString}>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in pkFields)
        {
            //content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString} {field.Name} {{ get; set; }}{_singlelb}";
            //content += $"{_singlelb}";
        }
        content += $"{_singlelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}public Delete{model.SingularName}Command() {{ }}{_doublelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        foreach (var field in pkFields)
        {
            content += $"{_space}{_space}/// <param name=\"{field.NameCamelCase}\">{field.Description}.</param>{_singlelb}";
        }
        content += $"{_space}{_space}public Delete{model.SingularName}Command({pkField.TypeToString} {pkField.NameCamelCase}){_singlelb}";

        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{pkField.Name} = {pkField.NameCamelCase};{_singlelb}";

        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateDeleteCommandHandler(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var content = $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Enums;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_doublelb}";
        content += $"using Unir.Framework.ApplicationSuperTypes.Exceptions;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Delete{model.SingularName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Handler for the Delete{model.SingularName} command.</summary>{_singlelb}";
        content += $"{_space}public class Delete{model.SingularName}CommandHandler : IRequestHandler<Delete{model.SingularName}Command, Response<{pkField.TypeToString}>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly I{model.PluralName}Repository _{model.PluralNameCamelCase}Repository;{_doublelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"{model.PluralNameCamelCase}Repository\">Repository of {model.PluralName}.</param>{_singlelb}";
        content += $"{_space}{_space}public Delete{model.SingularName}CommandHandler(I{model.PluralName}Repository {model.PluralNameCamelCase}Repository){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository = {model.PluralNameCamelCase}Repository;{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}/// <inheritdoc/>{_singlelb}";
        content += $"{_space}{_space}public async Task<Response<{pkField.TypeToString}>> Handle(Delete{model.SingularName}Command command, CancellationToken cancellationToken){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}var deleted = await _{model.PluralNameCamelCase}Repository.GetAsync(command.{pkField.Name}){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}?? throw new NoDbRecordException(nameof({model.SingularName}), nameof(command.{pkField.Name}), command.{pkField.Name}.ToString());{_doublelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Delete(deleted);{_doublelb}";
        content += $"{_space}{_space}{_space}try{_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}await _{model.PluralNameCamelCase}Repository.UnitOfWork.SaveChangesAsync(cancellationToken);{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}return new Response<{pkField.TypeToString}>(command.{pkField.Name});{_singlelb}";
        content += $"{_space}{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_space}catch (Exception ex){_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}throw new CrudOperationException(CrudAction.DELETE, ex.Message + ex.StackTrace, ex.InnerException);{_singlelb}";
        content += $"{_space}{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }
    public string GetGenerateDeleteCommandValidator(GenerateParams model)
    {
        var content = $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Enums;{_singlelb}";
        content += $"using FluentValidation;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Delete{model.SingularName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Validator for the Delete{model.SingularName} command.</summary>{_singlelb}";
        content += $"{_space}public class Delete{model.SingularName}CommandValidator : AbstractValidator<Delete{model.SingularName}Command>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        
        content += $"{_space}{_space}/// <summary>/// <summary>Constructor that performs validations for Delete{model.SingularName} command.</summary>{_singlelb}";
        content += $"{_space}{_space}public Delete{model.SingularName}CommandValidator(ILocalizationService localization){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        foreach (var field in model.Fields.Where(x => x.IsPrimaryKey))
        {
            if (field.IsPrimaryKey)
            {
                content += $"{_space}{_space}{_space}RuleFor(c => c.{field.Name}){_singlelb}";
                content += $"{_space}{_space}{_space}{_space}.GreaterThan(0){_singlelb}";
                content += $"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.BAD_REQUEST}}\"){_singlelb}";
                content += $"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired());{_doublelb}";
            }
        }
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}