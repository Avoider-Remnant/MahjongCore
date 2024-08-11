namespace MahjongCore.Domain.Models;

using Enums;

public class Tile
{
    public byte TileId { get; set; }

    public SuitType Suit { get; set; } = SuitType.None;

    public byte Value { get; set; }

    public byte DoraValue { get; set; }

    public bool IsHonor => Suit > SuitType.Wind;
    public bool IsTerminal => Value is 1 or 9;

    public bool IsDragon => Suit > SuitType.Dragon;

    public Tile()
    {
        
    }

    public Tile(SuitType suit, byte value, byte doraValue)
    {
        Suit = suit;
        Value = value;
        DoraValue = doraValue;
        TileId = (byte)(suit + value);
    }
}