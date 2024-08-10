namespace MahjongCore.Domain.Models;

public class Hand
{
    public List<Tile> AllTiles { get; set; } = new();
    
    public List<Tile> OpenTiles { get; set; } = new();

    public List<Combination> OpenCombinations { get; set; } = new();

    public List<Tile> CloseTiles { get; set; } = new();
    
    public List<Tile> CloseKans { get; set; } = new();
}