using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateEtapasRelaciones
{
    public static GenerateParams GetConfig()
    {
        var etapaRelacion = new GenerateParams
        {
            GenerateOnlyModel = true,
            AgregateModel = "Etapas",
            SpanishName = "Relación de Etapas",
            EnglishName = "Stage Relationship",
            SingularName = "EtapaRelacion",
            PluralName = "EtapasRelaciones",
            auditable = null,
            CrudTypes = new List<CrudType>(), // No se generan cruds si solo es modelo
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador de la etapa",
                    IsPrimaryKey = true,
                    IsAutoIncrement = false,
                },
                new EntityField
                {
                    Name = "IdEtapaOrigen",
                    Type = FieldType.Int,
                    Description = "Identificador de la etapa origen",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Etapa",
                    ForeignKeyObject = "EtapaOrigen",
                    ForeignKeyTable = "Etapas",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Etapa Origen",
                    EnglishName = "Source Stage Id",
                    TestExample = "1"
                },
                new EntityField
                {
                    Name = "IdEtapaDestino",
                    Type = FieldType.Int,
                    Description = "Identificador de la etapa destino",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Etapa",
                    ForeignKeyObject = "EtapaDestino",
                    ForeignKeyTable = "Etapas",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Etapa Destino",
                    EnglishName = "Target Stage Id",
                    TestExample = "2"
                }
            }
        };

        return etapaRelacion;
    }
}

/*

new EntityField
            {
                Name = "IdProceso",
                Type = FieldType.Int,
                Description = "Identificador del proceso al que pertenece la etapa",
                IsRequired = true,
                IsForeignKey = true,
                ForeignKeyObject = "Proceso",
                ForeignKeyTable = "Procesos",
                ForeignKeyField = "Id",
                IsEspecification = true,
                SpanishName = "IdProceso",
                EnglishName = "ProcessId",
                TestExample = "100"
            }
*/
