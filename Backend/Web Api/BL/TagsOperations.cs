using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    class TagsOperations
    {
        private QAContext databaseContext;

        public TagsOperations()
        {
            databaseContext = new QAContext();
        }

        public int addTags(Tags tags)
        {
            var output = databaseContext.tags.Any(x => x.TagName == tags.TagName);

            if (output)
            {
                return databaseContext.tags.FirstOrDefault(x => x.TagName == tags.TagName).TagId;
            }

            databaseContext.tags.Add(tags);
            databaseContext.SaveChanges();

            return databaseContext.tags.FirstOrDefault(x => x.TagName == tags.TagName).TagId;
        }

    }
}
