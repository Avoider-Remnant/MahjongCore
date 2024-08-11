namespace MahjongCore.Application;

using Domain.Models;

public interface IBaseHandEvaluator
{
    List<Yaku> Run( GameState state, List<Combination> closedHandCombinations, Combination currentPair);
}