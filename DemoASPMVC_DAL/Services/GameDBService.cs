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
    public class GameDBService : GenericApiRequester, IGameService
    {
        private readonly string _url;

        public GameDBService(IConfiguration config)
        {
            _url = config.GetConnectionString("api");

        }
        public void AddFavorite(int idUser, int idGame)
        {
            Post(new { idUser, idGame }, _url+"game/addfavorite");
        }

        public void Create(Game game, string token)
        {
            Post(game, _url + "game", token);
        }

        public void Delete(int id)
        {
            Delete(_url + "game/" + id);
        }

        public Game GetById(int id)
        {
            return Get<Game>(_url + "Game/" + id);
        }

        public IEnumerable<Game> GetByUserId(int userId, string token)
        {
            return Get<IEnumerable<Game>>(_url + "game/favoris/" + userId, token);
        }

        public IEnumerable<Game> GetGames()
        {
            return Get<IEnumerable<Game>>(_url + "game");
        }
    }
}
