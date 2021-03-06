using Newtonsoft.Json;
using System;

namespace DANMIS_NEW.Models.Public
{
    public class Config
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonIgnore]
        public Guid ID { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}