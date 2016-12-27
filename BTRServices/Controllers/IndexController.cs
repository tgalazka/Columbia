using BTRServices.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTRServices.Controllers
{
    public class IndexController : ApiController
    {
        Index[] indices = new Index[]
        {
            new Index {ID=1,Name="Computer Science", Number="1231231" },
            new Index {ID=2, Name="Computer Engineering", Number="233332" }
        };

        [SwaggerOperation("GetAll")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<Index> Get()
        {
            return indices;
        }

        [SwaggerOperation("GetAll")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetById(int id)
        {
            var index = indices.FirstOrDefault((p) => p.ID == id);
            if (index == null)
            {
                return NotFound();
            }
            return Ok(index);
        }

    }
}
