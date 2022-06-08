using System;
using System.Collections.Generic;

namespace Service
{
    public class CreateVisitorResponseMapper: ICreateVisitorResponseMapper
    {
        public Models.CreateVisitorResponse MapToCreateVisitorResponse(DbVisitors v)
        {
            Models.CreateVisitorResponse response = new Models.CreateVisitorResponse()
            {
                ID = v.ID,
                Name = v.Name,
                Age = v.Age,
                Result = "It is success",
                ValidationErrors = new List<string> {"No ValidationErrors"}
            };
            return response;
        }
    }
}
