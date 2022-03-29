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

            var userEntity = new UserEntity
            {
                Email = email,
                Password = password,
            };

            _repository.Insert(userEntity);

            await _repository.SaveChangesAsync();
        }
    }
}
