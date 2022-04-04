using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCDomain.ViewModels;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserViewModel> FetchUserAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("Null or empty Email");

            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Null or empty Password");

            UserEntity entity = await _repository.FindByEmailAsync(email);

            if (entity is null) throw new NullReferenceException("Email not registered");

            if (entity.Password != password) throw new ArgumentException("Invalid Password");

            //map entity into view model

            UserViewModel userVM = new UserViewModel(entity.Id, entity.Email, entity.Password, entity.Name, entity.Cel, entity.Worker_Count);

            return userVM;
        }

        public async Task AddUserAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(email) + " or " + nameof(password) + " null");

            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentNullException("Invalid e-mail");

            if (await _repository.FindByEmailAsync(email) is not null)
                throw new ArgumentNullException("E-mail already registered");

            if (password.Count() <= 4)
                throw new ArgumentNullException("Password has less than 5 characters");

            UserEntity userEntity = new UserEntity
            {
                Email = email,
                Password = password,
            };

            _repository.Insert(userEntity);

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserViewModel userVM)
        {
            if (userVM is null) throw new ArgumentNullException("Null userVM object");

            UserEntity userEntity = await _repository.FindAsync(userVM.id);

            userEntity.Cel = userVM.cel;
            userEntity.Worker_Count = userVM.worker_count;
            userEntity.Name = userVM.name;

            _repository.Update(userEntity);

            await _repository.SaveChangesAsync();
        }
    }
}
