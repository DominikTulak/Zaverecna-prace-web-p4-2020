using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TestBookmarksDatabase.Pages
{
    public class IndexModel : PageModel
    {
        public string slovo = "Hangman" ;
        public string vstup;

        public void onPost() { }

        public void OnGet()
        {


            slovo = "Hangman";
        }
    }
}
