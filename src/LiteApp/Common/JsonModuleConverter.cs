using LiteApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LiteApp.Common
{
    public class JsonModuleConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Module>
    {
        public override Module Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public Module Create(Type objectType, JObject jObject)
        {
            // Instansiate module with the given type
            return Activator.CreateInstance(Type.GetType($"{typeof(Module).Namespace}.{(string)jObject.Property("Type")}")) as Module;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            var target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }

}
