using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;
public class ConfigGenerateCar
{
    public static GenerateParams GetConfig()
    {
        var car = new GenerateParams();
        car.SpanishName = "Coche";
        car.EnglishName = "Car";
        car.SingularName = "Car";
        car.PluralName = "Cars";
        car.auditable = Auditable.Full;
        car.CrudTypes = new List<CrudType> { CrudType.Create, CrudType.Update, CrudType.Delete, CrudType.GetById, CrudType.GetByFilter };
        car.Fields = new List<EntityField>
        {
            new EntityField
            {
                Name = "Id",
                Type = FieldType.Int,
                Description = "Id of the car",
                IsPrimaryKey = true,
                IsAutoIncrement = true,
            },
            new EntityField
            {
                Name = "Age",
                Type = FieldType.Int,
                Description = "Age of the car",
                IsRequired = true,
                SpanishName = "Anio",
                TestExample = "2024"
            },
            new EntityField
            {
                Name = "Model",
                Type = FieldType.String,
                Description = "Model of the car",
                Length = 100,
                IsRequired = true,
                IsEspecification = true,
                SpanishName = "Modelo",
                TestExample = "Tesla Model 3"
            },
            new EntityField
            {
                Name = "CarStatus",
                Type = FieldType.Enum,
                EnumClass = new EnumClass
                {
                    Name = "CarStatus",
                    IsPersistDB = false,
                    Description = "Status of the car",
                    Values = new List<EnumItem>
                    {
                        new EnumItem { Value = 1, Name = "New", Description = "New" },
                        new EnumItem { Value = 2, Name = "Used", Description = "Used" },
                        new EnumItem { Value = 3, Name = "Old", Description = "Old" }
                    }
                },
                Description = "Current status of the car",
                IsEspecification = true,
                EspecificationType = EspecificationType.Equal,
                TestExample = "New"
            },
            // new EntityField
            // {
            //     Name = "Color",
            //     Type = FieldType.Enum,
            //     EnumClass = new EnumClass
            //     {
            //         Name = "Color",
            //         FkName = "ColorId",
            //         IsPersistDB = true,
            //         Description = "Status of the car",
            //         Values = new List<EnumItem>
            //         {
            //             new EnumItem { Value = 1, Name = "Red", Description = "Red" },
            //             new EnumItem { Value = 2, Name = "Blue", Description = "Blue" },
            //             new EnumItem { Value = 3, Name = "Orange", Description = "Orange" }
            //         }
            //     },
            //     Description = "Identifier of the car's color",
            //     IsRequired = true,
            //     IsEspecification = true,
            //     EspecificationType = EspecificationType.Equal,
            //     TestExample = "Red"
            // },

            new EntityField
            {
                Name = "ColorId",
                Type = FieldType.Int,
                Description = "The identifier of the color to which the student is subscribed",
                IsForeignKey = true,
                ForeignKeyObject = "Color",
                ForeignKeyTable = "Colors",
                ForeignKeyField = "Id",
                IsRequired = true
            }
            
        };

        return car;
    }
}
