﻿using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public ReservationViewModel GetReservation(int id)
        {
            var r = _reservationRepository.Get(id);
             var result = new ReservationViewModel
             {
                 Id = r.Id,
                 NumberOfGuests = r.NumberOfGuests,
                 reservationStatus = r.reservationStatus,
                 ReservationTime = r.ReservationTime,
                 SpecialRequests = r.SpecialRequests,
                 userId = r.Id,
                 restaurantName = r.Restaurant.Name

             };
            return result;
        }

        public List<ReservationViewModel> GetReservations()
        {
            return _reservationRepository.Get().Select(r =>
            new ReservationViewModel
            {
                Id = r.Id,
                NumberOfGuests = r.NumberOfGuests,
                reservationStatus = r.reservationStatus,
                ReservationTime = r.ReservationTime,
                SpecialRequests = r.SpecialRequests,
                userId = r.Id,
                restaurantName = r.Restaurant.Name

            }).ToList();
        }

        public bool CreateReservation(CreateReservationCommand reservationcmd)
        {
            if (reservationcmd.userId > 0 && reservationcmd != null)
            {
                var result = new Reservation(reservationcmd.NumberOfGuests, reservationcmd.ReservationTime, reservationcmd.SpecialRequests, reservationcmd.reservationStatus, reservationcmd.userId);
                _reservationRepository.Create(result);
                return _reservationRepository.SaveChanges() == 1;
            }
            return false;
        }

        public bool ReservationExists(Expression<Func<ReservationViewModel, bool>> expression)
        {
            var exp = Converter(expression);
            return _reservationRepository.Exists(exp);
        }

        public ReservationViewModel FindReservation(int id)
        {
            var reservation = _reservationRepository.FindUser(id);
            var result = new ReservationViewModel
            {
                reservationStatus = reservation.reservationStatus,
                restaurantName = reservation.User.Name,
                ReservationTime = reservation.ReservationTime,
                Id = id,
                SpecialRequests = reservation.SpecialRequests,
                NumberOfGuests = reservation.NumberOfGuests,
                userId = reservation.Id
            };
            return result;
        }

        public List<ReservationViewModel> GetReservations(Expression<Func<ReservationViewModel, bool>> expression)
        {
            var exp = Converter(expression);
            return _reservationRepository.Reservations(exp).Select(r =>
            new ReservationViewModel
            {
                Id = r.Id,
                NumberOfGuests = r.NumberOfGuests,
                reservationStatus = r.reservationStatus,
                ReservationTime = r.ReservationTime,
                SpecialRequests = r.SpecialRequests,
                userId = r.Id,
                restaurantName = r.Restaurant.Name

            }).ToList();
        }

        public bool UpdateReservation(UpdateReservationCommand reservation)
        {
            var result = new Reservation(reservation.NumberOfGuests,reservation.ReservationTime,reservation.SpecialRequests,reservation.reservationStatus,reservation.userId);
            return _reservationRepository.Update(result);
        }

        private Reservation Converter(ReservationViewModel vm)
        {
            if (vm.userId > 0 && vm != null)
            {
                return new Reservation(vm.NumberOfGuests, vm.ReservationTime, vm.SpecialRequests, vm.reservationStatus, vm.userId);
            }
            return new Reservation();
        }
        private Expression<Func<Reservation, bool>> Converter(Expression<Func<ReservationViewModel, bool>> expression)
        {
            var viewModelParameter = Expression.Parameter(typeof(ReservationViewModel), "viewModel");

            var reservationExpression = Expression.Lambda<Func<Reservation, bool>>(
                Expression.Invoke(expression,
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.Id)),
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.restaurantName)),
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.reservationStatus)),
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.NumberOfGuests)),
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.ReservationTime)),
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.SpecialRequests)),
                    Expression.Property(viewModelParameter, nameof(ReservationViewModel.userId))
                ),
                viewModelParameter
            );
            return reservationExpression;
        }

     
    }
}
