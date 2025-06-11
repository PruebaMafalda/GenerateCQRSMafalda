using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;

public class ConfigGenerateCasosPedidos
{
    public static GenerateParams GetConfig()
    {
        var config = new GenerateParams
        {
            GenerateOnlyModel = true,
            AgregateModel = "Casos",
            SpanishName = "Caso del pedido",
            EnglishName = "Case Orders",
            SingularName = "CasoPedido",
            PluralName = "CasosPedidos",
            auditable = Auditable.Create,
            CrudTypes = new List<CrudType>(), // Solo modelo
            Fields = new List<EntityField>
            {
                new EntityField
                {
                    Name = "Id",
                    Type = FieldType.Int,
                    Description = "Identificador del caso",
                    IsPrimaryKey = true,
                    IsAutoIncrement = false // Es el mismo que IdCaso
                },
                // new EntityField
                // {
                //     Name = "IdCaso",
                //     Type = FieldType.Int,
                //     Description = "Identificador del caso",
                //     IsRequired = true,
                //     IsForeignKey = true,
                //     ForeignKeyEntity = "Caso",
                //     ForeignKeyObject = "Caso",
                //     ForeignKeyTable = "Casos",
                //     ForeignKeyField = "Id",
                //     IsEspecification = true,
                //     EspecificationType = EspecificationType.Equal,
                //     SpanishName = "Id Caso",
                //     EnglishName = "Case Id",
                //     TestExample = "100"
                // },
                new EntityField
                {
                    Name = "IdPedido",
                    Type = FieldType.Int,
                    Description = "Identificador del pedido",
                    IsRequired = true,
                    IsForeignKey = true,
                    ForeignKeyEntity = "Pedido",
                    ForeignKeyObject = "Pedido",
                    ForeignKeyTable = "Pedidos",
                    ForeignKeyField = "Id",
                    IsEspecification = true,
                    EspecificationType = EspecificationType.Equal,
                    SpanishName = "Id Pedido",
                    EnglishName = "Order Id",
                    TestExample = "200"
                }
            }
        };

        return config;
    }
}
