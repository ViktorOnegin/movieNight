using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using movieNight.Model;
using movieNight.Services;
using Newtonsoft.Json.Linq;

namespace movieNight.GetData
{
    public class GetMovieDetails
    {
        public static async Task<MovieDetailsDataModel> GetMovieDetailsDataTask(int id)
        {
            string key = "ed47b05cca6dc603460f42899bea7008";
            string url = "https://api.themoviedb.org/3/movie/" + id + "?api_key=" + key + "&language=en-US";

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);
           

            MovieDetailsDataModel MovieDetails = new MovieDetailsDataModel();
            MovieDetails = new MovieDetailsDataModel
            {
                adult = (bool) results["adult"],
                backdrop_path = (string) results["backdrop_path"],
                budget = (int) results["budget"],
                id = (int) results["id"],
                title = (string)results["title"],
                overview = (string) results["overview"],
                poster_path = (string) results["poster_path"],
                release_date = (string)results["release_date"],
                revenue = (int) results["revenue"],
                tagline = (string)results["tagline"],
                runtime = (int)results["runtime"]
            };

            return MovieDetails;
        }
    }
}