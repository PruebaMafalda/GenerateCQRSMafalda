using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;
public class ConfigGeneratePedidos
{
    public static GenerateParams GetConfig()
    {
        var pedido = new GenerateParams();
        pedido.SpanishName = "Pedido";
        pedido.AgregateModel = "Pedidos";
        pedido.EnglishName = "Order";
        pedido.SingularName = "Pedido";
        pedido.PluralName = "Pedidos";
        pedido.auditable = Auditable.Create;
        pedido.CrudTypes = new List<CrudType> { CrudType.Create, CrudType.GetById, CrudType.GetByFilter };
        pedido.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Identificador del Pedido",
                IsPrimaryKey = true,
                IsAutoIncrement = true,
            },
            new EntityField
            {
                Name = "CodigoCliente",
                Type = FieldType.String,
                Description = "Código del cliente",
                Length = 50,
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Código Cliente",
                TestExample = "CLI123456"
            },
            new EntityField
            {
                Name = "IdMatriculaIntegracion",
                Type = FieldType.Int,
                Description = "Id de integración de matrícula",
                IsUnique = true,
                IsRequired = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Id Matrícula Integración",
                EnglishName = "Enrollment Integration Id",
                TestExample = "1001"
            },
            new EntityField
            {
                Name = "IdAlumnoIntegracion",
                Type = FieldType.Int,
                Description = "Id de integración de alumno",
                IsEspecification = true,
                IsRequired = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Id Alumno Integración",
                TestExample = "2001"
            },
            new EntityField
            {
                Name = "IdEstadoPedido",
                Type = FieldType.Int,
                Description = "Estado del pedido",
                
                IsForeignKey = true,
                ForeignKeyObject = "EstadoPedido",
                ForeignKeyTable = "EstadosPedido",
                ForeignKeyField = "Id",

                IsEspecification = true,
                IsRequired = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Estado Pedido",
                TestExample = "1"
            },
            
            new EntityField
            {
                Name = "IdAgenteAsignado",
                Type = FieldType.Int,                
                Description = "Id del agente asignado",
                IsNullable = true,
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Id Agente Asignado",
                TestExample = "3001"
            },
            new EntityField
            {
                Name = "IdUsuarioActualizacion",
                Type = FieldType.Int,
                Description = "Id del usuario que actualizó",
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                SpanishName = "Id Usuario Actualización",
                TestExample = "4001"
            },
            new EntityField
            {
                Name = "FechaActualizacion",
                Type = FieldType.DateTime,
                Description = "Fecha de última actualización",
                IsEspecification = true,
                EspecificationType = EspecificationType.GreaterThanOrEqual,
                SpanishName = "Fecha Actualización",
                TestExample = "2024-01-01"
            }
        };

        return pedido;
    }
}
