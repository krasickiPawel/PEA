Jest to cały projekt z zajęć projektowych z kursu Projektowanie Efektywnych Algorytmów [PEA]. Projekt jest napisany przy wykorzystaniu technologii
takich jak: język C#, Windows Form Application, .NET 5.0

Po konsultacji z prowadzącym, weryfikacji poprawności działania i otrzymywanych wyników dostałem odpowiedź, że "kod jest bardzo dobrze zoptymalizowany, jeden
szczegół to, że brute force działałby proawdopodobnie szybciej używając rekurencji i innej metody przechodzenia po sąsiedztwie" 

Wyjaśnienie powyższego: metoda next_permutation w C/C++ jest świetnie zoptymalizowana i nie da się zrobić lepiej, a w C# jej nie ma i moja implementacja działa 
wolniej niż w C/C++, ale i tak BF diała w rozsądnym czasie do 13 - 14 miast, czyli tyle co powinien.

DP przetestowany do rozmiaru 26.

SA i TS przetestowane to rozmiaru 358 - błąd względny w okolicach 10% czyli rewelacyjny.
