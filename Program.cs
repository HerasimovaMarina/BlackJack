using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Card
{
    public enum CardSuit
    {
        Clubs,
        Hearts,
        Spades,
        Diamonds
    }

    public enum CardNumber
    {
        Ace = 11,
        King = 4,
        Queen = 3,
        Jack = 2,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10
    }

    struct Card
    {
        public CardSuit Suit;
        public CardNumber Number;
    }

    struct Deck
    {
        public Card[] Cards;
    }

    class Program
    {
        static void Main(string[] args)
        {

            //int suitsLength = Enum.GetValues(typeof(CardSuit)).Length;
            //int numberLength = Enum.GetValues(typeof(CardNumber)).Length;

            CardSuit[] cardSuits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            CardNumber[] cardNumber = (CardNumber[])Enum.GetValues(typeof(CardNumber));

            int suitsLength = cardSuits.Length;
            int numberLength = cardNumber.Length;

            int cardsInDeck = suitsLength * numberLength;

            Deck Deck = new Deck();
            Deck.Cards = new Card[cardsInDeck];

            for (int s = 0; s < suitsLength; s++)
            {
                int changeSuits = s * numberLength;
                for (int r = 0; r < numberLength; r++)
                {
                    Deck.Cards[changeSuits].Suit = cardSuits[s];
                    Deck.Cards[changeSuits].Number = cardNumber[r];

                    changeSuits++;
                }
            }


            int CountOfGames = 0;
            int PlayerWins = 0;
            int ComputerWins = 0;
            int Wow = 0;
            string NextGame = "";
        do
            { 

            Random random = new Random();
            for (int i = 0; i < Deck.Cards.Length; i++)
            {
                int j = random.Next(0, 35);
                var temp = Deck.Cards[i];
                Deck.Cards[i] = Deck.Cards[j];
                Deck.Cards[j] = temp;
            }


            int operation = 0;
            Console.WriteLine("1-Player Start the Game. 2-Computer Start the Game.");
            operation = int.Parse(Console.ReadLine());


            Deck Player = new Deck();
            Player.Cards = new Card[8];

            Deck Computer = new Deck();
            Computer.Cards = new Card[8];

            int PlayersScore = 0;
            int ComputersScore = 0;
            int CountCards = 4;
            int playerscard = 2;
            int computerscard = 2;

            
            if (operation == 1)
            {
                for (int i = 0; i < playerscard; i++)
                {
                    Player.Cards[i] = Deck.Cards[i];
                    PlayersScore += (int)Player.Cards[i].Number;

                    Console.WriteLine("Your Card " + (i + 1) + " -  " + (Player.Cards[i].Suit) + " - " + (Player.Cards[i].Number));
                }

                Console.WriteLine("Your score: " + PlayersScore);

                for (int i = 0; i < computerscard; i++)

                {
                    Computer.Cards[i] = Deck.Cards[i + 8];
                    ComputersScore += (int)Computer.Cards[i].Number;

                    Console.WriteLine("Computer Card " + (i + 1) + " - " + (Computer.Cards[i].Suit) + " - " + (Computer.Cards[i].Number));
                }

                Console.WriteLine("Computer score: " + ComputersScore);

                if (PlayersScore == ComputersScore && PlayersScore == 21 ||
                   (Player.Cards[0].Number == CardNumber.Ace && Player.Cards[1].Number == CardNumber.Ace &&
                    Computer.Cards[0].Number == CardNumber.Ace && Computer.Cards[1].Number == CardNumber.Ace)
                   )
                {
                    Console.WriteLine("WOW!!!");
                    Wow++;
                    CountOfGames++;
                }

                else if (PlayersScore == 21 ||
                        (Player.Cards[0].Number == CardNumber.Ace && Player.Cards[1].Number == CardNumber.Ace)

                        )
                {
                    Console.WriteLine("The Game is over! /n You won!!! ");
                    PlayerWins++;
                    CountOfGames++;
                }
                else if (ComputersScore == 21 ||
                        Computer.Cards[0].Number == CardNumber.Ace && Computer.Cards[1].Number == CardNumber.Ace
                         )
                {
                    Console.WriteLine("The Game is over! /n Computer won!!! ");
                    ComputerWins++;
                    CountOfGames++;
                }
                else
                {
                    string answer = "";
                    do
                    {
                        Console.WriteLine("Do you want one more card? Type +/-");
                        answer = Console.ReadLine();
                    }
                    while (answer != "+" && answer != "-");

                    while (answer != "-" && answer != "-")
                    {
                        Player.Cards[playerscard] = Deck.Cards[CountCards];
                        CountCards++;
                        PlayersScore += (int)Player.Cards[playerscard].Number;
                        playerscard++;

                        for (int i = 0; i < playerscard; i++)
                        {
                            Console.WriteLine("Your Card " + (i + 1) + " - " + (Player.Cards[i].Suit) + " - " + (Player.Cards[i].Number));
                        }
                        Console.WriteLine("Your score: " + PlayersScore);

                        if (PlayersScore >= 21)
                        {
                            Console.WriteLine(" Youre count " + PlayersScore + "Now computer's turn. ");
                            Console.WriteLine("Press enter.");
                            Console.ReadLine();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Do you want one more card? Type +/-");
                            answer = Console.ReadLine();
                        }
                    }

                    while (ComputersScore <= 17)
                    {
                        Console.WriteLine("Computer's cards..");
                        Computer.Cards[computerscard] = Deck.Cards[CountCards];
                        CountCards++;

                        ComputersScore += (int)Computer.Cards[computerscard].Number;
                        playerscard++;

                        for (int i = 0; i < computerscard + 1; i++)
                        {
                            Console.WriteLine("Computer card: " + (i + 1) + " - " + (Computer.Cards[i].Suit) + " - " + (Computer.Cards[i].Number));

                        }
                        Console.WriteLine("Computer score: " + ComputersScore);
                        computerscard++;

                    }
                    if (PlayersScore == ComputersScore)
                    {
                        Console.WriteLine("WOW!");
                        Wow++;
                        CountOfGames++;
                    }
                    else if (

                        (PlayersScore == 21) ||
                        (PlayersScore > 21 && ComputersScore > 21 && PlayersScore < ComputersScore) ||
                        (PlayersScore < 21 && ComputersScore < 21 && PlayersScore > ComputersScore) ||
                        (PlayersScore < 21 && ComputersScore > 21)
                             )
                    {
                        Console.WriteLine("You won!");
                        PlayerWins++;
                        CountOfGames++;
                    }
                    else
                    {
                        Console.WriteLine("Computer won!");
                        ComputerWins++;
                        CountOfGames++;

                    }
                    Console.ReadLine();
                }

            }

            //Computer start the game

            else
            {
                for (int i = 0; i < computerscard; i++)

                {
                    Computer.Cards[i] = Deck.Cards[i + 8];
                    ComputersScore += (int)Computer.Cards[i].Number;

                    Console.WriteLine("Computer Card " + (i + 1) + " - " + (Computer.Cards[i].Suit) + " - " + (Computer.Cards[i].Number));
                }

                Console.WriteLine("Computer score: " + ComputersScore);


                for (int i = 0; i < playerscard; i++)
                {
                    Player.Cards[i] = Deck.Cards[i];
                    PlayersScore += (int)Player.Cards[i].Number;

                    Console.WriteLine("Your Card " + (i + 1) + " -  " + (Player.Cards[i].Suit) + " - " + (Player.Cards[i].Number));
                }
                Console.WriteLine("Your score: " + PlayersScore);

                if (PlayersScore == ComputersScore && PlayersScore == 21 ||
                   (Player.Cards[0].Number == CardNumber.Ace && Player.Cards[1].Number == CardNumber.Ace &&
                    Computer.Cards[0].Number == CardNumber.Ace && Computer.Cards[1].Number == CardNumber.Ace)
                   )

                {
                    Console.WriteLine("WOW!!!");
                    Wow++;
                    CountOfGames++;
                }

                else if (PlayersScore == 21 ||
                        (Player.Cards[0].Number == CardNumber.Ace && Player.Cards[1].Number == CardNumber.Ace)

                        )

                {
                    Console.WriteLine("The Game is over! /n You won!!! ");
                    PlayerWins++;
                    CountOfGames++;
                }

                else if (ComputersScore == 21 ||
                        Computer.Cards[0].Number == CardNumber.Ace && Computer.Cards[1].Number == CardNumber.Ace
                         )

                {
                    Console.WriteLine("The Game is over! /n Computer won!!! ");
                    ComputerWins++;
                    CountOfGames++;
                }


                else
                {

                    while (ComputersScore <= 17)
                    {
                        Console.WriteLine("Computer's turn! Please, Wait for it..");
                        Computer.Cards[computerscard] = Deck.Cards[CountCards];
                        CountCards++;

                        ComputersScore += (int)Computer.Cards[computerscard].Number;
                        playerscard++;

                        for (int i = 0; i < computerscard + 1; i++)
                        {
                            Console.WriteLine();

                        }

                        computerscard++;
                    }

                    Console.WriteLine("Computer is Done. Now it is your turn!");

                    string answer = "";
                    do
                    {
                        Console.WriteLine("Do you want one more card? Type +/-");
                        answer = Console.ReadLine();
                    }
                    while (answer != "+" && answer != "-");

                    while (answer != "-" && answer != "-")
                    {
                        Player.Cards[playerscard] = Deck.Cards[CountCards];
                        CountCards++;
                        PlayersScore += (int)Player.Cards[playerscard].Number;
                        playerscard++;

                        for (int i = 0; i < playerscard; i++)
                        {
                            Console.WriteLine("Your Card " + (i + 1) + " - " + (Player.Cards[i].Suit) + " - " + (Player.Cards[i].Number));
                        }
                        Console.WriteLine("Your score: " + PlayersScore);

                        if (PlayersScore >= 21)
                        {
                            Console.WriteLine(" Youre count is " + PlayersScore);
                            Console.WriteLine("Press enter.");
                            Console.ReadLine();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Do you want one more card? Type +/-");
                            answer = Console.ReadLine();
                        }

                    }

                    if (PlayersScore == ComputersScore)
                    {
                        Console.WriteLine("Computer score: " + ComputersScore);
                        Console.WriteLine("WOW!");
                        Wow++;
                        CountOfGames++;
                    }
                    else if (

                        (PlayersScore == 21) ||
                        (PlayersScore > 21 && ComputersScore > 21 && PlayersScore < ComputersScore) ||
                        (PlayersScore < 21 && ComputersScore < 21 && PlayersScore > ComputersScore) ||
                        (PlayersScore < 21 && ComputersScore > 21)
                             )
                    {
                        Console.WriteLine("Computer score: " + ComputersScore);
                        Console.WriteLine("You won!");
                        PlayerWins++;
                        CountOfGames++;
                    }
                    else
                    {
                        Console.WriteLine("Computer score: " + ComputersScore);
                        Console.WriteLine("Computer won!");
                        ComputerWins++;
                        CountOfGames++;
                    }
                }

            }

                Console.ReadLine();
                do
                {
                    Console.Clear();
                    Console.WriteLine(" Liked it? Want to try agayn?  + / - ");
                    NextGame = Console.ReadLine();
                }
                while (NextGame != "-" && NextGame != "+");
                
            }
            while (NextGame != "-");

            Console.WriteLine("You played : " + CountOfGames + " games! WoW!");
            Console.WriteLine("You won : " + PlayerWins + " times! Congrats!");
            Console.WriteLine("Computer won : " + ComputerWins + " times! Sorry!");
            Console.WriteLine("You both was too brilliant : " + Wow + " times! Perfect! \n ");
            Console.WriteLine("Thanks for the game!\n Live long and prosper! ");
            Console.ReadLine();
        }

    }
}
