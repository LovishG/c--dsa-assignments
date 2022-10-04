using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter your Hand");
        string[] cards = new string[5];
        for(int i = 0; i < cards.Length; i++)
        {
            Console.WriteLine($"Enter your {i + 1} card");
            string card = Console.ReadLine()!;
            cards[i] = card;
        }
        string wonSituation = PokerHandRanking(cards);
        Console.WriteLine("win is " + wonSituation);


    }

    public static string PokerHandRanking(string[] hand)
    {
        string order = "AKQJ198765432";
        var card_counts = hand
                .GroupBy(c => c.Substring(0, c.Length - 1))
                .Select(g => new { card = g.Key, count = g.Count() })
                .OrderByDescending(g => g.count)
                .ToArray();
        var card_seq = hand
                .Select(c => order.IndexOf(c[0]))
                .OrderBy(i => i)
                .ToArray();
        bool is_flush = hand.All(c => c.Last() == hand[0].Last());
        bool is_straight = Enumerable.Range(0, 4).All(i => card_seq[i] == card_seq[i + 1] - 1);
        if (is_flush)
        {
            if (is_straight)
            {
                return card_seq[0] == 0 ? "Royal Flush" : "Straight Flush";
            }
            return "Flush";
        }
        if (is_straight) return "Straight";
        if (card_counts[0].count == 4) return "Four of a Kind";
        if (card_counts[0].count == 3) return card_counts[1].count == 2 ? "Full House" : "Three of a Kind";
        if (card_counts[0].count == 2) return card_counts[1].count == 2 ? "Two Pair" : "Pair";
        return "High Card";
    }
}
