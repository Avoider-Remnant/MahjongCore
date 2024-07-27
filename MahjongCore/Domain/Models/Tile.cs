namespace MahjongCore.Domain.Models;

using Enums;

public class Tile
{
    public byte TileId { get; set; }

    public SuitType Suit { get; set; }

    public byte Value { get; set; }

    public byte DoraValue { get; set; }


    public Tile(SuitType suit, byte value, byte doraValue)
    {
        Suit = suit;
        Value = value;
        DoraValue = doraValue;
        TileId = (byte)(suit + value);
    }
}