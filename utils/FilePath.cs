namespace GenerateCQRSMafalda.Utils;
// public class SpaceProject{
//     public string Location { get; set; }
//     public string FullPath { get{
//         var parts = Location.Split('.');
//         return Path.Combine(PathProject.Root, Path.Combine(parts));
//     } }
//     public string NameSpace { get{
//         return $"{PathProject.NameSpaceProject}.{Location}";
//     } }
//     public SpaceProject(string location){
//         Location = location;
//     }
// }

public class FilePathTest{
    public string Location { get; set; }
    public string FullPath { get{
        var parts = Location.Split('.');
        return Path.Combine(PathProject.RootTest, Path.Combine(parts));
    } }
    public string NameSpace { get{
        return $"{PathProject.NameSpaceProject}.Tests.{Location}";
    } }

}

