using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microbloging.Models;

namespace Microbloging.Data
{
    public class PostRepository
    {

        public void AddPost(Post post)
        {
            using (var db = new MicroblogContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public List<Post> GetAllPost()
        {
            using (var db = new MicroblogContext())
            {
                return db.Posts.OrderByDescending(x=>x.Id).ToList();
            }
        }
    }
}