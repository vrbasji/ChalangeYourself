﻿using ChalangeYourself.Data.Model;
using ChalangeYourself.Services.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalangeYourself.Services.Repositories
{
    public class ChalangeRepository
    {
        private ChalangeDbContext _dbContext;

        public ChalangeRepository(ChalangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Chalange> GetChalangeByUserId(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            return _dbContext
                .Chalanges
                .Where(x => x.Users.Contains(user));
        }

        public IEnumerable<Chalange> GetAllOrderedByDay()
        {
            return _dbContext
                .Chalanges
                .Where(x=>x.Active)
                .OrderBy(x => x.EndDate);
        }
        public IEnumerable<ProposalChalange> GetActivePropousalChalanges()
        {
            return _dbContext
                .ProposalChalanges
                .Where(x=>x.Activated);
        }
        public IEnumerable<ProposalChalange> GetAllPropousalChalanges()
        {
            return _dbContext
                .ProposalChalanges
                .OrderBy(x=>!x.Activated);
        }

        public void AddProposalChalange(ProposalChalange chalange)
        {
            chalange.User = _dbContext.Users.FirstOrDefault(x => x.Id == chalange.User.Id);
            _dbContext.ProposalChalanges.Add(chalange);
            _dbContext.SaveChanges();
        }
        public Chalange GetById(int id)
        {
            return _dbContext
                .Chalanges
                .FirstOrDefault(x => x.ChalangeId == id);
        }

        public bool AddUserToChalange(Chalange chalange, ApplicationUser user)
        {
            var chalangeToEdit = _dbContext
                .Chalanges
                .FirstOrDefault(x => x.ChalangeId == chalange.ChalangeId);
            chalangeToEdit.Users.Add(user);
            _dbContext.SaveChanges();
            return true;//TODO:
        }
        public void AproveProposalChalange(int chalangeId)
        {
            var proposalChalange = _dbContext.ProposalChalanges.FirstOrDefault(x => x.ProposalChalangeId == chalangeId);
            if (proposalChalange == null)
            {
                throw new ArgumentNullException("proposalChalange");
            }
            proposalChalange.Activated = true;
            _dbContext.SaveChanges();
        }
        public bool CreateChalangeFromProposalChalange(int proposalChalangeId, Chalange chalange)
        {
            var propChalange = _dbContext.ProposalChalanges.FirstOrDefault(x => x.ProposalChalangeId == proposalChalangeId);
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.ProposalChalanges.Remove(propChalange);
                    _dbContext.Chalanges.Add(chalange);
                    _dbContext.SaveChanges();
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
            }
            return true;
        }
        public void AddChalange(Chalange chalange)
        {
            _dbContext.Chalanges.Add(chalange);
            _dbContext.SaveChanges();
        }
    }
}
