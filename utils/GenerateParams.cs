namespace GenerateCQRSMafalda.Utils;
public class GenerateParams
{
    public string SpanishName { get; set; }
    public string EnglishName { get; set; }
    public string SingularName { get; set; }
    public string PluralName { get; set; }
    public string Description { get; set; }
    public bool GenerateOnlyModel { get; set; } = false;
    public string AgregateModel { get; set; }
    public string ConrollerRoute { get; set; }
    public bool HasLogicDeleted { get; set; } = false;
    public Auditable? auditable { get; set; }
    public List<EntityField> Fields { get; set; }
    public List<CrudType> CrudTypes { get; set; }
    public string PluralNameCamelCase {
        get{
            return char.ToLower(PluralName[0]) + PluralName.Substring(1);
        }
    }
    public string SingularNameCamelCase {
        get{
            return char.ToLower(SingularName[0]) + SingularName.Substring(1);
        }
    }
}

public class EntityField
{
    public string Name { get; set; }
    public string Description { get; set; }
    public FieldType Type { get; set; }
    public EnumClass EnumClass { get; set; }
    public int Length { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNullable { get; set; }
    public bool IsPrimaryKey { get; set; }
    public bool IsAutoIncrement { get; set; }
    public bool IsAuditField { get; set; }
    public bool isCreatedBy { get; set; }
    public bool isCreatedAt { get; set; }
    public bool isUpdateBy { get; set; }
    public bool isUpdatedAt { get; set; }
    public bool IsLogicDeleted { get; set; }
    public bool IsUnique { get; set; }
    public string SpanishName { get; set; }
    public string EnglishName { get; set; }
    public string TestExample { get; set; }
    public bool IsForeignKey { get; set; }
    public string ForeignKeyEntity { get; set; }
    public string ForeignKeyObject { get; set; }
    public string ForeignKeyTable { get; set; }
    public string ForeignKeyField { get; set; }
    public bool IsEspecification { get; set; }
    public EspecificationType EspecificationType { get; set; }
    public string TypeToString {
        get{
            switch (Type) {
                case FieldType.String:
                    return "string";
                case FieldType.Int:
                    return "int";
                case FieldType.BigInt:
                    return "long";
                case FieldType.Decimal: 
                    return "decimal";
                case FieldType.Double:
                    return "double";
                case FieldType.Float:   
                    return "float";
                case FieldType.DateTime:
                    return "DateTime";
                case FieldType.Bool:
                    return "bool";
                case FieldType.Guid:
                    return "Guid";
                case FieldType.Enum:
                    return EnumClass.Name;
                default:    
                    return "string";
            }
        }
    }

    public string NameCamelCase {
        get{
            return char.ToLower(Name[0]) + Name.Substring(1);
        }
    }
}
public class EnumClass
{
    public string Name { get; set; }
    public bool IsPersistDB { get; set; }
    public string FkName { get; set; }
    public string Description { get; set; }
    public List<EnumItem> Values { get; set; }
}

public class EnumItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
}


public enum CrudType{
    Create,
    Update,
    Delete,
    GetByFilter,
    GetById,
}

public enum FieldType{
    String,
    Int,
    BigInt,
    Decimal,
    Double,
    Float,
    DateTime,
    Bool,
    Guid,
    Enum
}

public enum EspecificationType{
    Equal,
    NotEqual,
    GreaterThan,
    LessThan,
    GreaterThanOrEqual,
    LessThanOrEqual,
    Contains,
    StartsWith,
    EndsWith,
    In,
    NotIn,
    Between,
    NotBetween,
    IsNull,
    IsNotNull,
    IsEmpty,
    IsNotEmpty,
    And,
    Or,
    Not
}

public enum Auditable{
    Full,
    Create
}