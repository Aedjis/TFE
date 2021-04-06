using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour0Suisse.Web.Procedure
{
    public static partial class CallAPI
    {
        private static string _BaseUri;

        static CallAPI() => _BaseUri = "https://localhost:44321";
    }
}
