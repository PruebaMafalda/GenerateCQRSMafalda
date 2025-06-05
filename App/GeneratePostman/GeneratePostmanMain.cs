
using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GeneratePostman;
public class GeneratePostmanMain
{
    private GenerateJsonCollectionContent _generateJsonCollectionContent = new GenerateJsonCollectionContent();
    public void Generate(GenerateParams model)
    {
        // generate agregate model
        GenerateJsonCollectionFiles(model);
        // generate Contracts
        
    }
    public void GenerateJsonCollectionFiles(GenerateParams model)
    {
        ProjectFile.CreateFile(new CreateFileParams{
            Path = PathProject.PostmanCollection,
            FileName = $"{model.PluralName}.postman_collection.json",
            Content = _generateJsonCollectionContent.GetGenerateJsonCollectionContent(model)
        });
    }
}