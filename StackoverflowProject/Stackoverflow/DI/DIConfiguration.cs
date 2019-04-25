//using Autofac;
//using StackOverflowProjectRepositories;
//using StackOverflowProjectRepositories.Interfaces;


//namespace Stackoverflow.DI
//{
//    public static class DIConfiguration
//    {
//        public static IContainer Configure()
//        {
//            var builder = new ContainerBuilder();

//            //builder.RegisterType<StackOverflowDatabaseDbContext>().As<>();
//            builder.RegisterType<CategoryRepository>().As<ICategoryRepostiory>();
//            builder.RegisterType<UsersRepository>().As<IUsersRepository>();
//            builder.RegisterType<VotesRepository>().As<IVotesRepository>();
//            builder.RegisterType<QuestionsRepository>().As<IQuestionsRepository>();
//            builder.RegisterType<AnswersRepository>().As<IAnswersRepository>();

//            return builder.Build();
//        }
//    }
//}