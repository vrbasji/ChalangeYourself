using ChalangeYourself.Data.Model;
using ChalangeYourself.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalangeYourself.Services
{
    public class ProposalChalangeService
    {
        private ChalangeRepository _chalangeRepository;

        public ProposalChalangeService(ChalangeRepository chalangeRepository)
        {
            _chalangeRepository = chalangeRepository;
        }
        public bool ActivateProposalChalange(int proposalChalangeId, Chalange chalange)
        {
            return _chalangeRepository.CreateChalangeFromProposalChalange(proposalChalangeId, chalange);
        }

        public bool AproveProposalChalange(int chalangeId)
        {
            try
            {
                _chalangeRepository.AproveProposalChalange(chalangeId);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
