using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RATPPS1
{
    public class XMLParser
    {
        public static T Deserialize<T>(string input)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(input))
            {
                return (T)(serializer.Deserialize(reader));
            }
        }

        public static string Serizalize<T>(T output)
        {
            var serializer = new XmlSerializer(typeof(T));
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (StringWriter stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, output, emptyNamespaces);

                return stream.ToString();
            }
        }
    }
}
