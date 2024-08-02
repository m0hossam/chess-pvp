using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public class Board
    {
        public readonly ulong[] AllBitboards;

        public Board()
        {
            AllBitboards = new ulong[12];
        }
    }
}
