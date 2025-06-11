using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateCasosLogs
{
    public static GenerateParams GetConfig()
    {
        var casosLogs = new GenerateParams
        {
            GenerateOnlyModel = false,
            ConrollerRoute = "casos-logs",
            AgregateModel = "Casos",
            SpanishName = "Logs de Casos",
            EnglishName = "Case Logs",
            SingularName = "CasoLog",
            PluralName = "CasosLogs",
            auditable = Auditable.Create,
            CrudTypes = new List<CrudType>
            {
                CrudType.Create,
                CrudType.GetByFilter
            },
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador del log del caso",
                    IsPrimaryKey = true,
                    IsAutoIncrement = true
                },
                new EntityField
                {
                    Name = "IdCaso",
                    Type = FieldType.Int,
                    Description = "Identificador del caso",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Caso",
                    ForeignKeyObject = "Caso",
                    ForeignKeyTable = "Casos",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Caso",
                    EnglishName = "Case Id",
                    TestExample = "10"
                },
                new EntityField
                {
                    Name = "Observacion",
                    Type = FieldType.String,
                    Length = 1000,
                    Description = "Observaciones del log",
                    IsRequired = true,
                    SpanishName = "Observación",
                    EnglishName = "Observation",
                    TestExample = "El usuario actualizó el estado del caso"
                }
            }
        };

        return casosLogs;
    }
}
