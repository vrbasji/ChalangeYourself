using ChalangeYourself.Data.Model;
using ChalangeYourself.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChalangeYourself.Services.Repositories
{
    public class UserRepository
    {
        private ChalangeDbContext _dbContext;

        public UserRepository(ChalangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _dbContext.Users;
        }

        public IEnumerable<ApplicationUser> GetAllOrderedByPoints()
        {
            return GetAll()
                .OrderBy(x=>x.Points);
        }

        public ApplicationUser GetById(string userId)
        {
            return _dbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);
        }
        public ApplicationUser GetByEmail(string email)
        {
            return _dbContext
                .Users
                .FirstOrDefault(x => x.Email == email);
        }
        public IEnumerable<ApplicationUser> GetRankedUser()
        {
            return _dbContext
                .Users
                .OrderBy(x => x.Points);
        }
        public void Edit(ApplicationUser user)
        {
            var editUser = GetById(user.Id);

            if (editUser == null) throw new ArgumentNullException("User");

            editUser.DateOfBirth = user.DateOfBirth;
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.PhoneNumber = user.PhoneNumber;
            if (editUser.ShipingAddress == null)
            {
                var shippingAddress = new ShipingAddress();
                shippingAddress.City = user.ShipingAddress.City;
                shippingAddress.Country = user.ShipingAddress.Country;
                shippingAddress.HouseNumber = user.ShipingAddress.HouseNumber;
                shippingAddress.PostCode = user.ShipingAddress.PostCode;
                shippingAddress.Street = user.ShipingAddress.Street;
                editUser.ShipingAddress = shippingAddress;
            }
            else
            {
                editUser.ShipingAddress.City = user.ShipingAddress.City;
                editUser.ShipingAddress.Country = user.ShipingAddress.Country;
                editUser.ShipingAddress.HouseNumber = user.ShipingAddress.HouseNumber;
                editUser.ShipingAddress.PostCode = user.ShipingAddress.PostCode;
                editUser.ShipingAddress.Street = user.ShipingAddress.Street;
            }

            editUser.Interests = user.Interests;
            _dbContext.SaveChanges();
        }
    }
}
