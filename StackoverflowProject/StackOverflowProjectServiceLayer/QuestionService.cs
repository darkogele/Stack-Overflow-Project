using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StackOverFlowProjectDomainModels;
using StackOverflowProjectRepositories.Interfaces;
using StackOverflowProjectServiceLayer.Interfaces;
using StackOverflowProjectViewModels;

namespace StackOverflowProjectServiceLayer
{
    public class QuestionService : IQuestionService
    {
        IQuestionsRepository _Qr;
        public QuestionService(IQuestionsRepository Qr)
        {
            _Qr = Qr;
        }

        public void DeleteQuestion(int qid)
        {
            _Qr.DeleteQuestion(qid);
        }

        public QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID = 0)
        {
            var q = _Qr.GetQuestionsByQuestionsID(QuestionID).FirstOrDefault();
            QuestionViewModel qvm = null;
            if (q != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Question, QuestionViewModel>(); cfg.IgnoreUnmapped(); });
                var mapper = config.CreateMapper();
                qvm = mapper.Map<Question, QuestionViewModel>(q);

                foreach (var item in qvm.Answers)
                {
                    item.CurrentUserVoteType = 0;
                    var vote = item.Votes.FirstOrDefault(x => x.UserID == UserID);
                    if (vote != null)
                    {
                        item.CurrentUserVoteType = vote.VoteValue;
                    }
                }
            }
            return qvm;
        }

        public List<QuestionViewModel> GetQuestions()
        {
            var questions = _Qr.GetQuestions();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<List<Question>, List<QuestionViewModel>>(); cfg.IgnoreUnmapped(); });
            var mapper = config.CreateMapper();
            var ql = mapper.Map<List<Question>, List<QuestionViewModel>>(questions);
            return ql;
        }

        public void InsertQuestion(NewQuestionViewModel question)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            var mapper = config.CreateMapper();
            var qvm = mapper.Map<NewQuestionViewModel, Question>(question);
            _Qr.InsertQuestion(qvm);
        }

        public void UpdateQuestionAnwserCount(int qid, int value)
        {
            _Qr.UpdateQuestionsAnswersCount(qid, value);
        }

        public void UpdateQuestionDetails(EditQuestionViewModel question)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            var mapper = config.CreateMapper();
            var eqvm = mapper.Map<EditQuestionViewModel, Question>(question);
            _Qr.UpdateQuestionDetails(eqvm);
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            _Qr.UpdateQuestionsAnswersCount(qid, value);
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            _Qr.UpdateQuestionVotesCount(qid, value);
        }
    }
}
