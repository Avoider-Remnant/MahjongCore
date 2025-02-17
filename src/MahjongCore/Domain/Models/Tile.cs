﻿namespace MahjongCore.Domain.Models;

using Enums;
using System;

public class Tile
{
    public byte TileId { get; set; }

    public SuitType Suit { get; set; }

    public byte Value { get; set; }

    public byte DoraValue { get; set; }

    public bool IsHonor => Suit > SuitType.Wind;
    public bool IsTerminal => Value == 1 || Value == 9 || IsHonor;

    public bool IsDragon => Suit > SuitType.Dragon;

    public Tile(SuitType suit, byte value, byte doraValue)
    {
        Suit = suit;
        Value = value;
        DoraValue = doraValue;
        TileId = (byte)(suit + value);
    }
}