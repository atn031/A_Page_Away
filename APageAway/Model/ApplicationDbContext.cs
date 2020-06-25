using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APageAway.Model
{
    //ApplicationDbContext links the database server to the data model classes.
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        //Needed in order to add the model to the database.
        public DbSet<Book> Book{ get; set; }
    }
}
