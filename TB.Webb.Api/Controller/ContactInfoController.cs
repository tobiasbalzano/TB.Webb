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
    [RoutePrefix("api/resume/contactinfo")]
    public class ContactInfoController : ApiController
    {
        ContactInfoService Service = new ContactInfoService();

        [Route, HttpGet]
        public HttpResponseMessage Get(int resumeId)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetContactInfo(resumeId));
        }

        [Route, HttpPost]
        public HttpResponseMessage Post(ResumeContactInfo inputInfo)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PostContactInfo(inputInfo));
        }

        [Route, HttpPut]
        public HttpResponseMessage Putt(ResumeContactInfo inputInfo)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PutContactInfo(inputInfo));
        }

        [Route, HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.DeleteContactInfo(id));
        }
    }
}
