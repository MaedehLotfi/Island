using Island.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Island.Controllers
{
    public class UserController : ApiController
    {
        ApplicationDbContext mydb = new ApplicationDbContext();
        
        //all services

        List<Models.Service> ServicesList = new List<Models.Service>();
        public IEnumerable<Models.Service> GetServices()
        {
            ServicesList = mydb.Services.ToList();
            return ServicesList;
        }

        //specidic Service with Serviceid
        List<Models.Service> ServiceList = new List<Models.Service>();
        public IEnumerable<Models.Service> GetService(int id)
        {
            ServiceList = mydb.Services.Where(p => p.id == id).ToList();
            return ServiceList;
        }

        //specidic places created by userid
        List<Models.Service> userServiceList = new List<Models.Service>();
        public IEnumerable<Models.Service> GetuserServices(int id)
        {
            userServiceList = mydb.Services.Where(p => p.UserId == id).ToList();
            return userServiceList;
        }




        //all places

        List<Models.Place> PlacesList = new List<Models.Place>();
        public IEnumerable<Models.Place> GetPlaces()
        {
            PlacesList = mydb.Places.ToList();
            return PlacesList;
        }

        //specidic place with placeid
        List<Models.Place> PlaceList = new List<Models.Place>();
        public IEnumerable<Models.Place> GetPlace(int id)
        {
            PlaceList = mydb.Places.Where(p => p.id == id).ToList();
            return PlaceList;
        }

        //specidic places created by userid
        List<Models.Place> userPlaceList = new List<Models.Place>();
        public IEnumerable<Models.Place> GetuserPlaces(int id)
        {
            userPlaceList = mydb.Places.Where(p => p.UserId == id).ToList();
            return userPlaceList;
        }


        //all users
        List<Models.User> UsersList = new List<Models.User>();
        public IEnumerable<Models.User> GetUsers()
        {
            UsersList = mydb.Users.ToList();
            return UsersList;
        }


        //specific user infos with userid
        List<Models.User> UserList = new List<Models.User>();
        public IEnumerable<Models.User> GetUser(int id)
        {
            UserList = mydb.Users.Where(p => p.id == id).ToList();
            return UserList;
        }

        //Specific user favorites
        List<Models.Favorite> UserFavorites = new List<Models.Favorite>();
        public IEnumerable<Models.Favorite> GetUserFavorite(int id)
        {
            UserFavorites = mydb.Favorites.Where(p => p.UserId == id).ToList();
            return UserFavorites;
        }

        //Specific user placereports
        List<Models.PlaceReport> UserPlaceReports = new List<Models.PlaceReport>();
        public IEnumerable<Models.PlaceReport> GetUserPlaceReport(int id)
        {
            UserPlaceReports = mydb.PlaceReports.Where(p => p.UserId == id).ToList();
            return UserPlaceReports;
        }
        //Specific user servicereports
        List<Models.ServiceReport> UserServiceReports = new List<Models.ServiceReport>();
        public IEnumerable<Models.ServiceReport> GetUserServiceReport(int id)
        {
            UserServiceReports = mydb.ServiceReports.Where(p => p.UserId == id).ToList();
            return UserServiceReports;
        }

        //Specific user placereviews
        List<Models.PlaceReview> UserPlaceReviews = new List<Models.PlaceReview>();
        public IEnumerable<Models.PlaceReview> GetUserPlaceReview(int id)
        {
            UserPlaceReviews = mydb.PlaceReviews.Where(p => p.UserId == id).ToList();
            return UserPlaceReviews;
        }
        //Specific user servicereviews
        List<Models.ServiceReview> UserServiceReviews = new List<Models.ServiceReview>();
        public IEnumerable<Models.ServiceReview> GetUserServiceReview(int id)
        {
            UserServiceReviews = mydb.ServiceReviews.Where(p => p.UserId == id).ToList();
            return UserServiceReviews;
        }


        //[System.Web.Http.HttpPost]
        //public void AddUser([FormBody]Models.User person)
        //{
        //    mydb.Users.Add(person);
        //    mydb.SaveChanges();
        //}



        //[System.Web.Http.HttpPut]
        //public void EditUser(int id, [FormBody] Models.User person)
        //{
        //    var UsersExited = mydb.Users.Where(p => p.id == id).FirstOrDefault<Models.User>();
        //    UsersExited.FirstName= person.FirstName;
        //    UsersExited.LastName= person.LastName;
        //    UsersExited.Username= person.Username;
        //    UsersExited.Password = person.Password;
        //    UsersExited.Email= person.Email;
        //    UsersExited.PhoneNumber = person.PhoneNumber;
        //    UsersExited.Country = person.Country;
        //    UsersExited.City = person.City;
        //    UsersExited.Gender = person.Gender;
        //    mydb.SaveChanges();
        //}


        //List<Models.User> UserX = new List<Models.User>();
        //public void DeleteUser(int id)
        //{
        //    UserX = mydb.Users.Where(p => p.id == id).ToList();
        //    mydb.Users.RemoveRange(UserX);
        //    mydb.SaveChanges();
        //}

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    internal class FormBodyAttribute : Attribute
    {
    }
}