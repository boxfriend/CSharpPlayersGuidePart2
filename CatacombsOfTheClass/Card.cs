namespace CatacombsOfTheClass;

internal class Card
{
    //Answer to challenge question: The Color class is to create new colors with defined RGB value, this only requires an identifier for the color of the card
    //It also only has 4 possible values, we do not need to use another class to represent the color for the card when an enum is sufficient for an identifier
    public static int NumberOfColors => 4;
    public static int NumberOfRanks => 14;

    public bool IsNumber => (int)Rank < 10;
    public bool IsSymbol => !IsNumber;

    public CardRank Rank { get; set; }
    public CardColor Color { get; set; }

    public Card(int color, int rank): this((CardColor)color, (CardRank)rank) { }
    public Card (CardColor color, CardRank rank)
    {
        Rank = rank;
        Color = color;
    }

    public static Card[] CreateDeck ()
    {
        var deck = new Card[NumberOfColors * NumberOfRanks];
        var index = 0;
        for(var i = 0; i < NumberOfColors; i++)
        {
            for(var j = 0; j < NumberOfRanks; j++)
            {
                deck[index++] = new Card(i, j);
            }
        }

        return deck;
    }

    public override string ToString () => $"The {Color} {Rank}";
}

enum CardColor { Red, Green, Blue, Yellow }
enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Arrow, Ampersand }
