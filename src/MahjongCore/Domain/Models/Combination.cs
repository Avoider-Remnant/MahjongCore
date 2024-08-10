﻿

namespace MahjongCore.Domain.Models;

    using Enums;
    using System;
using System.Runtime.CompilerServices;

public class Combination
{
    public CombinationType Type { get; set; } = CombinationType.None;

    public Tile? InitialTile { get; set; }

    public bool IsOpenHand { get; set; } = false;
    public Combination()
    {

    }

    public Combination (CombinationType type, Tile initialTile, bool isOpenHand)
    {
        Type = type;
        InitialTile = initialTile;
        IsOpenHand = isOpenHand;
    }

    public void SetCombination( CombinationType combinationType, Tile initialTile, bool isOpenHand = false)
    {
        this.Type = combinationType;
        this.InitialTile = initialTile;
        this.IsOpenHand = isOpenHand;

    }

    internal void Clear()
    {
        throw new NotImplementedException();
    }
}