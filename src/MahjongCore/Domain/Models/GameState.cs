namespace MahjongCore.Domain.Models;

public class GameState
{
    public Hand PlayerHand { get; set; }

    public int timeFromLastCall { get; set; }

    public int LiveWallCount { get; set; }

    public int SeatWindId { get; set; }

    public int RoundWindId { get; set; }
}