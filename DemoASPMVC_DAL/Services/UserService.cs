using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToolApiRequester;

namespace DemoASPMVC_DAL.Services
{
    public class UserService : GenericApiRequester, IUserService
    {
       
        private HttpClient _httpClient;
        private string _url = "https://localhost:7004/api/";

        public UserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7004/api/");
        }

        public User GetById(int id)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync("user/byid/"+id).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<User>(json);

                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        public string Login(string email, string pwd)
        {
            string token = "";
            string jsonToSend = JsonConvert.SerializeObject(new { email, password = pwd });
            HttpContent content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _httpClient.PostAsync("user/login", content).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    token = response.Content.ReadAsStringAsync().Result;

                    //JwtSecurityToken jwt = new JwtSecurityToken(token);
                    //int id = int.Parse(jwt.Claims.First(x => x.Type == ClaimTypes.Sid).Value);
                    //return GetById(id);
                }
            }
            return token;
        }

        public bool Register(string email, string pwd, string nickname)
        {
            string jsonToSend = JsonConvert.SerializeObject(new { email, password = pwd, nickname });
            HttpContent content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _httpClient.PostAsync("user/register", content).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<User> GetUsers(string token)
        {
            return Get<IEnumerable<User>>(_url+"user",token);
        }

        public bool SetRole(int idUser, int idRole, string token)
        {
            return Patch(new { idUser, idRole }, _url+"user/setrole",token);
        }
    }
}
