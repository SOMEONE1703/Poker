using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker;

interface IPokerHand
{
    public List<(string Strength, int[] Values)> Evaluate();

    public Card[] _cards { get; set; }
}

