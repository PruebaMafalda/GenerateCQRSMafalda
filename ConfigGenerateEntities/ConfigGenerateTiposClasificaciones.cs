using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateTiposClasificaciones
{
    public static GenerateParams GetConfig()
    {
        var tiposClasificaciones = new GenerateParams
        {
            GenerateOnlyModel = false,
            ConrollerRoute = "tipos-clasificaciones",
            AgregateModel = "TiposClasificaciones",
            SpanishName = "Tipos de Clasificación",
            EnglishName = "Classification Types",
            SingularName = "TipoClasificacion",
            PluralName = "TiposClasificaciones",
            auditable = Auditable.Full,
            CrudTypes = new List<CrudType>
            {
                CrudType.Update,
                CrudType.GetByFilter
            },
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador del tipo de clasificación",
                    IsPrimaryKey = true,
                    IsAutoIncrement = false,
                    SpanishName = "Id",
                    EnglishName = "Id",
                    TestExample = "1"
                },
                new EntityField
                {
                    Name = "Nombre",
                    Type = FieldType.String,
                    Length = 100,
                    Description = "Nombre del tipo de clasificación",
                    IsRequired = true,
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Contains,
                    SpanishName = "Nombre",
                    EnglishName = "Name",
                    TestExample = "Documentación"
                },
                new EntityField
                {
                    Name = "Etiqueta",
                    Type = FieldType.String,
                    Length = 50,
                    Description = "Etiqueta corta",
                    IsRequired = true,
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Contains,
                    SpanishName = "Etiqueta",
                    EnglishName = "Tag",
                    TestExample = "DOC"
                },
                new EntityField
                {
                    Name = "Codigo",
                    Type = FieldType.String,
                    Length = 30,
                    Description = "Codigo único",
                    IsRequired = true,
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Contains,
                    SpanishName = "Codigo",
                    EnglishName = "Code",
                    TestExample = "DOC01"
                },
                new EntityField
                {
                    Name = "IdTipoClasificacionPadre",
                    Type = FieldType.Int,
                    Description = "Tipo de clasificación padre",
                    IsRequired = false,
                    IsForeignKey = true,
                    ForeignKeyEntity = "TipoClasificacion",
                    ForeignKeyObject = "TipoClasificacion",
                    ForeignKeyTable = "TiposClasificaciones",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Tipo Clasificación Padre",
                    EnglishName = "Parent Classification Id",
                    TestExample = "0"
                },
                new EntityField
                {
                    Name = "Activo",
                    Type = FieldType.Bool,
                    Description = "Indica si está activo",
                    IsRequired = true,
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Activo",
                    EnglishName = "Active",
                    TestExample = "true"
                }
            }
        };

        return tiposClasificaciones;
    }
}
