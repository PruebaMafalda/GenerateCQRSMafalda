using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateRepositoryTestContent : GenerateBase
{
    public string GetGenerateRepositoryTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using {PathApplication.ApplicationServicesInterfaces.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.InfrastructureRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.EntityFramework;{_singlelb}";
        content += $"using Microsoft.EntityFrameworkCore;{_singlelb}";
        content += $"using Microsoft.EntityFrameworkCore.ChangeTracking;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";
        content += $"namespace {PathApplication.TestInfrastructureRepositories.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class {model.PluralName}RepositoryTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}private DbContextOptions<{PathProject.TestProjectContext}> GetInMemoryOptions(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}return new DbContextOptionsBuilder<{PathProject.TestProjectContext}>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.UseInMemoryDatabase(Guid.NewGuid().ToString()){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Options;{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}private Mock<IAuditableService> SetupAuditableServiceMock(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}var auditableServiceMock = new Mock<IAuditableService>();{_singlelb}";
        content += $"{_space}{_space}{_space}auditableServiceMock{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Setup(a => a.TrackAuditableEntitiesChanges({_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{_space}It.IsAny<object>(),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{_space}It.IsAny<SavingChangesEventArgs>(),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{_space}It.IsAny<IEnumerable<EntityEntry>>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space})){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Callback<object, SavingChangesEventArgs, IEnumerable<EntityEntry>>((sender, args, entityEntries) =>{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{_space}{_space}Console.WriteLine(\"TrackAuditableEntitiesChanges was called\");{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_space}{_space});{_singlelb}";
        content += $"{_space}{_space}{_space}return auditableServiceMock;{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}private {model.SingularName} CreateTest{model.SingularName}(int id = 1){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}return new {model.SingularName}{_singlelb}";
        content += $"{_space}{_space}{_space}{{{_singlelb}";        
        content += $"{_space}{_space}{_space}{_space}Id = id,{_singlelb}";
        var fields = model.Fields.Where(x => !x.IsPrimaryKey).ToList();
        foreach (var field in fields)
        {
            if (field.Type == FieldType.String || field.Type == FieldType.Guid)
            {
                if (!string.IsNullOrEmpty(field.TestExample))
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = \"{field.TestExample}\",{_singlelb}";
                }
                else
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = \"Test {field.Name} of {model.SingularName}\",{_singlelb}";    
                }
            }
            else if (field.Type == FieldType.DateTime)
            {
                content += $"{_space}{_space}{_space}{_space}{field.Name} = DateTime.UtcNow,{_singlelb}";
            }
            else if (field.Type == FieldType.Bool)
            {
                if (!string.IsNullOrEmpty(field.TestExample))
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = {field.TestExample.ToLower()},{_singlelb}";

                }
                else
                { 
                    var random = new Random();
                    var randomBool = random.Next(2) == 1? "true" : "false";
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = {randomBool},{_singlelb}";    
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(field.TestExample))
                {
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = {field.TestExample},{_singlelb}";
                }
                else
                { 
                    var random = new Random();
                    var randomNum = random.Next(100) ;
                    content += $"{_space}{_space}{_space}{_space}{field.Name} = {randomNum},{_singlelb}";    
                }
            }
        }
        content = content.Substring(0, content.Length - 2);
        content += $"{_singlelb}";
        content += $"{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";
        content += $"{_space}{_space}[Fact]{_singlelb}";
        content += $"{_space}{_space}public async Task Add{model.SingularName}_ShouldAdd{model.SingularName}ToDatabase(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var options = GetInMemoryOptions();{_singlelb}";
        content += $"{_space}{_space}{_space}var auditableService = SetupAuditableServiceMock().Object;{_singlelb}";
        content += $"{_space}{_space}{_space}using var context = new {PathProject.TestProjectContext}(options, auditableService);{_singlelb}";
        content += $"{_space}{_space}{_space}var repository = new {model.PluralName}Repository(context);{_singlelb}";
        content += $"{_space}{_space}{_space}var {model.SingularNameCamelCase} = CreateTest{model.SingularName}();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}await repository.AddAsync({model.SingularNameCamelCase});{_singlelb}";
        content += $"{_space}{_space}{_space}await context.SaveChangesAsync();{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}var result = context.{model.PluralName}.FirstOrDefault(c => c.Id == {model.SingularNameCamelCase}.Id);{_singlelb}";
        content += $"{_space}{_space}{_space}Assert.NotNull(result);{_singlelb}";
        foreach (var field in fields)
        {
            content += $"{_space}{_space}{_space}Assert.Equal({model.SingularNameCamelCase}.{field.Name}, result.{field.Name});{_singlelb}";
        }
        content += $"{_space}{_space}}}{_doublelb}";
        content += $"{_space}{_space}[Fact]{_singlelb}";
        content += $"{_space}{_space}public async Task Get{model.SingularName}_ShouldReturnCorrect{model.SingularName}(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var options = GetInMemoryOptions();{_singlelb}";
        content += $"{_space}{_space}{_space}var auditableService = SetupAuditableServiceMock().Object;{_singlelb}";
        content += $"{_space}{_space}{_space}using var context = new {PathProject.TestProjectContext}(options, auditableService);{_singlelb}";
        content += $"{_space}{_space}{_space}var repository = new {model.PluralName}Repository(context);{_singlelb}";
        content += $"{_space}{_space}{_space}var {model.SingularNameCamelCase} = CreateTest{model.SingularName}();{_singlelb}";
        content += $"{_space}{_space}{_space}context.{model.PluralName}.Add({model.SingularNameCamelCase});{_singlelb}";
        content += $"{_space}{_space}{_space}await context.SaveChangesAsync();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await repository.GetAsync({model.SingularNameCamelCase}.Id);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}Assert.NotNull(result);{_singlelb}";
        foreach (var field in fields)
        {
            content += $"{_space}{_space}{_space}Assert.Equal({model.SingularNameCamelCase}.{field.Name}, result.{field.Name});{_singlelb}";
        }
        content += $"{_space}{_space}}}{_doublelb}";
        content += $"{_space}{_space}[Fact]{_singlelb}";
        content += $"{_space}{_space}public async Task Remove{model.SingularName}_ShouldRemove{model.SingularName}FromDatabase(){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var options = GetInMemoryOptions();{_singlelb}";
        content += $"{_space}{_space}{_space}var auditableService = SetupAuditableServiceMock().Object;{_singlelb}";
        content += $"{_space}{_space}{_space}using var context = new {PathProject.TestProjectContext}(options, auditableService);{_singlelb}";
        content += $"{_space}{_space}{_space}var repository = new {model.PluralName}Repository(context);{_singlelb}";
        content += $"{_space}{_space}{_space}var {model.SingularNameCamelCase} = CreateTest{model.SingularName}();{_singlelb}";
        content += $"{_space}{_space}{_space}context.{model.PluralName}.Add({model.SingularNameCamelCase});{_singlelb}";
        content += $"{_space}{_space}{_space}await context.SaveChangesAsync();{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}repository.Delete({model.SingularNameCamelCase});{_singlelb}";
        content += $"{_space}{_space}{_space}await context.SaveChangesAsync();{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}var result = context.{model.PluralName}.FirstOrDefault(c => c.Id == {model.SingularNameCamelCase}.Id);{_singlelb}";
        content += $"{_space}{_space}{_space}Assert.Null(result);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}