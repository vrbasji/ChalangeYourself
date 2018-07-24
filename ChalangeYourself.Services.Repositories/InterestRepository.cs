using ChalangeYourself.Data.Model;
using ChalangeYourself.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalangeYourself.Services.Repositories
{
    public class InterestRepository
    {
        private ChalangeDbContext _dbContext;

        public InterestRepository(ChalangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Interest> GetAll()
        {
            return _dbContext.Interests;
        }

        public Interest GetById(int interestId)
        {
            return _dbContext.Interests
                .FirstOrDefault(x=>x.InterestId == interestId);
        }

        public void AddInterest(ApplicationUser user, Interest interest)
        {

        }

        public void RemoveInterest(ApplicationUser user, Interest interest)
        {

        }

        public void UpdateUserInterestsByIds(ApplicationUser user, int[] interestIds)
        {
            var userToEdit = _dbContext.Users.FirstOrDefault(x => x.Id == user.Id);

            userToEdit.Interests.Clear();
            
            foreach (var id in interestIds)
            {
                var interestToAdd = GetById(id);
                userToEdit.Interests.Add(interestToAdd);
            }
            _dbContext.SaveChanges();
        }


        public IEnumerable<Interest> GetAllByUserId(string userId)
        {
            return _dbContext
                .Users
                .FirstOrDefault(x=>x.Id == userId)
                .Interests;
        }
    }
}
