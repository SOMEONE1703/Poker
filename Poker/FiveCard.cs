using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker;

class FiveCard : IPoker
{
    public FiveCard()
    {
        _cards = new Cards();
    }

    public string CompareHands(Cards firstHand, Cards secondHand)
    {
        var FirstEval = new FiveCardHand(firstHand).Evaluate();
        var SecondEval = new FiveCardHand(secondHand).Evaluate();

        string[] hierarchy = new string[]
        {
            "Straight Flush",
            "Four of a Kind",
            "Full House",
            "Straight",
            "Three of a Kind",
            "Two Pair",
            "One Pair",
            "Kicker"
        };
        while (true)
        {
            if (FirstEval.Count == 0 || SecondEval.Count == 0)
            {
                Console.WriteLine("Hands are Tied");
                return "Hands are Tied";
            }
            var FirstTemp = FirstEval.First();
            var SecondTemp = SecondEval.First();
            FirstEval.Remove(FirstTemp);
            SecondEval.Remove(SecondTemp);
            for (int i = 0; i < hierarchy.Length; i++)
            {
                if (hierarchy[i]==FirstTemp.Strength && hierarchy[i] == SecondTemp.Strength)
                {
                    for (int j = 0; j < FirstTemp.Values.Length; j++)
                    {
                        if (FirstTemp.Values[j] > SecondTemp.Values[j])
                        {
                            Console.WriteLine($"First Hand Wins by Kicker:{FirstTemp.Values[j]}");
                            return "First Hand Wins";
                        }
                        else if (FirstTemp.Values[j] < SecondTemp.Values[j])
                        {
                            Console.WriteLine($"Second Hand Wins by Kicker:{FirstTemp.Values[j]}");
                            return "Second Hand Wins";
                        }
                    }
                }
                else if (hierarchy[i] == FirstTemp.Strength)
                {
                    Console.WriteLine($"First Hand Wins by: {hierarchy[i]}");
                    return "First Hand Wins";
                }
                else if (hierarchy[i] == SecondTemp.Strength)
                {
                    Console.WriteLine($"Second Hand Wins by: {hierarchy[i]}");
                    return "Second Hand Wins";
                }
            }
        }
    }



    public LinkedList<Card> Deal()
    {
        throw new NotImplementedException();
    }

    public Dictionary<int, List<Card>> DealMultiple(int numPlayers)
    {
        throw new NotImplementedException();
    }


    public Cards _cards { get; set; }
}

