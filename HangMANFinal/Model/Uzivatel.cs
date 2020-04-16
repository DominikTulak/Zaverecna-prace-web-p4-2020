using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangMANFinal.Model
{
    public class Uzivatel : IdentityUser
    {
        public string slovo { get; set; }
        public string aktualnistavslova { get; set; }
        public string hadanapismena { get; set; }
        
        public int uhodnutaslova { get; set; }

    }
}
