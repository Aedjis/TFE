using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tour0Suisse.Model
{
    public class Organisateur : IViewOrga
    {
        public Organisateur()
        {
            User = new ViewUser();
        }
        public IViewTournament Tournament { get; set; }
        public IViewUser User { get; set; }
        [Display(Name = "Niveau de compétance")]
        public int? Level { get; set; }
        public string Name { get => Tournament.Name; set => Tournament.Name = value; }
        public int IdUser { get => User.IdUser; set => User.IdUser = value; }
        public string Pseudo { get => User.Pseudo; set => User.Pseudo = value; }
        public int IdTournament { get => Tournament.IdTournament; set => Tournament.IdTournament = value; }
    }
}
