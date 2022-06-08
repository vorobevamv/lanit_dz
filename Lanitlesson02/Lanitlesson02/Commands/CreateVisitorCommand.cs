using Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MassTransit;

namespace Client
{
    public class CreateVisitorCommand : ICreateVisitorCommand
    {
        IValidator<Models.CreateVisitorRequest> validator;
        IRequestClient<Models.CreateVisitorRequest> rc;

        public CreateVisitorCommand(
            [FromServices] IValidator<Models.CreateVisitorRequest> _validator,
            [FromServices] IRequestClient<Models.CreateVisitorRequest> _rc
            )
        {
            validator = _validator;
            rc = _rc;
        }

        public async Task<CreateVisitorResponse> Execute(CreateVisitorRequest request)
        {
            var a = validator.Validate(request);
            bool n = a.IsValid; 


            if (a.IsValid)                               //IsValid - no errors; !xxx.IsValid - errors
            {
                var r = await rc.GetResponse<Models.CreateVisitorResponse>(request, default, default);   //отправляет запрос и ждёт ответ, обозначение типа ответа - CreateVisitorResponse; request - экземпляр запроса CreateVisitorRequest (конкретный запрос)
                return r.Message;
            }
            return new Models.CreateVisitorResponse { Result = "It is failed", ValidationErrors = a.Errors.Select(x=>x.ErrorMessage).ToList() };

        }
    }
}
