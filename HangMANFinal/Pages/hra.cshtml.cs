using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangMANFinal.Sluzby;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangMANFinal.Pages
{
    [Authorize]
    public class hraModel : PageModel
    {
        [BindProperty]
        public string pismenko { get; set; }
        public string slovo { get; set; }
        public Funkcionalita metody { get; set; }
        public hraModel(Funkcionalita f)
        {
            metody = f;
        }

        public void OnGet()
        {
            slovo = metody.zneniSlova();
        }

        public IActionResult OnPost()
        {
            if (pismenko != null && pismenko != "" && pismenko.Length == 1)
            {
                bool dohrano = metody.hadani(Convert.ToChar(pismenko));
                if (dohrano)
                {
                    return RedirectToPage("vyhra");
                }
            }

            return RedirectToPage();
            
        }
    }
}