using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace HousesApiTest
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [AllureSuite("API")]
    [AllureSubSuite("Role Tests")]
    public class HousesTests
    {
        private const string BASE_URL = "https://www.anapioficeandfire.com/api/";
        private JsonSchema schema = JsonSchema.Parse(
                @"{
            'url': {'type':'string'},
            'name': {'type': 'string'},
            'region': {'type':'string'},
            'coatOfArms': {'type': 'string'},
            'words': {'type':'string'},
            'titles': {'type': 'array'},
            'seats': {'type':'array'},
            'currentLord': {'type': 'string'},
            'overlord': {'type':'string'},
            'founded': {'type': 'string'},
            'founder': {'type':'string'},
            'diedOut': {'type': 'string'},
            'ancestralWeapons': {'type':'array'},
            'cadetBranches': {'type': 'array'},
            'swornMembers': {'type':'array'}
        }");
        
        [OneTimeSetUp]
        public void Init()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [Test, Description("Checking houses json scheme")]
        public void Test_SortHouses()
        {
            //Creating Client connection
            RestClient client = new RestClient(BASE_URL);
            //Creating request to get data from server
            RestRequest request = new RestRequest("houses", Method.GET);
           
            //Specify query string
            request.AddParameter("region", "Dorne");
            request.AddParameter("haswords", "true");
            request.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            
            // Executing request to server and checking server response to the it
            IRestResponse response = client.Execute(request);
            var housesModel = JsonConvert.DeserializeObject<List<HousesModel>>(response.Content);
            
            //JSON validation against JSON schema
            JArray jsonArray = JArray.Parse(response.Content);
            var data = JObject.Parse(jsonArray[0].ToString());
            var valid = data.IsValid(schema);

            Assert.Multiple(() =>
            {
                foreach (var val in housesModel)
                {
                    Assert.True(val.Region.Equals("Dorne"), "All regions aren't equal Dorne");
                    Assert.NotNull(val.Words, "All word aren't equal null");
                }
                
                Assert.True(valid,"Json Schema isn't correct");
                Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"), "ContentType isn't application/json");
                Assert.AreNotEqual(response.StatusCode, HttpStatusCode.BadRequest, "HttpStatusCode isn't BadRequest");
            });
        }
    }
}
