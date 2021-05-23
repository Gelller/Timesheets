﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Data;
using Timesheets.Models.Dto;
using System.Security.Cryptography;
using System.Text;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Domain.Implementation
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepo _userRepo;

        public UsersManager(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User> GetUser(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);

            return user;
        }
        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }
        public async Task<Guid> Create(UserDto item)
        {
            item.EnsureNotNull(nameof(item));

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = item.Username,
                PasswordHash = GetPasswordHash(item.Password),
                Role = item.Role
            };
            await _userRepo.Add(user);
            return user.Id;
        }
        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }
        public async Task Update(Guid id, User item)
        {
            item.Id = id;
            await _userRepo.Update(item);
        }
        public async Task Delete(Guid id)
        {
            await _userRepo.Delete(id);
        }
        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
