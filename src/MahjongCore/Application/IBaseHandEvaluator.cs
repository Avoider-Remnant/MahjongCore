namespace MahjongCore.Application;

using Domain.Models;

public interface IBaseHandEvaluator
{
    List<Yaku> Run(List<Combination> combinations, GameState state);
}