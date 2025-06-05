using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateApplicationMain
{
    private GenerateControllerContent _generateControllerContent = new GenerateControllerContent();
    private GenerateCreateCommandContent _generateCreateCommandContent = new GenerateCreateCommandContent();
    private GenerateDeleteCommandContent _generateDeleteCommandContent = new GenerateDeleteCommandContent();
    private GenerateGetByIdQueryContent _generateGetByIdQueryContent = new GenerateGetByIdQueryContent();
    private GenerateGetByFilterQueryContent _generateGetByFilterQueryContent = new GenerateGetByFilterQueryContent();
    private GenerateUpdateCommandContent _generateUpdateCommandContent = new GenerateUpdateCommandContent();
    private GenerateResourcesContent _generateResourcesContent = new GenerateResourcesContent();
    private GenerateRequestParamsContent _generateRequestParamsContent = new GenerateRequestParamsContent();

    public void Generate(GenerateParams model)
    {
        if(model.GenerateOnlyModel)
        {
            return;
        }
        // generate AppContext Commands [Create, Update, Delete]
        GenerateAppContextCommandsFiles(model);
        // generate AppContext Queries [GetById, GetByFilter]
        GenerateAppContextQueriesFiles(model);
        // generate Request Files
        GenerateRequestsFiles(model);
        // generate Controllers
        GenerateControllersFiles(model);
        if (model.Fields.Any(x => x.IsUnique))
        {
            // generate Resources Files
            GenerateResourcesFiles(model);
        }
    }
    public void GenerateAppContextCommandsFiles(GenerateParams model)
    {
        // Generate Create Command
        if (model.CrudTypes.Contains(CrudType.Create))
            GenerateAppContextCreateCommandsFiles(model);

        // Generate Update Command
        if (model.CrudTypes.Contains(CrudType.Update))
            GenerateAppContextUpdateCommandsFiles(model);

        // Generate Delete Command
        if (model.CrudTypes.Contains(CrudType.Delete))
            GenerateAppContextDeleteCommandsFiles(model);
    }
    public void GenerateAppContextQueriesFiles(GenerateParams model)
    {
        // Generate GetById
        if (model.CrudTypes.Contains(CrudType.GetById))
            GenerateAppContextGetByIdQueriesFiles(model);
        // Generate GetByFilter
        if (model.CrudTypes.Contains(CrudType.GetByFilter))
            GenerateAppContextGetByFilterQueriesFiles(model);
    }
    public void GenerateAppContextCreateCommandsFiles(GenerateParams model)
    {
        var operation = "Create";
        var pathCreateCommand = Path.Combine(PathApplication.ApplicationAppContext.FullPath, model.PluralName, "Commands", $"{operation}{model.SingularName}");
        // Generate Create Command 
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}Command.cs",
            Content = _generateCreateCommandContent.GetGenerateCreateCommand(model)
        });
        // Generate Create Command Handler
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}CommandHandler.cs",
            Content = _generateCreateCommandContent.GetGenerateCreateCommandHandler(model)
        });
        // Generate Create Command Validator
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}CommandValidator.cs",
            Content = _generateCreateCommandContent.GetGenerateCreateCommandValidator(model)
        });
    }
    public void GenerateAppContextUpdateCommandsFiles(GenerateParams model)
    {
        var operation = "Update";
        var pathCreateCommand = Path.Combine(PathApplication.ApplicationAppContext.FullPath, model.PluralName, "Commands", $"{operation}{model.SingularName}");        
        // Generate Create Command 
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}Command.cs",
            Content = _generateUpdateCommandContent.GetGenerateUpdateCommand(model)
        });
        // Generate Create Command Handler
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}CommandHandler.cs",
            Content = _generateUpdateCommandContent.GetGenerateUpdateCommandHandler(model)
        });
        // Generate Create Command Validator
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}CommandValidator.cs",
            Content = _generateUpdateCommandContent.GetGenerateUpdateCommandValidator(model)
        });
    }
    public void GenerateAppContextDeleteCommandsFiles(GenerateParams model)
    {
        var operation = "Delete";
        var pathCreateCommand = Path.Combine(PathApplication.ApplicationAppContext.FullPath, model.PluralName, "Commands", $"{operation}{model.SingularName}");        
        // Generate Create Command 
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}Command.cs",
            Content = _generateDeleteCommandContent.GetGenerateDeleteCommand(model)
        });
        // Generate Create Command Handler
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}CommandHandler.cs",
            Content = _generateDeleteCommandContent.GetGenerateDeleteCommandHandler(model)
        });
        // Generate Create Command Validator
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateCommand,
            FileName = $"{operation}{model.SingularName}CommandValidator.cs",
            Content = _generateDeleteCommandContent.GetGenerateDeleteCommandValidator(model)
        });
    }
    public void GenerateAppContextGetByIdQueriesFiles(GenerateParams model)
    {
        var pathCreateQuery = Path.Combine(PathApplication.ApplicationAppContext.FullPath, model.PluralName, "Queries", $"Get{model.SingularName}ById");
        // Generate GetById Query DTO
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateQuery,
            FileName = $"{model.SingularName}Dto.cs",
            Content = _generateGetByIdQueryContent.GetGenerateGetByIdDtoQuery(model)
        });
        // Generate GetById Query 
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateQuery,
            FileName = $"Get{model.SingularName}ByIdQuery.cs",
            Content = _generateGetByIdQueryContent.GetGenerateGetByIdQuery(model)
        });
        // Generate GetById Query Handler
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateQuery,
            FileName = $"Get{model.SingularName}ByIdQueryHandler.cs",
            Content = _generateGetByIdQueryContent.GetGenerateGetByIdQueryHandler(model)
        });
    }
    public void GenerateAppContextGetByFilterQueriesFiles(GenerateParams model)
    {
        var pathCreateQuery = Path.Combine(PathApplication.ApplicationAppContext.FullPath, model.PluralName, "Queries", $"Get{model.SingularName}ByFilterss");
        // Generate GetByFilter Query DTO
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateQuery,
            FileName = $"{model.SingularName}ListItemDto.cs",
            Content = _generateGetByFilterQueryContent.GetGenerateGetByFilterDtoQuery(model)
        });
        // Generate GetByFilter Query 
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateQuery,
            FileName = $"Get{model.SingularName}ByFilterQuery.cs",
            Content = _generateGetByFilterQueryContent.GetGenerateGetByFilterQuery(model)
        });
        // Generate GetByFilter Query Handler
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = pathCreateQuery,
            FileName = $"Get{model.SingularName}ByFilterQueryHandler.cs",
            Content = _generateGetByFilterQueryContent.GetGenerateGetByFilterQueryHandler(model)
        });
    }
    public void GenerateRequestsFiles(GenerateParams model)
    {
        var pathCreateCommand = Path.Combine(PathApplication.ApplicationAppContext.FullPath, model.PluralName, "Requests");
        // Generate Request Create
        if (model.CrudTypes.Contains(CrudType.Create))
        { 
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = pathCreateCommand,
                FileName = $"{model.SingularName}CreateRequestParams.cs",
                Content = _generateRequestParamsContent.GetGenerateCreateRequestParams(model)
            });
        }

        if(model.CrudTypes.Contains(CrudType.Update))
        {
            // Generate Request Update
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = pathCreateCommand,
                FileName = $"{model.SingularName}UpdateRequestParams.cs",
                Content = _generateRequestParamsContent.GetGenerateUpdateRequestParams(model)
            });
        }
    }
    public void GenerateControllersFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = PathApplication.ApplicationControllers.FullPath,
            FileName = $"{model.PluralName}Controller.cs",
            Content = _generateControllerContent.GetGenerateController(model)
        });
    }

    public void GenerateResourcesFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = PathApplication.ApplicationLocalizationResources.FullPath,
            FileName = $"{model.SingularName}Resources.en.resx",
            Content = _generateResourcesContent.GetGenerateResourcesEnglish(model)
        });
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = PathApplication.ApplicationLocalizationResources.FullPath,
            FileName = $"{model.SingularName}Resources.resx",
            Content = _generateResourcesContent.GetGenerateResourcesSpanish(model)
        });

    }
}