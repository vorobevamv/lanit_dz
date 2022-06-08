using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service
{
    public class VisitorsRepository : IVisitorRepository
    {
        private DatabaseContext _context;
        public VisitorsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<DbVisitors> CreateVisitor (DbVisitors visitor)
            {
            await using (DatabaseContext con = new DatabaseContext())
            {
                con.Visitors.Add(visitor);
                con.SaveChanges();

                var v = con.Visitors.Where(x => x.ID == visitor.ID).FirstOrDefault();
                return v;
            }
        }

         
       


    }
}
