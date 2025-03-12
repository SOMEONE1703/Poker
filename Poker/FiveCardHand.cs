using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker;

class FiveCardHand:IPokerHand
{
    private int[] Ranks=new int[13];
    string FlushSuite = "unknowns";
    private int Highest;
    private bool Straight = true;
    private bool Flush = true;

    public FiveCardHand(Cards dealt)
    {
        for (int i = 0; i < 13; i++)
        {
            Ranks[i]=0;
        }
        _cards = dealt.Sort().ToArray();
        Highest = _cards[0].Rank;
    }

    public List<(string Strength, int[] Values)> Evaluate()
    {
        var strengths = new List<(string Strength, int[] Values)>();
        int[] straightRanks = new int[] { 14, 5, 4, 3, 2 };
        int straightValue = _cards[0].Rank;
        bool lowStraight = true;
        for (int i = 0; i < 5; i++)
        {
            if (_cards[i].Rank != straightRanks[i])
                lowStraight = false;
            if (_cards[i].Rank != straightValue--)
                Straight = false;
            Ranks[_cards[i].Rank + 2]++;
        }
        strengths.Insert(0, ("Kicker", _cards.Select(_card=>_card.Rank).ToArray()));
        
        for (int i = 0; i < 13; i++)
        {
            if (Ranks[i] == 2)
            {
                for (int j = i + 1; j < 13; j++)
                {
                    if (Ranks[j] == 3)
                    {
                        strengths.Insert(0, ("Full House", new int[] { j + 2, i + 2, Highest }));
                        break;
                    }
                    else if (Ranks[j] == 2)
                    {
                        strengths.Insert(0, ("Two Pair", new int[] { j + 2, i + 2, Highest }));
                        break;
                    }
                }
                if (strengths.Count == 1)
                {
                    strengths.Insert(0, ("One Pair", new int[] { i + 2, 0, Highest }));
                }
            }
            else if (Ranks[i] == 3)
            {
                for (int j = i + 1; j < 13; j++)
                {
                    if (Ranks[j] == 2)
                    {
                        strengths.Insert(0, ("Full House", new int[] { j + 2, i + 2, Highest }));
                        break;
                    }
                }
                if (strengths.Count == 1)
                {
                    strengths.Insert(0, ("One Pair", new int[] { i + 2, 0, Highest }));
                }
            }
            else if (Ranks[i] == 4)
            {
                strengths.Insert(0, ("Four of a Kind", new int[] { i + 2, 0, Highest }));
            }
        }
        if (Straight)
        {
            if (Flush)
                strengths.Insert(0, ("Straight Flush", new int[] { Highest, 0, Highest }));
            else
                strengths.Insert(0, ("Straight", new int[] { Highest, Highest-1, Highest }));
        }
        if (Flush && strengths.Count == 1)
        {
            strengths.Insert(0, ("Flush", new int[] { Highest, 0, Highest }));
        }
        return strengths;
    }

    public Card[] _cards { get; set; }
}

