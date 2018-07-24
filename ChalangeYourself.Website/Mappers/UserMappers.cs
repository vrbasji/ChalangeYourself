using ChalangeYourself.Data.Model;
using ChalangeYourself.Website.Models;

namespace ChalangeYourself.Website.Mappers
{
    public class UserMappers
    {
        public static UserRankViewModel UserToUsersRankMap(ApplicationUser user)
        {
            return new UserRankViewModel()
            {
                Points = user.Points,
                UserId = user.Id,
                Username = user.UserName
            };
        }
    }
}