using GenerateCQRSMafalda.Utils;
namespace GenerateCQRSMafalda.App.GenerateApplication;
public class GenerateResourcesContent : GenerateBase
{
  public string GetGenerateResourcesEnglish(GenerateParams model)
  {
    var uniqueFields = model.Fields.Where(f => f.IsUnique).ToList();
    var messages = new List<Tuple<string, string>>();
    foreach (var field in uniqueFields)
    {
      messages.Add(new Tuple<string, string>($"Duplicated{field.Name}", $"There is already a {model.EnglishName} with the same {field.EnglishName}"));
    }
    var content = GetGenerateResources(messages);
    return content;
  }
  public string GetGenerateResourcesSpanish(GenerateParams model)
  {
    var uniqueFields = model.Fields.Where(f => f.IsUnique).ToList();
    var messages = new List<Tuple<string, string>>();
    foreach (var field in uniqueFields)
    {
      messages.Add(new Tuple<string, string>($"Duplicated{field.Name}", $"Ya existe un {model.SpanishName} con el mismo {field.SpanishName}"));
    }
    var content = GetGenerateResources(messages);
    return content;
  }
  private string GetGenerateResources(List<Tuple<string, string>> messages)
  {
    var content = $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{_singlelb}";
    content += $"<root>{_singlelb}";
    content += $"{_space}<!--{_singlelb}";
    content += $"{_space}Microsoft ResX Schema{_singlelb}";
    content += $"{_space}Version 2.0{_singlelb}";
    content += $"{_space}The primary goals of this format is to allow a simple XML format{_singlelb}";
    content += $"{_space}that is mostly human readable. The generation and parsing of the{_singlelb}";
    content += $"{_space}various data types are done through the TypeConverter classes{_singlelb}";
    content += $"{_space}associated with the data types.{_singlelb}";
    content += $"{_space}Example:{_singlelb}";
    content += $"{_space}... ado.net/XML headers & schema ...{_singlelb}";
    content += $"{_space}<resheader name=\"resmimetype\">text/microsoft-resx</resheader>{_singlelb}";
    content += $"{_space}<resheader name=\"version\">2.0</resheader>{_singlelb}";
    content += $"{_space}<resheader name=\"reader\">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>{_singlelb}";
    content += $"{_space}<resheader name=\"writer\">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>{_singlelb}";
    content += $"{_space}<data name=\"Name1\"><value>this is my long string</value><comment>this is a comment</comment></data>{_singlelb}";
    content += $"{_space}<data name=\"Color1\" type=\"System.Drawing.Color, System.Drawing\">Blue</data>{_singlelb}";
    content += $"{_space}<data name=\"Bitmap1\" mimetype=\"application/x-microsoft.net.object.binary.base64\">{_singlelb}";
    content += $"{_space}    <value>[base64 mime encoded serialized .NET Framework object]</value>{_singlelb}";
    content += $"{_space}</data>{_singlelb}";
    content += $"{_space}<data name=\"Icon1\" type=\"System.Drawing.Icon, System.Drawing\" mimetype=\"application/x-microsoft.net.object.bytearray.base64\">{_singlelb}";
    content += $"{_space}    <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>{_singlelb}";
    content += $"{_space}    <comment>This is a comment</comment>{_singlelb}";
    content += $"{_space}</data>{_singlelb}";
    content += $"{_space}There are any number of \"resheader\" rows that contain simple{_singlelb}";
    content += $"{_space}name/value pairs.{_singlelb}";
    content += $"{_space}Each data row contains a name, and value. The row also contains a{_singlelb}";
    content += $"{_space}type or mimetype. Type corresponds to a .NET class that support{_singlelb}";
    content += $"{_space}text/value conversion through the TypeConverter architecture.{_singlelb}";
    content += $"{_space}Classes that don't support this are serialized and stored with the{_singlelb}";
    content += $"{_space}mimetype set.{_singlelb}";
    content += $"{_space}The mimetype is used for serialized objects, and tells the{_singlelb}";
    content += $"{_space}ResXResourceReader how to depersist the object. This is currently not{_singlelb}";
    content += $"{_space}extensible. For a given mimetype the value must be set accordingly:{_singlelb}";
    content += $"{_space}Note - application/x-microsoft.net.object.binary.base64 is the format{_singlelb}";
    content += $"{_space}that the ResXResourceWriter will generate, however the reader can{_singlelb}";
    content += $"{_space}read any of the formats listed below.{_singlelb}";
    content += $"{_space}mimetype: application/x-microsoft.net.object.binary.base64{_singlelb}";
    content += $"{_space}value   : The object must be serialized with{_singlelb}";
    content += $"{_space}        : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter{_singlelb}";
    content += $"{_space}        : and then encoded with base64 encoding.{_singlelb}";
    content += $"{_space}mimetype: application/x-microsoft.net.object.soap.base64{_singlelb}";
    content += $"{_space}value   : The object must be serialized with{_singlelb}";
    content += $"{_space}        : System.Runtime.Serialization.Formatters.Soap.SoapFormatter{_singlelb}";
    content += $"{_space}        : and then encoded with base64 encoding.{_singlelb}";
    content += $"{_space}mimetype: application/x-microsoft.net.object.bytearray.base64{_singlelb}";
    content += $"{_space}value   : The object must be serialized into a byte array{_singlelb}";
    content += $"{_space}        : using a System.ComponentModel.TypeConverter{_singlelb}";
    content += $"{_space}        : and then encoded with base64 encoding.{_singlelb}";
    content += $"{_space}-->{_singlelb}";
    content += $"{_space}<xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">{_singlelb}";
    content += $"{_space}  <xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />{_singlelb}";
    content += $"{_space}  <xsd:element name=\"root\" msdata:IsDataSet=\"true\">{_singlelb}";
    content += $"{_space}    <xsd:complexType>{_singlelb}";
    content += $"{_space}      <xsd:choice maxOccurs=\"unbounded\">{_singlelb}";
    content += $"{_space}        <xsd:element name=\"metadata\">{_singlelb}";
    content += $"{_space}          <xsd:complexType>{_singlelb}";
    content += $"{_space}            <xsd:sequence>{_singlelb}";
    content += $"{_space}              <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" />{_singlelb}";
    content += $"{_space}            </xsd:sequence>{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"name\" use=\"required\" type=\"xsd:string\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"type\" type=\"xsd:string\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"mimetype\" type=\"xsd:string\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute ref=\"xml:space\" />{_singlelb}";
    content += $"{_space}          </xsd:complexType>{_singlelb}";
    content += $"{_space}        </xsd:element>{_singlelb}";
    content += $"{_space}        <xsd:element name=\"assembly\">{_singlelb}";
    content += $"{_space}          <xsd:complexType>{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"alias\" type=\"xsd:string\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"name\" type=\"xsd:string\" />{_singlelb}";
    content += $"{_space}          </xsd:complexType>{_singlelb}";
    content += $"{_space}        </xsd:element>{_singlelb}";
    content += $"{_space}        <xsd:element name=\"data\">{_singlelb}";
    content += $"{_space}          <xsd:complexType>{_singlelb}";
    content += $"{_space}            <xsd:sequence>{_singlelb}";
    content += $"{_space}              <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />{_singlelb}";
    content += $"{_space}              <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />{_singlelb}";
    content += $"{_space}            </xsd:sequence>{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />{_singlelb}";
    content += $"{_space}            <xsd:attribute ref=\"xml:space\" />{_singlelb}";
    content += $"{_space}          </xsd:complexType>{_singlelb}";
    content += $"{_space}        </xsd:element>{_singlelb}";
    content += $"{_space}        <xsd:element name=\"resheader\">{_singlelb}";
    content += $"{_space}          <xsd:complexType>{_singlelb}";
    content += $"{_space}            <xsd:sequence>{_singlelb}";
    content += $"{_space}              <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />{_singlelb}";
    content += $"{_space}            </xsd:sequence>{_singlelb}";
    content += $"{_space}            <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />{_singlelb}";
    content += $"{_space}          </xsd:complexType>{_singlelb}";
    content += $"{_space}        </xsd:element>{_singlelb}";
    content += $"{_space}      </xsd:choice>{_singlelb}";
    content += $"{_space}    </xsd:complexType>{_singlelb}";
    content += $"{_space}  </xsd:element>{_singlelb}";
    content += $"</xsd:schema>{_singlelb}";
    content += $"<resheader name=\"resmimetype\">{_singlelb}";
    content += $"{_space}<value>text/microsoft-resx</value>{_singlelb}";
    content += $"</resheader>{_singlelb}";
    content += $"<resheader name=\"version\">{_singlelb}";
    content += $"{_space}<value>2.0</value>{_singlelb}";
    content += $"</resheader>{_singlelb}";
    content += $"<resheader name=\"reader\">{_singlelb}";
    content += $"{_space}<value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>{_singlelb}";
    content += $"</resheader>{_singlelb}";
    content += $"<resheader name=\"writer\">{_singlelb}";
    content += $"{_space}<value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>{_singlelb}";
    content += $"</resheader>{_singlelb}";

    foreach (var message in messages)
    {
      content += $"<data name=\"{message.Item1}\" xml:space=\"preserve\">{_singlelb}";
      content += $"{_space}<value>{message.Item2}</value>{_singlelb}";
      content += $"</data>{_singlelb}";
    }
    content += $"</root>{_singlelb}";
    return content;

  }
}