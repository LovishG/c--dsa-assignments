using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter your Hand");
        string[] cards = new string[5];
        for(int i = 0; i < cards.Length; i++)
        {
            string card = Console.ReadLine();
            cards[i] = card;
        }
        string wonSituation = PokerHandRanking(cards);
        Console.WriteLine("win is " + wonSituation);


    }

    public static string PokerHandRanking(string[] hand)
    {
        string retVal = "High Card";
        bool isStraight = false;
        bool isFlush = false;
        bool isRoyal = false;
        // Hand has a 2 then NOT aceHigh per se...
        bool aceHigh = hand.Where(c => c.StartsWith("2")).Count() <= 0;

        // Card: Rank, Suit, Ordinal Sort Value
        List<Tuple<string, string, int>> cards = new List<Tuple<string, string, int>>(); ;
        foreach (var item in hand)
        {
            string card = item.Substring(0, item.Length - 1);
            //Console.WriteLine($"card.Length-1: {item.Length - 1}");
            string suit = item.Substring(item.Length - 1, 1);
            int rank = 0;
            switch (card)
            {
                case "J":
                    rank = 11;
                    break;
                case "Q":
                    rank = 12;
                    break;
                case "K":
                    rank = 13;
                    break;
                case "A":
                    rank = (aceHigh) ? 14 : 1;
                    break;
                default:
                    Int32.TryParse(card, out rank);
                    break;
            }

            cards.Add(Tuple.Create<string, string, int>(card, suit, rank));
        }

        // NO PAIRS IF 5 GROUPS
        if (cards.GroupBy(c => c.Item1).Count() == hand.Count())
        {
            // Flush
            isFlush = (cards.GroupBy(g => g.Item2).Count() == 1);

            // Check for straight
            var sortedCollection = cards.OrderBy(t => t.Item3).ToList();
            int? previousVal = null;

            foreach (var item in cards.OrderBy(t => t.Item3).Select(s => s.Item3))
            {
                if (previousVal != null)
                {
                    isStraight = (previousVal + 1 == item);
                    if (!isStraight)
                    {
                        break;
                    }
                }
                previousVal = item;

            }

            if (!isFlush && !isStraight)
            {
                retVal = "High Card";
            }
            else if (isStraight || isFlush)
            {
                // is straight or flush... is it ROYAL
                isRoyal = (cards.Where(c => c.Item1 == "A" || c.Item1 == "10").Count() == 2 && isFlush);

                retVal = (isRoyal) ? "Royal " : string.Empty;
                retVal += (isStraight && !isRoyal) ? "Straight " : string.Empty;
                retVal += (isFlush) ? "Flush" : string.Empty;
            }

        }
        else
        {
            var groups = cards.GroupBy(c => c.Item1).ToList();

            var pairs = groups.Where(g => g.Count() == 2).Count();
            var threeOfAKind = groups.Where(g => g.Count() == 3).Count();
            var fourOfAKind = groups.Where(g => g.Count() == 4).Count();
            if (pairs > 0 && threeOfAKind == 0)
            {
                retVal = (pairs > 1) ? "Two Pair" : "Pair";
            }
            else if (threeOfAKind > 0)
            {
                retVal = (pairs > 0) ? "Full House" : "Three of a Kind";
            }
            else if (fourOfAKind > 0)
            {
                retVal = "Four of a Kind";
            }
            else
            {
                retVal = string.Empty;
            }
        }
        return retVal.Trim();
    }
}
