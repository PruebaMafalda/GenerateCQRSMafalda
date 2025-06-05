using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;
public class ConfigGeneratePedidosContactosMotivos
{
    public static GenerateParams GetConfig()
    {
        var car = new GenerateParams();
        car.GenerateOnlyModel = false;
        car.AgregateModel = "Pedidos";
        car.SpanishName = "PedidosContactosMotivos";
        car.EnglishName = "OrderContactMotives";
        car.SingularName = "PedidoContactoMotivo";
        car.PluralName = "PedidosContactosMotivos";
        car.auditable = Auditable.Full;
        car.CrudTypes = new List<CrudType> { CrudType.Create, CrudType.Update, CrudType.Delete, CrudType.GetById, CrudType.GetByFilter };
        car.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Id del motivo de contacto",
                IsPrimaryKey = true,
                IsAutoIncrement = true,
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre del motivo de contacto",
                Length = 100,
                IsRequired = true,
                IsUnique = true,
                IsEspecification = true,
                SpanishName = "Nombre",
                EnglishName = "Name",
                TestExample = "Primer contacto"
            }
        };

        return car;
    }
}
