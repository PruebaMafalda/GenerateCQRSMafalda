using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateOrigenesAtencion
{
    public static GenerateParams GetConfig()
    {
        var config = new GenerateParams
        {
            GenerateOnlyModel = true,
            AgregateModel = "Acciones",
            ConrollerRoute = "", // no aplica si solo se genera modelo
            SpanishName = "Origen Atención",
            EnglishName = "Care Origin",
            SingularName = "OrigenAtencion",
            PluralName = "OrigenesAtencion",
            auditable = null,
            CrudTypes = new List<CrudType>(), // vacío al ser solo modelo
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador",
                    IsPrimaryKey = true,
                    IsAutoIncrement = false
                },
                new EntityField
                {
                    Name = "Codigo",
                    Type = FieldType.String,
                    Description = "Código del origen de atención",
                    Length = 50,
                    IsRequired = true,
                    SpanishName = "Código",
                    EnglishName = "Code",
                    TestExample = "ORI001"
                },
                new EntityField
                {
                    Name = "Nombre",
                    Type = FieldType.String,
                    Description = "Nombre del origen de atención",
                    Length = 50,
                    IsRequired = true,
                    SpanishName = "Nombre",
                    EnglishName = "Name",
                    TestExample = "Presencial"
                }
            }
        };

        return config;
    }
}
