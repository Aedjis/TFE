using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Tour0Suisse.Model
{
    public interface IViewUser
    {
        int IdUser { get; set; }
        string Pseudo { get; set; }
        string Email { get; set; }
        bool Organizer { get; set; }
        DateTime? Deleted { get; set; }
    }

    public class ViewUser : IViewUser
    {
        public int IdUser { get; set; }
        [Display(Name = "Nom")]
        public string Pseudo { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Organise des tournois")]
        public bool Organizer { get; set; }
        [Display(Name = "Date de supression de l'utilisateur")]
        public DateTime? Deleted { get; set; }

    }
}
