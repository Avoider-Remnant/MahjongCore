namespace MahjongCore.Domain.Models;

using Enums;

public class Combination
{
    public CombinationType Type { get; private set; } = CombinationType.None;

    public Tile InitialTile { get; private set; } = new Tile();

    public bool IsOpenHand { get; set; } = false;

    public void SetCombination(CombinationType combinationType,
        Tile initialTile,
        bool isOpenHand = false)
    {
        Type = combinationType;
        InitialTile = initialTile;
        IsOpenHand = isOpenHand;
    }
}