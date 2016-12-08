using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Webb.Models
{

    public class ResumeTag
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonIgnore]
        public virtual ICollection<ResumeEntry> ResumeEntries { get; set; }
    }
}
