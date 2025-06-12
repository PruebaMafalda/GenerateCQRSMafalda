using GenerateCQRSMafalda.App;
using GenerateCQRSMafalda.ConfigGenerateEntities;

namespace GenerateCQRSMafalda;
class Program
{
    static void Main(string[] args)
    {
        var generator = new Generate();
        Console.WriteLine($">>>>>>>>>>>>>>>> Init Generate:  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        //var entity = ConfigGenerateStudent.GetConfig(); // Student
        //  var entity = ConfigGenerateCar.GetConfig(); // Car
        // var entity = ConfigGenerateModelo.GetConfig(); // Modelo
        //var entity = ConfigGeneratePedidosContactosMotivos.GetConfig(); // Modelo
        //var entity = ConfigGeneratePedidos.GetConfig(); // Modelo
        //var entity = ConfigGenerateParametrosConfig.GetConfig(); // ParametrosConfig
        //var entity = ConfigGenerateAgentes.GetConfig(); 
        //var entity = ConfigGenerateGrupos.GetConfig(); 
        //var entity = ConfigGenerateProcesos.GetConfig(); 
        //var entity = ConfigGenerateEtapas.GetConfig(); 
        //var entity = ConfigGenerateEtapasRelaciones.GetConfig(); 
        // var entity = ConfigGenerateAlumnosInfo.GetConfig(); 
        // var entity = ConfigGenerateOrigenesAtencion.GetConfig(); 
        // var entity = ConfigGenerateFinalidades.GetConfig(); 
        //var entity = ConfigGenerateFinalidadesGrupos.GetConfig(); 
        //var entity = ConfigGenerateAcciones.GetConfig(); 
        // var entity = ConfigGenerateCasos.GetConfig(); 
        //var entity = ConfigGenerateCasosEtapas.GetConfig(); 
        //var entity = ConfigGenerateCasosAgentes.GetConfig();
        //var entity = ConfigGenerateCasosPedidos.GetConfig(); 
        //var entity = ConfigGenerateCasosLogs.GetConfig(); 
        //var entity = ConfigGenerateTiposClasificaciones.GetConfig(); 
        var entity = ConfigGenerateClientesFinanciero.GetConfig(); 
        generator.Execute(entity);
        Console.WriteLine($">>>>>>>>>>>>>>>> Finish Generate {DateTime.Now.ToString("yyyy-MM-dd HH:ii:ss")}");
    }
}