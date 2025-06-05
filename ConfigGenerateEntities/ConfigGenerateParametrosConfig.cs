using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;
public class ConfigGenerateParametrosConfig
{
    public static GenerateParams GetConfig()
    {
        var config = new GenerateParams();
        config.GenerateOnlyModel = false;
        config.AgregateModel = "ParametrosConfig";

        config.SpanishName = "Parámetro de Configuración";
        config.EnglishName = "ConfigurationParameter";

        config.SingularName = "ParametroConfig";
        config.PluralName = "ParametrosConfig";
        config.ConrollerRoute = "parametros-config";
        config.auditable = Auditable.Full;
        config.CrudTypes = new List<CrudType>
        {
            CrudType.Update,
            CrudType.GetById,
            CrudType.GetByFilter
        };
        config.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Id del parametro de configuración",
                IsPrimaryKey = true,
                IsAutoIncrement = false,
            },
            new EntityField
            {
                Name = "Clave",
                Type = FieldType.String,
                Description = "Clave del parámetro de configuración",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Clave",
                EnglishName = "Key",
                TestExample = "ParametroClave"
            },
            new EntityField
            {
                Name = "Valor",
                Type = FieldType.String,
                Description = "Valor del parámetro de configuración",
                Length = -1, // 0 para nvarchar(max)
                IsRequired = true,
                SpanishName = "Valor",
                EnglishName = "Value",
                TestExample = "ValorEjemplo"
            },
            new EntityField
            {
                Name = "Tipo",
                Type = FieldType.Int,
                Description = "Tipo del parámetro de configuración",
                IsRequired = true,
                SpanishName = "Tipo",
                EnglishName = "Type",
                TestExample = "1"
            }
        };

        return config;
    }
}
