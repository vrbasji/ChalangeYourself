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
                ProposalChalangeId = propChalange.ProposalChalangeId
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
    }
}