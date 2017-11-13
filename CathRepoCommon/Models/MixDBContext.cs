using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CathRepoCommon.Models
{
    public class MixDBContext : DbContext
    {
        public MixDBContext()
        {

        }
        public DbSet<Mix> Mixes { get; set; }
    }
}
