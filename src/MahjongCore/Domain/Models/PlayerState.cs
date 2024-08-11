namespace MahjongCore.Domain.Models;

using Enums;

public class PlayerState
{
    public Hand Hand { get; set; } = new();

    public int LastCallRound { get; set; }

    public CallType LastCall { get; set; }
}