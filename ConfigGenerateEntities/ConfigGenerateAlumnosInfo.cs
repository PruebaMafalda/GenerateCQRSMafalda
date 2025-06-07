using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateAlumnosInfo
{
    public static GenerateParams GetConfig()
    {
        var alumno = new GenerateParams();
        alumno.GenerateOnlyModel = false;
        alumno.ConrollerRoute = "alumnos-info";
        alumno.AgregateModel = "AlumnosInfo";
        alumno.SpanishName = "Alumno";
        alumno.EnglishName = "Student";
        alumno.SingularName = "AlumnoInfo";
        alumno.PluralName = "AlumnosInfo";
        alumno.auditable = Auditable.Full;
        alumno.HasLogicDeleted = false;
        alumno.CrudTypes = new List<CrudType>
        {
            CrudType.Create,
            CrudType.Update,
            CrudType.GetById,
            CrudType.GetByFilter
        };
        alumno.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador del alumno",
                IsPrimaryKey = true,
                IsAutoIncrement = true
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre del alumno",
                Length = 300,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.StartsWith,
                SpanishName = "Nombre",
                EnglishName = "FirstName",
                TestExample = "María"
            },
            new EntityField
            {
                Name = "Apellidos",
                Type = FieldType.String,
                Description = "Apellidos del alumno",
                Length = 300,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.StartsWith,
                SpanishName = "Apellidos",
                EnglishName = "LastName",
                TestExample = "López Martínez"
            },
            new EntityField
            {
                Name = "Email",
                Type = FieldType.String,
                Description = "Correo electrónico del alumno",
                Length = 300,
                IsUnique = true,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Email",
                EnglishName = "Email",
                TestExample = "alumno@correo.com"
            },
            new EntityField
            {
                Name = "CodigoPais",
                Type = FieldType.String,
                Description = "Código del país del alumno",
                Length = 20,
                IsRequired = false,
                // IsNullable = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "CodigoPais",
                EnglishName = "CountryCode",
                TestExample = "ES"
            },
            new EntityField
            {
                Name = "Telefono",
                Type = FieldType.String,
                Description = "Teléfono del alumno",
                Length = 50,
                IsRequired = false,
                // IsNullable = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.StartsWith,
                SpanishName = "Telefono",
                EnglishName = "Phone",
                TestExample = "+34666111222"
            },
            new EntityField
            {
                Name = "IdAlumnoIntegracion",
                Type = FieldType.Int,
                Description = "Identificador externo del alumno para integración",
                IsRequired = false,
                // IsNullable = true,
                SpanishName = "IdAlumnoIntegracion",
                EnglishName = "IntegrationStudentId",
                TestExample = "456"
            },
            new EntityField
            {
                Name = "Activo",
                Type = FieldType.Bool,
                Description = "Indica si el alumno está activo",
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Activo",
                EnglishName = "Active",
                TestExample = "true"
            }
        };

        return alumno;
    }
}
