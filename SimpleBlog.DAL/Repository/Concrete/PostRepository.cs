using Microsoft.EntityFrameworkCore;
using SimpleBlog.DAL.Models;
using SimpleBlog.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DAL.Repository.Concrete
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }

        public void Delete(int id)
        {
            Post post = Get(id);
            if (post is not null)
            {
                _context.Posts.Remove(post);
            }
        }

        public Post Get(int id)
        {
            return _context.Posts.Find(id);
        }

        public List<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Categories).ToList();
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
