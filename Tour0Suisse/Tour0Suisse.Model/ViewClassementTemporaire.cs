﻿using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewClassementTemporaire
    {
        public int IdTournament { get; set; }
        public int IdPlayer { get; set; }
        public int Victoire { get; set; }
        public int Egaliter { get; set; }
        public int Defaite { get; set; }
        public string IGPseudo { get; set; }
        public string Pseudo { get; set; }
    }
}