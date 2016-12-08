using Newtonsoft.Json;

namespace TB.Webb.Models
{
    public class ResumeContactInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        //[JsonProperty("resume_id")]
        //public int ResumeId { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("phone2")]
        public string Phone2 { get; set; }

        [JsonProperty("phone3")]
        public string Phone3 { get; set; }

        [JsonProperty("webpage")]
        public string WebPage { get; set; }

        [JsonProperty("github")]
        public string Github { get; set; }

        [JsonProperty("linkedin")]
        public string LinkedIn { get; set; }

        [JsonProperty("external_link1")]
        public string ExternalLink1 { get; set; }

        [JsonProperty("external_link2")]
        public string ExternalLink2 { get; set; }

        [JsonProperty("external_link3")]
        public string ExternalLink3 { get; set; }

        //[JsonIgnore]
        //public virtual Resume Resume { get; set; }

    }
}
