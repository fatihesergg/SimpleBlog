﻿using Microsoft.AspNetCore.Http;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DAL.DTO
{
    public class AddPostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<AddPostCategoryDTO> Categories { get; set; }
        public IFormFile formFile { get; set; }
    }
}
