using HangMANFinal.Data;
using HangMANFinal.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangMANFinal.Sluzby
{
    public class Funkcionalita
    {
        string word;
        List<char> GuessedChars;

        private ApplicationDbContext databaze;
        private IHttpContextAccessor http;
        private string id_aktualniho_uzivatele;
        private Uzivatel aktualni_uzivatel;
        private readonly Random rnd = new Random();

        public Funkcionalita(ApplicationDbContext aplikacni_kontext, IHttpContextAccessor http_)
        {
            databaze = aplikacni_kontext;
            http = http_;

            id_aktualniho_uzivatele = http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            aktualni_uzivatel = databaze.uzivatele.Find(id_aktualniho_uzivatele);
        }

        public void noveslovo()
        {
            int index = rnd.Next(0, databaze.slova.Count());
            string slovo = databaze.slova.Find(index).slovo;
            aktualni_uzivatel.slovo = slovo;
            aktualni_uzivatel.hadanapismena = "";
            aktualni_uzivatel.aktualnistavslova = "";
            for (int i = 0; i < aktualni_uzivatel.slovo.Length; i++)
            {
                aktualni_uzivatel.aktualnistavslova = aktualni_uzivatel.aktualnistavslova + "*";
            }
            databaze.SaveChanges();
        }

        public bool upravaktualnistavslova(char znak)
        {
            if (aktualni_uzivatel.slovo.Contains(znak) == false) return false;
            char[] znaky = aktualni_uzivatel.aktualnistavslova.ToCharArray();
            for (int i = 0; i < znaky.Length; i++)
            {
                if (aktualni_uzivatel.slovo[i] == znak)
                {
                    znaky[i] = znak;
                }
            }
            aktualni_uzivatel.aktualnistavslova = new string(znaky);

            if (aktualni_uzivatel.aktualnistavslova.Contains('*') == false)
            {
                aktualni_uzivatel.uhodnutaslova += 1;
                noveslovo();
                return true;
            }
            databaze.SaveChanges();
            return false;
        }

        public bool hadani(char znak)
        {
            if (aktualni_uzivatel.hadanapismena.Contains(znak))
            {
                return false;
            }
            aktualni_uzivatel.hadanapismena = aktualni_uzivatel.hadanapismena + znak;
            bool dohrano = upravaktualnistavslova(znak);
            databaze.SaveChanges();
            return dohrano;
        }

        public string zneniSlova()
        {
            if (aktualni_uzivatel.slovo == null) noveslovo();
            return aktualni_uzivatel.aktualnistavslova;
        }
        /*
        public bool Guess(char letter)
        {
            GuessedChars.Add(letter);
            if (word.Contains(letter))
            {
                return true;
            }
            return false;
        }
        public string GetWord()
        {
            string vystup = "";
            for (int i = 0; i < word.Length; i++)
            {
                vystup = vystup + "*";
            }
            foreach (char i in GuessedChars)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == i)
                    {
                        var x = vystup.ToCharArray();
                        x[j] = i;
                        vystup = new string(x);
                    }
                }
            }
            return vystup;
        }
        public void GetNewWord()
        {
            Random rnd = new Random();
            string[] slova = { "kočka", "pes", "aligátor" };
            word = slova[rnd.Next(0, 3)];
        }
        public List<char> GetGuessedChars()
        {
            return GuessedChars;
        }*/
    }
}
