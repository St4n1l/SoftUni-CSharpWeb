using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Web.ViewModels.Post;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services.Contracts
{
    internal class PostService : IPostService
    {

        private ForumDbContext dbContext;

        public PostService(ForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await dbContext.Posts.Select(p => new PostListViewModel()
            {
                Id = p.Id.ToString(),
                Title = p.Title,
                Content = p.Content
            }).ToArrayAsync();

            return allPosts;
        }
    }
}
