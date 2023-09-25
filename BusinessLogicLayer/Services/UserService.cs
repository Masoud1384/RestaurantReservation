using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel GetUser(int id)
        {
            var result = _userRepository.FindUser(id);
            var vm = new UserViewModel
            {
                id = id,
                Email = result.Email,
                Name = result.Name,
                Reservations = result.Reservations.Select(r => new ReservationViewModel
                {
                    reservationStatus = r.reservationStatus,
                    Id = r.Id ,
                    NumberOfGuests = r.NumberOfGuests,
                    ReservationTime =r.ReservationTime,
                    SpecialRequests = r.SpecialRequests,
                    userId =r.UserId,
                    restaurantId = r.RestaurantId
                }).ToList()
            };
            return vm;
        }

        public List<UserViewModel> GetUsers()
        {
            return _userRepository.Get()
                .Select(u => new UserViewModel
                {
                    id = u.Id ,
                    Email = u.Email,
                    Name = u.Name,
                }).ToList();
        }

        public int CreateUser(CreateUserCommand user)
        {
            var newUser = new User(user.Name, user.Email);
            var result = _userRepository.CreateUser(newUser);
            if (_userRepository.SaveChanges() == 1)
            {
                _userRepository.Create(newUser);
                return newUser.Id;
            }
            return -1;
        }

        public bool UserExists(Expression<Func<UserViewModel, bool>> expression)
        {
            var userExpression = Converter(expression);
            return _userRepository.Exists(userExpression);
        }

        public UserViewModel FindUser(int id)
        {
            var result = _userRepository.FindUser(id);
            return new UserViewModel
            {
                Email = result.Email,
                Name = result.Name,
                Reservations = result.Reservations.Select(r => new ReservationViewModel
                {
                    Id = r.Id,
                    NumberOfGuests = r.NumberOfGuests,
                    reservationStatus = r.reservationStatus,
                    ReservationTime = r.ReservationTime,
                    SpecialRequests = r.SpecialRequests,
                    restaurantId = r.RestaurantId
                }).ToList()
            };
        }

        public List<UserViewModel> GetUsers(Expression<Func<UserViewModel, bool>> expression)
        {
            var userExpression = Converter(expression);
            var result = _userRepository.Users(userExpression)
                .Select(u => new UserViewModel
                {
                    Email = u.Email,
                    Name = u.Name,
                    Reservations = u.Reservations.Select(r => new ReservationViewModel
                    {
                        Id = r.Id,
                        NumberOfGuests = r.NumberOfGuests,
                        reservationStatus = r.reservationStatus,
                        ReservationTime = r.ReservationTime,
                        SpecialRequests = r.SpecialRequests,
                        restaurantId = r.RestaurantId
                    }).ToList()
                }).ToList();
            return result;
        }
        public bool UpdateUser(UpdateUserCommand userCmd)
        {
            if (userCmd != null)
            {
                var user = new User(userCmd.Name, userCmd.Email, (List<Reservation>?)userCmd.Reservations
                    .Select(r => new Reservation(r.NumberOfGuests, r.ReservationTime, r.SpecialRequests, r.reservationStatus, userCmd.Id)));
                return _userRepository.Update(user);
            }
            return false;
        }
        public bool DeleteUser(int id)
        {
            if (_userRepository.Exists(u => u.Id == id))
            {
                return _userRepository.Delete(id);
            }
            return false;
        }
        private Expression<Func<User, bool>> Converter(Expression<Func<UserViewModel, bool>> expression)
        {
            var viewModelParameter = Expression.Parameter(typeof(UserViewModel), "viewModel");
            var userExpression = Expression.Lambda<Func<User, bool>>(
                Expression.Invoke(expression,
                    Expression.Property(viewModelParameter, nameof(UserViewModel.Name)),
                    Expression.Property(viewModelParameter, nameof(UserViewModel.Email))
                ),
                viewModelParameter
            );
            return userExpression;
        }
    }
}
