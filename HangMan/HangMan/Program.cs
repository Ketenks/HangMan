
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            //CALL FUNCTION
            Console.WriteLine("HANGMAN");
            Console.WriteLine();
            

            HangMan();

            //keeps console open
            Console.ReadKey();
        }
        //BEGIN FUNCTION DECLARATION
        static void HangMan()
        {
            //preface
            Console.WriteLine("What is your name?\n");
            string input = Console.ReadLine();

            //this is the big loop to reset the game after the game is completed
            bool looping = true;
            while (looping)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Welcome, " + input + ", to the public hearing for HangMan.\n");
                Console.WriteLine("Will YOU save HangMan?");
                Console.WriteLine("Then guess THIS word!\n");
                Console.WriteLine("RULES:\n-----\nNow before you begin guessing, understand: HangMan's life hangs in the balance.\nYou will be guessing a letter that you think is found within the word.\nYou have only so many mistaken guesses before his sentence is executed.\nYou will save him, if you reveal the word through your guesses or if you guess the word itself.");
                Console.WriteLine("\n");

                //set the while loop variables outside for user input
                bool looping2 = true;
                int loopCount = 0;
                int guessCount = 7;
                int imminent = 0;

                //obviously this is the wordBank
                List<string> wordBank = new List<string> { "Ailurophile","Assemblage","Beleaguer","Bucolic",
"Bungalow","Chatoyant","Comely","Conflate","Cynosure","Dalliance","Demesne","Demure","Denouement","Desuetude","Desultory",
"Diaphanous","Dissemble","Ebullience","Effervescent","Efflorescence","Elision","Elixir","Eloquence","Embrocation",
"Emollient","Ephemeral","Epiphany","Erstwhile","Ethereal","Evanescent","Evocative","Fetching","Felicity","Forbearance",
"Fugacious","Furtive","Gambol","Glamour","Gossamer","Halcyon","Harbinger","Imbrication","Imbroglio","Imbue",
"Incipient","Ineffable","Ingenue","Inglenook","Insouciance","Inure","Labyrinthine","Lagniappe","Lagoon",
"Languish","Languor","Lassitude","Leisure","Lilt","Lissome","Lithe","Mellifluous","Moiety","Mondegreen","Murmurous",
"Nemesis","Offing","Onomatopoeia","Opulent","Palimpsest","Panacea","Panoply","Pastiche","Penumbra","Petrichor",
"Plethora","Propinquity","Pyrrhic","Quintessential","Ratatouille","Ravel","Riparian","Ripple","Scintilla",
"Sempiternal","Seraglio","Serendipity","Summery","Sumptuous","Surreptitious","Susquehanna","Susurrous",
"Talisman","Tintinnabulation","Umbrella","Untoward","Vestigial","Wafture","Wherewithal","Woebegone" };

                //this is extra: it is a hint for each word chosen when guessCount = 1
                List<string> bankDef = new List<string> {"A cat-lover.","A gathering.","To exhaust with attacks.","In a lovely rural setting.","A small, cozy cottage.","Like a cat's eye.","Attractive.","To blend together.","A focal point of admiration.","Inflamed and unnatural desire.",
"Dominion, territory.","Shy and reserved.","The resolution of a mystery.","Disuse.","Slow, sluggish.","Filmy.","Deceive.","Bubbling enthusiasm.","Bubbly.","Flowering, blooming.",	"Dropping a sound or syllable in a word.",
"A good potion.","Beauty and persuasion in speech.","Rubbing on a lotion.","A softener.","Short-lived.","A sudden revelation.","At one time, for a time.","Gaseous, invisible but detectable.",
"Vanishing quickly, lasting a very short time.","Suggestive.","Pretty.","Pleasantness.","Withholding response to provocation.","Fleeting.",	"Shifty, sneaky.","To skip or leap about joyfully.","Beauty.","The finest piece of thread, a spider's silk","Happy, sunny, care-free.","Messenger with news of the future.","Overlapping and forming a regular pattern.",
"An altercation or complicated situation.","To infuse, instill.","Beginning, in an early stage.","Unutterable, inexpressible.","A naïve young woman.","A cozy nook by the hearth.",
"Blithe nonchalance.","To become jaded.","Twisting and turning.","A special kind of gift.","A small gulf or inlet.","Waste time while wasting away.","Listlessness, inactivity.",
"Weariness, listlessness.","Free time.","To move musically or lively.","Slender and graceful.","Slender and flexible.","Sweet sounding.","One of two equal parts.","A slip of the ear.","Murmuring.",
"An unconquerable archenemy.","The sea between the horizon and the offshore.","A word that sounds like its meaning.","Lush, luxuriant.","A manuscript written over earlier ones.",
"A solution for all problems","A complete set.","An art work combining materials from various sources.","A half-shadow.","The smell of earth after rain.","A large quantity.","An inclination.","Successful with heavy losses.",
"Most essential.","A spicy French stew.","To knit or unknit.","Fragrant.","By the bank of a stream.","A very small wave.","A spark or very small thing.","Eternal.","Rich, luxurious oriental palace or harem.",
"Finding something nice while looking for something else.","Light, delicate or warm and sunny.","Lush, luxurious.","Secretive, sneaky.","A river in Pennsylvania.","Whispering, hissing.",
"A good luck charm.","Tinkling.","Protection from sun or rain.","Unseemly, inappropriate.","In trace amounts.","Waving.","The means.","Sorrowful, downcast."};

                //pick a random number for the word bank
                Random randNumGen = new Random();
                int randNum = randNumGen.Next(0, wordBank.Count - 1);

                // set the word and list variables to parse              
                string theWord = wordBank[randNum].ToUpper();
                List<char> theWordChar = new List<char> { };
                List<char> undScores = new List<char> { };
                
                string temp = "";
                string lettersGuessed = "";

                //loop to write preliminary underscores
                for (int i = 0; i < theWord.Length; i++)
                {
                    temp += "_ ";
                }
                Console.Write("|  ");
                Console.Write(temp);
                Console.WriteLine("  |");
                Console.WriteLine();

                //this is the little loop for the user's guesses within the game itself
                while (looping2)
                {
                    //count the tries
                    loopCount++;
                    
                    


                    //get user input and compile into a list
                    string input2 = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    

                    //for length of string perform associated checks to print output
                    if (input2.Length == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Be bold! You need to make a guess.");
                    }
                    else if (input2.Length == 1)
                    {
                        //count for an unequivalence
                        int errorCount = 0;

                        //compile all the letters guessed for user reference, write a check for similar input                                             
                        if (lettersGuessed.Contains(Convert.ToChar(input2)))
                        {
                            Console.WriteLine("You have guessed that one! I have recorded all your guesses for your convenience.");

                        }
                        else
                        {
                            lettersGuessed += input2 + ", ";


                            //write revealed letters and reduce chances for errors
                            Console.Write("|  ");
                            for (int i = 0; i < theWord.Length; i++)
                            {

                                //check to see what letter goes where
                                if (Convert.ToChar(input2) != theWord[i])
                                {
                                    //temp.Replace(temp[i], undScores[i]);
                                    errorCount++;

                                }
                                else if (Convert.ToChar(input2) == theWord[i])
                                {
                                    temp = temp.Insert(i * 2, input2 + " ").Remove((i * 2 + 2), 2);
                                }

                            }


                            //decrement for making a wrong guess and if they have not guessed that letter already
                            if (errorCount == theWord.Length)
                            {
                                guessCount--;
                            }


                            Console.Write(temp);
                            Console.WriteLine("  |");
                            Console.WriteLine();
                            Console.WriteLine("Letters Guessed: " + lettersGuessed);
                            Console.WriteLine("Chances Left: " + guessCount);
                            Console.WriteLine();
                        }
                        
                            string revealed = temp.Replace(" ", "");

                            if (revealed  == theWord)                      
                            {
                                Console.WriteLine();
                                Console.WriteLine("It appears all the letters appeared...A little too easy eh? Well, I do believe HangMan has escaped his mortal fate. Good guessing.");
                                Console.WriteLine("It took you " + loopCount + " guesses to get it.");
                                Console.WriteLine("\nWould you like to save the next HangMan?\nYay or Nay?\n");
                                input2 = Console.ReadLine().ToUpper();
                                if (input2 == "Y" || input2 == "YES" || input2 == "YAY")
                                {
                                    looping2 = false;
                                }
                                else
                                {
                                    looping = false;
                                    looping2 = false;
                                }
                                
                            }
                        
                    }
                    else
                    {
                        if (theWord == input2)
                        {
                            Console.WriteLine("By jove! Huzzah!! HangMan is free!\n\n" + input + ", you really have done it!");
                            Console.WriteLine("It took you " + loopCount + " guesses to get it.");
                            Console.WriteLine("\n\nWould you like to save the next HangMan?\nYay or Nay?");
                            input2 = Console.ReadLine().ToUpper();
                            if (input2 == "Y" || input2 == "YES" || input2 == "YAY")
                            {
                                looping2 = false;
                            }
                            else
                            {
                                looping = false;
                                looping2 = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nooo. I am sorry. That is not the word at all.");
                            guessCount--;
                            Console.WriteLine("Chances Left: " + guessCount);
                        }
                    }
                    if (guessCount == 0)
                    {
                        Console.WriteLine("HangMan...has died...it seems your vocabulary was not able. Try reading a book from time to time.");
                        looping = false;
                        looping2 = false;
                    }
                    else if (guessCount == 1 && imminent == 0)
                    {
                        imminent++;
                        Console.WriteLine("HangMan's execution is imminent! Would you like a piece of mercy to help his cause?\n\nYay or Nay");
                        input2 = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                        if (input2 == "Y" || input2 == "YES" || input2 == "YAY")
                        {
                            Console.WriteLine("HINT: " + bankDef[randNum]);
                            Console.WriteLine();
                            Console.WriteLine("I did tell you it was A piece of mercy.");
                        }
                        else
                        {
                            Console.WriteLine("A brazen fellow! Is his life so futile as your vocabulary?");
                        }
                    }


                }
            

            }
       }
    }
}

