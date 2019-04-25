using System.Linq;
using StackOverFlowProjectDomainModels;
using StackOverflowProjectRepositories.Interfaces;

namespace StackOverflowProjectRepositories
{
    public class VotesRepository : IVotesRepository
    {   
        private StackOverflowDatabaseDbContext _db;
   
        public VotesRepository()
        {
            _db = new StackOverflowDatabaseDbContext();
        }

        public void UpdateVote(int aid, int uid, int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;
            else updateValue = 0;

            var vot = _db.Votes.FirstOrDefault(v => v.AnswerID == aid && v.UserID == uid);
            if (vot != null)
            {
                vot.VoteValue = updateValue;
            }
            else
            {
                var newVote = new Vote() { AnswerID = aid, UserID = uid, VoteValue = updateValue };
                _db.Votes.Add(newVote);              
            }
            _db.SaveChanges();
        }
    }
}
