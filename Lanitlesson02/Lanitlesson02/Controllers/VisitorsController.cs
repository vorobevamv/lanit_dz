using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MassTransit;

namespace Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitorsController : ControllerBase
    {
   
        [HttpPost("createvisitor")]
        public async Task<Models.CreateVisitorResponse> createvisitor(
          [FromServices] ICreateVisitorCommand command,
          [FromBody] Models.CreateVisitorRequest request)
        {
            return await command.Execute(request);
        }
    }
}