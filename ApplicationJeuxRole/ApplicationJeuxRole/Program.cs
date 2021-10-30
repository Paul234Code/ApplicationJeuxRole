using System;
using System.Collections.Generic;

namespace ApplicationJeuxRole
{
    internal class Program
    {
         readonly string[] tableau = new string[] { "roche", "ciseau", "papier" };
         readonly string[] Liste = new string[] { "banane", "poire", "pomme", "cerise", "mangue", "figue", "tangerine", "fraise", "framboise", "bleuet" };

        static void Main(string[] args)
        {
            Program program = new();
            
            program.AfficherMenu();
            program.StartApplication();

          
        }

        // Fonction qui affiche le menu  principal de l'application
        private  void AfficherMenu()
        {
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("Veuillez choisir le jeu a jouer:");
            Console.WriteLine("1- Roche/Papier/ciseau \t2- La devinette\t 3-Quitter");

            Console.WriteLine("------------------------------------------------------");
        }
        // Fonction  qui demarre  l'application aussi longtemps que le l'Utilisateur desire jouer a un jeu
        private  void StartApplication()
        {
            string choix  = "";
            while (choix != "3")
            {

                choix = Console.ReadLine();
                SelectChoice(choix);
            }
            
        }

        // Fonction qui permet a l'Utlisateur de refaire un choix pour une nouvelle partie
        private  void RefaireChoix(string choix)
        {
            while(choix != "o" && choix != "O" && choix != "n" && choix != "N")
            {
                Console.WriteLine("Voullez-vous refaire une partie (O/N) ?");
                choix = Console.ReadLine();

            }
           
            switch (choix.ToLower())
            {
                    case "o":
                        JeuRochePapierCiseau();
                        break;
                    case "n":
                    Console.WriteLine();
                        AfficherMenu();
                        break;
                    

            }

                
        }
            
                    
        // Fonction qui  redirige l'application selon le choix de l'utilisateur
        private  void SelectChoice(string choice)
        {

            switch (choice)
            {
                case "1":
                    MessageBienvenue("Bienvenue dans le jeu roche/papier/ciseau");
                    JeuRochePapierCiseau();                    
                    break;
                case "2":
                    MessageBienvenue("Bienvenue dans la devinette");
                    JeuDevinette();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    MessageErreurDuMenu();
                    Console.WriteLine();
                    AfficherMenu();
                    break;

            }
        }

        // Fonction qui affiche un message de bienvenue dans la console
        private  void MessageBienvenue(string messageDeBienvenue)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(messageDeBienvenue);
            Console.WriteLine("-------------------------------------------------------");
        }
        // Fonction qui affiche un message d'erreur pour l'Utilisateur
        private  void MessageErreurDuMenu()
        {
            Console.WriteLine("Veuillez effectuer un choix valide: ");

        }
        // Fonction qui valide le  choix dans le jeu Roche/papier/ciseau
        private  bool ValidationUserChoice(string choice)
        {
            return choice == "roche" || choice == "papier" || choice == "ciseau";
        }

        // Fonction  qui demarre le jeu  Roche/Papier/ Ciseau ,qui valide le choix de l'Utlisateur
        // Et qui affiche le gagnant de la partie

        private  void JeuRochePapierCiseau()
        {
            Random random = new Random();
            int indice = random.Next(0, tableau.Length);
            string computerChoice = tableau[indice];
            string nouvellePartie;

            
            Console.WriteLine("J'ai déjà choisis mon élément! A votre tour de choisir l'élément :");
            var UserChoice = Console.ReadLine();
            if (!ValidationUserChoice(UserChoice))
            {
                MessageErreurDuJeuRoche();
            }
            // Tant que le choix de l'utilisateur n'est pas valide l'utilisateur doit saisir a nouveau
            while (!ValidationUserChoice(UserChoice))
            {
                UserChoice = Console.ReadLine();
                if (!ValidationUserChoice(UserChoice))
                {
                    MessageErreurDuJeuRoche();

                }


            }

            // Si le choix de l'utilisateur est egale au choix de l'Ordinateur la partie est nulle
            if (UserChoice.Equals(computerChoice))
            {
                Console.WriteLine("Partie  nulle!  Nous avons choisi le même élément!");

            }
            else
            {
                switch (UserChoice)
                {
                    case "ciseau":
                        UtilisateurGagnant1(UserChoice,computerChoice);
                        break;
                    case "papier":
                        UtilisateurGagnant3(UserChoice,computerChoice);
                        break;
                    case "roche":
                        UtilisateurGagnant2(UserChoice,computerChoice);
                        break ;
                }
                              
            }
            // On demande a l'utilsateur s'il desire jouer à une nouvelle partie
            Console.WriteLine();
            Console.WriteLine("Voullez-vous refaire une partie (O/N) ?");
            nouvellePartie = Console.ReadLine().ToLower();
            RefaireChoix(nouvellePartie);
        }

        // Fonction qui affiche un gagnant au suivant le choix de l'utilisateur
        private  void UtilisateurGagnant1(string UserChoice,string ComputerChoice)
        {
            if (ComputerChoice.Equals("papier"))
            {
                Console.WriteLine("Votre choix est " + UserChoice + " mon choix est " + ComputerChoice + ". Vous avez gagné la partie!");

            }
            else
            {
                Console.WriteLine("Votre choix est " + UserChoice + " et mon choix est " + ComputerChoice + " Je gagne la partie!");

            }


        }

        // Fonction qui affiche un gagnant au suivant le choix de l'utilisateur
        private  void UtilisateurGagnant3(string UserChoice, string ComputerChoice)
        {
            if (ComputerChoice.Equals( "roche"))
            {
                Console.WriteLine("Votre choix est " + UserChoice + " mon choix est " + ComputerChoice + ". Vous avez gagné la partie!");

            }
            else // Ordinateur gagne la partie
            {
                Console.WriteLine("Votre choix est " + UserChoice + " et mon choix est " + ComputerChoice + " Je gagne la partie!");

            }


        }

        // Fonction qui affiche un gagnant au suivant le choix de l'utilisateur
        private  void UtilisateurGagnant2(string UserChoice, string ComputerChoice)
        {
            if (ComputerChoice.Equals("ciseau"))
            {
                Console.WriteLine("Votre choix est " + UserChoice + " mon choix est " + ComputerChoice + ". Vous avez gagné la partie!");

            }
            else
            {
                Console.WriteLine("Votre choix est " + UserChoice + " et mon choix est " + ComputerChoice + " Je gagne la partie!");

            }



        }

        // Fonction qui affiche un message d'erreur du Jeu Roche/papier/ciseau
        private  void MessageErreurDuJeuRoche()
        {

             Console.WriteLine("Votre choix est invalide, veuillez le saisir a nouveau:");
        }
        

//########################################################################################################
//                                  Fonction du Jeux Devinettes
//########################################################################################################

// Fonction qui traite la devinette 
        private  void JeuDevinette()
        {
            string motADeviner = RandomString(Liste);
            string FruitATrouver = RandomStringModify(motADeviner);
            int nombreDeChance = 0;
            Console.WriteLine("FRUIT A TROUVER : " + FruitATrouver);
            while( nombreDeChance < 3 && motADeviner != Console.ReadLine())
            {
                Console.WriteLine("FRUIT A TROUVER : " + FruitATrouver);
                ++nombreDeChance;

            }
            if(nombreDeChance < 3)
            {
                Console.WriteLine();
                Console.WriteLine("Bravo! vous avez trouvé le mot !");
                Console.WriteLine();
                AfficherMenu();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Le mot etait :  " + motADeviner);
                Console.WriteLine();
                AfficherMenu();
            }


        }

        // Fonction qui teste si un element entier est present dans une liste d'entier
        // fonction a modifier
        private  bool VerifyElement(List<int> tableau, int element)
        {
            int indice = 0;
            while (indice < tableau.Count && tableau[indice] != element)
            {
                indice++;
            }
            if (indice < tableau.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Fonction qui permet de retourner  trois nombres entiers  aléatoires  et distinctes dans une liste
        private  List<int> TroisNombresAleaDistinct(int n)
        {
            List<int> trois = new List<int>();     // sera la longeur de la chaine aleatoire
            Random rand = new Random();
            int indice = 0;
            int NombresAleatoireDistinct = 0;
            int valeur;
            while (indice < 100 && NombresAleatoireDistinct < 3)
            {
                valeur = rand.Next(0, n);
                if (VerifyElement(trois, valeur))
                {
                    indice++;

                }
                else
                {
                    trois.Add(valeur);
                    indice++;
                    ++NombresAleatoireDistinct;

                }

            }
            return trois;


        }

        // Fonction qui retourne une chaine de caractere  aleatoire tirée de la liste
        private  string RandomString(string [] Liste)
        {
            Random rand = new Random();
            string str = Liste[rand.Next(0,Liste.Length)];
            return str;
        }

        // Fonction qui retourne la chaine aleatoire modifiée
       private  string RandomStringModify(string str)
       {
             
            char[] chars = str.ToCharArray();   // on convertit la chaine en tableau de chars
            List<int> vs = TroisNombresAleaDistinct(str.Length);
            chars[vs[0]] = '_';      
            chars[vs[1]] = '_';
            chars[vs[2]] = '_'; 
            // on retourne la nouvelle chaine modifiée
            return new string(chars);

       }
        
    }
}

