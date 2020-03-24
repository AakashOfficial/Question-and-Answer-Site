namespace DL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DL.QAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DL.QAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            var users = new List<User>
            {
                new User{ UserFirstName = "Aakash" , UserLastName = "Tyagi", UserEmail = "aakash.tyagi@nagarro.com" , UserPassword = "Passw0rd@123" , UserActive = 1 , CreationDate = DateTime.Parse("2020-03-24") , UserId = 1 ,},
                new User { UserFirstName = "Anshika", UserLastName = "Tyagi", UserEmail = "anshikatyagi2007@outlook.com", UserPassword = "Passw0rd@123", UserActive = 1, CreationDate = DateTime.Parse("2020-03-24"), UserId = 2 , }
            };

            users.ForEach(s => context.user.AddOrUpdate(p => p.UserEmail, s));
            context.SaveChanges();


            var question = new List<Question> 
            {
                new Question{ QuestionId = 1 , UserId = 1 , QuestionName = "What is the capital of India" , CreationDate = DateTime.Parse("2020-03-24") , QuestionActive = 1 , },
                new Question{ QuestionId = 2 , UserId = 2 , QuestionName = "What is the capital of Uttar Pradesh" , CreationDate = DateTime.Parse("2020-03-24") , QuestionActive = 1 , }
            };

            question.ForEach(s => context.question.AddOrUpdate(p => p.QuestionName, s));
            context.SaveChanges();

            var answer = new List<Answer>
            {
                new Answer{ AnswerId = 1 , QuestionId = 1 , UserId = 2 , AnswerName = "Delhi" , CreationDate = DateTime.Parse("2020-03-24") , AnswerActive = 1,},
                new Answer{AnswerId = 2 , QuestionId = 2 , UserId = 1 , AnswerName = "Lucknow" , CreationDate = DateTime.Parse("2020-03-24") , AnswerActive = 1,}
            };

            answer.ForEach(s => context.answer.AddOrUpdate(p => p.AnswerName, s));
            context.SaveChanges();

            var tags = new List<Tags>
            {
                new Tags{ QuestionTagId = 1 , TagName = "Capital" , CreationDate = DateTime.Parse("2020-03-24") , QuestionId = 1 , TagActive = 1 , },
                new Tags{ QuestionTagId = 2 , TagName = "Capital" , CreationDate = DateTime.Parse("2020-03-24") , QuestionId = 2 , TagActive = 1 , }
            };

            tags.ForEach(s => context.tags.AddOrUpdate(p => p.TagName, s));
            context.SaveChanges();

            var userreaction = new List<UserReaction>
            {
                new UserReaction{ ReactionId = 1 , UserId = 2 , ReactionType = 1 , CreationDate = DateTime.Parse("2020-03-24") , AnswerId = 1 , ReactionActive = 1 , },
                new UserReaction{ ReactionId = 2 , UserId = 1 , ReactionType = 0 , CreationDate = DateTime.Parse("2020-03-24") , AnswerId = 1 , ReactionActive = 1 , },
                new UserReaction{ ReactionId = 3 , UserId = 2 , ReactionType = 0 , CreationDate = DateTime.Parse("2020-03-24") , AnswerId = 2 , ReactionActive = 1 , },
                new UserReaction{ ReactionId = 4 , UserId = 1 , ReactionType = 1 , CreationDate = DateTime.Parse("2020-03-24") , AnswerId = 2 , ReactionActive = 1 , }
            };

            userreaction.ForEach(s => context.userreaction.AddOrUpdate(p => p.ReactionType, s));
        }
    }
}