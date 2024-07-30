namespace MahjongCore.Application;

using Domain.Models;
using System.Collections.Generic;
using Domain.Enums;

public class BaseHandEvaluator : IBaseHandEvaluator
{
    #region Interface

    public List<Yaku> Run(GameState state)
    {
        var result = new List<Yaku>();

        var isOpenHand = state.PlayerHand.OpenTiles.Count > 0;

        // var isBonusForClosedHand = false;
        //check for open yaku

        if (IsHaitei(state))
        {
            result.Add(new Yaku { Name = "Haitei", Han = 1 });
        }
        else if (IsHoutei(state))
        {
            result.Add(new Yaku { Name = "Hoitei", Han = 1 });
        }
        else if (IsRinshanKaihou(state))
        {
            result.Add(new Yaku { Name = "RinshanKaihou", Han = 1 });
        }

        if (IsChanKan(state))
        {
            result.Add(new Yaku { Name = "ChanKan", Han = 1 });
        }

        if (IsTanyao(state))
        {
            result.Add(new Yaku { Name = "Tanyao", Han = 1 });
        }

        if (IsYakuhai(state))
        {
            result.Add(new Yaku { Name = "Yakuhai", Han = 1 });
        }

        if (IsChantaiyao(state))
        {
            result.Add(new Yaku { Name = "Chantaiyao", Han = 2 });
        }

        if (IsSanshoku(state))
        {
            result.Add(new Yaku { Name = "Sanshoku", Han = 2 });
        }

        if (IsIttsu(state))
        {
            result.Add(new Yaku { Name = "Ittsu", Han = 2 });
        }

        if (IsToiToi(state))
        {
            result.Add(new Yaku { Name = "ToiToi", Han = 2 });
        }

        if (IsSanankou(state))
        {
            result.Add(new Yaku { Name = "Sanankou", Han = 2 });
        }

        if (IsSanshoku(state))
        {
            result.Add(new Yaku { Name = "Sanshoku", Han = 2 });
        }

        if (IsSankantsu(state))
        {
            result.Add(new Yaku { Name = "Sankantsu", Han = 2 });
        }

        if (IsHonroutou(state))
        {
            result.Add(new Yaku { Name = "Honroutou", Han = 2 });
        }

        if (IsShousangen(state))
        {
            result.Add(new Yaku { Name = "Shousangen", Han = 2 });
        }

        if (IsHonitsu(state))
        {
            result.Add(new Yaku { Name = "Honroutou", Han = 2 });
        }

        if (IsJunchan(state))
        {
            result.Add(new Yaku { Name = "Honroutou", Han = 2 });
        }

        if (IsChinitsu(state))
        {
            result.Add(new Yaku { Name = "Chinitsu", Han = 6 });
        }

        if (IsKazoe(state))
        {
            result.Add(new Yaku { Name = "Kazoe ", Han = 6 });
        }

        if (IsDaisangen(state))
        {
            result.Add(new Yaku { Name = "Daisangen ", Han = 6 });
        }

        if (IsShousuushii(state))
        {
            result.Add(new Yaku { Name = "Shousuushii ", Han = 6 });
        }

        if (IsDaisuushii(state))
        {
            result.Add(new Yaku { Name = "Daisuushii ", Han = 6 });
        }

        if (IsTsuuiisou(state))
        {
            result.Add(new Yaku { Name = "Tsuuiisou ", Han = 6 });
        }

        if (IsChinroutou(state))
        {
            result.Add(new Yaku { Name = "Chinroutou ", Han = 6 });
        }

        if (IsRyuuiisou(state))
        {
            result.Add(new Yaku { Name = "Ryuuiisou ", Han = 6 });
        }

        if (IsSuukantsu(state))
        {
            result.Add(new Yaku { Name = "Suukantsu ", Han = 6 });
        }

        if (isOpenHand) return result;

        if (IsMenzenTsumo(state))
        {
            result.Add(new Yaku { Name = "Menzen Tsumo", Han = 1 });
        }

        if (IsRiichi(state))
        {
            result.Add(new Yaku { Name = "Riichi", Han = 1 });
        }

        if (IsIppatsu(state))
        {
            result.Add(new Yaku { Name = "Ippatsu", Han = 1 });
        }

        if (IsPinfu(state))
        {
            result.Add(new Yaku { Name = "Pinfu", Han = 1 });
        }


        if (IsIipeikou(state))
        {
            result.Add(new Yaku { Name = "Iipeikou", Han = 1 });
        }

        if (IsDoubleRiichi(state))
        {
            result.Add(new Yaku { Name = "DoubleRiichi", Han = 1 });
        }

        if (IsJunchantaiyao(state))
        {
            result.Add(new Yaku { Name = "Junchantaiyao", Han = 3 });
        }

        if (IsChiitoitsu(state))
        {
            result.Add(new Yaku { Name = "Chiitoitsu", Han = 2 });
        }

        if (IsRyanpeikou(state))
        {
            result.Add(new Yaku { Name = "Ryanpeikou", Han = 3 });
        }

        if (IsKokushi(state))
        {
            result.Add(new Yaku { Name = "Kokushi", Han = 6 });
        }

        if (IsSuuankou(state))
        {
            result.Add(new Yaku { Name = "Suuankou", Han = 6 });
        }

        if (IsChuuren(state))
        {
            result.Add(new Yaku { Name = "Chuuren", Han = 6 });
        }

        if (IsTenhou(state))
        {
            result.Add(new Yaku { Name = "Tenhou", Han = 6 });
        }

        if (IsChiihou(state))
        {
            result.Add(new Yaku { Name = "Chiihou", Han = 6 });
        }

        if (IsNagashi(state))
        {
            result.Add(new Yaku { Name = "Nagashi", Han = 6 });
        }

        return result;
    }

    #endregion

    #region Private(s)

    private bool IsNagashi(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChiihou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsTenhou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChuuren(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsRyanpeikou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsJunchantaiyao(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsDoubleRiichi(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsIipeikou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsIppatsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsRiichi(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsMenzenTsumo(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsSuukantsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsRyuuiisou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChinroutou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsTsuuiisou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsDaisuushii(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsShousuushii(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsDaisangen(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsSuuankou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsKokushi(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsKazoe(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChinitsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsJunchan(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsHonitsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsShousangen(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsHonroutou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChiitoitsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsSankantsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsSanankou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsToiToi(GameState state)
    {
        // The entire hand is composed of triplets.
        for (int i = 0; i < state.PlayerHand.OpenTiles.Count; i += 3)
        {
            if (!IsTriplet(state.PlayerHand.OpenTiles, i)) return false;
        }
        bool isPairFound = false;
        for (int i = 0; i < state.PlayerHand.CloseTiles.Count;)
        {
            if (IsTriplet(state.PlayerHand.OpenTiles, i))
            {
                i += 3;
            }
            else if (!isPairFound && IsPair(state.PlayerHand.OpenTiles, i))
            {
                i += 2;
                isPairFound = true;
            }
            else return false;
        }
        return true;
    }

    private bool IsIttsu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsSanshoku(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChantaiyao(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsYakuhai(GameState state)
    {
        //A hand with at least one group of dragon tiles, seat wind, or round wind tiles. Each group is worth 1 han.
        bool isNeededHonor = false;
        foreach (Tile tile in state.PlayerHand.AllTiles)
        {
            if (tile.TileId == state.SeatWindId || tile.TileId == state.RoundWindId || tile.IsDragon)
            {
                isNeededHonor = true;
                break;
            }
        }
        if (isNeededHonor) return IsHandPartComplete(state.PlayerHand.CloseTiles);
        else return false;
    }

    private bool IsTanyao(GameState state)
    {
        //A hand composed of only tiles that are numbered from 2 - 8. (In other words, a hand with no 1's, 9's, or honors.)
        foreach (Tile tile in state.PlayerHand.AllTiles)
        {
            if (tile.IsTerminal) return false;
        }
        return IsHandPartComplete(state.PlayerHand.CloseTiles);
    }

    private bool IsChanKan(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsRinshanKaihou(GameState state)
    {
        // Win with a tile from the dead wall - i.e., win by the tile drawn after a kan.
        throw new NotImplementedException();
    }

    private bool IsHoutei(GameState state)
    {
        // Win with the very last discarded tile.
        return state.LiveWallCount == 0 && state.timeFromLastCall == 0 && IsHandPartComplete(state.PlayerHand.CloseTiles);
    }

    private bool IsHaitei(GameState state)
    {
        // Win by drawing the last tile from the live wall.
        return state.LiveWallCount == 0 && state.timeFromLastCall > 1 && IsHandPartComplete(state.PlayerHand.CloseTiles);
    }

    private bool IsPinfu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsHandPartComplete(List<Tile> tiles)
    {
        var pairIndexes = FindPairsIndexes(tiles);
        if (pairIndexes.Count == 0) return false;
        if (pairIndexes.Count == 7 || tiles.Count == 2) return true;// all pairs or tiles list is only one pair

        List<Tile> remainingTiles = new(tiles.Count);
        foreach (var pairIndex in pairIndexes)
        {
            CopyTilesWithoutPair(tiles, remainingTiles, pairIndex);
            if (IsAllSets(remainingTiles)) return true;
            remainingTiles.Clear();
        }
        return false;
    }

    private void CopyTilesWithoutPair(List<Tile> tiles, List<Tile> remainingTiles, int pairIndex)
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (i == pairIndex)
            {
                i++;
                continue;
            }
            remainingTiles.Add(tiles[i]);
        }
    }


    private bool IsAllSets(List<Tile> tiles)
    {
        int i = 0;
        for (; (IsTriplet(tiles, i) || IsSequence(tiles, i)) && i < tiles.Count; i += 3) ;
        return i == tiles.Count;

    }

    private static bool IsPair(List<Tile> tiles, int initialTileIndex)
    {
        return tiles[initialTileIndex].TileId == tiles[initialTileIndex + 1].TileId;
    }

    private static bool IsTriplet(List<Tile> tiles, int initialTileIndex)
    {
        return tiles[initialTileIndex].TileId == tiles[initialTileIndex + 1].TileId && tiles[initialTileIndex].TileId == tiles[initialTileIndex + 2].TileId;
    }

    private static bool IsSequence(List<Tile> tiles, int initialTileIndex)
    {
        return !tiles[initialTileIndex].IsHonor && tiles[initialTileIndex].TileId + 1 == tiles[initialTileIndex + 1].TileId &&
                tiles[initialTileIndex].TileId + 2 == tiles[initialTileIndex + 2].TileId;
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
    #endregion
}