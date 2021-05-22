using Newtonsoft.Json;

namespace LogicSolver
{
    public class DataClass
    {
        [Generator(typeof(TestName))]
        [JsonProperty]
        public string Public { get; set; }

        // [Generator(typeof(TestName))]
        // [JsonProperty]
        // private string Private { get; set; }
        //
        // [Generator(typeof(TestName))]
        // [JsonProperty]
        // public string PublicPrivateSet { get; private set; }
        //
        // [Generator(typeof(TestName))]
        // [JsonProperty]
        // private string PrivateInit { get; init; }
        //
        // [Generator(typeof(TestName))]
        // [JsonProperty]
        // public string PublicField;
        //
        // [Generator(typeof(TestName))]
        // [JsonProperty]
        // private string PrivateField;
        //
        // [Generator(typeof(TestName))]
        // [JsonProperty]
        // private readonly string PrivateReadonlyField;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}