using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DataAccessLayer.Repositories
{
    public class ReservationRepository : Repository<int, Reservation>, IReservationRepository
    {
        private Context _context;

        public ReservationRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var result = _context.reservations.Find(id);
            _context.reservations.Remove(result);
            var value = _context.SaveChanges();
            return value == 1;
        }

        public Reservation FindUser(int id)
        {
            return _context.reservations.Include(r=>r.User).Include(r=>r.Restaurant).FirstOrDefault(r => r.Id == id);
        }

        public List<Reservation> Reservations(Expression<Func<Reservation, bool>> expression)
        {
            var result = _context.reservations.Include(r=>r.User).Include(r=>r.Restaurant).Where(expression).ToList();
            return result;
        }

        public bool Update(Reservation reservation)
        {
            _context.reservations.Update(reservation);
            var result = _context.SaveChanges();
            return result == 1;
        }
    }
}
