using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateProcesos
{
    public static GenerateParams GetConfig()
    {
        var proceso = new GenerateParams();
        proceso.GenerateOnlyModel = false;
        proceso.ConrollerRoute = "procesos";
        proceso.AgregateModel = "Procesos";
        proceso.SpanishName = "Proceso";
        proceso.EnglishName = "Process";
        proceso.SingularName = "Proceso";
        proceso.PluralName = "Procesos";
        proceso.auditable = Auditable.Full;
        proceso.CrudTypes = new List<CrudType>
        {
            CrudType.Update,
            CrudType.GetById,
            CrudType.GetByFilter
        };
        proceso.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador del proceso",
                IsPrimaryKey = true,
                IsAutoIncrement = false, // No autoincremental
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre del proceso",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "Nombre",
                EnglishName = "Name",
                TestExample = "Proceso 1"
            },
            new EntityField
            {
                Name = "Titulo",
                Type = FieldType.String,
                Description = "Título del proceso",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "Titulo",
                EnglishName = "Title",
                TestExample = "Proceso de Facturación"
            },
            new EntityField
            {
                Name = "TituloAbreviado",
                Type = FieldType.String,
                Description = "Título abreviado del proceso",
                Length = 50,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "TituloAbreviado",
                EnglishName = "ShortTitle",
                TestExample = "Facturación"
            },
            new EntityField
            {
                Name = "Activo",
                Type = FieldType.Bool,
                Description = "Indica si el proceso está activo",
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Activo",
                EnglishName = "Active",
                TestExample = "true"
            }
        };

        return proceso;
    }
}
