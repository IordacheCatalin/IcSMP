using IcSMP.DataContext;
using IcSMP.Models;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    public class ClientsRepository
    {
        private readonly IcSMPDataContext _context;
        public ClientsRepository(IcSMPDataContext context)
        {
            _context = context;
        }

        //GET ALL FROM TABLE SECTION 
        public DbSet<ClientModel> GetClients ()
        {
            return _context.Client;
        }

        //ADD SECTION

        public void AddClient(ClientModel client)
        {

            _context.Client.Add(client);
            _context.SaveChanges();
        }
    }
}
