using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;

namespace restauranter.Controllers
{
    public class ReviewController : Controller
    {
        private RestaurContext _context;
 
        public ReviewController(RestaurContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View("Index");
        }
        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ReviewViewModel item)
        {
            // As soon as the model is submitted TryValidateModel() is run for us, ModelState is already set
            if(ModelState.IsValid)
            {
                // Handle Success Case
                Review newReview = new Review {
                    ReviewerName = item.ReviewerName,
                    RestaurantName = item.RestaurantName,
                    ReviewText = item.ReviewText,
                    Rating = item.Rating,
                    DateVisit = item.DateVisit
                };
                // _context.Add(NewPerson);
                // OR _context.Users.Add(NewPerson);
                _context.Reviews.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("ShowReviews");
            }
            return View("Index",item);
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult ShowReviews()
        {
            List<Review> AllReviews = _context.Reviews.ToList();
            ViewBag.Reviews = AllReviews;
            return View("AllReviews");
        }

        [HttpGet]
        [Route("/{ReviewId}/{RateType}")]
        public IActionResult RateReview(int ReviewId, string RateType)
        {
            Review RateReview = _context.Reviews.SingleOrDefault(r => r.ReviewId == ReviewId);
            if (RateType == "helpful") 
            {
                RateReview.Helpful += 1; 
            } else if (RateType == "unhelpful") {
                RateReview.Unhelpful += 1;
            }
            _context.SaveChanges();
            
            return RedirectToAction("ShowReviews");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
