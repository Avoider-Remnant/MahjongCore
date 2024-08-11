namespace MahjongCore.Application.Utils;

using Domain.Models;

public static class TileListExtentions
{
    public static void TakeNonAlloc(
        this List<Tile> original,
        List<Tile> result,
        int skipFromIndex,
        int skippedСount)
    {
        result.Clear();
        for (var i = 0; i < original.Count; i++)
        {
            if (i == skipFromIndex)
            {
                i += skippedСount - 1;
                continue;
            }

            result.Add(original[i]);
        }
    }

    public static void TakeNonAlloc(
        this List<Tile> original,
        List<Tile> result,
        int[] skipedIndexs)
    {
        var k = 0;
        result.Clear();
        for (var i = 0; i < original.Count; i++)
        {
            if (i == skipedIndexs[k])
            {
                k++;
                continue;
            }

            result.Add(original[i]);
        }
    }
}