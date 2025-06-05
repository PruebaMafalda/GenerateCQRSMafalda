using GenerateCQRSMafalda.App;
using GenerateCQRSMafalda.ConfigGenerateEntities;

namespace GenerateCQRSMafalda;
class Program
{
    static void Main(string[] args)
    {
        var generator = new Generate();
        Console.WriteLine(">>>>>>>>>>>>>>>> Init Generate");
        //var entity = ConfigGenerateStudent.GetConfig(); // Student
        //  var entity = ConfigGenerateCar.GetConfig(); // Car
        // var entity = ConfigGenerateModelo.GetConfig(); // Modelo
        //var entity = ConfigGeneratePedidosContactosMotivos.GetConfig(); // Modelo
        //var entity = ConfigGeneratePedidos.GetConfig(); // Modelo
        //var entity = ConfigGenerateParametrosConfig.GetConfig(); // ParametrosConfig
        //var entity = ConfigGenerateAgentes.GetConfig(); // ConfigGenerateAgentes
        //var entity = ConfigGenerateGrupos.GetConfig(); // ConfigGenerateAgentes
        //var entity = ConfigGenerateProcesos.GetConfig(); // ConfigGenerateAgentes
        //var entity = ConfigGenerateEtapas.GetConfig(); // ConfigGenerateAgentes
        var entity = ConfigGenerateEtapasRelaciones.GetConfig(); // ConfigGenerateAgentes
        generator.Execute(entity);
        Console.WriteLine(">>>>>>>>>>>>>>>> Finish Generate");
    }
}