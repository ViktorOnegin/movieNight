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
    public class GetPopular
    {
        public static async Task<List<MovieDataModel>> GetPopularDataTask()
        {
            string key = "ed47b05cca6dc603460f42899bea7008";
            string url = "https://api.themoviedb.org/3/trending/all/week?api_key=" + key;
            int NumberOfResults;

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);
            NumberOfResults = ((JArray)results["results"]).Count;

            List<MovieDataModel> Popular = new List<MovieDataModel>();

            for (int i = 0; i < NumberOfResults; i++)
            {
                MovieDataModel data = null;
                if (results["results"][i]["name"] == null)
                {
                    data = new MovieDataModel()
                    {
                        adult = (bool)results["results"][i]["adult"],
                        id = (int)results["results"][i]["id"],
                        overview = (string)results["results"][i]["overview"],
                        posterUrl = (string)results["results"][i]["poster_path"],
                        releaseDate = "Release Date: " + (string)results["results"][i]["release_date"],
                        title = (string)results["results"][i]["title"]
                    };
                }
                else if (results["results"][i]["title"] == null)
                {
                    data = new MovieDataModel()
                    {
                        adult = false,
                        id = (int)results["results"][i]["id"],
                        overview = (string)results["results"][i]["overview"],
                        posterUrl = (string)results["results"][i]["poster_path"],
                        releaseDate = "Air Date: " + (string)results["results"][i]["first_air_date"],
                        title = (string)results["results"][i]["name"]
                    };
                }
                
                Popular.Add(data);
            }

            return Popular;
        }
    }
}