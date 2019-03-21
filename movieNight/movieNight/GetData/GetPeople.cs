using Android.Content;
using Android.Views;
using Android.Widget;
using movieNight.Model;
using movieNight.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Media.Audiofx;

namespace movieNight.GetData
{
    public class GetPeople
    {
        public static async Task<List<PeopleDataModel>> GetPeopleDataTask(string name)
        {
            
                string key = "ed47b05cca6dc603460f42899bea7008";
                string url = "https://api.themoviedb.org/3/search/person?api_key=" + key + "&search_type=ngram&query=" + name;
                int NumberOfResults;

                dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);
                NumberOfResults = ((JArray)results["results"]).Count;

                if (NumberOfResults > 50)
                {
                    NumberOfResults = 50;
                }
                List<PeopleDataModel> People = new List<PeopleDataModel>();

                for (int i = 0; i < NumberOfResults; i++)
                {
                    var data = new PeopleDataModel()
                    {
                        id = (int)results["results"][i]["id"],
                        popularity = (float)results["results"][i]["popularity"], //popularity out of 100%
                        imageUrl = (string)results["results"][i]["profile_path"], //Can return null
                        name = (string)results["results"][i]["name"],
                        //Description = (string)results["weather"][0]["main"],
                        //Wind = (string)results["wind"]["speed"],
                        //Icon = (string)results["weather"][0]["icon"]
                    };
                    People.Add(data);
                }

                return People;
            
        }
    }
}