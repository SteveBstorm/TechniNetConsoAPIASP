using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApiRequester;

namespace DemoASPMVC_DAL.Services
{
    public class GenreService : GenericApiRequester, IGenreService
    {
        private readonly string _url;
        
        public GenreService(IConfiguration config)
        {
            _url = config.GetConnectionString("api");
            
        }
        public void Add(string genre)
        {

            Post(genre, _url + "genre");
        }

        public IEnumerable<Genre> GetAll()
        {
            return Get<IEnumerable<Genre>>(_url + "genre");
        }

        public Genre GetById(int id)
        {
            return Get<Genre>(_url + "genre/"+id);
        }

        public void Delete(int id)
        {

        }
    }
}
