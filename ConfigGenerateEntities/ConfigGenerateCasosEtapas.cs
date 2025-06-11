using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateCasosEtapas
{
    public static GenerateParams GetConfig()
    {
        var config = new GenerateParams
        {
            GenerateOnlyModel = true,
            AgregateModel = "Casos",
            SpanishName = "Etapas del Caso",
            EnglishName = "Case Stages",
            SingularName = "CasoEtapa",
            PluralName = "CasosEtapas",
            auditable = Auditable.Create,
            CrudTypes = new List<CrudType>(), // Solo modelo
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador de la relación etapa-caso",
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
                    Name = "IdEtapaAnterior",
                    Type = FieldType.Int,
                    Description = "Identificador de la etapa anterior",
                    IsRequired = false,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Etapa",
                    ForeignKeyObject = "EtapaAnterior",
                    ForeignKeyTable = "Etapas",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Etapa Anterior",
                    EnglishName = "Previous Stage Id",
                    TestExample = "1"
                },
                new EntityField
                {
                    Name = "IdEtapa",
                    Type = FieldType.Int,
                    Description = "Identificador de la etapa actual",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Etapa",
                    ForeignKeyObject = "Etapa",
                    ForeignKeyTable = "Etapas",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Etapa",
                    EnglishName = "Stage Id",
                    TestExample = "2"
                }
            }
        };

        return config;
    }
}
