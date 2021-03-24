using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewOrga
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public int? Level { get; set; }
    }
}
