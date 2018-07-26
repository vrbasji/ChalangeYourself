using ChalangeYourself.Data.Model;
using ChalangeYourself.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChalangeYourself.Website.Mappers
{
    public class ChalangeMappers
    {
        public static ChalangeOverViewViewModel ChalangeToOverViewMap(Chalange chalange)
        {
            return new ChalangeOverViewViewModel()
            {
                ChalangeId = chalange.ChalangeId,
                ChalangeImageUrl = chalange.ThumbnailUrl,
                FinishAt = chalange.EndDate
            };
        } 
        public static ProposalChalangeRankViewModel ProposalChalangeToProposalRankMap(ProposalChalange propChalange)
        {
            return new ProposalChalangeRankViewModel()
            {
                ChalangeName = propChalange.Name,
                UserId = propChalange.User.Id,
                Username = propChalange.User.UserName,
                Points = propChalange.Points,
                ProposalChalangeId = propChalange.ProposalChalangeId,
                UsersVote = propChalange.UserVotes.Select(x=>x.Id).ToList()
            };
        }
        public static ProposalChalangeAdminViewModel ProposalChalangeToProposalAdminMap(ProposalChalange propChalange)
        {
            return new ProposalChalangeAdminViewModel()
            {
                Activated = propChalange.Activated,
                Description = propChalange.Description,
                ProposalChalangeId = propChalange.ProposalChalangeId,
                Name = propChalange.Name,
                UserId = propChalange.User.Id
            };
        }
        public static ProposalChalange ProposalChalangeVMToPropChalange(ProposalChalangeViewModel model)
        {
            return new ProposalChalange()
            {
                Description = model.Description,
                Name = model.Name,
                User = model.User
            };
        }
        public static DetailChalangeViewModel ChalangeToDetailChalangeVM(Chalange chalange)
        {
            return new DetailChalangeViewModel()
            {
                ChalangeId = chalange.ChalangeId,
                Description = chalange.Description,
                Difficulty = chalange.Difficulty,
                EndDate = chalange.EndDate,
                InterestsTags = chalange.Interests.Select(x=> x.Name),
                MaxAge = chalange.MaxAge,
                MinAge = chalange.MinAge,
                Name = chalange.Name,
                Prices = chalange.Prices.Select(x=>x.Name),
                RegisteredUsers = chalange.Users.Select(x=> new DetailChalangeUserViewModel() {
                    Points = x.Points,
                    UserId = x.Id,
                    Username = x.UserName
                })
                .OrderBy(x=>x.Points),
                StartDate = chalange.StartDate,
                ThumbnailUrl = chalange.ThumbnailUrl
            };
        }
        public static Chalange ProposalChalangeVMToChalange(ProposalChalangeAdminViewModel prChalange)
        {
            return new Chalange()
            {
                Active = true,
                Description = prChalange.Description,
                Difficulty = prChalange.Difficulty,
                EndDate = prChalange.EndDate,
                Interests = prChalange.Interests.ToList(),
                MaxAge = prChalange.MaxAge,
                MinAge = prChalange.MinAge,
                Name = prChalange.Name,
                PublishDate = DateTime.Now,
                StartDate = prChalange.StartDate,
                ThumbnailUrl = prChalange.ThumbnailUrl
            };
        }
    }
}