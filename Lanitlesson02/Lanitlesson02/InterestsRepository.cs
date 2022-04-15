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

namespace Lanitlesson02
{
   public class InterestsRepository
    {
        private DatabaseContext _context;
        public InterestsRepository(DatabaseContext context)
        { 
            _context = context;
        }

       /* public void NewVisitor(CreateNewVisitor createnewvisitor)
        { 
        
        }*/



    }
}


