﻿using Newtonsoft.Json;

namespace Sources.Utils.Data
{
    public class Vector2Data
    {
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }
    }
}