using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker;

interface IPoker
{
    public LinkedList<Card> Deal();

    public Dictionary<int, List<Card>> DealMultiple(int numPlayers);

    public string CompareHands(Cards firstHand, Cards secondHand);

}

