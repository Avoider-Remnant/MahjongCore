namespace MahjongCore.Domain.Models;

public class GameState
{
    public int RoundId { get; set; }

    public List<PlayerState> PlayerStates { get; set; } = new();

    public int LiveWallCount { get; set; }

    public int SeatWindId { get; set; }

    public int RoundWindId { get; set; }
}