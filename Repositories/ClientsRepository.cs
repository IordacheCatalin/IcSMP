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

        //GET CODE FOR A CERTAIN ID

        public ClientModel GetClientById(int id)
        {
            ClientModel client = _context.Client.Find(id);
            return client;

        }

        //ADD SECTION

        public void AddClient(ClientModel client)
        {

            _context.Client.Add(client);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void Update(ClientModel client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void Delete(int id)
        {
            ClientModel client = GetClientById(id);
            if (client != null)
            {
                _context.Client.Remove(client);
                _context.SaveChanges();
            }
        }
    }
}
