namespace MahjongCore.Application;

using Utils;
using Domain.Enums;
using Domain.Models;

internal class HandDivider
{
    private readonly IBaseHandEvaluator _baseHandEvaluator;

    public HandDivider(IBaseHandEvaluator baseHandEvaluator)
    {
        _baseHandEvaluator = baseHandEvaluator;
    }

    public void Run(
        GameState gameState,
        int playerId)
    {
        var playerHand = gameState.PlayerStates[playerId].Hand;
        var currentPair = new Combination();
        var pairsIndexes = FindPairsIndexes(playerHand.CloseTiles);

        // TODO class field insted of using "out" 
        if (pairsIndexes.Count == 0) return;
        if (pairsIndexes.Count == 7)
        {
            // only one yaku separate metod
            //Combination[] allPairs = new Combination[7];
            //foreach (int pairIndex in pairsIndexes)
            //   allPairs[pairIndex] = new Combination(CombinationType.Pair, playerHand.CloseTiles[pairIndex], false);
            //CheckHand(allPairs, playerHand);
            return;
        }

        var handState = new List<Tile>[4]; // use arr
        var combinations = new Combination[4];
        var escapeDepthLevel = playerHand.CloseTiles.Count / 3;
        for (var i = 0; i < 4; i++)
        {
            handState[i] = new List<Tile>();
            combinations[i] = new Combination();
        }

        foreach (var pairsIndex in pairsIndexes)
        {
            currentPair.SetCombination(CombinationType.Pair, playerHand.CloseTiles[pairsIndex]);
            playerHand.CloseTiles.TakeNonAlloc(handState[0], pairsIndex, 2);
            Divider(gameState, handState, currentPair, combinations, 0, escapeDepthLevel, playerId);
        }
    }

    private void Divider(
        GameState gameState,
        List<Tile>[] handState,
        Combination currentPair,
        Combination[] combinations,
        int depthIndex,
        int escapeDepthLevel,
        int playerId)
    {
        if (depthIndex == escapeDepthLevel)
        {
            CheckHand(combinations, gameState, currentPair, playerId);
            return;
        }

        if (IsTriplet(handState[depthIndex]))
        {
            combinations[depthIndex].SetCombination(CombinationType.Triplet, handState[depthIndex][0]);
            handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], 0, 3);
            Divider(gameState, handState, currentPair, combinations, depthIndex + 1, escapeDepthLevel, playerId);
        }

        if (TryGetSequenceIndexes(handState[depthIndex], out var sequenceIndexes))
        {
            combinations[depthIndex].SetCombination(CombinationType.Sequence, handState[depthIndex][0]);
            handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], sequenceIndexes);
            Divider(gameState, handState, currentPair, combinations, depthIndex + 1, escapeDepthLevel, playerId);
        }
    }

    private static bool TryGetSequenceIndexes(
        List<Tile> tiles,
        out int[] sequenceIndexes)
    {
        var initialElementIndex = 0;
        var nextElemetIndex = 1;
        var sequenceIndexesIndex = 1;

        sequenceIndexes = new int[3];

        if (tiles[initialElementIndex].IsHonor) return false;

        do
        {
            if (tiles[initialElementIndex].TileId + 1 == tiles[nextElemetIndex].TileId)
            {
                sequenceIndexes[sequenceIndexesIndex] = nextElemetIndex;
                initialElementIndex = nextElemetIndex;
                sequenceIndexesIndex++;
            }
        } while (tiles[initialElementIndex].TileId == tiles[nextElemetIndex].TileId
                 && ++nextElemetIndex < tiles.Count
                 && sequenceIndexesIndex < 3);

        return sequenceIndexesIndex == 3;
    }

    private void CheckHand(Combination[] combinations,
        GameState gameState,
        Combination currentPair,
        int playerId)
    {
        _baseHandEvaluator.Run(gameState, combinations, currentPair, playerId);
    }

    private static List<int> FindPairsIndexes(List<Tile> tiles)
    {
        var pairIndexes = new List<int>();

        for (var i = 0; i < tiles.Count - 1; i++)
        {
            if (IsPair(tiles, i))
            {
                pairIndexes.Add(i);
                i++;
            }
        }

        return pairIndexes;
    }

    private static bool IsPair(
        List<Tile> tiles,
        int initialTileIndex)
    {
        return tiles[initialTileIndex].TileId == tiles[initialTileIndex + 1].TileId;
    }

    private static bool IsTriplet(List<Tile> tiles)
    {
        return tiles[0].TileId == tiles[1].TileId && tiles[0].TileId == tiles[2].TileId;
    }

    private static bool IsKan(List<Tile> tiles)
    {
        return tiles[0].TileId == tiles[1].TileId && tiles[0].TileId == tiles[2].TileId &&
               tiles[0].TileId == tiles[3].TileId;
    }
}