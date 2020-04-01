using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class TagsOperations
    {
        private QAContext databaseContext;

        public TagsOperations()
        {
            databaseContext = new QAContext();
        }

        public int addTags(Tags tags)
        {
            System.Diagnostics.Debug.WriteLine(tags);
            var output = databaseContext.tags.Where(x => x.TagName == tags.TagName).ToList().Count;

            if (output > 0)
            {
                return databaseContext.tags.FirstOrDefault(x => x.TagName == tags.TagName).QuestionTagId;
            }
            tags.CreationDate = DateTime.Now;
            databaseContext.tags.Add(tags);
            databaseContext.SaveChanges();

            return databaseContext.tags.FirstOrDefault(x => x.TagName == tags.TagName).QuestionTagId;
        }

        public void updateTags(Tags tags)
        {
            databaseContext.Entry(tags).State = EntityState.Modified;
            databaseContext.SaveChanges();
        }
    }
}
