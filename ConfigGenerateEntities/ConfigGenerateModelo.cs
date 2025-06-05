using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;
public class ConfigGenerateModelo
{
    public static GenerateParams GetConfig()
    {
        var car = new GenerateParams();
        car.GenerateOnlyModel = false;
        car.AgregateModel = "Cars";
        car.SpanishName = "ModeloCoche";
        car.EnglishName = "CarModel";
        car.SingularName = "ModeloCoche";
        car.PluralName = "ModelosCoche";
        car.auditable = Auditable.Full;
        car.CrudTypes = new List<CrudType> { CrudType.Create, CrudType.Update, CrudType.Delete, CrudType.GetById, CrudType.GetByFilter };
        car.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Id del modelo de coche",
                IsPrimaryKey = true,
                IsAutoIncrement = true,
            },
            new EntityField
            {
                Name = "Codigo",
                Type = FieldType.String,
                Description = "Codigo del modelo de coche",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Codigo",
                EnglishName = "Code",
                TestExample = "RAN-1234"
            },
            new EntityField
            {
                Name = "Nombre",
                Type = FieldType.String,
                Description = "Nombre del modelo de coche",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Nombre",
                EnglishName = "Name",
                TestExample = "Model 3"
            }
            
        };

        return car;
    }
}
