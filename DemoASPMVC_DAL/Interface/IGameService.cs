using DemoASPMVC_DAL.Models;

namespace DemoASPMVC_DAL.Interface
{
    public interface IGameService
    {
        void Create(Game game, string token);
        void Delete(int id);
        Game GetById(int id);
        IEnumerable<Game> GetGames();
        IEnumerable<Game> GetByUserId(int userId, string token);
        void AddFavorite(int idUser, int idGame);
    }
}