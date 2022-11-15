using Newtonsoft.Json;
using System.Text;

namespace AxiGroep_5
{
    public class SerializeHelper
    {
        /// <summary>
        /// Serializes any object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The serialized object.</returns>
        public static string Serielise(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes a serialized object.
        /// </summary>
        /// <typeparam name="ReceivedObjectType">The original type of the serialized object.</typeparam>
        /// <param name="serializedObject">The string to deserialize.</param>
        /// <returns>The deserialized objec</returns>
        public static ReceivedObjectType Deserieliase<ReceivedObjectType>(string serializedObject)
        {
            return JsonConvert.DeserializeObject<ReceivedObjectType>(serializedObject);
        }
    }
}
