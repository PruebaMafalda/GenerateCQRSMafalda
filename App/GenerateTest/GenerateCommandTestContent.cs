using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateCommandTestContent : GenerateBase
{
    public string GetGenerateCreateCommandHandlerTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoFixture.Xunit2;{_singlelb}";
        content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Create{model.SingularName};{_singlelb}";
        var hasUniqueField = model.Fields.Any(x => x.IsUnique);
        if (hasUniqueField)
        {
            content += $"using {PathApplication.ApplicationLocalizationEnums.NameSpace};{_singlelb}";
        }
        content += $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using System.Linq.Expressions;{_singlelb}";
        content += $"using Unir.Framework.ApplicationSuperTypes.Exceptions;{_singlelb}";
        content += $"using Xunit;{_doublelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Commands{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Create{model.SingularName}CommandHandlerTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";

        var uniqueField = model.Fields.FirstOrDefault(x => x.IsUnique);
        if (uniqueField != null)
        {
            content += $"{_space}{_space}[Theory(DisplayName = \"It Should throw a ValidationErrors Exception if a {model.SingularName} with the same {uniqueField.Name} is found\"), AutoMoq]{_singlelb}";
            content += $"{_space}{_space}public async Task HandleTest_ValidationErrors({_singlelb}";
            content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
            content += $"{_space}{_space}{_space}[Frozen] Mock<ILocalizationService> localization,{_singlelb}";
            content += $"{_space}{_space}{_space}Create{model.SingularName}Command command,{_singlelb}";
            content += $"{_space}{_space}{_space}Create{model.SingularName}CommandHandler sut){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
            content += $"{_space}{_space}{_space}string expectedMessage = \"There is already a {model.SingularName} with the same {uniqueField.Name}\";{_singlelb}";
            content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>())).ReturnsAsync(true);{_singlelb}";
            content += $"{_space}{_space}{_space}localization.Setup(localization => localization.GetString(It.IsAny<string>(), It.IsAny<LocalizationDomain>())){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}.Returns(expectedMessage);{_doublelb}";
            content += $"{_space}{_space}{_space}// Act{_singlelb}";
            content += $"{_space}{_space}{_space}var result = () => sut.Handle(command, CancellationToken.None);{_doublelb}";
            content += $"{_space}{_space}{_space}// Assert{_singlelb}";
            content += $"{_space}{_space}{_space}await result.Should().ThrowAsync<CustomValidationException<ValidationErrorsException>>(){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}.WithMessage(expectedMessage);{_singlelb}";
            content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(x => x.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>()), Times.Once());{_singlelb}";
            content += $"{_space}{_space}{_space}localization.Verify(localization => localization.GetString(It.IsAny<string>(), LocalizationDomain.{model.SingularName}), Times.Once);{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }

        content += $"{_space}{_space}[Theory(DisplayName = \"It should insert the {model.SingularName} with the provided data\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_Create({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
        content += $"{_space}{_space}{_space}Create{model.SingularName}Command command,{_singlelb}";
        content += $"{_space}{_space}{_space}Create{model.SingularName}CommandHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>())).ReturnsAsync(false);{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.AddAsync(It.IsAny<{model.SingularName}>())).ReturnsAsync(new {model.SingularName} {{ Id = 1 }});{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.Handle(command, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}//Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Data[0].Should().BeGreaterThan(0);{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(repo => repo.AddAsync(It.IsAny<{model.SingularName}>()), Times.Once());{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(default), Times.Once());{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }

    public string GetGenerateCreateCommandValidatorTest(GenerateParams model)
    {
        var content = $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Create{model.SingularName};{_singlelb}";
        //content += $"using {PathApplication.ApplicationServices.NameSpace};{_singlelb}";
        content += $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Commands{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Create{model.SingularName}CommandValidatorTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly Mock<ILocalizationService> _localizationMock;{_singlelb}";
        content += $"{_space}{_space}private Create{model.SingularName}CommandValidator _validator;{_doublelb}";
        var hasAnyRequiredField = model.Fields.Any(x => x.IsRequired);
        if (hasAnyRequiredField)
        {
            content += $"{_space}{_space}private const string MESSAGE_REQUIRED = \"The field is required\";{_singlelb}";
        }

        var maxLengthOfFields = model.Fields.Select(e => e.Length).Where(e => e > 0).Distinct().OrderBy(e => e).ToList();
        foreach (var length in maxLengthOfFields)
        {
            content += $"{_space}{_space}private const string MESSAGE_MAX_LENGTH_{length} = \"The field exceeds the allowed limit.({length})\";{_singlelb}";
        }

        content += $"{_space}{_space}public Create{model.SingularName}CommandValidatorTests(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_localizationMock = new Mock<ILocalizationService>();{_singlelb}";
        content += $"{_space}{_space}{_space}ConfigureLocalizationMock();{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}private void ConfigureLocalizationMock(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        if (hasAnyRequiredField)
        {
            content += $"{_space}{_space}{_space}_localizationMock.Setup(l => l.GetMessageRequired()).Returns(MESSAGE_REQUIRED);{_singlelb}";
        }
        foreach (var length in maxLengthOfFields)
        {
            content += $"{_space}{_space}{_space}_localizationMock.Setup(l => l.GetMessageMaxLength({length})).Returns(MESSAGE_MAX_LENGTH_{length});{_singlelb}";
        }
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}private Create{model.SingularName}CommandValidator GetValidator(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}return new Create{model.SingularName}CommandValidator(_localizationMock.Object);{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        var requiredFields = model.Fields.Where(x => x.IsRequired).ToList();
        if (hasAnyRequiredField)
        {
            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Type == FieldType.Bool)
                {
                    continue;
                }
                content += $"{_space}{_space}[Fact(DisplayName = \"Should fail validation if {requiredField.Name} is empty\")]";
                content += $"{_singlelb}{_space}{_space}public void Validate_{requiredField.Name}Empty_ShouldFail(){_singlelb}";
                content += $"{_space}{_space}{{{_singlelb}";
                content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
                var value = requiredField.Type == FieldType.String ? "string.Empty" : "0";
                content += $"{_space}{_space}{_space}var command = new Create{model.SingularName}Command {{ {requiredField.Name} = {value} }};{_singlelb}";
                content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";

                content += $"{_space}{_space}{_space}// Act{_singlelb}";
                content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";

                content += $"{_space}{_space}{_space}// Assert{_singlelb}";
                content += $"{_space}{_space}{_space}result.IsValid.Should().BeFalse();{_singlelb}";
                content += $"{_space}{_space}{_space}result.Errors.Should().ContainSingle(e => e.PropertyName == nameof(command.{requiredField.Name}))";
                content += $"{_singlelb}{_space}{_space}{_space}{_space}.Which.ErrorMessage.Should().Be(MESSAGE_REQUIRED);{_singlelb}";
                content += $"{_space}{_space}}}{_doublelb}";
            }
        }

        var maxLengthFields = model.Fields.Where(x => x.Length > 0 && x.Type == FieldType.String).OrderBy(e => e.Length).ToList();
        foreach (var maxLengthField in maxLengthFields)
        {
            content += $"{_space}{_space}[Fact(DisplayName = \"Should fail validation if {maxLengthField.Name} exceeds max length\")]";
            content += $"{_singlelb}{_space}{_space}public void Validate_{maxLengthField.Name}ExceedsMaxLength_ShouldFail(){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
            content += $"{_space}{_space}{_space}var command = new Create{model.SingularName}Command {{ {maxLengthField.Name} = new string('A', {maxLengthField.Length + 1}) }};{_singlelb}";
            content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
            content += $"{_space}{_space}{_space}// Act{_singlelb}";
            content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
            content += $"{_space}{_space}{_space}// Assert{_singlelb}";
            content += $"{_space}{_space}{_space}result.IsValid.Should().BeFalse();{_singlelb}";
            content += $"{_space}{_space}{_space}result.Errors.Should().ContainSingle(e => e.PropertyName == nameof(command.{maxLengthField.Name}))";
            content += $"{_singlelb}{_space}{_space}{_space}{_space}.Which.ErrorMessage.Should().Be(MESSAGE_MAX_LENGTH_{maxLengthField.Length});{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }
        
        content += $"{_space}{_space}[Fact(DisplayName = \"Should pass validation for valid command\")]{_singlelb}";
        content += $"{_space}{_space}public void Validate_ValidCommand_ShouldPass(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var command = new Create{model.SingularName}Command{_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";

        foreach (var field in model.Fields)
        {
            if(field.IsPrimaryKey) continue;
            
            if(field.TestExample != null)
            {
                if (IsStringType(field.Type))
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = \"{field.TestExample}\",{_singlelb}";
                }
                else
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = {field.TestExample},{_singlelb}";
                }
            }else if (field.Type == FieldType.String)
            {
                content += $"{_space}{_space}{_space}{_space}{field.Name} = \"Valid {field.Name}\",{_singlelb}";
            }
            else if (field.Type == FieldType.DateTime)
            {
                content += $"{_space}{_space}{_space}{_space}{field.Name} = DateTime.UtcNow,{_singlelb}";
            }
            else if (field.Type == FieldType.Bool)
            {
                var random = new Random();
                var randomBool = random.Next(2) == 1 ? "true" : "false";
                content += $"{_space}{_space}{_space}{_space}{field.Name} = {randomBool},{_singlelb}";
            }
            else
            {
                var random = new Random();
                var randomNum = random.Next(100);
                content += $"{_space}{_space}{_space}{_space}{field.Name} = {randomNum},{_singlelb}";
            }
        }
        content += $"{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.IsValid.Should().BeTrue();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Errors.Should().BeEmpty();{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;

    }

    public string GetGenerateUpdateCommandHandlerTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoFixture.Xunit2;{_singlelb}";
        content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Update{model.SingularName};{_singlelb}";
        //content += $"using {PathApplication.ApplicationServices.NameSpace};{_singlelb}";
        var hasUniqueField = model.Fields.Any(x => x.IsUnique);
        if (hasUniqueField)
        {
            content += $"using {PathApplication.ApplicationLocalizationEnums.NameSpace};{_singlelb}";
        }
        content += $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using System.Linq.Expressions;{_singlelb}";
        content += $"using Unir.Framework.ApplicationSuperTypes.Exceptions;{_singlelb}";
        content += $"using Xunit;{_doublelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Commands{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Update{model.SingularName}CommandHandlerTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";

        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        content += $"{_space}{_space}[Theory(DisplayName = \"Should throw NoDbRecord exception if {model.SingularName} is not located by ID\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_NotFound({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
        content += $"{_space}{_space}{_space}Update{model.SingularName}Command command,{_singlelb}";
        content += $"{_space}{_space}{_space}Update{model.SingularName}CommandHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange  {_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.GetAsync(It.IsAny<{pkField.TypeToString}>())).ReturnsAsync(() => null);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = () => sut.Handle(command, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}await result.Should().ThrowAsync<NoDbRecordException>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Where(ex => ex.Message.Contains($\"{{command.{pkField.Name}}}\"));{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        var uniqueField = model.Fields.FirstOrDefault(x => x.IsUnique);
        if (uniqueField != null)
        {
            content += $"{_space}{_space}[Theory(DisplayName = \"It Should throw a ValidationErrors Exception if a {model.SingularName} with the same {uniqueField.Name} is found\"), AutoMoq]{_singlelb}";
            content += $"{_space}{_space}public async Task HandleTest_ValidationErrors({_singlelb}";
            content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
            content += $"{_space}{_space}{_space}[Frozen] Mock<ILocalizationService> localization,{_singlelb}";
            content += $"{_space}{_space}{_space}Update{model.SingularName}Command command,{_singlelb}";
            content += $"{_space}{_space}{_space}Update{model.SingularName}CommandHandler sut){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
            content += $"{_space}{_space}{_space}string expectedMessage = \"There is already a {model.SingularName} with the same {uniqueField.Name}\";{_singlelb}";
            content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>())).ReturnsAsync(true);{_singlelb}";
            content += $"{_space}{_space}{_space}localization.Setup(localization => localization.GetString(It.IsAny<string>(), It.IsAny<LocalizationDomain>())){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}.Returns(expectedMessage);{_singlelb}";
            content += $"{_space}{_space}{_space}// Act{_singlelb}";
            content += $"{_space}{_space}{_space}var result = () => sut.Handle(command, CancellationToken.None);{_singlelb}";
            content += $"{_space}{_space}{_space}// Assert{_singlelb}";
            content += $"{_space}{_space}{_space}await result.Should().ThrowAsync<CustomValidationException<ValidationErrorsException>>(){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}.WithMessage(expectedMessage);{_singlelb}";
            content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(x => x.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>()), Times.Once());{_singlelb}";
            content += $"{_space}{_space}{_space}localization.Verify(localization => localization.GetString(It.IsAny<string>(), LocalizationDomain.{model.SingularName}), Times.Once);{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }
        content += $"{_space}{_space}[Theory(DisplayName = \"It should insert the {model.SingularName} with the provided data\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_Update({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
        content += $"{_space}{_space}{_space}Update{model.SingularName}Command command,{_singlelb}";
        content += $"{_space}{_space}{_space}Update{model.SingularName}CommandHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.GetAsync(It.IsAny<{pkField.TypeToString}>())).ReturnsAsync(() => new {model.SingularName} {{ Id = 1 }});{_singlelb}";
        if (hasUniqueField)
        { 
            content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>())).ReturnsAsync(false);{_singlelb}";
        }
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.Handle(command, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}//Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Data[0].Should().Be(command.Id);{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(x => x.GetAsync(It.IsAny<{pkField.TypeToString}>()), Times.Once());{_singlelb}";
        if (hasUniqueField)
        {
            content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(x => x.AnyAsync(It.IsAny<Expression<Func<{model.SingularName}, bool>>>()), Times.Once());{_singlelb}";
        }
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(x => x.Update(It.IsAny<{model.SingularName}>()), Times.Once());{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(default), Times.Once());{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }

    public string GetGenerateUpdateCommandValidatorTest(GenerateParams model)
    {
        var content = $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Update{model.SingularName};{_singlelb}";
        //content += $"using {PathApplication.ApplicationServices.NameSpace};{_singlelb}";
        content += $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Commands{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Update{model.SingularName}CommandValidatorTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly Mock<ILocalizationService> _localizationMock;{_singlelb}";
        content += $"{_space}{_space}private Update{model.SingularName}CommandValidator _validator;{_doublelb}";

        var hasAnyRequiredField = model.Fields.Any(x => x.IsRequired);
        if (hasAnyRequiredField)
        {
            content += $"{_space}{_space}private const string MESSAGE_REQUIRED = \"The field is required\";{_singlelb}";
        }

        var maxLengthOfFields = model.Fields.Select(e => e.Length).Where(e => e > 0).Distinct().OrderBy(e => e).ToList();
        foreach (var length in maxLengthOfFields)
        {
            content += $"{_space}{_space}private const string MESSAGE_MAX_LENGTH_{length} = \"The field exceeds the allowed limit.({length})\";{_singlelb}";
        }

        content += $"{_space}{_space}public Update{model.SingularName}CommandValidatorTests(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_localizationMock = new Mock<ILocalizationService>();{_singlelb}";
        content += $"{_space}{_space}{_space}ConfigureLocalizationMock();{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}private void ConfigureLocalizationMock(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        if (hasAnyRequiredField)
        {
            content += $"{_space}{_space}{_space}_localizationMock.Setup(l => l.GetMessageRequired()).Returns(MESSAGE_REQUIRED);{_singlelb}";
        }
        foreach (var length in maxLengthOfFields)
        {
            content += $"{_space}{_space}{_space}_localizationMock.Setup(l => l.GetMessageMaxLength({length})).Returns(MESSAGE_MAX_LENGTH_{length});{_singlelb}";
        }
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}private Update{model.SingularName}CommandValidator GetValidator(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}return new Update{model.SingularName}CommandValidator(_localizationMock.Object);{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        content += $"{_space}{_space}[Fact(DisplayName = \"Should fail validation if {pkField.Name} is invalid\")]";
        content += $"{_singlelb}{_space}{_space}public void Validate_{pkField.Name}Invalid_ShouldFail(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var command = new Update{model.SingularName}Command {{ {pkField.Name} = 0 }};{_singlelb}";
        content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.IsValid.Should().BeFalse();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Errors.Should().ContainSingle(e => e.PropertyName == nameof(command.{pkField.Name}))";
        content += $"{_singlelb}{_space}{_space}{_space}{_space}.Which.ErrorMessage.Should().Be(MESSAGE_REQUIRED);{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";
        
        var requiredFields = model.Fields.Where(x => x.IsRequired).ToList();
        if (hasAnyRequiredField)
        {
            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Type == FieldType.Bool)
                {
                    continue;
                }
                content += $"{_space}{_space}[Fact(DisplayName = \"Should fail validation if {requiredField.Name} is empty\")]";
                content += $"{_singlelb}{_space}{_space}public void Validate_{requiredField.Name}Empty_ShouldFail(){_singlelb}";
                content += $"{_space}{_space}{{{_singlelb}";
                content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
                var value = requiredField.Type == FieldType.String ? "string.Empty" : "0";
                content += $"{_space}{_space}{_space}var command = new Update{model.SingularName}Command {{ {requiredField.Name} = {value} }};{_singlelb}";
                content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";

                content += $"{_space}{_space}{_space}// Act{_singlelb}";
                content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";

                content += $"{_space}{_space}{_space}// Assert{_singlelb}";
                content += $"{_space}{_space}{_space}result.IsValid.Should().BeFalse();{_singlelb}";
                content += $"{_space}{_space}{_space}result.Errors.Should().ContainSingle(e => e.PropertyName == nameof(command.{requiredField.Name}))";
                content += $"{_singlelb}{_space}{_space}{_space}{_space}.Which.ErrorMessage.Should().Be(MESSAGE_REQUIRED);{_singlelb}";
                content += $"{_space}{_space}}}{_doublelb}";
            }
        }
        var maxLengthFields = model.Fields.Where(x => x.Length > 0 && x.Type == FieldType.String).OrderBy(e => e.Length).ToList();
        foreach (var maxLengthField in maxLengthFields)
        {
            content += $"{_space}{_space}[Fact(DisplayName = \"Should fail validation if {maxLengthField.Name} exceeds max length\")]";
            content += $"{_singlelb}{_space}{_space}public void Validate_{maxLengthField.Name}ExceedsMaxLength_ShouldFail(){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
            content += $"{_space}{_space}{_space}var command = new Update{model.SingularName}Command {{ {maxLengthField.Name} = new string('A', {maxLengthField.Length + 1}) }};{_singlelb}";
            content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
            content += $"{_space}{_space}{_space}// Act{_singlelb}";
            content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
            content += $"{_space}{_space}{_space}// Assert{_singlelb}";
            content += $"{_space}{_space}{_space}result.IsValid.Should().BeFalse();{_singlelb}";
            content += $"{_space}{_space}{_space}result.Errors.Should().ContainSingle(e => e.PropertyName == nameof(command.{maxLengthField.Name}))";
            content += $"{_singlelb}{_space}{_space}{_space}{_space}.Which.ErrorMessage.Should().Be(MESSAGE_MAX_LENGTH_{maxLengthField.Length});{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }
        
        content += $"{_space}{_space}[Fact(DisplayName = \"Should pass validation for valid command\")]{_singlelb}";
        content += $"{_space}{_space}public void Validate_ValidCommand_ShouldPass(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var command = new Update{model.SingularName}Command{_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";

        foreach (var field in model.Fields)
        {

            if(field.TestExample != null)
            {
                if (IsStringType(field.Type))
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = \"{field.TestExample}\",{_singlelb}";
                }
                else
                { 
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = {field.TestExample},{_singlelb}";
                }
            }
            else if (field.Type == FieldType.DateTime)
            {
                content += $"{_space}{_space}{_space}{_space}{field.Name} = DateTime.UtcNow,{_singlelb}";
            }
            else if (field.Type == FieldType.Bool)
            {
                var random = new Random();
                var randomBool = random.Next(2) == 1? "true" : "false";
                content += $"{_space}{_space}{_space}{_space}{field.Name} = {randomBool},{_singlelb}";
            }
            else
            {
                var random = new Random();
                var randomNum = random.Next(100) ;
                content += $"{_space}{_space}{_space}{_space}{field.Name} = {randomNum},{_singlelb}";
            }
        }
        content += $"{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.IsValid.Should().BeTrue();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Errors.Should().BeEmpty();{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }

    private bool IsStringType(FieldType type)
    {
        return type == FieldType.String || type == FieldType.Guid;
    }

    public string GetGenerateDeleteCommandHandlerTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoFixture.Xunit2;{_singlelb}";
        content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Delete{model.SingularName};{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";
        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Commands{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Delete{model.SingularName}CommandHandlerTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";

        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        content += $"{_space}{_space}[Theory(DisplayName = \"Should throw NoDbRecord exception if {model.SingularName} is not located by ID\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_NotFound({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
        content += $"{_space}{_space}{_space}Delete{model.SingularName}Command command,{_singlelb}";
        content += $"{_space}{_space}{_space}Delete{model.SingularName}CommandHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange  {_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.GetAsync(It.IsAny<{pkField.TypeToString}>())).ReturnsAsync(() => null);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = () => sut.Handle(command, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}await result.Should().ThrowAsync<NoDbRecordException>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Where(ex => ex.Message.Contains($\"{{command.{pkField.Name}}}\"));{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}[Theory(DisplayName = \"You should delete the {model.SingularName} located by ID\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_Ok({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
        content += $"{_space}{_space}{_space}Delete{model.SingularName}Command command,{_singlelb}";
        content += $"{_space}{_space}{_space}Delete{model.SingularName}CommandHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}await sut.Handle(command, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(repo => repo.Delete(It.IsAny<{model.SingularName}>()), Times.Once());{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(default), Times.Once());{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }

    public string GetGenerateDeleteCommandValidatorTest(GenerateParams model)
    {
        var content = $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Delete{model.SingularName};{_singlelb}";
        content += $"using {PathApplication.ApplicationServices.NameSpace};{_singlelb}";
        content += $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Commands{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Delete{model.SingularName}CommandValidatorTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private readonly Mock<ILocalizationService> _localizationMock;{_singlelb}";
        content += $"{_space}{_space}private Delete{model.SingularName}CommandValidator _validator;{_doublelb}";
        content += $"{_space}{_space}private const string MESSAGE_REQUIRED = \"The field is required\";{_singlelb}";
        content +=$"public Delete{model.SingularName}CommandValidatorTests(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_localizationMock = new Mock<ILocalizationService>();{_singlelb}";
        content += $"{_space}{_space}{_space}ConfigureLocalizationMock();{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}private void ConfigureLocalizationMock(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}_localizationMock.Setup(l => l.GetMessageRequired()).Returns(MESSAGE_REQUIRED);{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}private Delete{model.SingularName}CommandValidator GetValidator(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}return new Delete{model.SingularName}CommandValidator(_localizationMock.Object);{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        content += $"{_space}{_space}[Fact(DisplayName = \"Should fail validation if {pkField.Name} is invalid\")]";
        content += $"{_singlelb}{_space}{_space}public void Validate_{pkField.Name}Invalid_ShouldFail(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var command = new Delete{model.SingularName}Command {{ {pkField.Name} = 0 }};{_singlelb}";
        content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.IsValid.Should().BeFalse();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Errors.Should().ContainSingle(e => e.PropertyName == nameof(command.{pkField.Name}))";
        content += $"{_singlelb}{_space}{_space}{_space}{_space}.Which.ErrorMessage.Should().Be(MESSAGE_REQUIRED);{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        content += $"{_space}{_space}[Fact(DisplayName = \"Should pass validation for valid command\")]{_singlelb}";
        content += $"{_space}{_space}public void Validate_ValidCommand_ShouldPass(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var command = new Delete{model.SingularName}Command{_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{pkField.Name} = 1{_singlelb}";
        content += $"{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}_validator = GetValidator();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = _validator.Validate(command);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.IsValid.Should().BeTrue();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Errors.Should().BeEmpty();{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";

        return content;
    }

}