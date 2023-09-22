using System.Linq.Expressions;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            // declaring a bool and set it to "true" to tell my program to keep running for as long as the player
            //wants to play again.

            while (playAgain)
            {
                Random rand = new Random();
                int secretNumber = rand.Next(1, 21);        //creating a new random number between 1-20. 
                int myGuess = 0;                            //declaring a variable with the value of 0. This variable is gonna be used for the number we are guessing.
                int count = 0;                              // declaring a variable to keep count of how many times the user have guessed.

                string[] arrayComment = new string[6];                      //an array with different comments that are being executed when the users guess is wrong
                arrayComment[0] = "Lycka till!";
                arrayComment[1] = "Bra förstagissning. Försök igen!";
                arrayComment[2] = "Kom igen nu!";
                arrayComment[3] = "Nu börjar dina försök ta slut";
                arrayComment[4] = "Sista gissningen nu!";
                arrayComment[5] = "Din amatör!";


                Console.WriteLine("Välkommen!\nJag tänker på ett nummer mellan 1-20, kan du gissa vilket?\nDu får fem försök.");
                Console.WriteLine(arrayComment[0]);             //Printing the first field in our arrayComment-array.

                while (count != 5)   // creating a while-loop that terminates after the value of count reaches 5.
                {
                    count++;        //increasing the value of count with 1 each time being executed
                    try             //if the user tries to print something else than a integer in myGuess, a message will be displayed
                                    //in the catch-block telling te user that it is the wrong format, choose a number between 1-20.
                    {

                        myGuess = int.Parse(Console.ReadLine());    //assigning a value and converting in to an int to our variable "myGuess"
                        CheckGuess(myGuess, secretNumber);             //running our function "CheckGuess" with the parameters "myGuess" and "secretNumber".
                    }                                         //The function is explained in the bottom of our project.

                    catch (FormatException) { Console.WriteLine("Ogiltlig inmatning, vänligen ange ett ta mellan 1-20"); }

                    if (myGuess == secretNumber)                        //if the guess has the same value as "secret number" a comment will be executed, and the if-statement
                    {                                                   //will break and send us to the top of our while-loop
                        Console.WriteLine("Woho! Du gjorde det!");
                        break;
                    }
                    Console.WriteLine(arrayComment[count]);                 //if the guess is wrong the next arrayComment will be executed and
                    Console.WriteLine("Antal gissningar : " + count);       //the number of guesses will be displayed in the console
                    Console.WriteLine();

                }                                                           //If the user hasn't  guessed the right number after 5 times, the while-loop will be terminated.                                                        

                Console.WriteLine($"Det hemliga talet var {secretNumber}\nVill du spela igen? [Ja/Nej]"); //The round is finnished, so the correct answer will be displayed and
                                                                                                          //the program asking the user if he wants to play again.

                while (true)                                                    //creating a while-loop that runs until the answer-string is "ja" or "nej"                                
                {
                    string answer = Console.ReadLine().ToLower();               //The user prints the answer, and the answer is converted to lower letters.


                    if (answer == "ja")                                         //if the answer is "ja" we just running through the if-statement and clearing the console, jumping
                    {                                                           //to the top of our external while-loop, since the bool "playAgain" is still "true"
                        Console.WriteLine("Kul! Då kör vi");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    } else if (answer == "nej")                                     //if the answer is "nej" the game will stop because our "playAgain" bool is set to false.
                    {
                        Console.WriteLine("Tack för att du ville spela. Hejdå!");
                        Console.ReadKey();
                        playAgain = false;
                        break;
                    } else
                    {
                        Console.WriteLine("Ogiltlig inmatning, vänligen skriv 'ja' eller 'nej'");
                    }
                }



            }

            Console.WriteLine("Vi ses nästa gång");     //our program is finished.
            Console.ReadKey();


        }

        static void CheckGuess(int guess, int secretNumber)      //creating a method called CheckGuess with two arguments - int guess and int secretNumber
        {
            if (guess == secretNumber)                         //Running an if-statement that checks if our guess is equal to secretNumber.           
            {
                return;

            } else if (guess > secretNumber && guess <= 20)
            {
                Console.WriteLine("Tyvärr, {0} är för högt", guess);
            } else if (guess < secretNumber && guess <= 20)
            {
                Console.WriteLine("Tyvärr, {0} är för lågt", guess);
            } else
            {
                Console.WriteLine("Ogiltigt nummer");
            }


        }

    }
}