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
    public class TagController : ApiController
    {
        ResumeTagService Service = new ResumeTagService();

        [Route, HttpGet]
        public HttpResponseMessage Get()
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResumeTags());
        }

        [Route, HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResumeTag(id));
        }

        [Route, HttpPost]
        public HttpResponseMessage Post(ResumeTag inputTag)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PostResumeTag(inputTag));
        }

        [Route, HttpPut]
        public HttpResponseMessage Put(ResumeTag inputTag)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PutResumeTag(inputTag));
        }

        [Route, HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.DeleteResumeTag(id));
        }
    }
}
