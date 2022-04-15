using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson02
{
    public class Service
    {
        public void NewVisitor()
        {
            using (DatabaseContext con = new DatabaseContext())
            {
                InterestsRepository repositry = new(con);

            }
        }




    }
}
