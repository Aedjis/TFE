﻿using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class ViewTournament
    {
        public int IdTournament { get; set; }
        public int IdGame { get; set; }
        public string Name { get; set; }
        public string Game { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int MaxNumberPlayer { get; set; }
        public int DeckListNumber { get; set; }
        public int Ppwin { get; set; }
        public int Ppdraw { get; set; }
        public int Pplose { get; set; }
        public DateTime? Deleted { get; set; }
        public bool Over { get; set; }
    }
}