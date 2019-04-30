using StackOverFlowProjectDomainModels;
using StackOverflowProjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectServiceLayer.Interfaces
{
    public interface IQuestionService
    {
        void InsertQuestion(NewQuestionViewModel question);
        void UpdateQuestionDetails(EditQuestionViewModel question);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnwserCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);
        void DeleteQuestion(int qid);
        List<QuestionViewModel> GetQuestions();
        QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID);             
    }
}
