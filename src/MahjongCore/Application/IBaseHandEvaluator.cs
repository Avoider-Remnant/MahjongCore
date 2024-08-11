namespace MahjongCore.Application;

using Domain.Models;

public interface IBaseHandEvaluator
{
    List<Yaku> Run(
        GameState state,
        Combination[] closedHandCombinations,
        Combination currentPair);
}