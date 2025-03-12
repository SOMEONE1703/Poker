using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker;

class Card:IComparable<Card>
{
    public Card(string suite, int rank)
    {
        Suite = suite;
        Rank = rank;
    }

    public int CompareTo(Card compareCard)
    {
        // A null value means that this object is greater.
        if (compareCard == null)
            return 1;

        else
            return this.Rank.CompareTo(compareCard.Rank);
    }

    public static bool operator ==(Card a, Card b) {
        if (a.Rank == b.Rank)
        {
            return true;
        }
        return false;
    }

    public static bool operator != (Card a, Card b) => !(a == b);

    public static bool operator > (Card a, Card b)
    {
        if (a.Rank > b.Rank)
        {
            return true;
        }
        return false;
    }
    public static bool operator < (Card a, Card b) => !(a == b || a > b);

    public string Suite { get; set; }
    public int Rank { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (obj is not Card objAsCard) return false;
        else return Equals(objAsCard);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

