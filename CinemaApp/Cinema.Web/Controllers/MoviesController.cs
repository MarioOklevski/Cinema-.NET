using Cinema.Domain.DomainModels.Domain;
using Cinema.Domain.DTO;
using Cinema.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Cinema.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        //private readonly UserManager<CinemaAppUser> _userManager;

        public MoviesController(IMovieService _movieService)
        {
            this._movieService = _movieService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            var allMovies = this._movieService.GetAllMovies();
            return View(allMovies);
        }

        public IActionResult AddMovieToCart(Guid? id)
        {
            var model = this._movieService.GetShoppingCartInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovieToCart([Bind("MovieId", "Quantity")] AddToShoppingCartDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._movieService.AddToShoppingCart(item, userId);


            if (result)
            {
                return RedirectToAction("Index", "Movies");
            }

            return View(item);
        }

        // GET: Movies/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this._movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MovieName,MovieImage,MovieDescriprtion,MoviePrice,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                this._movieService.CreateNewMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this._movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,MovieName,MovieImage,MovieDescriprtion,MoviePrice,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._movieService.UpdateExistingMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this._movieService.GetDetailsForMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return this._movieService.GetDetailsForMovie(id) != null;
        }
    }
}
