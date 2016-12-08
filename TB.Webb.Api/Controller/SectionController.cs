using Helpers.HttpResponseReturnService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TB.Webb.Logic;
using TB.Webb.Models;

namespace TB.Webb.Api.Controller
{
    [RoutePrefix("api/resume/section")]
    public class SectionController : ApiController
    {
        ResumeSectionService Service = new ResumeSectionService();

        [Route, HttpGet]
        public HttpResponseMessage Get(int resumeId)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResumeSections(resumeId));
        }

        [Route, HttpGet]
        public HttpResponseMessage Get(int resumeId, int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResumeSection(id));
        }

        [Route, HttpPost]
        public HttpResponseMessage Post(ResumeSection inputSection)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PostResumeSection(inputSection));
        }

        [Route, HttpPut]
        public HttpResponseMessage Put(ResumeSection inputSection)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PutResumeSection(inputSection));
        }

        [Route, HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.DeleteResumeSection(id));
        }
    }
}
