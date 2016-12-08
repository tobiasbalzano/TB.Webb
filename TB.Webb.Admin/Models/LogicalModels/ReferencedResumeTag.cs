using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TB.Webb.Admin.Models.LogicalModels
{
    public class ReferencedResumeTag
    {
        public ResumeTag Tag { get; set; }
        public bool IsReferenced { get; set; }

        public ReferencedResumeTag(ResumeTag tag)
        {
            Tag = tag;
            IsReferenced = false;
        }
    }
}