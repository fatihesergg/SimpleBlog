using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate = DateTime.Now;
        public DateTime LastEditDate = DateTime.Now;
        public List<Category> Categories { get; set; }


    }
}
