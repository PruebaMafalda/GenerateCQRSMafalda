using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateEtapas
{
    public static GenerateParams GetConfig()
    {
        var etapa = new GenerateParams();
        etapa.GenerateOnlyModel = false;
        etapa.ConrollerRoute = "etapas";
        etapa.AgregateModel = "Etapas";
        etapa.SpanishName = "Etapa";
        etapa.EnglishName = "Stage";
        etapa.SingularName = "Etapa";
        etapa.PluralName = "Etapas";
        etapa.auditable = Auditable.Full;
        etapa.CrudTypes = new List<CrudType>
        {
            CrudType.Update,
            CrudType.GetByFilter
        };
        etapa.Fields = new List<EntityField>
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
                Name = "Codigo",
                Type = FieldType.String,
                Description = "Codigo de la etapa",
                Length = 30,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "Codigo",
                EnglishName = "Code",
                TestExample = "Etapa1"
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre de la etapa",
                Length = 50,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Contains,
                SpanishName = "Nombre",
                EnglishName = "Name",
                TestExample = "Etapa 1"
            },
            new EntityField
            {
                Name = "Fase",
                Type = FieldType.Int,
                Description = "Número de fase de la etapa",
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Fase",
                EnglishName = "Phase",
                TestExample = "1"
            },
            new EntityField
            {
                Name = "Color",
                Type = FieldType.String,
                Description = "Color asociado a la etapa",
                Length = 10,
                IsRequired = true,
                SpanishName = "Color",
                EnglishName = "Color",
                TestExample = "#FF0000"
            },
            new EntityField
            {
                Name = "Activo",
                Type = FieldType.Bool,
                Description = "Indica si la etapa está activa",
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Activo",
                EnglishName = "Active",
                TestExample = "true"
            },
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
        };

        return etapa;
    }
}
