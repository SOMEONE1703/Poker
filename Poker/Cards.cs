using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker;

class Cards//:IEnumerable
{
    public Cards() 
    {
        _cards = new List<Card>();
        for (int i = 2; i < 15; i++)
        {
            foreach(string suite in new string[]
            {
                "Spades",
                "Clubs",
                "Hearts",
                "Diamonds",
            })
            {
                _cards.Insert(0,new Card(suite, i));
            }
        }
    }

    public Cards(List<Card> myCards)
    {
        myCards.Sort();
        _cards = myCards;
    }

    public void Shuffle()
    {
        Random rnd = new Random();
        for (int i = 0; i < _cards.Count; i++)
        {
            Card temp = _cards.First();
            _cards.RemoveAt(0);
            int randPos = rnd.Next(0, _cards.Count);
            _cards.Insert(randPos,temp);
        }
    }

    public Cards Sort()
    {
        _cards.Sort();
        return new Cards(_cards);
    }

    public override string ToString()
    {
        return _cards.ToString();
    }

    public Card this[int index]
    {
        get => _cards[index];
        set => _cards[index] = value;
    }
    public Card[] ToArray() => _cards.ToArray();

    public int[] GetRanks()
    {
        int[] final = new int[_cards.Count];
        for (int i = 0; i < _cards.Count; i++)
        {
            final[i] = _cards[i].Rank;
        }
        return final;
    }

    //public IEnumerator GetEnumerator()
    //{
    //    throw new NotImplementedException();
    //}
    private List<Card> _cards { get; set; }
}

