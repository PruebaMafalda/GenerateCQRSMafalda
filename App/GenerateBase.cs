using GenerateCQRSMafalda.Utils;

namespace GenerateCQRSMafalda.App;
public class GenerateBase
{
    public string NameSpaceProject = "Core.AtencionEstudiante.Be";
    public string _space = "    "; // 4 spaces
    public string _singlelb = "\n";
    public string _doublelb = "\n\n";
    public string _opencb = "{";
    public string _closecb = "}";
    public int ONE_SPACE = 1;
    public int TWO_SPACE = 1;
    public int THREE_SPACE = 1;
    public int FOURS_SPACE = 1;
    public int FIVE_SPACE = 1;

    //    public string SPACE = "    "; // 4 spaces
    // public string SINGLE_LB = "\n";
    // public string DOUBLE_LB = "\n\n";
    // public string OPEN_CB = "{";
    // public string CLOSE_CB = "}";


    // public string _space = "    "; // 4 spaces
    // public string _singlelb = "\n";
    // public string _doublelb = "\n\n";
    // public string _opencb = "{";
    // public string _closecb = "}";

    public string GetCharNullable(EntityField field)
    {
        return field.IsNullable && field.Type!= FieldType.String ? "?" : string.Empty;
    }
    public string GetSummaryField(string description, int spaces)
    {
        //return string.Empty;
        var identation = string.Concat(Enumerable.Repeat(_space, spaces));    
        return $"{identation}/// <summary>{description}.</summary>{_singlelb}";
    }
    // public string GetSummaryClass(string description, int spaces)
    // {
    //     return $"{_space}/// <summary>{description}.</summary>{_singlelb}";
    // }    
    public string GetSummaryMethod(string description, int spaces)
    {
        var identation = string.Concat(Enumerable.Repeat(_space, spaces));    
        return $"{identation}/// <summary>{description}.</summary>{_singlelb}";
    }
}