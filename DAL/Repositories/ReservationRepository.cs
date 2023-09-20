using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
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

        public Reservation FindUser(Expression<Func<Reservation, bool>> expression)
        {
            var result = _context.reservations.FirstOrDefault(expression);
            return result;
        }

        public List<Reservation> Ingredients(Expression<Func<Reservation, bool>> expression)
        {
            var result = _context.reservations.Where(expression).ToList();
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
