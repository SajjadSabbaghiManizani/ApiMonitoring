using ApiMonitoring.Domain.Entities;
using ApiMonitoring.Persistance.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Persistance.Repositories
{
    public class ServerRepository : GenericRepository<Server>
    {
        public ServerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
