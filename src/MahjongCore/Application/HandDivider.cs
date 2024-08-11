using MahjongCore.Application.Utils;
using MahjongCore.Domain.Enums;
using MahjongCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MahjongCore.Application
{
    internal class HandDivider
    {
        IBaseHandEvaluator baseHandEvaluator;
        public void Run(GameState gameState)
        {
            Hand playerHand = gameState.PlayerHand;
            Combination CurrentPair = new Combination();
            List<int> pairsIndexes = FindPairsIndexes(playerHand.CloseTiles);

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

            List<Tile>[] handState = new List<Tile>[4]; // use arr
            Combination[] combinations = new Combination[4];
            byte escapeDepthLevel = playerHand.CloseTiles.Length / 3;
            for (int i = 0; i < 4; i++)
            {
                handState[i] = new();
                combinations[i] = new Combination();
            }

            foreach (int pairsIndex in pairsIndexes)
            {
                CurrentPair.SetCombination(CombinationType.Pair, playerHand.CloseTiles[pairsIndex]);
                playerHand.CloseTiles.TakeNonAlloc(handState[0], pairsIndex, 2);
                Divider(handState, combinations, 0, gameState, CurrentPair, escapeDepthLevel);
            }
        }

        private void Divider(List<Tile>[] handState, Combination[] combinations, int depthIndex, Hand playerHand, byte escapeDepthLevel)
        {
            if (depthIndex == escapeDepthLevel)
            {
                CheckHand(combinations, gameState, CurrentPair);
                return;
            }

            if (IsTriplet(handState[depthIndex]))
            {
                combinations[depthIndex].SetCombination(CombinationType.Triplet, handState[depthIndex][0]);
                handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], 0, 3);
                Divider(handState, combinations, depthIndex + 1, playerHand, escapeDepthLevel);
            }
            if (TryGetSequenceIndexes(handState[depthIndex], out int[] sequenceIndexes))
            {
                combinations[depthIndex].SetCombination(CombinationType.Sequence, handState[depthIndex][0]);
                handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], sequenceIndexes);
                Divider(handState, combinations, depthIndex + 1, playerHand, escapeDepthLevel);
            }
        }

        private static bool TryGetSequenceIndexes(List<Tile> tiles, out int[] sequenceIndexes)
        {
            int initialElementIndex = 0;
            int nextElemetIndex = 1;
            int sequenceIndexesIndex = 1;

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
            }
            while (tiles[initialElementIndex].TileId == tiles[nextElemetIndex].TileId
                    && ++nextElemetIndex < tiles.Count
                    && sequenceIndexesIndex < 3);

            return sequenceIndexesIndex == 3;
        }

        private void CheckHand(Combination[] combinations, GameState gameState, Combination currentPair)
        {

            baseHandEvaluator.Run(gameState, combinations, currentPair);
        }

        private static List<int> FindPairsIndexes(List<Tile> tiles)
        {
            List<int> pairIndexes = new();

            for (int i = 0; i < tiles.Count - 1; i++)
            {
                if (IsPair(tiles, i))
                {
                    pairIndexes.Add(i);
                    i++;
                }

            }
            return pairIndexes;
        }

        private static bool IsPair(List<Tile> tiles, int initialTileIndex)
        {
            return tiles[initialTileIndex].TileId == tiles[initialTileIndex + 1].TileId;
        }

        private static bool IsTriplet(List<Tile> tiles)
        {
            return tiles[0].TileId == tiles[1].TileId && tiles[0].TileId == tiles[2].TileId;
        }

        private static bool IsKan(List<Tile> tiles)
        {
            return tiles[0].TileId == tiles[1].TileId && tiles[0].TileId == tiles[2].TileId && tiles[0].TileId == tiles[3].TileId;
        }
    }
}
