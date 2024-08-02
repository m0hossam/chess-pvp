using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public static class BitboardHelper
    {
        public static bool GetBit(ulong bitboard, int index)
        {
            return (bitboard & ((ulong)1 << index)) != 0;
        }

        public static void SetBit(ref ulong bitboard, int index)
        {
            bitboard |= ((ulong)1 << index);
        }

        public static void ClearBit(ref ulong bitboard, int index)
        {
            bitboard &= ~((ulong)1 << index);
        }

        public static int GetBitIndex(int rank, int file)
        {
            return file + 8 * rank;
        }
    }
}
