using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Bordspil.Models
{

    public class Game
    {
        [Key]
        [Display(Name = "Leikur nr.")]
        public int gameID { get; set; }
        [Display(Name = "Nafn")]
        [Required(ErrorMessage = "Þú verður nú að nefna greyið leikinn")]
        public string gameName { get; set; }
        [Display(Name = "Leikur")]
        [Required(ErrorMessage = "Læra að velja týpu, þarna")]
        public GameType gameType { get; set; }
        [Display(Name = "Virkur")]
        public bool gameActive { get; set; }
        [Display(Name = "Leikmenn")]
        public ICollection<UserProfile> gamePlayers { get; set; }
        [Display(Name = "Í bið")]
        public bool gamePending { get; set; }
        [Display(Name = "Sigurvegari")]
        public UserProfile gameWinner { get; set; }
    }

    public class GameType
    {
        [Key]
        [Display(Name = "Leiktýpa nr.")]
        public int gameTypeID { get; set; }
        [Display(Name = "Nafn")]
        [Required(ErrorMessage = "Þú verður nú að nefna greyið leikinn")]
        public string gameTypeName { get; set; }
        [Display(Name = "Hámarksfjöldi spilara")]
        public int maxPlayers { get; set; }
        [Display(Name = "Lágmarksfjöldi spilara")]
        public int minPlayers { get; set; }
        [Display(Name = "Hlekkur")]
        [Required(ErrorMessage = "Hlekkur á leik")]
        public string gameTypeLink { get; set; }
        [Display(Name = "Myndahlekkur")]
        [Required(ErrorMessage = "Hlekkur á mynd leiks")]
        public string gameTypeImgUrl { get; set; }
    }
}