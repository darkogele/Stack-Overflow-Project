using StackOverFlowProjectDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectRepositories.Interfaces
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
}
