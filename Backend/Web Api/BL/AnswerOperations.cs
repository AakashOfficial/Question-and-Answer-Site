﻿using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AnswerOperations
    {
        private QAContext databaseContext;

        public AnswerOperations()
        {
            databaseContext = new QAContext();
        }

        public Answer getAnswer(int id)
        {
            var result = databaseContext.answer.FirstOrDefault(d => d.AnswerId == id && d.AnswerActive == 1);
            return result;
        }
        public List<Answer> getAnswers(int id)
        {
            var result = databaseContext.answer.Where(d => d.QuestionId == id && d.AnswerActive == 1).OrderByDescending(x => x.CreationDate).ToList();//.ThenByDescending(x=> x.CreationDate)

            return result;
        }

        // for getting the count of the Answers of a Question
        public int getAnswerCount(int id) {
            int count = 0;

            count = databaseContext.answer.Where(d => d.QuestionId == id && d.AnswerActive == 1).Count();
            if(count > 0){
                return count;
            }
            else
            {
                return 0;
            }
        }

        // for edit the answer
        public bool editAnswer(Answer answer)
        {
            databaseContext.Entry(answer).State = EntityState.Modified;
            databaseContext.SaveChanges();
            return true;
        }

        // for add the answer
        public bool addAnswer(Answer answer)
        {
            answer.CreationDate = DateTime.Now;
            databaseContext.answer.Add(answer);
            databaseContext.SaveChanges();
            return true;
        }

        public bool deleteAnswer(int id)
        {
            var output = databaseContext.answer.Single(x => x.AnswerId == id);
            if(output != null)
            {
                databaseContext.answer.Remove(output);
                UserReactionOperation userReactionOperation = new UserReactionOperation();
                userReactionOperation.deleteAllReaction(id);
                databaseContext.SaveChanges();
            }
            return true;
        }

        public bool deactivateAnswer(int id)
        {
            var output = databaseContext.answer.Single(x => x.AnswerId == id);

            if(output != null)
            {
                output.AnswerActive = 0;
                UserReactionOperation userReactionOperation = new UserReactionOperation();
                userReactionOperation.deactivateAllReaction(id);
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool activateAnswer(int id)
        {
            var output = databaseContext.answer.Single(x => x.AnswerId == id);

            if (output != null)
            {
                output.AnswerActive = 1;
                UserReactionOperation userReactionOperation = new UserReactionOperation();
                userReactionOperation.activateAllReaction(id);
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteAllAnswer(int id)
        {
            var output = databaseContext.answer.Where(d => d.QuestionId == id).ToList();
            if(output != null)
            {
                foreach (var answers in output)
                {
                    UserReactionOperation userReactionOperation = new UserReactionOperation();
                    userReactionOperation.deleteAllReaction(answers.AnswerId);
                    databaseContext.answer.Remove(answers);
                }
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool activateAllAnswer(int id)
        {
            var output = databaseContext.answer.Where(d => d.QuestionId == id && d.AnswerActive == 0).ToList();
            if(output != null)
            {
                foreach (var answers in output)
                {
                    UserReactionOperation userReactionOperation = new UserReactionOperation();
                    userReactionOperation.activateAllReaction(answers.AnswerId);
                    answers.AnswerActive = 1;
                    databaseContext.SaveChanges();
                }
            }

            return true;
        }

        public bool deactivateAllAnswer(int id)
        {
            var output = databaseContext.answer.Where(d => d.QuestionId == id && d.AnswerActive == 1).ToList();
            if (output != null)
            {
                foreach (var answers in output)
                {
                    UserReactionOperation userReactionOperation = new UserReactionOperation();
                    userReactionOperation.deactivateAllReaction(answers.AnswerId);
                    answers.AnswerActive = 0;
                    databaseContext.SaveChanges();
                }
            }

            return true;
        }
    }
}