using Microsoft.AspNetCore.Mvc;
using NetCore_01.Models;
using NetCore_01.Utils;

namespace NetCore_01.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            List<Post> posts = PostData.GetPosts();

            return View("HomePage", posts);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Post postFound = null;
            
            foreach(Post post in PostData.GetPosts())
            {
                if(post.Id == id)
                {
                    postFound = post;
                    break;
                }
            }

            if(postFound != null)
            {
                return View("Details", postFound);
            } else
            {
                return NotFound("Il post con id " + id + " non è stato trovato");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPost");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post nuovoPost)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPost", nuovoPost);
            }

            Post nuovoPostConId = new Post(PostData.GetPosts().Count, nuovoPost.Title, nuovoPost.Description, nuovoPost.Image);

            // Il mio modello è corretto
            PostData.GetPosts().Add(nuovoPostConId);

            return RedirectToAction("Index", "Home");
        }
    }
}
