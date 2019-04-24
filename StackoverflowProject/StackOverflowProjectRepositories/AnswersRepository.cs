using System.Collections.Generic;
using System.Linq;
using StackOverFlowProjectDomainModels;
using StackOverflowProjectRepositories.Interfaces;

namespace StackOverflowProjectRepositories
{
    public class AnswersRepository : IAnswersRepository
    {
        private StackOverflowDatabaseDbContext _db;
        private IQuestionsRepository _qr;
        private IVotesRepository _vr;
        public AnswersRepository(IQuestionsRepository qr, IVotesRepository vr)
        {
            _db = new StackOverflowDatabaseDbContext();
            _qr = qr;
            _vr = vr; 
        }

        public void DeleteAnswer(int aid)
        {
            var ans = _db.Answers.FirstOrDefault(a => a.AnswerID == aid);
            if (ans != null)
            {
                _db.Answers.Remove(ans);
                _db.SaveChanges();
                _qr.UpdateQuestionsAnswersCount(ans.QuestionID, -1);
            }
        }

        public List<Answer> GetAnswersByAnswerID(int aid)
        {
            var ans = _db.Answers.Where(a => a.AnswerID == aid).ToList();
            return ans;
        }

        public List<Answer> GetAnswersByQuestionID(int qid)
        {
            var ans = _db.Answers.Where(a => a.QuestionID == qid).OrderByDescending(o=>o.AnswerDateAndTime).ToList();          
            return ans;
        }

        public void InesertAnswer(Answer answer)
        {
            if (answer != null)
            {
                _db.Answers.Add(answer);
                _db.SaveChanges();
                _qr.UpdateQuestionsAnswersCount(answer.QuestionID, 1);
            }
        }

        public void UpdateAnswer(Answer answer)
        {
            var ans = _db.Answers.FirstOrDefault(a => a.AnswerID == answer.AnswerID);
            if (ans != null)
            {
                ans.Answertext = answer.Answertext;
                _db.SaveChanges();
            }
        }

        public void UpdateAnswerVoteCount(int aid, int uid, int value)
        {
            var ans = _db.Answers.FirstOrDefault(a => a.AnswerID == aid);
            if (ans != null)
            {
                ans.VotesCount += value;
                _db.SaveChanges();
                _qr.UpdateQuestionVotesCount(ans.QuestionID, value);
                _vr.UpdateVote(aid, uid, value);
            }
        }
    }
}
