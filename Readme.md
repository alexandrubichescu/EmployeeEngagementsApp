# Employee Engagement App


Sistemul de gamification oferă utilizatorilor un mediu virtual în care să își îndeplinească sarcinile și să câștige recompense pentru activitățile lor. Aplicația ar trebui să ofere o experiență interactivă și distractivă, astfel încât utilizatorii să își dorească să participe în mod regulat. 

##Funcționalități care sunt incluse în aplicație la acest moment sunt:

### 1.	Utilizatori

Utilizatorii se identifică in sistem printr-un post request care necesită în body un JSON cu “email” și ”password”, dacă datele introduse sunt corecte, acestia primesc acces și la celelalte functionalități ale aplicației. Utilizatorii nelogați nu pot accesa nici un endpoint și vor primi 401 unauthorized response status code. 
Un utilizator poate fi de 2 tipuri: “Admin” sau „User”. 

În funcție de rolul utilizatorului, aceștia primesc acces la anumite funcționalități. 

-	„Admin” au acces la toate endpoint-urile
-	„User” pot accesa doar anumite funcționalități (ex: doar administratorii pot aproba quest-urile și vizualiza clasamentul utilizatorilor în funcție de punctaj).

### 2.	Sistem de punctaj

Utilizatorii vor câștiga puncte pentru îndeplinirea quest-urilor. 
Fiecare quest oferă un anumit număr de puncte, în funcție de dificultatea și importanța lor. Punctajul este stabilit de utilizatorul care creează quest-ul. Utilizatorul „Admin” poate oferi puncte bonus utilizatorilor. 

### 3.	Badges: 

Utilizatorii vor primi badge-uri pentru acumularea unui anumit număr de puncte. 
Atunci când utilizatorul finalizează un quest, se înregistrează în baza de date numărul de puncte pe care utilizatorul le primește și se actualizează scorul său total. 
Fiecare badge are un număr necesar de puncte pentru a fi acordat. Badges-urile vor fi vizibile pentru toți utilizatorii, astfel încât utilizatorii să îți poată calcula punctele necesare pentru a primi badge-ul la care aspiră. Doar utilizatorii „Admin” pot adauga Badge-uri.

### 4.	Quest-uri: 

Utilizatorii pot propune quest-uri, care sunt aprobate de către un administrator. Quest-urile ar trebui să fie variate și să se concentreze pe diferite obiective, cum ar fi îmbunătățirea abilităților de lucru în echipă, dezvoltarea abilităților de comunicare sau învățarea unor noi abilități, activități sportive pentru dezvoltarea stilului de viață sănătos, crearea de legături între colegi (ex: team building), etc.


### 5.	Clasament: 

Aplicația oferă un clasament al utilizatorilor în funcție de numărul de puncte acumulate. Administratorul poate vedea progresul lor și poate observa cei mai activi utilizatori.
