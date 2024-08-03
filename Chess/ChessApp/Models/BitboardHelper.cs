using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public static class BitboardHelper
    {
        public static int GetBit(ulong bitboard, int index)
        {
            return (bitboard & ((ulong)1 << index)) != 0 ? 1 : 0;
        }

        public static int GetBit(ulong bitboard, int rank, int file)
        {
            int index = GetBitIndex(rank, file);
            return (bitboard & ((ulong)1 << index)) != 0 ? 1 : 0;
        }

        public static void SetBit(ref ulong bitboard, int index)
        {
            bitboard |= ((ulong)1 << index);
        }

        public static void SetBit(ref ulong bitboard, int rank, int file)
        {
            int index = GetBitIndex(rank, file);
            bitboard |= ((ulong)1 << index);
        }

        public static void ClearBit(ref ulong bitboard, int index)
        {
            bitboard &= ~((ulong)1 << index);
        }

        public static void ClearBit(ref ulong bitboard, int rank, int file)
        {
            int index = GetBitIndex(rank, file);
            bitboard &= ~((ulong)1 << index);
        }

        public static int GetBitIndex(int rank, int file)
        {
            return file + 8 * rank;
        }
    }
}
