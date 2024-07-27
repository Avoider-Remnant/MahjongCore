namespace MahjongCore.Application;

using Domain.Models;

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
        else if (IsHoitei(state))
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    private bool IsTanyao(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsChanKan(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsRinshanKaihou(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsHoitei(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsHaitei(GameState state)
    {
        throw new NotImplementedException();
    }

    private bool IsPinfu(GameState state)
    {
        throw new NotImplementedException();
    }

    #endregion
}