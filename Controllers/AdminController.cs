using Island.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Island.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext mydb = new ApplicationDbContext();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        //------------------------- users
        //this function is for creating and editing a user
        public ActionResult User(int? id)
        {
            var result = new User();
            if (id != null)
            {
                var row = mydb.Users.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }
        //this function is for saving edited users
        [HttpPost]
        public ActionResult User(User row)
        {
            if (ModelState.IsValid == true)
            {
                if (row.id != 0)
                {
                    var result = mydb.Users.Where(p => p.id == row.id).FirstOrDefault();
                    result.FirstName = row.FirstName;
                    result.LastName = row.LastName;
                    result.Username = row.Username;
                    result.Password = row.Password;
                    result.Email = row.Email;
                    result.PhoneNumber = row.PhoneNumber;
                    result.Country = row.Country;
                    result.City = row.City;
                    result.Gender = row.Gender;

                    mydb.SaveChanges();
                    return RedirectToAction("UserList");
                }
                else
                {
                    mydb.Users.Add(row);
                    mydb.SaveChanges();
                    return RedirectToAction("UserList");
                }
            }
            return View(row);
        }
        //this function is for showing all users
        public ActionResult UserList(string searchValue, int? searchUserId)
        {
            var result = mydb.Users.ToList();

            if (searchValue != null && searchValue.Length > 0)
            {
                var searchValue1 = searchValue.Trim();
                result = result.Where(p => p.Username.Contains(searchValue1)).ToList();
            }
            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.id == searchUserId).ToList();
            }

            return View(result);
        }
        //this function is for deleting a user with ajax
        public async Task<ActionResult> DeleteUserByAjax(int id)
        {
            var result = mydb.Users.Where(p => p.id == id).FirstOrDefault();
            mydb.Users.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "User deleted" });

        }

        //------------------------- places 
        //this function is for creating and editing a place
        public ActionResult Place(int? id)
        {
            var result = new Place();
            if (id != null)
            {
                var row = mydb.Places.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }
        //this function is for saving edited places
        [HttpPost]
        public ActionResult Place(Place row)
        {
            if (ModelState.IsValid == true)
            {
                if (row.id != 0)
                {
                    var result = mydb.Places.Where(p => p.id == row.id).FirstOrDefault();
                    result.Name = row.Name;
                    result.Address = row.Address;
                    result.latG = row.latG;
                    result.longG = row.longG;
                    result.PhoneNumber = row.PhoneNumber;
                    result.TellNumber = row.TellNumber;
                    result.OpennigHour = row.OpennigHour;
                    result.MoreInfo = row.MoreInfo;
                    result.Instagram = row.Instagram;
                    result.Website = row.Website;
                    result.UserId = row.UserId;
                    result.CategoryId = row.CategoryId;


                    mydb.SaveChanges();
                    return RedirectToAction("PlacesList");
                }
                else
                {
                    mydb.Places.Add(row);
                    mydb.SaveChanges();
                    return RedirectToAction("PlacesList");
                }
            }
            return View(row);
        }

        public ActionResult PlacesList(string searchValue, int? searchPlaceId, int? searchUserId, int? searchCategoryId)
        {
            var result = mydb.Places.ToList();

            if (searchValue != null && searchValue.Length > 0)
            {
                var searchValue1 = searchValue.Trim();
                result = result.Where(p => p.Name.Contains(searchValue1)).ToList();
            }

            if (searchPlaceId != null && searchPlaceId != 0)
            {
                result = result.Where(p => p.id == searchPlaceId).ToList();
            }

            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }

            if (searchCategoryId != null && searchCategoryId != 0)
            {
                result = result.Where(p => p.CategoryId == searchCategoryId).ToList();
            }

            return View(result);
        }

        public async Task<ActionResult> DeletePlaceByAjax(int id)
        {
            var result = mydb.Places.Where(p => p.id == id).FirstOrDefault();
            mydb.Places.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Place deleted" });

        }

        //------------------------- place's images 
        public ActionResult PlaceGallery(int? id)
        {
            var result = new PlaceGallery();
            if (id != null)
            {
                var row = mydb.PlaceGalleries.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult PlaceGallery(PlaceGallery row, HttpPostedFileBase f1)
        {
            var result = mydb.PlaceGalleries.Where(p => p.id == row.id).FirstOrDefault();
  
            if (f1 != null)
            {
                var namefile = Path.GetFileName(f1.FileName);
                var directoryToSave = Server.MapPath(Url.Content("~/uploadPlaceimg"));
                var uploadpath = Path.Combine(directoryToSave, namefile);
                f1.SaveAs(uploadpath);
            }

            if (ModelState.IsValid)
            {
                if (result == null)
                {
                    row.filePath = Path.GetFileName(f1.FileName);
                    mydb.PlaceGalleries.Add(row);
                    mydb.SaveChanges();
                }
                else
                {
                    result.title = row.title;
                    result.filePath = Path.GetFileName(f1.FileName);
                    mydb.SaveChanges();
                }
                return RedirectToAction("PlacesListGallery");
            }

            return View(row);
        }
        public ActionResult PlacesListGallery(int? searchPlaceId, int? searchUserId)
        {
            var result = mydb.PlaceGalleries.ToList();
            if (searchPlaceId != null && searchPlaceId != 0)
            {
                result = result.Where(p => p.PlaceId == searchPlaceId).ToList();
            }

            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }

            return View(result);
        }

        public async Task<ActionResult> DeletePlaceImageByAjax(int id)
        {
            var result = mydb.PlaceGalleries.Where(p => p.id == id).FirstOrDefault();
            mydb.PlaceGalleries.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Image deleted" });

        }
        //------------------------- place's reviews 
        public ActionResult PlaceReview()
        {
            var result = new PlaceReview();
            return View(result);
        }
        [HttpPost]
        public ActionResult PlaceReview(PlaceReview row)
        {
            if (ModelState.IsValid)
            {
                mydb.PlaceReviews.Add(row);
                mydb.SaveChanges();
                return RedirectToAction("PlacesReviewList");
            }

            return View(row);
        }
        public ActionResult PlacesReviewList(int? searchPlaceId, int? searchUserId, int? searchId)
        {
            var result = mydb.PlaceReviews.ToList();
            if (searchPlaceId != null && searchPlaceId != 0)
            {
                result = result.Where(p => p.PlaceId == searchPlaceId).ToList();
            }
            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }
            if (searchId != null && searchId != 0)
            {
                result = result.Where(p => p.id == searchId).ToList();
            }
            return View(result);
        }
        public async Task<ActionResult> DeletePlaceReviewByAjax(int id)
        {
            var result = mydb.PlaceReviews.Where(p => p.id == id).FirstOrDefault();
            mydb.PlaceReviews.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Place's review deleted" });

        }
        //------------------------- place reviews' report
        public ActionResult PlaceReviewReport()
        {
            var result = new PlaceReport();
            return View(result);
        }
        [HttpPost]
        public ActionResult PlaceReviewReport(PlaceReport row)
        {
            if (ModelState.IsValid)
            {
                mydb.PlaceReports.Add(row);
                mydb.SaveChanges();
                return RedirectToAction("PlaceReviewsReportList");
            }

            return View(row);
        }
        public ActionResult PlaceReviewsReportList()
        {
            var result = mydb.PlaceReports.ToList();
           
            return View(result);
        }
        public async Task<ActionResult> DeletePlaceReportByAjax(int id)
        {
            var result = mydb.PlaceReports.Where(p => p.id == id).FirstOrDefault();
            mydb.PlaceReports.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Place review's report deleted" });

        }


        //------------------------- Services 
        //this function is for creating and editing a service
        public ActionResult Service(int? id)
        {
            var result = new Service();
            if (id != null)
            {
                var row = mydb.Services.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }
        //this function is for saving edited service
        [HttpPost]
        public ActionResult Service(Service row)
        {
            if (ModelState.IsValid == true)
            {
                if (row.id != 0)
                {
                    var result = mydb.Services.Where(p => p.id == row.id).FirstOrDefault();
                    result.title = row.title;
                    result.FirstName = row.FirstName;
                    result.LastName = row.LastName;
                    result.Address = row.Address;
                    result.PhoneNumber = row.PhoneNumber;
                    result.TellNumber = row.TellNumber;
                    result.Gender = row.Gender;
                    result.Bio = row.Bio;
                    result.Website = row.Website;
                    result.UserId = row.UserId;
                    result.CategoryId = row.CategoryId;


                    mydb.SaveChanges();
                    return RedirectToAction("ServicesList");
                }
                else
                {
                    mydb.Services.Add(row);
                    mydb.SaveChanges();
                    return RedirectToAction("ServicesList");
                }
            }
            return View(row);
        }

        public ActionResult ServicesList(string searchValue, int? searchServiceId, int? searchUserId, int? searchCategoryId)
        {
            var result = mydb.Services.ToList();

            if (searchValue != null && searchValue.Length > 0)
            {
                var searchValue1 = searchValue.Trim();
                result = result.Where(p => p.title.Contains(searchValue1)).ToList();
            }
            if (searchServiceId != null && searchServiceId != 0)
            {
                result = result.Where(p => p.id == searchServiceId).ToList();
            }

            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }

            if (searchCategoryId != null && searchCategoryId != 0)
            {
                result = result.Where(p => p.CategoryId == searchCategoryId).ToList();
            }

            return View(result);
        }

        public async Task<ActionResult> DeleteServiceByAjax(int id)
        {
            var result = mydb.Services.Where(p => p.id == id).FirstOrDefault();
            mydb.Services.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Service deleted" });

        }

        //------------------------- services's images 
        public ActionResult ServiceGallery(int? id)
        {
            var result = new ServiceGallery();
            if (id != null)
            {
                var row = mydb.ServiceGalleries.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult ServiceGallery(ServiceGallery row, HttpPostedFileBase f1)
        {
            var result = mydb.ServiceGalleries.Where(p => p.id == row.id).FirstOrDefault();

            if (f1 != null)
            {
                var namefile = Path.GetFileName(f1.FileName);
                var directoryToSave = Server.MapPath(Url.Content("~/uploadServiceimg"));
                var uploadpath = Path.Combine(directoryToSave, namefile);
                f1.SaveAs(uploadpath);
            }

            if (ModelState.IsValid)
            {
                if (result == null)
                {
                    row.filePath = Path.GetFileName(f1.FileName);
                    mydb.ServiceGalleries.Add(row);
                    mydb.SaveChanges();
                }
                else
                {
                    result.title = row.title;
                    result.filePath = Path.GetFileName(f1.FileName);
                    mydb.SaveChanges();
                }
                return RedirectToAction("ServicesListGallery");
            }

            return View(row);
        }
        public ActionResult ServicesListGallery(int? searchServiceId, int? searchUserId)
        {
            var result = mydb.ServiceGalleries.ToList();
            if (searchServiceId != null && searchServiceId != 0)
            {
                result = result.Where(p => p.ServiceId == searchServiceId).ToList();
            }

            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }
            
            return View(result);
        }

        public async Task<ActionResult> DeleteServiceImageByAjax(int id)
        {
            var result = mydb.ServiceGalleries.Where(p => p.id == id).FirstOrDefault();
            mydb.ServiceGalleries.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Image deleted" });

        }
        //------------------------- services's reviews 
        public ActionResult ServiceReview()
        {
            var result = new ServiceReview();
            return View(result);
        }
        [HttpPost]
        public ActionResult ServiceReview(ServiceReview row)
        {
            if (ModelState.IsValid)
            {
                mydb.ServiceReviews.Add(row);
                mydb.SaveChanges();
                return RedirectToAction("ServicesReviewList");
            }

            return View(row);
        }
        public ActionResult ServicesReviewList(int? searchServiceId, int? searchUserId, int? searchId)
        {
            var result = mydb.ServiceReviews.ToList();
            if (searchServiceId != null && searchServiceId != 0)
            {
                result = result.Where(p => p.ServiceId == searchServiceId).ToList();
            }
            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }
            if (searchId != null && searchId != 0)
            {
                result = result.Where(p => p.id == searchId).ToList();
            }
            return View(result);
        }
        public async Task<ActionResult> DeleteServiceReviewByAjax(int id)
        {
            var result = mydb.ServiceReviews.Where(p => p.id == id).FirstOrDefault();
            mydb.ServiceReviews.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Service's review deleted" });

        }

        //------------------------- service reviews' report
        public ActionResult ServiceReviewReport()
        {
            var result = new ServiceReport();
            return View(result);
        }
        [HttpPost]
        public ActionResult ServiceReviewReport(ServiceReport row)
        {
            if (ModelState.IsValid)
            {
                mydb.ServiceReports.Add(row);
                mydb.SaveChanges();
                return RedirectToAction("ServiceReviewsReportList");
            }

            return View(row);
        }
        public ActionResult ServiceReviewsReportList()
        {
            var result = mydb.ServiceReports.ToList();

            return View(result);
        }
        public async Task<ActionResult> DeleteServiceReportByAjax(int id)
        {
            var result = mydb.ServiceReports.Where(p => p.id == id).FirstOrDefault();
            mydb.ServiceReports.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Service review's report deleted" });

        }

        //------------------------- Category 
        //this function is for creating and editing a place
        public ActionResult Category(int? id)
        {
            var result = new Category();
            if (id != null)
            {
                var row = mydb.Categories.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }
        //this function is for saving edited Categories
        [HttpPost]
        public ActionResult Category(Category row)
        {
            if (ModelState.IsValid == true)
            {
                if (row.id != 0)
                {
                    var result = mydb.Categories.Where(p => p.id == row.id).FirstOrDefault();
                    result.Name = row.Name;
                    mydb.SaveChanges();
                    return RedirectToAction("CategoriesList");
                }
                else
                {
                    mydb.Categories.Add(row);
                    mydb.SaveChanges();
                    return RedirectToAction("CategoriesList");
                }
            }
            return View(row);
        }

        public ActionResult CategoriesList()
        {
            var result = mydb.Categories.ToList();
            return View(result);
        }

        public async Task<ActionResult> DeleteCategoryByAjax(int id)
        {
            var result = mydb.Categories.Where(p => p.id == id).FirstOrDefault();
            mydb.Categories.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Category deleted" });

        }


        //------------------------- Favorites 
        //this function is for creating and editing a Favorite
        public ActionResult Favorite(int? id)
        {
            var result = new Favorite();
            if (id != null)
            {
                var row = mydb.Favorites.Where(p => p.id == id).FirstOrDefault();
                result = row;
            }
            return View(result);
        }
        //this function is for saving edited Favorites
        [HttpPost]
        public ActionResult Favorite(Favorite row)
        {
            if (ModelState.IsValid == true)
            {
                if (row.id != 0)
                {
                    var result = mydb.Favorites.Where(p => p.id == row.id).FirstOrDefault();
                    result.UserId = row.UserId;
                    result.PlaceId = row.PlaceId;
                    result.ServiceId = row.ServiceId;

                    mydb.SaveChanges();
                    return RedirectToAction("FavoritesList");
                }
                else
                {
                    mydb.Favorites.Add(row);
                    mydb.SaveChanges();
                    return RedirectToAction("FavoritesList");
                }
            }
            return View(row);
        }

        public ActionResult FavoritesList(int? searchUserId)
        {
            var result = mydb.Favorites.ToList();
            if (searchUserId != null && searchUserId != 0)
            {
                result = result.Where(p => p.UserId == searchUserId).ToList();
            }
            return View(result);
        }

        public async Task<ActionResult> DeleteFavoriteByAjax(int id)
        {
            var result = mydb.Favorites.Where(p => p.id == id).FirstOrDefault();
            mydb.Favorites.Remove(result);
            mydb.SaveChanges();

            return Json(new { msg = "Favorite deleted" });

        }
    }
}