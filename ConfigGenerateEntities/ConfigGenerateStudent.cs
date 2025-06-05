using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.ConfigGenerateEntities;
public class ConfigGenerateStudent
{
    public static GenerateParams GetConfig()
    {
        var student = new GenerateParams();
        student.SpanishName = "Estudiante";
        student.EnglishName = "Student";
        student.SingularName = "Student";
        student.PluralName = "Students";
        student.auditable = Auditable.Full;
        student.CrudTypes = new List<CrudType> { CrudType.Create, CrudType.Update, CrudType.Delete, CrudType.GetById, CrudType.GetByFilter };
        student.Fields = new List<EntityField>
                {
                    new EntityField
                    {
                        Name = "Id",
                        Type = FieldType.Int,
                        Description = "Id of Student",
                        IsPrimaryKey = true,
                        IsAutoIncrement = true,
                    },
                    new EntityField
                    {
                        Name = "FirstName",
                        Type = FieldType.String,
                        Description = "First name of the student",
                        Length = 100,
                        IsRequired = true,
                        IsEspecification = true,
                        EspecificationType = EspecificationType.Contains,
                        SpanishName = "Nombre",
                        TestExample = "Robert"
                    },
                    new EntityField
                    {
                        Name = "FirstLastName",
                        Type = FieldType.String,
                        Description = "First last name of the student",
                        Length = 100,
                        TestExample = "Jackson"
                    },
                    new EntityField
                    {
                        Name = "SecondLastName",
                        Type = FieldType.String,
                        Description = "Second last name of the student",
                        Length = 100,
                        TestExample = "Smith"
                    },
                    new EntityField
                    {
                        Name = "DocumentType",
                        Type = FieldType.Enum,
                        EnumClass = new EnumClass(){
                            Name = "DocumentType",
                            IsPersistDB=true,
                            Description = "Type of identification document",
                            Values = new List<EnumItem>{
                                new EnumItem(){Value = 1 , Name="DNI", Description = "DNI"},
                                new EnumItem(){Value = 2 , Name="NIE", Description = "NIE"},
                                new EnumItem(){Value = 3 , Name="Passport", Description = "Passport"}
                            }
                        },
                        Description = "Type of identification document",
                        Length = 30,
                        IsEspecification = true,
                        EspecificationType = EspecificationType.Equal,
                        TestExample = "DNI"
                    },
                    new EntityField
                    {
                        Name = "Nif",
                        Type = FieldType.String,
                        Description = "National identification number",
                        Length = 20,
                        IsEspecification = true,
                        EspecificationType = EspecificationType.Equal,
                        IsUnique = true,
                        SpanishName = "NIF",
                        EnglishName = "NIF",
                        TestExample="12345678A"

                    },
                    new EntityField
                    {
                        Name = "DateOfBirth",
                        Type = FieldType.DateTime,
                        Description = "student's date of birth",
                        IsEspecification = true,
                        EspecificationType = EspecificationType.Equal,
                        TestExample = "1990-01-01"
                    },
                    // new EntityField
                    // {
                    //     Name = "Age",
                    //     Type = FieldType.Int,
                    //     Description = "Age of the student",
                    //     IsNullable = true
                    // },
                    new EntityField
                    {
                        Name = "Gender",
                        Type = FieldType.Enum,
                        EnumClass = new EnumClass(){
                            Name = "GenderType",
                            IsPersistDB = false,
                            Description = "Type of Gender",
                            Values = new List<EnumItem>{
                                new EnumItem(){Value=1, Name="Male", Description = "Male"},
                                new EnumItem(){Value=2, Name="Femail", Description = "Femail"}
                            }
                        },
                        Description = "Gender of the student",
                        Length = 10,
                        TestExample = "Male"
                    },
                    new EntityField
                    {
                        Name = "Address",
                        Type = FieldType.String,
                        Description = "Street address of the student",
                        Length = 100,
                        TestExample = "Calle Mayor"
                    },
                    new EntityField
                    {
                        Name = "StreetNumber",
                        Type = FieldType.String,
                        Description = "Street number of the address",
                        Length = 10,
                        TestExample = "1"
                    },
                    new EntityField
                    {
                        Name = "Floor",
                        Type = FieldType.String,
                        Description = "Floor number of the address",
                        Length = 5,
                        TestExample = "1"
                    },
                    new EntityField
                    {
                        Name = "Locality",
                        Type = FieldType.String,
                        Description = "Locality where the student lives",
                        Length = 50,
                        TestExample = "Madrid"
                    },
                    new EntityField
                    {
                        Name = "Province",
                        Type = FieldType.String,
                        Description = "Province or state of residence",
                        Length = 50,
                        TestExample = "Madrid"
                    },

                    new EntityField
                    {
                        Name = "Email",
                        Type = FieldType.String,
                        Description = "Email address of the student",
                        Length = 200,
                        IsEspecification = true,
                        EspecificationType = EspecificationType.Equal,
                        TestExample = "robert@gmail.com"
                    },
                    new EntityField
                    {
                        Name = "Zip",
                        Type = FieldType.String,
                        Description = "Postal code of the address",
                        Length = 10,
                        TestExample = "28001"
                    },
                    new EntityField
                    {
                        Name = "PhoneNumber",
                        Type = FieldType.String,
                        Description = "Phone number of the student",
                        Length = 30,
                        TestExample = "912345678"
                    },
                    new EntityField
                    {
                        Name = "MobilePhone",
                        Type = FieldType.String,
                        Description = "Mobile phone number of the student",
                        Length = 30,
                        TestExample = "666777888"
                    },

                    new EntityField
                    {
                        Name = "PlanId",
                        Type = FieldType.Int,
                        Description = "The identifier of the plan to which the student is subscribed",
                        IsForeignKey = true,
                        ForeignKeyObject = "Plan",
                        ForeignKeyTable = "Plans",
                        ForeignKeyField = "Id",
                        IsRequired = true
                    }
                    
                };

        return student;
    }

}

