using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.Data.Entity;

namespace EF7_3029.Data
{
    public static class SampleData
    {
        public static void EnsureSampleData(this IApplicationBuilder app)
        {
            var context = (MyContext)app.ApplicationServices.GetService(typeof(MyContext));

            if (!context.Forums.Any())
            {
                var forum = new Forum();
                forum.Title = "SAMPLE";

                var topic = new Topic();
                topic.Title = "SAMPLE";
                topic.Forum = forum;

                forum.Topics.Add(topic);

                var topic2 = new Topic();
                topic2.Title = "SAMPLE2";
                topic2.Forum = forum;

                forum.Topics.Add(topic2);

                context.SaveChanges();
            }
        }

        public static void EnsureMigrationsApplied(this IApplicationBuilder app)
        {
            var context = (MyContext) app.ApplicationServices.GetService(typeof (MyContext));

            context.Database.Migrate();
        }
    }
}
