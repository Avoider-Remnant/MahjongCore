namespace MahjongCore.Domain.Models;

public class GameState
{
    public Hand PlayerHand { get; set; }

    public int LiveWallCount { get; set; }
}