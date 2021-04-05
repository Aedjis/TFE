using System;
using System.Collections.Generic;
using System.Text;

namespace Tour0Suisse.Model
{
    public class RetourAPI
    {
        public RetourAPI(bool Succes, string Message = "", int? CreateId = null)
        {
            this.Succes = Succes;
            this.Message = Message;
            this.CreateID = CreateId;
        }

        public bool Succes { get; set; }
        public string Message { get; set; }
        public int? CreateID { get; set; }
    }
}
