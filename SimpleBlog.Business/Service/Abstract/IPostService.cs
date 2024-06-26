﻿using FluentValidation.Results;
using SimpleBlog.DAL.DTO;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business.Service.Abstract
{
    public interface IPostService
    {
        public Post Get(int id);
        public List<Post> GetAll();
        public void Add(Post post);
        public void Update(Post post);
        public void Delete(int id);
        public void Delete(Post post);
        public ValidationResult ValidatePost(AddPostDTO dto);
        public ValidationResult ValidatePost(Post model);
    }
}
