using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateTest;
public class GenerateControllerTestContent : GenerateBase
{
    public string GetGenerateControllerTest(GenerateParams model)
    {
        var content = $"using AutoFixture.Xunit2;{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.Create))
            content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Create{model.SingularName};{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.Delete))
            content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Delete{model.SingularName};{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.Update))
            content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Commands.Update{model.SingularName};{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.GetById))
            content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.SingularName}ById;{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.GetByFilter))
            content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Queries.Get{model.PluralName}ByFilter;{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.Create) || model.CrudTypes.Contains(CrudType.Update))
            content += $"using {PathApplication.ApplicationAppContext.NameSpace}.{model.PluralName}.Requests;{_singlelb}";

        content += $"using {PathApplication.ApplicationControllers.NameSpace};{_singlelb}";
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using {NameSpaceProject}.Tests.Configuration.AutoMoq;{_singlelb}";
        content += $"using FluentAssertions;{_singlelb}";
        content += $"using MediatR;{_singlelb}";
        content += $"using Microsoft.AspNetCore.Mvc;{_singlelb}";
        content += $"using Microsoft.Extensions.Logging;{_singlelb}";
        content += $"using Moq;{_singlelb}";
        content += $"using Xunit;{_doublelb}";
        content += $"namespace {PathApplication.TestApplicationControllers.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}public class {model.PluralName}ControllerTests{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        if (model.CrudTypes.Contains(CrudType.GetById))
            content += GetGenerateControllerGetByIdTest(model);

        if (model.CrudTypes.Contains(CrudType.GetByFilter))
            content += GetGenerateControllerGetByFilterTest(model);

        if (model.CrudTypes.Contains(CrudType.Create))
            content += GetGenerateControllerCreateTest(model);

        if (model.CrudTypes.Contains(CrudType.Update))
            content += GetGenerateControllerUpdateTest(model);

        if (model.CrudTypes.Contains(CrudType.Delete))
            content += GetGenerateControllerDeleteTest(model);

        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }

    private string GetGenerateControllerGetByIdTest(GenerateParams model)
    {
        var content = $"{_space}{_space}[Theory(DisplayName = \"It should directly return the result obtained from the service.\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task GetByIdAsyncTest_Ok{_singlelb}";
        content += $"{_space}{_space}({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMediator> mockMediator,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<ILogger<{model.PluralName}Controller>> mockLogger,{_singlelb}";
        content += $"{_space}{_space}{_space}int id{_singlelb}";
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Setup(a => a.Send(It.IsAny<Get{model.SingularName}ByIdQuery>(), It.IsAny<CancellationToken>())){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync(new Response<{model.SingularName}Dto>(new {model.SingularName}Dto {{ Id = id }}));{_singlelb}";
        content += $"{_space}{_space}{_space}var sut = new {model.PluralName}Controller(mockLogger.Object){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}Mediator = mockMediator.Object{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.GetByIdAsync(id);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<OkObjectResult>();{_singlelb}";
        content += $"{_space}{_space}{_space}var response = result.As<OkObjectResult>().Value;{_singlelb}";
        content += $"{_space}{_space}{_space}response.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}response.Should().BeOfType<{model.SingularName}Dto>();{_singlelb}";
        content += $"{_space}{_space}{_space}response.As<{model.SingularName}Dto>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.As<{model.SingularName}Dto>(){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.Id.Should().Be(id);{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Verify(s => s.Send({_singlelb}";
        content += $"{_space}{_space}{_space}{_space}It.Is<Get{model.SingularName}ByIdQuery>(q => q.Id == id),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}It.IsAny<CancellationToken>()), Times.Once);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_singlelb}";
        return content;
    }
    private string GetGenerateControllerGetByFilterTest(GenerateParams model)
    {
        var content = $"{_space}{_space}[Theory(DisplayName = \"Should return a list of {model.PluralName} if there are items that meet the filter criteria\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task GetByFilterAsyncTest_Ok{_singlelb}";
        content += $"{_space}{_space}({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMediator> mockMediator,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<ILogger<{model.PluralName}Controller>> mockLogger,{_singlelb}";
        content += $"{_space}{_space}{_space}Get{model.PluralName}ByFilterQuery filter,{_singlelb}";
        content += $"{_space}{_space}{_space}{model.SingularName}ListItemDto {model.SingularName.ToLower()}1,{_singlelb}";
        content += $"{_space}{_space}{_space}{model.SingularName}ListItemDto {model.SingularName.ToLower()}2{_singlelb}";
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}var {model.SingularName.ToLower()}List = new List<{model.SingularName}ListItemDto> {{ {model.SingularName.ToLower()}1, {model.SingularName.ToLower()}2 }};{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Setup(m => m.Send(It.IsAny<Get{model.PluralName}ByFilterQuery>(), It.IsAny<CancellationToken>())){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync(new Response<{model.SingularName}ListItemDto>({model.SingularName.ToLower()}List));{_singlelb}";
        content += $"{_space}{_space}{_space}var sut = new {model.PluralName}Controller(mockLogger.Object){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}Mediator = mockMediator.Object{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.GetByFilterAsync(filter);{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<OkObjectResult>();{_singlelb}";
        content += $"{_space}{_space}{_space}var response = result.As<OkObjectResult>().Value;{_singlelb}";
        content += $"{_space}{_space}{_space}response.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}response.Should().BeOfType<Response<{model.SingularName}ListItemDto>>();{_singlelb}";
        content += $"{_space}{_space}{_space}var data = response.As<Response<{model.SingularName}ListItemDto>>().Data;{_singlelb}";
        content += $"{_space}{_space}{_space}data.Should().NotBeEmpty();{_singlelb}";
        content += $"{_space}{_space}{_space}data.Count.Should().Be({model.SingularName.ToLower()}List.Count);{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Verify(m => m.Send(It.Is<Get{model.PluralName}ByFilterQuery>(q => q.Page == filter.Page && q.PageSize == filter.PageSize),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}It.IsAny<CancellationToken>()), Times.Once);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_singlelb}";
        return content;
    }
    private string GetGenerateControllerCreateTest(GenerateParams model)
    {
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var content = $"{_space}{_space}[Theory(DisplayName = \"It should call the creation service and return the generated ID with a 201 status code.\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task CreateAsyncTest_Ok{_singlelb}";
        content += $"{_space}{_space}({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMediator> mockMediator,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<ILogger<{model.PluralName}Controller>> mockLogger,{_singlelb}";
        content += $"{_space}{_space}{_space}int {pkField.NameCamelCase},{_singlelb}";
        var fields = model.Fields.Where(x => !x.IsPrimaryKey);
        for (int i = 0; i < fields.Count(); i++)
        {
            var field = fields.ElementAt(i);
            content += $"{_space}{_space}{_space}{field.TypeToString} {field.NameCamelCase}";
            if (i < fields.Count() - 1)
                content += $",{_singlelb}";

            if (i == fields.Count() - 1)
                content += $"{_singlelb}";
        }
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Setup(a => a.Send(It.IsAny<Create{model.SingularName}Command>(), It.IsAny<CancellationToken>())){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync(new Response<int>(id));{_singlelb}";
        content += $"{_space}{_space}{_space}var sut = new {model.PluralName}Controller(mockLogger.Object){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}Mediator = mockMediator.Object{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.CreateAsync(new {model.SingularName}CreateRequestParams{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        for (int i = 0; i < fields.Count(); i++)
        {
            var field = fields.ElementAt(i);
            content += $"{_space}{_space}{_space}{_space}{_space}{field.Name} = {field.NameCamelCase}";
            if (i < fields.Count() - 1)
                content += $",{_singlelb}";
            else
                content += $"{_singlelb}";
        }
        content += $"{_space}{_space}{_space}{_space}}});{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<ObjectResult>();{_singlelb}";
        content += $"{_space}{_space}{_space}var response = result.As<ObjectResult>().Value;{_singlelb}";
        content += $"{_space}{_space}{_space}response.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}response.Should().BeOfType<int>();{_singlelb}";
        content += $"{_space}{_space}{_space}response.As<int>().Should().Be(id);{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Verify(a => a.Send(It.Is<Create{model.SingularName}Command>(p => {_singlelb}";
        var isFirst = true;
        foreach (var field in fields)
        {
            if (isFirst)
            {
                content += $"{_space}{_space}{_space}{_space}p.{field.Name} == {field.NameCamelCase}{_singlelb}";
                isFirst = false;
            }
            else
            {
                content += $"{_space}{_space}{_space}{_space}&& p.{field.Name} == {field.NameCamelCase}{_singlelb}";
            }   
            
        }
        content += $"{_space}{_space}{_space}{_space}),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}It.IsAny<CancellationToken>()));{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_singlelb}";
        return content;
    }
    private string GetGenerateControllerUpdateTest(GenerateParams model)
    {
        var content = $"{_space}{_space}[Theory(DisplayName = \"It should call the update service and return a response with status code 204.\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task UpdateAsyncTest_Ok{_singlelb}";
        content += $"{_space}{_space}({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMediator> mockMediator,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<ILogger<{model.PluralName}Controller>> mockLogger,{_singlelb}";
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        var fields = model.Fields.Where(x => !x.IsPrimaryKey);
        content += $"{_space}{_space}{_space}int {pkField.NameCamelCase},{_singlelb}";
        for (int i = 0; i < fields.Count(); i++)
        {
            var field = fields.ElementAt(i);
            content += $"{_space}{_space}{_space}{field.TypeToString} {field.NameCamelCase}";
            if (i < fields.Count() - 1)
                content += $",{_singlelb}";

            if (i == fields.Count() - 1)
                content += $"{_singlelb}";
        }
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Setup(a => a.Send(It.IsAny<Update{model.SingularName}Command>(), It.IsAny<CancellationToken>())){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync(new Response<int> {{ Data = new List<int> {{ {pkField.NameCamelCase} }} }});{_singlelb}";
        content += $"{_space}{_space}{_space}var sut = new {model.PluralName}Controller(mockLogger.Object){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}Mediator = mockMediator.Object{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.UpdateAsync({pkField.NameCamelCase}, new {model.SingularName}UpdateRequestParams{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        for (int i = 0; i < fields.Count(); i++)
        {
            var field = fields.ElementAt(i);
            content += $"{_space}{_space}{_space}{_space}{_space}{field.Name} = {field.NameCamelCase}";
            if (i < fields.Count() - 1)
                content += $",{_singlelb}";
            else
                content += $"{_singlelb}";
        }
        content += $"{_space}{_space}{_space}{_space}}});{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<NoContentResult>();{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Verify(a => a.Send(It.Is<Update{model.SingularName}Command>(p => p.{pkField.Name} == {pkField.NameCamelCase}{_singlelb}";
        foreach (var field in fields)
        {
            content += $"{_space}{_space}{_space}{_space}&& p.{field.Name} == {field.NameCamelCase}{_singlelb}";
        }
        content += $"{_space}{_space}{_space}{_space}),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}It.IsAny<CancellationToken>()), Times.Once);{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_singlelb}";
        return content;
    }
    private string GetGenerateControllerDeleteTest(GenerateParams model)
    {
        var content = $"{_space}{_space}[Theory(DisplayName = \"It should call the deletion service and return a response with status code 204.\"), AutoMoq]{_singlelb}";
        content += $"{_space}{_space}public async Task DeleteAsyncTest_Ok{_singlelb}";
        content += $"{_space}{_space}({_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<IMediator> mockMediator,{_singlelb}";
        content += $"{_space}{_space}{_space}[Frozen] Mock<ILogger<{model.PluralName}Controller>> mockLogger,{_singlelb}";
        var pkField = model.Fields.FirstOrDefault(x => x.IsPrimaryKey);
        content += $"{_space}{_space}{_space}int {pkField.NameCamelCase}{_singlelb}";
        content += $"{_space}{_space}){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}// Arrange{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Setup(a => a.Send(It.IsAny<Delete{model.SingularName}Command>(), It.IsAny<CancellationToken>())){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}.ReturnsAsync(new Response<int> {{ Data = new List<int> {{ {pkField.NameCamelCase} }} }});{_singlelb}";
        content += $"{_space}{_space}{_space}var sut = new {model.PluralName}Controller(mockLogger.Object){_singlelb}";
        content += $"{_space}{_space}{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}Mediator = mockMediator.Object{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}}};{_singlelb}";
        content += $"{_space}{_space}{_space}// Act{_singlelb}";
        content += $"{_space}{_space}{_space}var result = await sut.DeleteAsync({pkField.NameCamelCase});{_singlelb}";
        content += $"{_space}{_space}{_space}// Assert{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().NotBeNull();{_singlelb}";
        content += $"{_space}{_space}{_space}result.Should().BeOfType<NoContentResult>();{_singlelb}";
        content += $"{_space}{_space}{_space}mockMediator.Verify(a =>{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}a.Send(It.Is<Delete{model.SingularName}Command>(p => p.{pkField.Name} == {pkField.NameCamelCase}),{_singlelb}";
        content += $"{_space}{_space}{_space}{_space}It.IsAny<CancellationToken>()));{_singlelb}";
        content += $"{_space}{_space}}}{_singlelb}";
        content += $"{_space}{_space}{_singlelb}";
        return content;
    }

}