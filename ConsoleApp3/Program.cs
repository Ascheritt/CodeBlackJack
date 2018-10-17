using System;

namespace BlackJack
{



    class Program
    {

        static void Main(string[] args)
        {

            int chips = 100;
            string nom = "";
            int prixMise = 0;
            int action = 0;
            int valeurCachée = 0;
            string carteCachée = "Cette carte est cachée...";
            int banqueEnnemie = 100;
            bool jeu = true;
            string typeCarte = "";
            string faceCarte = "";
            int valeurCarte = 0;
            string carte = "";


            void mise()
                {
                    Console.WriteLine("Vos jetons: {0}", chips);
                    Console.WriteLine("Combien aimeriez-vous miser? (1 - {0})", chips);
                    string input = Console.ReadLine().Trim().Replace(" ", "");
                    Console.Clear();
                    while (!Int32.TryParse(input, out prixMise) || prixMise < 1 || prixMise > chips)
                    {
                        Console.WriteLine("Le total est illégal, combien aimeriez-vous miser? (1 - {0})", chips);
                        input = Console.ReadLine().Trim().Replace(" ", "");
                    }
                    Console.Clear();
                }

                void carteAleatoire()
                {
                    Random aleatoire = new Random();
                    int couleur = aleatoire.Next(1, 5);
                    int valeur = aleatoire.Next(1, 14);

                    //--Couleur de carte--//

                    if (couleur == 1)
                    {
                        typeCarte = "Coeur";
                    }
                    else if (couleur == 2)
                    {
                        typeCarte = "Pique";
                    }
                    else if (couleur == 3)
                    {
                        typeCarte = "Carreau";
                    }
                    else if (couleur == 4)
                    {
                        typeCarte = "Trèfle";
                    }

                    //--Valeur de carte--//

                    if (valeur == 1)
                    {
                        faceCarte = "As";
                        valeurCarte = 11;
                    }
                    else if (valeur == 11)
                    {
                        faceCarte = "Valet";
                        valeurCarte = 10;
                    }
                    else if (valeur == 12)
                    {
                        faceCarte = "Dame";
                        valeurCarte = 10;
                    }
                    else if (valeur == 13)
                    {
                        faceCarte = "Roi";
                        valeurCarte = 10;
                    }
                    else if (valeur > 1 && valeur < 11)
                    {
                        faceCarte = Convert.ToString(valeur);
                        valeurCarte = valeur;
                    }

                    carte = "Carte tirée " + faceCarte + " de " + typeCarte;
                }

                //--Titre--//
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                Console.CursorVisible = false;

                Console.WriteLine("Bien le bonjour, vous êtes sur le point de commencer une partie de Blackjack. Veuillez s'il vous plaît entrer votre nom.");
                Console.WriteLine();
                Console.Write("Votre nom:");
                nom = Convert.ToString(Console.ReadLine());
                Console.Clear();

            while (jeu == true)
            {

                string valeurCarteCache = "";
                int valeurTotaleEnnemi = 0;
                int valeurTotaleMoi = 0;

                mise();

                
                    //--Menu Croupier--//
                    Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(2, 4);
                carteAleatoire();
                Console.Write(carte);
                valeurTotaleEnnemi = valeurCarte;
                valeurCachée += valeurCarte;
                Console.SetCursorPosition(2, 6);
                carteAleatoire();
                valeurCarteCache = carte;
                Console.Write(carteCachée);
                valeurCachée += valeurCarte;
                carteCachée = "Carte tirée " + faceCarte + " de " + typeCarte;
                Console.SetCursorPosition(2, 1);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Croupier: " + valeurTotaleEnnemi);

                //--Ton Menu--//
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(2, 18);
                carteAleatoire();
                Console.Write(carte);
                valeurTotaleMoi += valeurCarte;
                Console.SetCursorPosition(2, 20);
                carteAleatoire();
                valeurTotaleMoi += valeurCarte;
                Console.Write(carte);
                Console.SetCursorPosition(2, 15);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("" + nom +": " + valeurTotaleMoi);

                //--Affichage--//
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(80, 28);
                Console.Write("[1]Hit");
                Console.SetCursorPosition(100, 28);
                Console.Write("[2]Stand");
                Console.SetCursorPosition(50, 28);
                Console.Write("Votre mise: " + prixMise);
                Console.SetCursorPosition(2, 28);
                Console.Write("Ta Banque = " + (chips-prixMise));

                //--Entrées--//
                Console.SetCursorPosition(0, 29);
                action = Convert.ToInt32(Console.ReadLine());
                if (action == 1)
                {

                    Console.SetCursorPosition(2, 22);
                    carteAleatoire();
                    Console.Write(carte);
                    valeurTotaleMoi += valeurCarte;
                    Console.SetCursorPosition(2, 15);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("" + nom + ": " + valeurTotaleMoi);
                    Console.ReadKey(true);

                    if (valeurCachée­ < valeurTotaleMoi && valeurTotaleMoi <= 21)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(2, 6);
                        Console.Write(valeurCarteCache);
                        valeurTotaleEnnemi += valeurCarte;
                        Console.SetCursorPosition(2, 8);
                        carteAleatoire();
                        Console.Write(carte);
                        valeurTotaleEnnemi += valeurCarte;
                        Console.SetCursorPosition(2, 1);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Croupier: " + valeurTotaleEnnemi);
                        Console.ReadKey(true);

                    }

                    if (valeurTotaleMoi < valeurTotaleEnnemi && valeurTotaleEnnemi < 21)
                    {
                        chips = chips - prixMise;
                    }
                    else if (valeurTotaleEnnemi == 21)
                    {
                        chips = chips - prixMise;
                    }
                    else if (valeurTotaleMoi > 21)
                    {
                        chips = chips - prixMise;
                    }
                    if (valeurTotaleEnnemi < valeurTotaleMoi && valeurTotaleMoi < 21)
                    {
                        chips = chips + prixMise;
                        banqueEnnemie = banqueEnnemie - prixMise;
                    }
                    else if (valeurTotaleMoi == 21)
                    {
                        chips = chips + prixMise;
                        banqueEnnemie = banqueEnnemie - prixMise;
                    }
                    else if (valeurTotaleEnnemi > 21)
                    {
                        chips = chips + prixMise;
                        banqueEnnemie = banqueEnnemie - prixMise;
                    }



                    Console.Clear();
                    //-Condition de vitoire--//
                    if (1 > chips)
                    {
                        Console.Clear();
                        Console.WriteLine("Vous avez perdu...");
                        Console.ReadKey(true);
                        jeu = false;
                    }
                    else if (banqueEnnemie < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Vous avez gagné, félicitation!");
                        Console.ReadKey(true);
                        jeu = false;
                    }


                }
                else if (action == 2)
                {
                    if (valeurCachée­ < valeurTotaleMoi)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(2, 6);
                        Console.Write(valeurCarteCache);
                        valeurTotaleEnnemi += valeurCarte;
                        Console.SetCursorPosition(2, 8);
                        carteAleatoire();
                        Console.Write(carte);
                        valeurTotaleEnnemi += valeurCarte;
                        Console.SetCursorPosition(2, 1);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Croupier: " + valeurTotaleEnnemi);
                        Console.ReadKey(true);

                    }

                    if (valeurTotaleMoi < valeurTotaleEnnemi && valeurTotaleEnnemi < 21)
                    {
                        chips = chips - prixMise;
                    }
                    else if (valeurTotaleEnnemi == 21)
                    {
                        chips = chips - prixMise;
                    }
                    else if (valeurTotaleMoi > 21)
                    {
                        chips = chips - prixMise;
                    }
                    if (valeurTotaleEnnemi < valeurTotaleMoi && valeurTotaleMoi < 21)
                    {
                        chips = chips + prixMise;
                        banqueEnnemie = banqueEnnemie - prixMise;
                    }
                    else if (valeurTotaleMoi == 21)
                    {
                        chips = chips + prixMise;
                        banqueEnnemie = banqueEnnemie - prixMise;
                    }
                    else if (valeurTotaleEnnemi > 21)
                    {
                        chips = chips + prixMise;
                        banqueEnnemie = banqueEnnemie - prixMise;
                    }

                    Console.ForegroundColor = ConsoleColor.White;


                    Console.Clear();
                    //-Condition de vitoire--//
                    if (1 > chips)
                    {
                        Console.Clear();
                        Console.WriteLine("Vous avez perdu...");
                        jeu = false;
                    }
                    else if (banqueEnnemie < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Vous avez gagné, félicitation!");
                        Console.ReadKey(true);
                        jeu = false;
                    }

                }
            }
        }
    }
}
