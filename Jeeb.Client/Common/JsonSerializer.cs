﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace Jeeb.Client.Common
{
    internal class JsonSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;

        public JsonSerializer()
        {
            ContentType = "application/json";
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

        }
        public string Serialize(object obj)
        {
            using (var writer = new StringWriter())
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    _serializer.Serialize(jsonWriter, obj);
                    var result = writer.ToString();
                    return result;
                }
            }
        }

        public string ContentType { get; set; }
    }
}
