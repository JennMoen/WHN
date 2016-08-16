using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class GooglePlaceService
    {
        private static HttpClient Client { get; set; }
        public static string AppSercret = "AIzaSyAhVEucz_h1LEmiUD5q1wlSeK-pv90KFDk";

        public void Api()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/");
        }
    }

}
