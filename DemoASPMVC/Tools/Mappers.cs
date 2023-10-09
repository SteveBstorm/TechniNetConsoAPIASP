using DAL = DemoASPMVC_DAL.Models;
using ASP = DemoASPMVC.Models;
using DemoASPMVC.Models.ViewModel;

namespace DemoASPMVC.Tools
{
    public static class Mappers
    {
        //Methode d'extension
        public static DAL.Game ToDal(this GameForm game)
        {
            return new DAL.Game
            {
                Title = game.Title,
                IdGenre = game.IdGenre,
                Description = game.Description
            };
        }
        public static ASP.Game ToASP(this DAL.Game game)
        {
            return new ASP.Game
            {
                Id = game.Id,
                Title = game.Title,
                IdGenre = game.IdGenre,
                Description = game.Description,
                Genre = game.Genre is not null ? game.Genre.Label : ""
            };
        }
    }
}
