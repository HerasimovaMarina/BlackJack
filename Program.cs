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

            int suitsLength = Enum.GetValues(typeof(CardSuit)).Length;
            int numberLength = Enum.GetValues(typeof(CardNumber)).Length;

            int cardsInDeck = suitsLength * numberLength;

            Deck Deck = new Deck();
            Deck.Cards = new Card[cardsInDeck];

            CardSuit[] cardSuits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            CardNumber[] cardNumber = (CardNumber[])Enum.GetValues(typeof(CardNumber));

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

            Random random = new Random();

            for (int i = 0; i < Deck.Cards.Length; i++)
            {
                int j = random.Next(0, 35);
                var temp = Deck.Cards[i];
                Deck.Cards[i] = Deck.Cards[j];
                Deck.Cards[j] = temp;
            }


            int operation = 0;
            Console.WriteLine("1-Start the Game. 2-Exit.");
            operation = int.Parse(Console.ReadLine());


            if (operation == 1)
            {
                Deck Player = new Deck();
                Player.Cards = new Card[8];

                Deck Computer = new Deck();
                Computer.Cards = new Card[8];

                int PlayersScore = 0;
                int ComputersScore = 0;
                int CountCards = 4;
                int playerscard = 2;
                int computerscard = 2;

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

                if (PlayersScore == ComputersScore && PlayersScore == 21)

                    Console.WriteLine("WOW!!!");

                else if (PlayersScore == 21 ||
                    (Player.Cards[0].Number == CardNumber.Ace && Player.Cards[1].Number == CardNumber.Ace)
                    )
                    Console.WriteLine("The Game is over! /n You won!!! ");

                else if (ComputersScore == 21)
                    Console.WriteLine("The Game is over! /n Computer won!!! ");
                else
                {
                    string answer = "";
                    do
                    {
                        Console.WriteLine("Do you want one more card? Type +/-");
                        answer = Console.ReadLine();
                    }
                    while (answer != "+" && answer != "-");

                    if (answer == "+")


                        for (int i = 0; i < playerscard + 1; i++)
                        {
                            Player.Cards[i] = Deck.Cards[i];
                            PlayersScore += (int)Player.Cards[playerscard].Number;

                            Console.WriteLine("Your Card " + (i + 1) + " - " + (Player.Cards[i].Suit) + " - " + (Player.Cards[i].Number));

                        }
                    Console.WriteLine("Your score: " + PlayersScore);

                    if (PlayersScore >= 21)

                    {
                        Console.WriteLine(" Youre count " + PlayersScore + "Now computer's turn. ");
                        Console.WriteLine("Press enter.");
                        Console.ReadLine();

                    }

                    else

                    {
                        Console.WriteLine("Do you want one more card? Type +/-");
                        answer = Console.ReadLine();

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

                        Console.WriteLine("WOW!");

                    else if (
                        (PlayersScore == 21) ||
                        (PlayersScore > 21 && ComputersScore > 21 && PlayersScore < ComputersScore) ||
                        (PlayersScore < 21 && ComputersScore < 21 && PlayersScore > ComputersScore) ||
                        (PlayersScore < 21 && ComputersScore > 21)
                    )

                    {
                        Console.WriteLine("You won!");
                    }
                    else

                    {

                        Console.WriteLine("Computer won!");

                    }
                    Console.ReadLine();
                    if (operation == 2)
                        Console.ReadLine();
                }

            }
        }
    }

}

