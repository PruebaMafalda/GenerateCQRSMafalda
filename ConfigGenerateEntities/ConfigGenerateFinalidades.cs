using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateFinalidades
{
    public static GenerateParams GetConfig()
    {
        var config = new GenerateParams();
        config.GenerateOnlyModel = false;
        config.ConrollerRoute = "finalidades";
        config.AgregateModel = "Finalidades";
        config.SpanishName = "Finalidad";
        config.EnglishName = "Purpose";
        config.SingularName = "Finalidad";
        config.PluralName = "Finalidades";
        config.auditable = Auditable.Full;
        config.CrudTypes = new List<CrudType>
        {
            CrudType.Create,
            CrudType.Update,
            CrudType.GetByFilter
        };

        config.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador de la finalidad",
                IsPrimaryKey = true,
                IsAutoIncrement = true
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre de la finalidad",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "Nombre",
                EnglishName = "Name",
                TestExample = "Seguimiento académico"
            },
            new EntityField
            {
                Name = "Orden",
                Type = FieldType.Int,
                Description = "Orden de la finalidad",
                IsRequired = true,
                SpanishName = "Orden",
                EnglishName = "Order",
                TestExample = "1"
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
        };

        return config;
    }
}
