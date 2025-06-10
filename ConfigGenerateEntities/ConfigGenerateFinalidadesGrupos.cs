using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateFinalidadesGrupos
{
    public static GenerateParams GetConfig()
    {
        var config = new GenerateParams
        {
            GenerateOnlyModel = true,
            AgregateModel = "Finalidades",
            SpanishName = "Grupo de Finalidad",
            EnglishName = "Purpose Group",
            SingularName = "FinalidadGrupo",
            PluralName = "FinalidadesGrupos",
            auditable = Auditable.Full,
            CrudTypes = new List<CrudType>(), // Solo modelo
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador del registro",
                    IsPrimaryKey = true,
                    IsAutoIncrement = true
                },
                new EntityField
                {
                    Name = "IdFinalidad",
                    Type = FieldType.Int,
                    Description = "Identificador de la finalidad",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Finalidad",
                    ForeignKeyObject = "Finalidad",
                    ForeignKeyTable = "Finalidades",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Finalidad",
                    EnglishName = "Purpose",
                    TestExample = "1"
                },
                new EntityField
                {
                    Name = "IdGrupo",
                    Type = FieldType.Int,
                    Description = "Identificador del grupo",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Grupo",
                    ForeignKeyObject = "Grupo",
                    ForeignKeyTable = "Grupos",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Grupo",
                    EnglishName = "Group",
                    TestExample = "2"
                },
                new EntityField
                {
                    Name = "Activo",
                    Type = FieldType.Bool,
                    Description = "Indica si la finalidad está activa",
                    IsRequired = true,
                    IsEspecification = true,
                    SpanishName = "Activo",
                    EnglishName = "Active",
                    TestExample = "true"
                }
            }
        };

        return config;
    }
}
