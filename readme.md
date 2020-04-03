# Hangman



## K dokončení
- [X] Registrace a přihlášení 
- [ ] FUNKČNÍ registrace a přihlášení
- [X] Databáze
- [ ] Logika hry
- [ ] Input
- [ ] Output
- [ ] Funkční hratelnost

## Problémy
- Při obnově hesla se nepošle email
- Nejde se přihlásit
- Neznámá funkčnost registrace, jméno a email se "zaberou" ale nejde se 
skrze ně přihlásit

## Návrh databáze
```mermaid
graph LR
ID --> NAME[Jméno] 
NAME--> PASS[Heslo]
ID --> WINS[Výhry]
```
![Návrh databáze](https://github.com/DominikTulak/Zaverecna-prace-web-p4-2020/raw/master/Navrh_databaze.png)

ID: INT  
NAME: STRING  
WINS: INT  
