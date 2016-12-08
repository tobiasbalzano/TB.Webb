using System.Net.Http;
using System.Web.Http;
using Helpers.HttpResponseReturnService;
using TB.Webb.Logic;
using TB.Webb.Models;

namespace TB.Webb.Api.Controller
{
    [RoutePrefix("api/resume")]
    public class ResumeController : ApiController
    {
        private ResumeService Service => new ResumeService();

        [Route, HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.GetResume(id));
        }

        [Route, HttpPost]
        public HttpResponseMessage Post(Resume inputResume)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PostResume(inputResume));
        }

        [Route, HttpPut]
        public HttpResponseMessage Put(Resume inputResume)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.PutResume(inputResume));
        }

        [Route, HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return ReturnObjectService.BuildContentResponseMessage(Service.DeleteResume(id));
        }
    }
}
