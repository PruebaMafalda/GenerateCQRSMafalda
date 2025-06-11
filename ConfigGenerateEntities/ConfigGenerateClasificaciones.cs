using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateClasificaciones
{
    public static GenerateParams GetConfig()
    {
        var clasificaciones = new GenerateParams
        {
            GenerateOnlyModel = false,
            ConrollerRoute = "clasificaciones",
            AgregateModel = "Clasificaciones",
            SpanishName = "Clasificaciones",
            EnglishName = "Classifications",
            SingularName = "Clasificacion",
            PluralName = "Clasificaciones",
            auditable = Auditable.Full,
            CrudTypes = new List<CrudType>
            {
                CrudType.Create,
                CrudType.Update,
                CrudType.GetByFilter
            },
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador de la clasificación",
                    IsPrimaryKey = true,
                    IsAutoIncrement = true,
                    SpanishName = "Id",
                    EnglishName = "Id",
                    TestExample = "1"
                },
                new EntityField
                {
                    Name = "Nombre",
                    Type = FieldType.String,
                    Length = 100,
                    Description = "Nombre de la clasificación",
                    IsRequired = true,
                    SpanishName = "Nombre",
                    EnglishName = "Name",
                    TestExample = "Clasificación A"
                },
                new EntityField
                {
                    Name = "IdTipoClasificacion",
                    Type = FieldType.Int,
                    Description = "Identificador del tipo de clasificación",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "TipoClasificacion",
                    ForeignKeyObject = "TipoClasificacion",
                    ForeignKeyTable = "TiposClasificaciones",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Tipo Clasificación",
                    EnglishName = "Classification Type Id",
                    TestExample = "2"
                },
                new EntityField
                {
                    Name = "IdClasificacionPadre",
                    Type = FieldType.Int,
                    Description = "Clasificación padre",
                    IsRequired = false,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Clasificacion",
                    ForeignKeyObject = "Clasificacion",
                    ForeignKeyTable = "Clasificaciones",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Clasificación Padre",
                    EnglishName = "Parent Classification Id",
                    TestExample = "0"
                },
                new EntityField
                {
                    Name = "Activo",
                    Type = FieldType.Bool,
                    Description = "Indica si la clasificación está activa",
                    IsRequired = true,
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Activo",
                    EnglishName = "Active",
                    TestExample = "true"
                }
            }
        };

        return clasificaciones;
    }
}
