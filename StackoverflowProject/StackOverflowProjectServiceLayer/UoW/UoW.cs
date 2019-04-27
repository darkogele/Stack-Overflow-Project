using StackOverflowProjectRepositories;
using StackOverflowProjectRepositories.Interfaces;
using System;
using System.Data.Entity;

namespace StackOverflowProjectServiceLayer.UoW
{
    public class UoW : IUoW
    {
        public DbContext Context { get; set; }

        public UoW()//ICategoryRepostiory categoryRepostiory, IUsersRepository usersRepository, IQuestionsRepository questionsRepository, IAnswersRepository answersRepository)
        {

        }

        public bool SaveChanges()
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    // TODO: LOG ERROR

                    return false;
                }
            }
        }
    }
}
