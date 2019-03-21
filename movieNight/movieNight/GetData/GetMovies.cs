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
    public class GetMovies
    {
        public static async Task<List<MovieDataModel>> GetMovieDataTask(int id, Context content)
        {
            string key = "ed47b05cca6dc603460f42899bea7008";
            string url = "https://api.themoviedb.org/3/person/" + id + "/movie_credits?api_key=" + key + "&language=en-US";
            int NumberOfResults;

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);
            NumberOfResults = ((JArray)results["cast"]).Count;

            List<MovieDataModel> Movies = new List<MovieDataModel>();

            for (int i = 0; i < NumberOfResults; i++)
            {
                var data = new MovieDataModel()
                {
                    character = (string)results["cast"][i]["character"],
                    adult = (bool)results["cast"][i]["adult"],
                    id = (int)results["cast"][i]["id"],
                    overview = (string)results["cast"][i]["overview"],
                    posterUrl = (string)results["cast"][i]["poster_path"],
                    releaseDate = (string)results["cast"][i]["release_date"],
                    title = (string)results["cast"][i]["title"]

                };
                Movies.Add(data);
            }

            return Movies;
        }
    }
}