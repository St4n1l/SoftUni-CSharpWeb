using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    class PostSeeder
    {
        internal ICollection<Post> GeneratePosts()
        {
            HashSet<Post> posts = new HashSet<Post>();
            Post currentPost = null;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut tempor placerat metus, eget feugiat risus viverra vitae. Integer sit amet."
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "Lorem ipsum dolor sit amet."
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third post",
                Content = "Sed quis neque finibus, condimentum."
            };

            posts.Add(currentPost);

            return posts.ToArray();
        }
       
    }
}
