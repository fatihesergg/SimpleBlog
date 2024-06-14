using SimpleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DAL.Repository.Abstract
{
    public interface IPostRepository
    {
        public Post Get(int id);
        public List<Post> GetAll();
        public void Add(Post post);
        public void Update(Post post);
        public void Delete(Post post);
        public void Delete(int id);

    }
}
