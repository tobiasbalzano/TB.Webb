using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Webb.Models
{
    public class ResumeSection
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resume_id")]
        public int ResumeId { get; set; }

        [JsonProperty("content_header")]
        public string ContentHeader { get; set; }

        [JsonProperty("sorter")]
        public int Sorter { get; set; }

        [JsonIgnore]
        public virtual Resume Resume { get; set; }

        [JsonProperty("entries")]
        public virtual ICollection<ResumeEntry> Entries { get; set; }

    }
}
