using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateCasosAgentes
{
    public static GenerateParams GetConfig()
    {
        var casosAgentes = new GenerateParams
        {
            GenerateOnlyModel = true,
            AgregateModel = "Casos",
            SpanishName = "Casos Agentes",
            EnglishName = "Case Agents",
            SingularName = "CasoAgente",
            PluralName = "CasosAgentes",
            auditable = Auditable.Create,
            CrudTypes = new List<CrudType>(), // Solo modelo
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador de la relación caso-agente",
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
                    Name = "IdAgente",
                    Type = FieldType.Int,
                    Description = "Identificador del agente",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Agente",
                    ForeignKeyObject = "Agente",
                    ForeignKeyTable = "Agentes",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Agente",
                    EnglishName = "Agent Id",
                    TestExample = "20"
                }
            }
        };

        return casosAgentes;
    }
}
