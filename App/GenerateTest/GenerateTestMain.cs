using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateTestMain
{
    private GenerateCommandTestContent _generateCommandTestContent = new GenerateCommandTestContent();
    private GenerateQueryTestContent _generateQueryTestContent = new GenerateQueryTestContent();
    private GenerateControllerTestContent _generateControllerTestContent = new GenerateControllerTestContent();
    private GenerateDomainAgregateModelTestContent _generateDomainAgregateModelTestContent = new GenerateDomainAgregateModelTestContent();
    private GenerateEntityConfigurationTestContent _generateEntityConfigurationTestContent = new GenerateEntityConfigurationTestContent();
    private GenerateRepositoryTestContent _generateRepositoryTestContent = new GenerateRepositoryTestContent();

    public void Generate(GenerateParams model)
    {
        if(!model.GenerateOnlyModel)
        {
            // generate commands test
            GenerateCommandsTestFiles(model);
            // generate queries test
            GenerateQueriesTestFiles(model);
            // generate controller test
            GenerateControllerTestFiles(model);
        }
        // generate domain agregate model test
        GenerateDomainAgregateModelTestFiles(model);
        // generate entity configuration test
        GenerateEntityConfigurationTestFiles(model);
        // generate repository test
        GenerateRepositoryTestFiles(model);
    }
    public void GenerateCommandsTestFiles(GenerateParams model)
    {
        if (model.CrudTypes.Contains(CrudType.Create))
        {
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Commands"),
                FileName = $"Create{model.SingularName}CommandHandler.Tests.cs",
                Content = _generateCommandTestContent.GetGenerateCreateCommandHandlerTest(model)
            });
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Commands"),
                FileName = $"Create{model.SingularName}CommandValidator.Tests.cs",
                Content = _generateCommandTestContent.GetGenerateCreateCommandValidatorTest(model)
            });
        }

        if (model.CrudTypes.Contains(CrudType.Update))
        {
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Commands"),
                FileName = $"Update{model.SingularName}CommandHandler.Tests.cs",
                Content = _generateCommandTestContent.GetGenerateUpdateCommandHandlerTest(model)
            });
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Commands"),
                FileName = $"Update{model.SingularName}CommandValidator.Tests.cs",
                Content = _generateCommandTestContent.GetGenerateUpdateCommandValidatorTest(model)
            });
        }

        if (model.CrudTypes.Contains(CrudType.Delete))
        {
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Commands"),
                FileName = $"Delete{model.SingularName}CommandHandler.Tests.cs",
                Content = _generateCommandTestContent.GetGenerateDeleteCommandHandlerTest(model)
            });
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Commands"),
                FileName = $"Delete{model.SingularName}CommandValidator.Tests.cs",
                Content = _generateCommandTestContent.GetGenerateDeleteCommandValidatorTest(model)
            });
        }
    }
    public void GenerateQueriesTestFiles(GenerateParams model)
    {
        if (model.CrudTypes.Contains(CrudType.GetById))
        {
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Queries"),
                FileName = $"Get{model.SingularName}ByIdQueryHandler.Tests.cs",
                Content = _generateQueryTestContent.GetGenerateGetCourseByIdQueryHandlerTest(model)
            });
        }

        if (model.CrudTypes.Contains(CrudType.GetByFilter))
        {
            ProjectFile.CreateFile(new CreateFileParams
            {
                Path = Path.Combine(PathApplication.TestApplicationAppContext.FullPath, model.PluralName, "Queries"),
                FileName = $"Get{model.PluralName}ByFilterHandler.Tests.cs",
                Content = _generateQueryTestContent.GetGenerateGetCourseByFilterQueryHandlerTest(model)
            });
        }
    }

    public void GenerateControllerTestFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = PathApplication.TestApplicationControllers.FullPath,
            FileName = $"{model.PluralName}Controller.Tests.cs",
            Content = _generateControllerTestContent.GetGenerateControllerTest(model)
        });
    }
    
    public void GenerateDomainAgregateModelTestFiles(GenerateParams model)
    {
        var agregateModelPath = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = Path.Combine(PathApplication.TestDomainAggregateModel.FullPath, agregateModelPath),
            FileName = $"{model.SingularName}.Tests.cs",
            Content = _generateDomainAgregateModelTestContent.GetGenerateDomainAgregateModelTest(model)
        });
    }
    public void GenerateEntityConfigurationTestFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = PathApplication.TestInfrastructureEntityConfiguration.FullPath,
            FileName = $"{model.SingularName}EntityConfiguration.Tests.cs",
            Content = _generateEntityConfigurationTestContent.GetGenerateEntityConfigurationTest(model)
        });

    }
    public void GenerateRepositoryTestFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams
        {
            Path = PathApplication.TestInfrastructureRepositories.FullPath ,
            FileName = $"{model.PluralName}Repository.Tests.cs",
            Content = _generateRepositoryTestContent.GetGenerateRepositoryTest(model)
        });
    }

}