using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TB.Webb.Models
{
    public class ResumeEntry
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resume_section_id")]
        public int ResumeSectionId { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("establishment")]
        public string Establishment { get; set; }

        [JsonProperty("additional")]
        public string Additional { get; set; }

        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("current")]
        public bool CurrentPosition { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sorter")]
        public int Sorter { get; set; }

        [JsonProperty("tags")]
        public virtual ICollection<ResumeTag> Tags { get; set; }

        [JsonIgnore]
        public virtual ResumeSection ResumeSection { get; set; }
    }
}
