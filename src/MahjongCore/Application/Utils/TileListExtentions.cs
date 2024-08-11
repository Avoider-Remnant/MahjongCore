using MahjongCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongCore.Application.Utils
{
    public static class TileListExtentions
    {
        public static void TakeNonAlloc(this List<Tile> original, List<Tile> result, int skipFromIndex, int skippedcount)
        {
            result.Clear();
            for (int i = 0; i < original.Count && j < result.Count; i++)
            {
                if (i == skipFromIndex)
                {
                    i += skippedcount - 1;
                    continue;
                }
                result.Add(original[i]);
            }
        }

        public static void TakeNonAlloc(this List<Tile> original, List<Tile> result, int[] skipedIndexs)
        {
            int k = 0;
            result.Clear();
            for (int i = 0; i < original.Count && j < result.Count; i++)
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
}
