using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateAgentes
{
    public static GenerateParams GetConfig()
    {
        var agente = new GenerateParams();
        agente.GenerateOnlyModel = false;
        agente.ConrollerRoute = "agentes";
        agente.AgregateModel = "Agentes";
        agente.SpanishName = "Agente";
        agente.EnglishName = "Agent";
        agente.SingularName = "Agente";
        agente.PluralName = "Agentes";
        agente.auditable = Auditable.Full;
        agente.HasLogicDeleted = true;
        agente.CrudTypes = new List<CrudType>
        {
            CrudType.Create,
            CrudType.Update,
            CrudType.GetById,
            CrudType.GetByFilter
        };
        agente.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador del agente",
                IsPrimaryKey = true,
                IsAutoIncrement = true
            },
            new EntityField
            {
                Name = "IdEmpleado",
                Type = FieldType.Int,
                Description = "Identificador del empleado asociado",
                IsRequired = true,
                SpanishName = "IdEmpleado",
                EnglishName = "EmployeeId",
                TestExample = "123"
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre del agente",
                Length = 200,
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Nombre",
                EnglishName = "FirstName",
                TestExample = "Juan"
            },
            new EntityField
            {
                Name = "Apellidos",
                Type = FieldType.String,
                Description = "Apellidos del agente",
                Length = 200,
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Apellidos",
                EnglishName = "LastName",
                TestExample = "Pérez García"
            },
            new EntityField
            {
                Name = "Email",
                Type = FieldType.String,
                Description = "Correo electrónico principal",
                Length = 200,
                IsRequired = true,
                IsUnique = true,
                IsEspecification = true,
                SpanishName = "Email",
                EnglishName = "Email",
                TestExample = "agente@empresa.com"
            },
            new EntityField
            {
                Name = "CorreoDefault",
                Type = FieldType.String,
                Description = "Correo electrónico por defecto",
                Length = 200,
                IsRequired = false,
                IsEspecification = true,
                SpanishName = "CorreoDefault",
                EnglishName = "DefaultEmail",
                TestExample = "default@empresa.com"
            },
            new EntityField
            {
                Name = "TimeZone",
                Type = FieldType.String,
                Description = "Zona horaria del agente",
                Length = 50,
                IsRequired = false,
                IsEspecification = true,
                EspecificationType = EspecificationType.StartsWith,
                SpanishName = "ZonaHoraria",
                EnglishName = "TimeZone",
                TestExample = "Europe/Madrid"
            },
            new EntityField
            {
                Name = "Activo",
                Type = FieldType.Bool,
                Description = "Indica si el agente está activo",
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Activo",
                EnglishName = "Active",
                TestExample = "true"
            }
        };

        return agente;
    }
}
