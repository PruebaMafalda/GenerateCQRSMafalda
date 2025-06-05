using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateControllerContent : GenerateBase
{
    public string GetGenerateController(GenerateParams model)
    {
        var content = "";
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
        content += $"using {NameSpaceProject}.{PathProject.Infrastructure}.Models.Response;{_singlelb}";
        content += $"using Microsoft.AspNetCore.Authorization;{_singlelb}";
        content += $"using Microsoft.AspNetCore.Mvc;{_singlelb}";
        content += $"using System.Net;{_singlelb}";
        content += $"using Unir.Framework.WebApiSuperTypes.Auth.Handlers.Oidc;{_doublelb}";

        content += $"namespace {PathApplication.ApplicationControllers.NameSpace}{_singlelb}";
        content += $"{{{_singlelb}";
        content += $"{_space}/// <summary>{model.PluralName} controller.</summary>{_singlelb}";
        content += $"{_space}[ApiController]{_singlelb}";
        content += $"{_space}[Route(\"api/v1/{model.ConrollerRoute.ToLower()}\")]{_singlelb}";
        content += $"{_space}[Authorize(AuthenticationSchemes = OidcAuthenticationOptions.DEFAULT_SCHEME)]{_singlelb}";
        content += $"{_space}public class {model.PluralName}Controller : BaseController{_singlelb}";
        content += $"{_space}{{{_singlelb}";
        content += $"{_space}{_space}/// <summary>Constructor.<summary>{_singlelb}";
        content += $"{_space}{_space}/// <param name=\"logger\">Logger.</param>{_singlelb}";
        content += $"{_space}{_space}public {model.PluralName}Controller(ILogger<{model.PluralName}Controller> logger) : base(logger){_singlelb}";
        content += $"{_space}{_space}{{{_singlelb}";
        content += $"{_space}{_space}}}{_doublelb}";

        if (model.CrudTypes.Contains(CrudType.GetById))
        {
            content += $"{_space}{_space}/// <summary>Retrieves the details of a {model.SingularName} by its identifier.</summary>{_singlelb}";
            content += $"{_space}{_space}/// <param name=\"id\">{model.SingularName.ToLower()} identifier.</param>{_singlelb}";
            content += $"{_space}{_space}/// <returns>Details of the located {model.SingularName}.</returns>{_singlelb}";
            content += $"{_space}{_space}[HttpGet(\"{{id}}\")]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof({model.SingularName}Dto), (int)HttpStatusCode.OK)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.NotFound)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]{_singlelb}";
            content += $"{_space}{_space}public async Task<IActionResult> GetByIdAsync(int id){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}var response = await Mediator.Send(new Get{model.SingularName}ByIdQuery(id));{_doublelb}";
            content += $"{_space}{_space}{_space}if (response != null){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}return response.HasError() ? Ko(response) : Ok(response.Data[0]);{_doublelb}";
            content += $"{_space}{_space}{_space}return StatusCode((int)HttpStatusCode.InternalServerError);{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }

        if (model.CrudTypes.Contains(CrudType.GetByFilter))
        {
            content += $"{_space}{_space}/// <summary>Retrieves a list of {model.PluralName} that meet the filter criteria.</summary>{_singlelb}";
            content += $"{_space}{_space}/// <param name=\"filter\">Get{model.PluralName}ByFilterQuery.</param>{_singlelb}";
            content += $"{_space}{_space}/// <returns>Structure with results and their metadata.</returns>{_singlelb}";
            content += $"{_space}{_space}[HttpPost(\"filter\")]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(Response<{model.SingularName}ListItemDto>), (int)HttpStatusCode.OK)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]{_singlelb}";            
            content += $"{_space}{_space}public async Task<IActionResult> GetByFilterAsync([FromBody] Get{model.PluralName}ByFilterQuery filter){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}var response = await Mediator.Send(filter);{_doublelb}";
            content += $"{_space}{_space}{_space}if(response == null){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}return StatusCode((int)HttpStatusCode.InternalServerError);{_doublelb}";
            content += $"{_space}{_space}{_space}if (response.HasError()){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}return Ko(response);{_doublelb}";
            content += $"{_space}{_space}{_space}return Ok(response);{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }

        if (model.CrudTypes.Contains(CrudType.Create))
        {
            content += $"{_space}{_space}/// <summary>Inserts a new {model.SingularName} record based on the provided data.</summary>{_singlelb}";
            content += $"{_space}{_space}/// <param name=\"request\">Object containing the {model.SingularName} data.</param>{_singlelb}";
            content += $"{_space}{_space}/// <returns>If the operation is successful, returns HTTP 201 along with the link to access the new resource.</returns>{_singlelb}";
            content += $"{_space}{_space}[HttpPost]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]{_singlelb}";
            content += $"{_space}{_space}public async Task<IActionResult> CreateAsync({model.SingularName}CreateRequestParams request){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}var response = await Mediator.Send(new Create{model.SingularName}Command({GetGenerateControllerParamsRequest(model)}));{_doublelb}";
            content += $"{_space}{_space}{_space}if (response == null){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}return StatusCode((int)HttpStatusCode.InternalServerError);{_doublelb}";
            content += $"{_space}{_space}{_space}return response.HasError() ? Ko(response) : StatusCode((int)HttpStatusCode.Created, response.Data[0]);{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";

        }
        if (model.CrudTypes.Contains(CrudType.Update))
        {
            content += $"{_space}{_space}/// <summary>Updates the values of a {model.SingularName} located by its identifier. All values are replaced by the provided ones.</summary>{_singlelb}";
            content += $"{_space}{_space}/// <param name=\"id\">{model.SingularName} identifier, used to locate it.</param>{_singlelb}";
            content += $"{_space}{_space}/// <param name=\"request\">New values to modify the current data of the located resource.</param>{_singlelb}";
            content += $"{_space}{_space}/// <returns>Result of the operation. HTTP 204 if successful.</returns>{_singlelb}";
            content += $"{_space}{_space}[Route(\"{{id:int}}\")]{_singlelb}";
            content += $"{_space}{_space}[HttpPut]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType((int)HttpStatusCode.NoContent)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.NotFound)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]{_singlelb}";
            content += $"{_space}{_space}public async Task<IActionResult> UpdateAsync(int id, {model.SingularName}UpdateRequestParams request){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}var response = await Mediator.Send(new Update{model.SingularName}Command(id, {GetGenerateControllerParamsRequest(model)}));{_doublelb}";
            content += $"{_space}{_space}{_space}if (response == null){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}return StatusCode((int)HttpStatusCode.InternalServerError);{_doublelb}";
            content += $"{_space}{_space}{_space}return response.HasError() ? Ko(response) : NoContent();{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }
        if (model.CrudTypes.Contains(CrudType.Delete))
        {
            content += $"{_space}{_space}/// <summary>Deletes the {model.SingularName} resource corresponding to the specified identifier.</summary>{_singlelb}";
            content += $"{_space}{_space}/// <param name=\"id\">Identifier of the {model.SingularName} to delete.</param>{_singlelb}";
            content += $"{_space}{_space}/// <returns>If the process is completed successfully, returns HTTP 204.</returns>{_singlelb}";
            content += $"{_space}{_space}[Route(\"{{id}}\")]{_singlelb}";
            content += $"{_space}{_space}[HttpDelete]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType((int)HttpStatusCode.NoContent)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.NotFound)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]{_singlelb}";
            content += $"{_space}{_space}[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]{_singlelb}";
            content += $"{_space}{_space}public async Task<IActionResult> DeleteAsync(int id){_singlelb}";
            content += $"{_space}{_space}{{{_singlelb}";
            content += $"{_space}{_space}{_space}var response = await Mediator.Send(new Delete{model.SingularName}Command(id));{_doublelb}";
            content += $"{_space}{_space}{_space}if (response == null){_singlelb}";
            content += $"{_space}{_space}{_space}{_space}return StatusCode((int)HttpStatusCode.InternalServerError);{_doublelb}";
            content += $"{_space}{_space}{_space}return response.HasError() ? Ko(response) : NoContent();{_singlelb}";
            content += $"{_space}{_space}}}{_doublelb}";
        }
        content += $"{_space}}}{_singlelb}";
        content += $"}}{_singlelb}";
        return content;
    }
    public string GetGenerateControllerParamsRequest(GenerateParams model)
    {
        var listParamsFields = new List<string>();
        foreach (var field in model.Fields.Where(x => !x.IsPrimaryKey))
        {
            listParamsFields.Add($"request.{field.Name}");
        }
        return string.Join(", ", listParamsFields);
    }
}