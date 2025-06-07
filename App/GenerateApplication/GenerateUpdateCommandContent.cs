using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateUpdateCommandContent : GenerateBase
{
    public string GetGenerateUpdateCommand(GenerateParams model)
    {
        var fieldList = model.Fields.Where(x =>!x.IsAuditField).ToList();
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var content = $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Update{model.SingularName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Command to update a {model.SingularName}.</summary>{_singlelb}";
        content += $"{_space}public class Update{model.SingularName}Command : IRequest<Response<{pkField.TypeToString}>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        foreach (var field in fieldList)
        {
            var charNullable = GetCharNullable(field);
            // content += GetSummaryField(field.Description, 2);
            content += $"{_space}{_space}public {field.TypeToString}{charNullable} {field.Name} {{ get; set; }}{_singlelb}";
            // content += $"{_singlelb}";
        }
        content += $"{_singlelb}";
        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}public Update{model.SingularName}Command() {{ }}{_doublelb}";

        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        foreach (var field in fieldList)
        {
            content += $"{_space}{_space}/// <param name=\"{field.NameCamelCase}\">{field.Description}.</param>{_singlelb}";
        }
        content += $"{_space}{_space}public Update{model.SingularName}Command({_singlelb}";
        var lastField = model.Fields.Last();
        foreach (var field in fieldList)
        {
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
        foreach (var field in fieldList)
        {
            content += $"{_space}{_space}{_space}{field.Name} = {field.NameCamelCase};{_singlelb}";
        }
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateUpdateCommandHandler(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var uniqueFields = model.Fields.Where(x => x.IsUnique).ToList();
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        //var content = $"using {NameSpaceProject}.{PathProject.Application}.Localization.Implementation;{_singlelb}";
        var content = "";
        if(uniqueFields.Any())
        {
            content += $"using {NameSpaceProject}.{PathProject.Application}.Localization.Enums;{_singlelb}";
        }
        content += $"using {PathApplication.ApplicationServices.NameSpace};{_singlelb}";
        content += $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Enums;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using MediatR;{_singlelb}";
        content += $"using Unir.Framework.ApplicationSuperTypes.Exceptions;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Update{model.SingularName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Handler of command UpdateCourse</summary>{_singlelb}";
        content += $"{_space}public class Update{model.SingularName}CommandHandler : IRequestHandler<Update{model.SingularName}Command, Response<{pkField.TypeToString}>>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly I{model.PluralName}Repository _{model.PluralNameCamelCase}Repository;{_doublelb}";
        var localizationInjection = string.Empty;
        if(uniqueFields.Any())
        {
            content += $"{_space}{_space}private readonly ILocalizationService _localization;{_singlelb}";
            localizationInjection = ", ILocalizationService localization";
        }

        content += $"{_space}{_space}/// <summary>Constructor.</summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"{model.PluralNameCamelCase}Repository\">Repository of {model.PluralName}.</param>{_singlelb}";
        content += $"{_space}{_space}public Update{model.SingularName}CommandHandler(I{model.PluralName}Repository {model.PluralNameCamelCase}Repository{localizationInjection}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository = {model.PluralNameCamelCase}Repository;{_singlelb}";
        if(uniqueFields.Any())
        {
            content += $"{_space}{_space}{_space}_localization = localization;{_singlelb}";
        }
        content += $"{_space}{_space}}}{_doublelb}";
        content += $"{_space}{_space}/// <inheritdoc/>{_singlelb}";
        content += $"{_space}{_space}public async Task<Response<{pkField.TypeToString}>> Handle(Update{model.SingularName}Command command, CancellationToken cancellationToken){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}var updated = await _{model.PluralNameCamelCase}Repository.GetAsync(command.{pkField.Name}) ?? throw new NoDbRecordException(nameof({model.SingularName}), nameof(command.{pkField.Name}), command.{pkField.Name}.ToString());{_doublelb}";
        foreach (var uniqueField in uniqueFields)
        {
            content +=$"{_space}{_space}{_space}if (await _{model.PluralNameCamelCase}Repository.AnyAsync({model.SingularNameCamelCase} => {model.SingularNameCamelCase}.{pkField.Name} != command.{pkField.Name} && {model.SingularNameCamelCase}.{uniqueField.Name} == command.{uniqueField.Name})){_singlelb}";
            content +=$"{_space}{_space}{_space}{_space}throw new CustomValidationException<ValidationErrorsException>(_localization.GetString(\"Duplicated{uniqueField.Name}\", LocalizationDomain.{model.SingularName}));{_doublelb}";
        }
        foreach (var field in model.Fields)
        {
            if (field.IsPrimaryKey)
            {
                continue;
            }
            content += $"{_space}{_space}{_space}updated.{field.Name} = command.{field.Name};{_singlelb}";
        }
        content += $"{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Update(updated);{_doublelb}";
        content += $"{_space}{_space}{_space}try{_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}await _{model.PluralNameCamelCase}Repository.UnitOfWork.SaveChangesAsync();{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}return new Response<{pkField.TypeToString}>(command.{pkField.Name});{_singlelb}";
        content += $"{_space}{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_space}catch (Exception ex){_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}throw new CrudOperationException(CrudAction.UPDATE, ex.Message + ex.StackTrace, ex.InnerException);{_singlelb}";
        content += $"{_space}{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateUpdateCommandValidator(GenerateParams model)
    {
        var content = $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Enums;{_singlelb}";
        content += $"using FluentValidation;{_doublelb}";
        content += $"namespace {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Update{model.SingularName}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>Validator for the UpdateCourse command.</summary>{_singlelb}";
        content += $"{_space}public class Update{model.SingularName}CommandValidator : AbstractValidator<Update{model.SingularName}Command>{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}/// <summary>Constructor that performs validations for Update{model.PluralName} command.</summary>{_singlelb}";
        content += $"{_space}{_space}public Update{model.SingularName}CommandValidator(ILocalizationService localization){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        foreach (var field in model.Fields)
        {
            /*
            RuleFor(c => c.Id)
                .GreaterThan(0)
                    .WithErrorCode($"{(int)ApiErrorCode.BAD_REQUEST}")
                    .WithMessage(localization.GetMessageRequired());
            */
            if (field.IsPrimaryKey)
            {
                content += $"{_space}{_space}{_space}RuleFor(c => c.{field.Name}){_singlelb}";
                content += $"{_space}{_space}{_space}{_space}.GreaterThan(0){_singlelb}";
                content += $"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.BAD_REQUEST}}\"){_singlelb}";
                content += $"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired());{_doublelb}";
            }
            var listRules = new List<string>();
            if (field.IsRequired || (field.Length > 0 && field.Type == FieldType.String))
            {
                listRules.Add($"{_space}{_space}{_space}RuleFor(c => c.{field.Name})");
            }
            if (field.IsRequired && field.Type == FieldType.String)
            {
                listRules.Add($"{_space}{_space}{_space}{_space}.NotEmpty()");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.REQUIRED_FIELD}}\")");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired())");
                listRules.Add($"{_space}{_space}{_space}{_space}.NotNull()");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.REQUIRED_FIELD}}\")");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired())");
            }else if (field.IsRequired && field.Type == FieldType.Int)
            {
                // if(field.IsNullable)
                // {
                    listRules.Add($"{_space}{_space}{_space}{_space}.NotNull()");
                    listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.REQUIRED_FIELD}}\")");
                    listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired())");
                // }
                listRules.Add($"{_space}{_space}{_space}{_space}.GreaterThan(0)");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.REQUIRED_FIELD}}\")");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired())");
            }else if (field.IsRequired)
            {
                listRules.Add($"{_space}{_space}{_space}{_space}.NotNull()");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.REQUIRED_FIELD}}\")");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageRequired())");
            }

            if (field.Length > 0 && field.Type == FieldType.String)
            {
                listRules.Add($"{_space}{_space}{_space}{_space}.MaximumLength({field.Length})");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithErrorCode($\"{{(int)ApiErrorCode.STRING_MAX_LENGTH}}\")");
                listRules.Add($"{_space}{_space}{_space}{_space}{_space}.WithMessage(localization.GetMessageMaxLength({field.Length}))");
            }
            if (listRules.Count > 0)
            {
                content += string.Join($"{_singlelb}", listRules) + $";{_doublelb}";
            }
        }
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    

}