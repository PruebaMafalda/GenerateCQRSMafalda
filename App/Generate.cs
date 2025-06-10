using GenerateCQRSMafalda.App.GenerateApplication;
using GenerateCQRSMafalda.App.GenerateDomain;
using GenerateCQRSMafalda.App.GenerateInfrastructure;
using GenerateCQRSMafalda.App.GeneratePostman;
using GenerateCQRSMafalda.App.GenerateTest;
using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.App;
public class Generate
{
    private GenerateInfrastructureMain _generateInfrastructure = new GenerateInfrastructureMain();
    private GenerateDomainMain _generateDomain = new GenerateDomainMain();
    private GenerateApplicationMain _generateApplication = new GenerateApplicationMain();
    private GenerateTestMain _generateTest = new GenerateTestMain();
    private GeneratePostmanMain _generatePostmanMain = new GeneratePostmanMain();
    public void Execute(GenerateParams model)
    {
        // GENERATE DOMAIN
        _generateDomain.Generate(model);
        // GENERATE INFRAESTRUCTURE
        _generateInfrastructure.Generate(model);
        // GENERATE APPLICATION
        _generateApplication.Generate(model);
        // GENERATE TEST
        _generateTest.Generate(model);
        if (!model.GenerateOnlyModel)
        {
            // GENERATE Postman        
            _generatePostmanMain.Generate(model);    
        }
    }

}