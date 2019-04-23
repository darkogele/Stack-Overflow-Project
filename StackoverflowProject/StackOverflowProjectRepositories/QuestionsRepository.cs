using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlowProjectDomainModels;

namespace StackOverflowProjectRepositories
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question question);
        void UpdateQuestionDetails(Question question);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionsAnswersCount(int qid, int value);
        void UpdateQuestionsViewsCount(int qid, int value);
        void DeleteQuestion(int qid);
        List<Question> GetQuestions();
        List<Question> GetQuestionsByQuestionsID(int questionID);
    }

    public class QuestionsRepository : IQuestionsRepository
    {
        private StackOverflowDatabaseDbContext _db;
        public QuestionsRepository(StackOverflowDatabaseDbContext db)
        {
            _db = db;
        }

        public void DeleteQuestion(int qid)
        {
            var question = _db.Questions.FirstOrDefault(q => q.QuestionID == qid);
            if (question != null)
            {
                _db.Questions.Remove(question);
                _db.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            var questions = _db.Questions.OrderBy(x=>x.QuestionDateAndTime).ToList();
            return questions;
        }

        public List<Question> GetQuestionsByQuestionsID(int questionID)
        {
            var singleQuestion = _db.Questions.Where(x => x.QuestionID == questionID).ToList();
            return singleQuestion;
        }

        public void InsertQuestion(Question question)
        {
            if (question != null)
            {
                _db.Questions.Add(question);
                _db.SaveChanges();
            }
        }

        public void UpdateQuestionDetails(Question question)
        {
            var questionDetails = _db.Questions.FirstOrDefault(x => x.QuestionID == question.QuestionID);
            if (questionDetails != null)
            {
                questionDetails.QuestionName = question.QuestionName;
                questionDetails.QuestionDateAndTime = question.QuestionDateAndTime;
                questionDetails.CategoryID = question.CategoryID;
                _db.SaveChanges();
            }
        }

        public void UpdateQuestionsAnswersCount(int qid, int value)
        {
            var questionsAnswerCount = _db.Questions.FirstOrDefault(q => q.QuestionID == qid);
            if (questionsAnswerCount != null)
            {
                questionsAnswerCount.AnswersCount += value;
                _db.SaveChanges();
            }
        }

        public void UpdateQuestionsViewsCount(int qid, int value)
        {
            var questionsViewsCount = _db.Questions.FirstOrDefault(q => q.QuestionID == qid);
            if (questionsViewsCount != null)
            {
                questionsViewsCount.ViewsCount += value;
                _db.SaveChanges();
            }
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            var questionVotes = _db.Questions.FirstOrDefault(q => q.QuestionID == qid);
            if (questionVotes != null)
            {
                questionVotes.VotesCount += value;
                _db.SaveChanges();
            }
        }
    }
}
