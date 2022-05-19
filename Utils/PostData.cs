using NetCore_01.Models;

namespace NetCore_01.Utils
{
    public static class PostData
    {

        private static List<Post> posts;

        public static List<Post> GetPosts()
        {
            if(PostData.posts != null)
            {
                return PostData.posts;
            }

            List<Post> nuovaListaPosts = new List<Post>();

            for(int i=0; i<1; i++)
            {
                Post post = new Post(i, "Pizza: " + i, "Margherita", "https://th.bing.com/th/id/OIP.N6oVQxrI4PN_sXzUt0IY6AHaF9?w=252&h=203&c=7&r=0&o=5&pid=1.7" + i + "/300/200");
                nuovaListaPosts.Add(post);
                Post post1 = new Post(i, "Pizza: " + i, "Norma", "https://th.bing.com/th/id/OIP.nKZYHaqKxMfjMCNvuv22DwHaE1?w=273&h=180&c=7&r=0&o=5&pid=1.7" + i + "/300/200");
                nuovaListaPosts.Add(post1);
            }

            PostData.posts = nuovaListaPosts;

            return PostData.posts;

        }

    }
}
