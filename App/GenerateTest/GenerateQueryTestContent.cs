using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateQueryTestContent : GenerateBase
{
    public string GetGenerateGetCourseByIdQueryHandlerTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoFixture.Xunit2;{_singlelb}";
        content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.SingularName}ById;{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Exceptions;{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_singlelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Queries{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Get{model.SingularName}ByIdQueryHandlerTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}[Theory(DisplayName = \"It should return a projection of the data for the subject located by Id\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_Ok({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> repo,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.SingularName}ByIdQuery query,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.SingularName}ByIdQueryHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}repo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(new {model.SingularName}() {{ Id = query.Id }});{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.Handle(query, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<Response<{model.SingularName}Dto>>();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Data[0].Id.Should().Be(query.Id);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";

        content += $"{_space}{_space}[Theory(DisplayName = \"Should throw NoDbRecord exception if subject is not located by ID\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_NotFound({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}Repository,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.SingularName}ByIdQuery query,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.SingularName}ByIdQueryHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}Repository.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = () => sut.Handle(query, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}await result.Should().ThrowAsync<NoDbRecordException>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Where(ex => ex.Message.Contains($\"{{query.Id}}\"));{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }

    public string GetGenerateGetCourseByFilterQueryHandlerTest(GenerateParams model)
    {
        var agregateModelSpace = !string.IsNullOrEmpty(model.AgregateModel) ? model.AgregateModel : model.PluralName;
        var content = $"using AutoFixture.Xunit2;{_singlelb}";
        content += $"using AutoMapper;{_singlelb}";
        content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.PluralName}ByFilter;{_singlelb}";
        content += $"using {PathApplication.DomainAggregateModel.NameSpace}.{agregateModelSpace};{_singlelb}";
        content += $"using {PathApplication.DomainContractsRepositories.NameSpace};{_singlelb}";
        content += $"using {PathApplication.DomainSpecifications.NameSpace}.{model.PluralName};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using MockQueryable;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";

        content += $"namespace {PathApplication.TestApplicationAppContext.NameSpace}.{model.PluralName}.Queries{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class Get{model.PluralName}ByFilterHandlerTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}[Theory(DisplayName = \"Should return an empty list if no {model.PluralName} match the filter\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task HandleTest_EmptyResult({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}RepositoryMock,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMapper> _mapperMock,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.PluralName}ByFilterQuery query,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.PluralName}ByFilterQueryHandler sut){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var mockEmptyQueryResult = new List<{model.SingularName}>().AsQueryable().BuildMock(); // Converts the IQueryable to a mock compatible with EF async{_singlelb}";
        content += $"{_space}{_space}{_space}// Set up the repository to return the mock data and the total count{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}RepositoryMock{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Setup(repo => repo.GetAsync(It.IsAny<{model.PluralName}QuerySpecification>(), query)){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync((mockEmptyQueryResult, mockEmptyQueryResult.Count()));{_singlelb}";
        content += $"{_space}{_space}{_space}var mappedResults = new List<{model.SingularName}ListItemDto>().AsQueryable().BuildMock();{_singlelb}";
        content += $"{_space}{_space}{_space}_mapperMock{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Setup(map => map.ProjectTo<{model.SingularName}ListItemDto>(It.IsAny<IQueryable<{model.SingularName}>>(), null)){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Returns(mappedResults);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.Handle(query, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Data.Should().BeEmpty();{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";

        content += $"{_space}{_space}[Theory(DisplayName = \"It should return a paginated and filtered list of {model.PluralName}\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task Handle_ShouldReturnFiltered{model.PluralName}s({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<I{model.PluralName}Repository> _{model.PluralNameCamelCase}RepositoryMock,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMapper> _mapperMock,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.PluralName}ByFilterQuery query,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.PluralName}ByFilterQueryHandler sut,{_singlelb}";
        content += $"{_space}{_space}{_space}{model.SingularName} {model.SingularNameCamelCase}1,{_singlelb}";
        content += $"{_space}{_space}{_space}{model.SingularName} {model.SingularNameCamelCase}2{_singlelb}";
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var mockQueryResult = new List<{model.SingularName}> {{ {model.SingularNameCamelCase}1, {model.SingularNameCamelCase}2 }}.AsQueryable().BuildMock();{_singlelb}";
        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}RepositoryMock{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Setup(repo => repo.GetAsync(It.IsAny<{model.PluralName}QuerySpecification>(), query)){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync((mockQueryResult, mockQueryResult.Count()));{_singlelb}";
        content += $"{_space}{_space}{_space}var mappedResults = mockQueryResult.Select({model.SingularNameCamelCase} => new {model.SingularName}ListItemDto{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        foreach (var field in model.Fields)
        {
            content += $"{_space}{_space}{_space}{_space}{_space}{field.Name} = {model.SingularNameCamelCase}.{field.Name},{_singlelb}";
        }
        content += $"{_space}{_space}{_space}{_space}}}).AsQueryable().BuildMock();{_singlelb}";
        content += $"{_space}{_space}{_space}_mapperMock{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Setup(map => map.ProjectTo<{model.SingularName}ListItemDto>(It.IsAny<IQueryable<{model.SingularName}>>(), null)){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Returns(mappedResults);{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.Handle(query, CancellationToken.None);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<Response<{model.SingularName}ListItemDto>>();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Data.Should().HaveCount(mappedResults.Count());{_singlelb}";

        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        content += $"{_space}{_space}{_space}result.Data[0].{pkField.Name}.Should().Be(mappedResults.ElementAt(0).{pkField.Name});{_singlelb}";
        content += $"{_space}{_space}{_space}result.Data[1].{pkField.Name}.Should().Be(mappedResults.ElementAt(1).{pkField.Name});{_singlelb}";

        content += $"{_space}{_space}{_space}_{model.PluralNameCamelCase}RepositoryMock.Verify(repo => repo.GetAsync(It.IsAny<{model.PluralName}QuerySpecification>(), query), Times.Once);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
}