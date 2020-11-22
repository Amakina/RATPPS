using Newtonsoft.Json;

namespace RATPPS1
{
    public class JSONParser
    {
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static string Serizalize<T>(T output)
        {
            return JsonConvert.SerializeObject(output);
        }
    }
}
