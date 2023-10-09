using DemoASPMVC_DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DemoASPMVC.Models.ViewModel
{
    public class GameForm
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Titre du jeu")]
        [MinLength(5, ErrorMessage = "Le titre doit faire minimum 5 caractères")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdGenre { get; set; }

        public IEnumerable<Genre> GenreList { get; set; }
    }
}
