using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestService _requestService;

        public RequestController(ILogger<RequestController> logger, IRequestService requestService)
        {
            _logger = logger;
            _requestService = requestService;
        }

        [HttpGet(Name = "GetAllRequest")]

        public IActionResult GetAll()
        {
            var result = _requestService.GetAll().AsEnumerable();
            return new JsonResult(result);
        }
        [HttpGet]
        [Route("{id:guid}")]
         public IActionResult GetOne(Guid id)
         {
            var request = _requestService.GetOne(id);
            if(request == null) return NotFound();
            return new JsonResult(request);
         }
        
        [HttpPost]
        [Route("AddOne")]
        public IActionResult Add(RequesCreateModel model)
        {
            var request = new Request
            {
                Title = model.Title,
                Description = model.Description,
                Id = Guid.NewGuid(),
                Complete = false,
            };
             var results = _requestService.Add(request);
             return new JsonResult(results);
        }
        [HttpPost]
        [Route("Multiple")]
        public List<Request> AddMultiple(List<RequesCreateModel> models)
        {
            var requests = new List<Request>();
            foreach(var model in models)
            {
                requests.Add(
                    new Request
                    {
                        Id = Guid.NewGuid(),
                        Title = model.Title,
                        Description = model.Description,
                        Complete = false
                    }
                );
                
            }
            _requestService.Add(requests);
            return requests;
             
        }
        [HttpPost]
        [Route("AddMany")]
        public IActionResult AddMany(List<RequesCreateModel> models)
        {
            List<Request> requests = new List<Request>();
            foreach(RequesCreateModel model in models)
            {
                requests.Add(new Request
                {
                    Id = Guid.NewGuid(),
                    Description = model.Description,
                    Title = model.Title,
                    Complete = false,
                });
            }
            _requestService.Add(requests);
            return new JsonResult(requests);

        }


        [HttpDelete]
        [Route("MultipleDelete")]
        public IActionResult Delete(List<Guid> ids)
        {
            _requestService.Remove(ids);
            return Ok();
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Edit(Guid id, RequesEditModel model)
        {
            var request = _requestService.GetOne(id);
            if(request == null) return NotFound();

            request.Title = model.Title;
            request.Description = model.Description;
            request.Complete = model.Complete;
            var result = _requestService.Edit(request);
            return new JsonResult(result);
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var request = _requestService.GetOne(id);
            if(request == null) return NotFound();
            _requestService.Remove(id);
            return Ok();
        }
    }
}