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
    [RoutePrefix("api/resume/entry")]
    public class EntryController : ApiController
    {
        ResumeEntryService Service = new ResumeEntryService();

        [Route, HttpGet]
        public HttpResponseMessage Get(int sectionId)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResumeEntries(sectionId));
        }

        [Route, HttpGet]
        public HttpResponseMessage Get(int sectionId, int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResumeEntry(sectionId));
        }

        [Route, HttpPost]
        public HttpResponseMessage Post(ResumeEntry inputEntry)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PostResumeEntry(inputEntry));
        }

        [Route, HttpPut]
        public HttpResponseMessage Put(ResumeEntry inputEntry)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PutResumeEntry(inputEntry));
        }

        [Route, HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.DeleteResumeEntry(id));
        }
    }
}
