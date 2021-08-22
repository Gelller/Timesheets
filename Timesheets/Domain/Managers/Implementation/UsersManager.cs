using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Data;
using Timesheets.Models.Dto;
using System.Security.Cryptography;
using System.Text;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Domain.Aggregates.UserAggregate;

namespace Timesheets.Domain.Managers.Implementation
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepo _userRepo;
        private readonly IUserAggregateRepo _userAggregateRepo;

        public UsersManager(IUserAggregateRepo userAggregateRepo, IUsersRepo userRepo)
        {
            _userAggregateRepo = userAggregateRepo;
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
            return await _userAggregateRepo.GetItem(id);
        }
        public async Task<Guid> Create(User item)
        {
            var user = UserAggregate.Create(item.Username, item.PasswordHash, item.Role);
            item.EnsureNotNull(nameof(item));
            await _userAggregateRepo.Add(user);
            return item.Id;
        }
        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userAggregateRepo.GetItems();
        }
        public async Task Update(Guid id, User item)
        {
            await _userAggregateRepo.Update(id, item);
        }
        public async Task Delete(Guid id)
        {
            await _userAggregateRepo.Delete(id);
        }
        public static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
