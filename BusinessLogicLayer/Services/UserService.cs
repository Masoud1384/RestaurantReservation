﻿using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        public List<UserViewModel> GetUsers()
        {
            return _userRepository.Get()
                .Select(u=> new UserViewModel
                {
                    Email = u.Email,
                    Name = u.Name,
                }).ToList();
        }

        public void CreateUser(CreateUserCommand user)
        {
            var newUser = new User(user.Name,user.Email);
            _userRepository.Create(newUser);
            _userRepository.SaveChanges();
        }

        public bool UserExists(Expression<Func<UserViewModel, bool>> expression)
        {
            var viewModelParameter = Expression.Parameter(typeof(UserViewModel), "viewModel");

            var userExpression = Expression.Lambda<Func<User, bool>>(
                Expression.Invoke(expression,
                    Expression.Property(viewModelParameter, nameof(UserViewModel.Name)),
                    Expression.Property(viewModelParameter, nameof(UserViewModel.Email))
                ),
                viewModelParameter
            );
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
                    restaurantName = r.Restaurant.Name,
                    reservatorEmail = r.User.Email,
                    SpecialRequests = r.SpecialRequests,
                }).ToList()
            };
        }

        public List<User> GetUsers(Expression<Func<UserViewModel, bool>> expression)
        {
            var viewModelParameter = Expression.Parameter(typeof(UserViewModel), "viewModel");

            var userExpression = Expression.Lambda<Func<User, bool>>(
                Expression.Invoke(expression,
                    Expression.Property(viewModelParameter, nameof(UserViewModel.Name)),
                    Expression.Property(viewModelParameter, nameof(UserViewModel.Email))
                ),
                viewModelParameter
            );

            return _userRepository.Users(userExpression);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
