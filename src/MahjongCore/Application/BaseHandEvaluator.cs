namespace MahjongCore.Application;

using Domain.Models;
using System.Collections.Generic;
using Domain.Enums;

public class BaseHandEvaluator : IBaseHandEvaluator
{
    #region Interface

    public List<Yaku> Run(
        GameState state,
        Combination[] combinations,
        Combination currentPair)
    {
        var result = new List<Yaku>();

        var isOpenHand = state.PlayerHand.OpenTiles.Count > 0;

        // var isBonusForClosedHand = false;
        //check for open yaku

        if (IsHaitei(combinations, state))
        {
            result.Add(new Yaku { Name = "Haitei", Han = 1 });
        }
        else if (IsHoutei(combinations, state))
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

        if (IsTanyao(combinations, state))
        {
            result.Add(new Yaku { Name = "Tanyao", Han = 1 });
        }

        if (IsYakuhai(combinations, state))
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

        if (IsToiToi(combinations, state))
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

    private void CalculateDoras(GameState state)
    {
        throw new NotImplementedException();
    }

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

    private bool IsToiToi(Combination[] combinations,
        GameState state)
    {
        // The entire hand is composed of triplets.
        int pairs = 0;
        int triplets = 0;
        foreach (Combination comb in combinations)
        {
            if (comb.Type == CombinationType.Triplet)
                triplets++;
            else if (comb.Type == CombinationType.Pair)
                pairs++;
            else break;
        }

        return pairs == 1 && triplets == 4;
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

    private bool IsYakuhai(Combination[] combinations,
        GameState state)
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

        return isNeededHonor && IsHandComplete(combinations);
    }

    private bool IsTanyao(Combination[] combinations,
        GameState state)
    {
        //A hand composed of only tiles that are numbered from 2 - 8. (In other words, a hand with no 1's, 9's, or honors.)
        foreach (Tile tile in state.PlayerHand.AllTiles)
        {
            if (tile.IsTerminal) return false;
        }

        return IsHandComplete(combinations);
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

    private bool IsHoutei(Combination[] combinations,
        GameState state)
    {
        // Win with the very last discarded tile.
        return state.LiveWallCount == 0 && state.timeFromLastCall == 0 && IsHandComplete(combinations);
    }

    private bool IsHaitei(Combination[] combinations,
        GameState state)
    {
        // Win by drawing the last tile from the live wall.
        return state.LiveWallCount == 0 && state.timeFromLastCall > 1 && IsHandComplete(combinations);
    }

    private bool IsPinfu(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsHandComplete(Combination[] combinations)
    {
        // rewrite using game state etc
        int pairs = 0;
        int triplets = 0;
        foreach (Combination comb in combinations)
        {
            if (comb.Type == CombinationType.Triplet || comb.Type == CombinationType.Sequence)
                triplets++;
            else if (comb.Type == CombinationType.Pair)
                pairs++;
            else break;
        }

        return pairs == 1 && triplets == 4;
    }

    private void CopyTilesWithoutPair(List<Tile> tiles,
        List<Tile> remainingTiles,
        int pairIndex)
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

    #endregion
}