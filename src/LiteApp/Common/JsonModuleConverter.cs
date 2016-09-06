using LiteApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var type = (string)jObject.Property("Type");
            switch (type)
            {
                case "HtmlModule":
                    return new HtmlModule();
                case "ContactModule":
                    return new ContactModule();
            }

            throw new Exception(String.Format("The given vehicle type {0} is not supported!", type));
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
