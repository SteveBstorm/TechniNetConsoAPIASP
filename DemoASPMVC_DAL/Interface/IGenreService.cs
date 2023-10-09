using DemoASPMVC_DAL.Models;

namespace DemoASPMVC_DAL.Interface
{
    public interface IGenreService
    {
        void Add(string genre);
        IEnumerable<Genre> GetAll();

        Genre GetById(int id);
    }
}