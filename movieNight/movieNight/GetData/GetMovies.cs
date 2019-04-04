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
        public static async Task<List<MovieDataModel>> GetMovieByIdDataTask(int id, Context content)
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

        public static async Task<MovieDetailsDataModel> GetMovieDetailsDataTask(int id)
        {
            string key = "ed47b05cca6dc603460f42899bea7008";
            string url = "https://api.themoviedb.org/3/movie/" + id + "?api_key=" + key + "&language=en-US";

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);


            MovieDetailsDataModel MovieDetails = new MovieDetailsDataModel();
            MovieDetails = new MovieDetailsDataModel
            {
                adult = (bool)results["adult"],
                backdrop_path = string.IsNullOrEmpty((string)results["backdrop_path"]) ? "0" : (string)results["backdrop_path"],
                budget = (int)results["budget"],
                id = (int)results["id"],
                title = (string)results["title"],
                overview = (string)results["overview"],
                poster_path = string.IsNullOrEmpty((string)results["poster_path"]) ? "0" : (string)results["poster_path"],
                release_date = (string)results["release_date"],
                revenue = (int)results["revenue"],
                tagline = string.IsNullOrEmpty((string)results["tagline"]) ? "0" : (string)results["tagline"],
                runtime = (int)results["runtime"],
                status = (string)results["status"],
                original_language = (string)results["original_language"],
                popularity = ((int)results["popularity"]).ToString(),
                genres = (string)results["genres"][0]["name"] + ", " + (string)results["genres"][1]["name"] + ", " + (string)results["genres"][2]["name"]

            };

            return MovieDetails;
        }

        public static async Task<List<MovieDataModel>>GetMoviesDataTask(string query)
        {
            string key = "ed47b05cca6dc603460f42899bea7008";
            string url = "https://api.themoviedb.org/3/search/movie?api_key=" + key + "&query=" + query;
            int NumberOfResults;

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);
            NumberOfResults = ((JArray)results["results"]).Count;

            List<MovieDataModel> Movies = new List<MovieDataModel>();
            for (int i = 0; i < NumberOfResults; i++)
            {
                var data = new MovieDataModel()
                {
                    title = (string)results["results"][i]["title"],
                    posterUrl = (string)results["results"][i]["poster_path"],
                    overview = (string)results["results"][i]["overview"],
                    releaseDate = (string)results["results"][i]["release_date"],
                    id = (int)results["results"][i]["id"]
                };
                Movies.Add(data);
            }
            return Movies;
        }
    }
}