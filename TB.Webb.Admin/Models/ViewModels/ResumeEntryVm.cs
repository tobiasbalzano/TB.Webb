using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TB.Webb.Admin.Models.LogicalModels;

namespace TB.Webb.Admin.Models.ViewModels
{
    public class ResumeEntryVm
    {
        public ResumeEntry Entry { get; set; }

        public IEnumerable<SelectListItem> Tags { get; set; }

        private List<int> _selectedTags { get; set; }
        public List<int> SelectedTags
        {
            get
            {
                if (_selectedTags == null)
                {
                    _selectedTags = Entry.ResumeTag.Select(t => t.Id).ToList();
                }
                return _selectedTags;
            }
            set
            {
                _selectedTags = value;
            }

        }
    }
}