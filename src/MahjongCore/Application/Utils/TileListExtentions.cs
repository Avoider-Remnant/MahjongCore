﻿namespace MahjongCore.Application.Utils;

using Domain.Models;

public static class TileListExtentions
{
    public static void TakeNonAlloc(
        this List<Tile> original,
        Tile[] result,
        int skipFromIndex,
        int skippedСount)
    {
        var j = 0;
        for (var i = 0; i < original.Count; i++)
        {
            if (i == skipFromIndex)
            {
                i += skippedСount - 1;
                continue;
            }

            result[j] = original[i];
            j++;
        }
    }

    public static void TakeNonAlloc(
        this List<Tile> original,
        Tile[] result,
        int[] skipedIndexs)
    {
        var k = 0;
        var j = 0;
        for (var i = 0; i < original.Count; i++)
        {
            if (i == skipedIndexs[k])
            {
                k++;
                continue;
            }

            result[j] = original[i];
            j++;
        }
    }
}