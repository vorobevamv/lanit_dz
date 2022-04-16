﻿using System;

namespace Service
{
    public class CreateVisitorRequestMapper: ICreateVisitorRequestMapper
    {
        public DbVisitors MapToDbVisitors(Models.CreateVistorRequest request)
        {
            DbVisitors visitor = new DbVisitors()
            {
                ID = Guid.NewGuid(),
                Name = request.Name,
                Age = request.Age
            };
            return visitor;
        }
    }
}