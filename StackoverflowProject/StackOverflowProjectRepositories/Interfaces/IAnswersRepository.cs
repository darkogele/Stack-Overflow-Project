using StackOverFlowProjectDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectRepositories.Interfaces
{
    public interface IAnswersRepository
    {
        void InesertAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void UpdateAnswerVoteCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<Answer> GetAnswersByQuestionID(int qid);
        List<Answer> GetAnswersByAnswerID(int aid);

    }
}
