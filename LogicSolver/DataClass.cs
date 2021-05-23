using Newtonsoft.Json;

namespace LogicSolver
{
    public class DataClass
    {
        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        public string Public { get; set; }

        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        private string Private { get; set; }
        
        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        public string PublicPrivateSet { get; private set; }
        
        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        private string PrivateInit { get; init; }
        
        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        public string PublicField;
        
        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        private string PrivateField;
        
        [Generator(typeof(NameGenerator))]
        [JsonProperty]
        private readonly string PrivateReadonlyField;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}