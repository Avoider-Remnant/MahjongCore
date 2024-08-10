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
        private Combination CurrentPair = new Combination();
        private List<List<Combination>> FullHand = new();
        public void Run(Hand playerHand)
        {
            List<int> pairsIndexes = FindPairsIndexes(playerHand.CloseTiles);

            // TODO class field insted of using "out" 
            if (pairsIndexes.Count == 0) return;
            if (pairsIndexes.Count == 7)
            {
                Combination[] allPairs = new Combination[7];
                foreach (int pairIndex in pairsIndexes)
                    allPairs[pairIndex] = new Combination(CombinationType.Pair, playerHand.CloseTiles[pairIndex], false);
                CheckHand(allPairs, playerHand);
                return;
            }

            List<Tile>[] handState = new List<Tile>[4];
            Combination[] combinations = new Combination[4];

            for (int i = 0; i < 4; i++)
            {
                handState[i] = new();
                // use arr 
                combinations[i] = new Combination();
            }

            foreach (int pairsIndex in pairsIndexes)
            {
                CurrentPair.SetCombination(CombinationType.Pair, playerHand.CloseTiles[pairsIndex]);
                playerHand.CloseTiles.TakeNonAlloc(handState[0], pairsIndex, 2);
                Divider(handState, combinations, 0, playerHand);
            }
        }

        private void Divider(List<Tile>[] handState, Combination[] combinations, int depthIndex, Hand playerHand)
        {
            if (depthIndex == handState.Length || handState[depthIndex].Count < 3)
            {
                CheckHand(combinations, playerHand);
                handState[depthIndex - 1].Clear();
                combinations[depthIndex - 1].Clear();
                return;
            }

            if (handState[depthIndex].Count > 3 && IsKan(handState[depthIndex]))
            {
                combinations[depthIndex].SetCombination(CombinationType.Kan, handState[depthIndex][0]);
                handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], 0, 4);
                Divider(handState, combinations, depthIndex + 1, playerHand);
            }
            if (IsTriplet(handState[depthIndex]))
            {
                combinations[depthIndex].SetCombination(CombinationType.Triplet, handState[depthIndex][0]);
                handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], 0, 3);
                Divider(handState, combinations, depthIndex + 1, playerHand);
            }
            if (TryGetSequenceIndexes(handState[depthIndex], out int[] sequenceIndexes))
            {
                combinations[depthIndex].SetCombination(CombinationType.Sequence, handState[depthIndex][0]);
                handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], sequenceIndexes);
                Divider(handState, combinations, depthIndex + 1, playerHand);
            }



            /*
            if (IsKan(handState[depthIndex]))
            {
                SetCombination(combinations[depthIndex], handState[depthIndex], 4);

                if (depthIndex == 3)
                {
                    CheckHand();
                }
                else
                {
                    handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], 0, 4);
                    Divider(ref handState, ref combinations, depthIndex + 1);
                }

            }

            if (IsTriplet(handState[depthIndex]))
            {
                SetCombination(combinations[depthIndex], handState[depthIndex], 3);

                if (depthIndex == 3)
                {
                    CheckHand();
                }
                else
                {
                    handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], 0, 3);
                    Divider(ref handState, ref combinations, depthIndex + 1);
                }

            }

            if (TryGetSequenceIndexes(handState[depthIndex], out int[] sequenceIndexes))
            {
                SetCombination(combinations[depthIndex], handState[depthIndex], sequenceIndexes);

                if (depthIndex == 3)
                {
                    CheckHand();
                }
                else
                {
                    handState[depthIndex].TakeNonAlloc(handState[depthIndex + 1], sequenceIndexes);
                    Divider(ref handState, ref combinations, depthIndex + 1);
                }

            }
            */
        }

        private static bool TryGetSequenceIndexes(List<Tile> tiles, out int[] sequenceIndexes)
        {
            int initialIndex = 0;
            int nextIndex = 1;
            int sequenceIndexesIndex = 1;

            sequenceIndexes = new int[3];

            if (tiles[initialIndex].IsHonor) return false;

            do
            {
                if (tiles[initialIndex].TileId + 1 == tiles[nextIndex].TileId)
                {
                    sequenceIndexes[sequenceIndexesIndex] = nextIndex;
                    initialIndex++;
                    sequenceIndexesIndex++;
                }
            }
            while (tiles[initialIndex].TileId == tiles[nextIndex].TileId && ++nextIndex < tiles.Count && sequenceIndexesIndex < 3);
            return sequenceIndexes[1] != 0 && sequenceIndexes[2] != 0;
        }

        private void CheckHand(Combination[] combinations, Hand playerHand)
        {
            List<Combination> temp = new List<Combination>();

            if (CurrentPair != null)
            {
                temp.Add(CurrentPair);
            }

            int i = 0;
            while (combinations[i].Type != CombinationType.None && i < combinations.Length)
            {
                temp.Add(combinations[i]);
            }

            foreach (Combination comb in playerHand.OpenCombinations)
            {
                temp.Add(comb);
            }

            FullHand.Add(temp);
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
