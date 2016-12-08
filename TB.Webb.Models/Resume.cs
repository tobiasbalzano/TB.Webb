using System.Collections.Generic;
using Newtonsoft.Json;

namespace TB.Webb.Models
{
    public class Resume
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resume_header")]
        public string ResumeHeader { get; set; }

        [JsonIgnore]
        public int ResumeContactInfoId { get; set; }

        [JsonProperty("resume_contact_info")]
        public virtual ResumeContactInfo ResumeContactInfo { get; set; }

        [JsonProperty("resume_sections")]
        public virtual ICollection<ResumeSection> ResumeSections { get; set; }
    }
}
