using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateGrupos
{
    public static GenerateParams GetConfig()
    {
        var grupo = new GenerateParams();
        grupo.GenerateOnlyModel = false;
        grupo.ConrollerRoute = "grupos";
        grupo.AgregateModel = "Grupos";
        grupo.SpanishName = "Grupo";
        grupo.EnglishName = "Group";
        grupo.SingularName = "Grupo";
        grupo.PluralName = "Grupos";
        grupo.auditable = Auditable.Full;
        grupo.CrudTypes = new List<CrudType>
        {
            CrudType.Create,
            CrudType.Update,
            CrudType.GetById,
            CrudType.GetByFilter
        };
        grupo.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador del grupo",
                IsPrimaryKey = true,
                IsAutoIncrement = true // No autoincremental
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre del grupo",
                Length = 200,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "Nombre",
                EnglishName = "Name",
                TestExample = "Atencion al alumno"
            },
            new EntityField
            {
                Name = "Codigo",
                Type = FieldType.String,
                Description = "Codigo del grupo",
                Length = 50,
                IsRequired = false,
                IsUnique = true,
                IsEspecification = true,
                SpanishName = "Codigo",
                EnglishName = "Code",
                TestExample = "AAAA"
            },
            new EntityField
            {
                Name = "Abreviatura",
                Type = FieldType.String,
                Description = "Abreviatura del grupo",
                Length = 50,
                IsRequired = false,
                IsEspecification = true,
                SpanishName = "Abreviatura",
                EnglishName = "Abbreviation",
                TestExample = "AttAlumno"
            },
            new EntityField
            {
                Name = "Activo",
                Type = FieldType.Bool,
                Description = "Indica si el grupo está activo",
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Activo",
                EnglishName = "Active",
                TestExample = "true"
            }
        };

        return grupo;
    }
}
