using System;
using System.Collections.Generic;

namespace Tour0Suisse.Repository
{
    public partial class ViewPseudo
    {
        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public int IdGame { get; set; }
        public string Game { get; set; }
        public string IgPseudo { get; set; }
    }
}
