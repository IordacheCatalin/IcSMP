using IcSMP.DataContext;
using IcSMP.Models;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    public class CouriersRepository
    {
        public readonly IcSMPDataContext _context;

        public CouriersRepository(IcSMPDataContext context)
        {
            _context = context;
        }

        //GET ALL FROM TABLE SECTION 
        public DbSet<CourierModel> GetCouriers()
        {
            return _context.Courier;
        }

        //GET CODE FOR A CERTAIN ID

        public CourierModel GetCourierById(int id) 
        {
            CourierModel couriers = _context.Courier.Find(id);
            return couriers;
        }

        //ADD SECTION

        public void AddCourier(CourierModel courier)
        {
            _context.Courier.Add(courier);
            _context.SaveChanges();
        }

        //Update section

        public void Update(CourierModel courier)
        {
            _context.Courier.Update(courier);
            _context.SaveChanges();
        }

        //Delete section

        public void Delete(int id)
        {
            CourierModel courier = GetCourierById(id);
            if (courier != null)
            {
                _context.Courier.Remove(courier);
                _context.SaveChanges();
            }
        }
    }
}
