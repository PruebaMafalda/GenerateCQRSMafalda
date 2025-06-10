using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateAcciones
{
    public static GenerateParams GetConfig()
    {
        var accion = new GenerateParams();
        accion.GenerateOnlyModel = false;
        accion.ConrollerRoute = "acciones";
        accion.AgregateModel = "Acciones";
        accion.SpanishName = "Accion";
        accion.EnglishName = "Action";
        accion.SingularName = "Accion";
        accion.PluralName = "Acciones";
        accion.auditable = Auditable.Full;
        accion.CrudTypes = new List<CrudType>
        {
            CrudType.Create,
            CrudType.GetById,
            CrudType.GetByFilter
        };

        accion.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador de la acción",
                IsPrimaryKey = true,
                IsAutoIncrement = true,
                SpanishName = "Id",
                EnglishName = "Id"
            },
            new EntityField
            {
                Name = "IdAlumnoInfo",
                Type = FieldType.Int,
                Description = "Identificador del alumno",
                IsRequired = false,
                IsForeignKey = true,
                ForeignKeyObject = "AlumnoInfo",
                ForeignKeyTable = "AlumnosInfo",
                IsEspecification = true,
                SpanishName = "Alumno",
                EnglishName = "Student",
                TestExample = "123"
            },
            new EntityField
            {
                Name = "IdOrigenAtencion",
                Type = FieldType.Int,
                Description = "Identificador del origen de atención",
                IsRequired = true,
                IsForeignKey = true,
                ForeignKeyObject = "OrigenAtencion",
                ForeignKeyTable = "OrigenesAtencion",
                IsEspecification = true,
                SpanishName = "Origen de Atención",
                EnglishName = "Origin of Attention",
                TestExample = "1"
            },
            new EntityField
            {
                Name = "IdFinalidad",
                Type = FieldType.Int,
                Description = "Identificador de la finalidad",
                IsRequired = false,
                IsForeignKey = true,
                ForeignKeyObject = "Finalidad",
                ForeignKeyTable = "Finalidades",
                IsEspecification = true,
                SpanishName = "Finalidad",
                EnglishName = "Purpose",
                TestExample = "5"
            },
            new EntityField
            {
                Name = "IdCaso",
                Type = FieldType.Int,
                Description = "Identificador del caso",
                IsRequired = false,
                IsForeignKey = true,
                ForeignKeyObject = "Caso",
                ForeignKeyTable = "Casos",
                IsEspecification = true,
                SpanishName = "Caso",
                EnglishName = "Case",
                TestExample = "77"
            },
            new EntityField
            {
                Name = "IdGrupo",
                Type = FieldType.Int,
                Description = "Identificador del grupo",
                IsRequired = false,
                IsForeignKey = true,
                ForeignKeyObject = "Grupo",
                ForeignKeyTable = "Grupos",
                IsEspecification = true,
                SpanishName = "Grupo",
                EnglishName = "Group",
                TestExample = "12"
            },
            new EntityField
            {
                Name = "Observacion",
                Type = FieldType.String,
                Description = "Observaciones sobre la acción",
                Length = 1000,
                IsRequired = false,
                SpanishName = "Observación",
                EnglishName = "Observation",
                TestExample = "Se hizo seguimiento telefónico."
            },
            new EntityField
            {
                Name = "FechaApertura",
                Type = FieldType.DateTime,
                Description = "Fecha en la que se abrió la acción",
                IsRequired = false,
                SpanishName = "Fecha de Apertura",
                EnglishName = "Opening Date",
                TestExample = "2025-06-10T10:00:00"
            },
            new EntityField
            {
                Name = "TiempoPausa",
                Type = FieldType.Int,
                Description = "Duración de pausa en minutos",
                IsRequired = false,
                SpanishName = "Tiempo de Pausa",
                EnglishName = "Pause Time",
                TestExample = "15"
            },
            new EntityField
            {
                Name = "Anulado",
                Type = FieldType.Bool,
                Description = "Indica si la acción fue anulada",
                IsRequired = true,
                SpanishName = "Anulado",
                EnglishName = "Canceled",
                TestExample = "false"
            }
        };

        return accion;
    }
}
