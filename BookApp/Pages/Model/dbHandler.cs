using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Pages.Model
{
    public class dbHandler: DbContext
    {
        public dbHandler(DbContextOptions<dbHandler> options): base(options)
        {

        }

        public DbSet<Book> Book { get;
            set;
        }
    }
}
