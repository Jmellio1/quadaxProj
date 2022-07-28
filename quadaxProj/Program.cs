/*
 * NOTE: Not sure what the rules of the game is when there are duplicate numbers in the generated number and they use it once.
 * I.E generated number 6631 and they enter 6222 I’m outputting  + - since 6 is there twice... and so forth...

 *  Please ignore sarcasm thanks!
*/
class quadaxProj
{
    static void Main(string[] args)
    {
        
   
       startGame();
     


    }
    static int[] generateNumber()
    {
        int[] array = new int[4];
        Random rnd = new Random();
        array[0] = rnd.Next(1, 7);
        array[1] = rnd.Next(1, 7);
        array[2] = rnd.Next(1, 7);
        array[3] = rnd.Next(1, 7);


        return  array;
    }
    static bool check(string entered)
    {
        int num;
        int length = entered.Length;
        try
        {
            num = Int32.Parse(entered);
            var match = entered.IndexOfAny(new char[] { '0', '7', '8', '9' }) != -1;
            if (match || length >= 5 || length <= 3)
            {
                Console.WriteLine("Soooo... You didn't enter a valid number... you lost a turn...");
                return false;
            }
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Yeah... You didn't enter a number do you not know what a number is? ... you lost a turn...");
            return false;
        }
    }
    static void playGame(int[] arry, int count, string guess)
    {
        if (count >= 9)
        {
            Console.WriteLine("You lost... so sad...for you that is... the number was: "+ String.Join("", arry)+" play again? Type yes or no");
            string entered = Console.ReadLine();
            if(String.Equals(entered, "yes", StringComparison.OrdinalIgnoreCase))
            {
                startGame();
            }
            else if(String.Equals(entered, "no", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Good you're leaving...");
            }
            else
            {
                Console.WriteLine("I see you can’t answer simple questions... as expected...goodbye.");
            }

        }
        else if (check(guess) == false)
        {
            count++;
            int gamesLeft = 10 - count;
            Console.WriteLine( "You have " + gamesLeft + " guesses left... use them wisely if you can...");

            guess = Console.ReadLine();

            playGame(arry, count, guess);
        }
        else if (Int32.Parse(String.Join("", arry)) == Int32.Parse(guess))
        {
            Console.WriteLine("Wow.... you actually won? Congratulations or whatever... play again? Type yes or no ");
            string entered = Console.ReadLine();
            if (String.Equals(entered, "yes", StringComparison.OrdinalIgnoreCase))
            {
                startGame();
            }
            else if (String.Equals(entered, "no", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Good you're leaving...");
            }
            else
            {
                Console.WriteLine("I see you can’t answer simple questions... as expected... goodbye.");
            }

        } 

        else 
        {
            
            List<char> list = new List<char>();
            for (int i = 0; i < arry.Length; i++)
            {
                bool testNeg = false;
                bool testPos=true;
                for (int j = 0; j < guess.Length; j++)
                {
                  var bug =guess[j].ToString();
                   var bugInt = Int32.Parse(bug);
                    var hold = numberCheck(bugInt, arry[i], j, i);
                    if (hold =='+')
                    {
                        list.Add((char)hold);
                        testPos=false;
                        break;
                    }
                    else if (hold=='-')
                    {
                        testNeg = true;
                    }
                }
                if (testNeg&&testPos)
                {
                    list.Add('-');
                }

            }
            count++;
            int gamesLeft = 10 - count;
            list.Sort();
            Console.WriteLine(String.Join("", list)+ " You have " +gamesLeft+ " guesses left... use them wisely if you can...");
           guess = Console.ReadLine();
            playGame(arry, count, guess);

        }
        

    }
    static char? numberCheck(int enterted, int actual, int enteredIndex, int actualIndex)
    {
        bool correctNumber = enterted == actual;
        bool correctIndex = enteredIndex==actualIndex;
        if(correctNumber==true && correctIndex == true)
        {
            return '+';
        }else if(correctNumber==true && correctIndex == false)
        {
            return '-';
        }else
        {
            return null;
        }
    }
    static void startGame()
    {
        Console.WriteLine("Oh you wanna play a game? The rules are blah blah blah goodluck");
        int[] num = generateNumber();
   //     Console.WriteLine(String.Join("", num));

        Console.WriteLine(@"Enter a number");
        string entered = Console.ReadLine();
        playGame(num, 0, entered);

    }
}  