using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Web.ViewModels.Post;

namespace Forum.Services.Contracts
{
    internal interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();



    }
}
