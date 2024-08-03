using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models
{
    public class Square
    {
        public readonly string Name;
        public readonly int Rank;
        public readonly int File;
        public readonly int Index;

        public Square(string name)
        {
            Name = name;
            File = name[0] - 'a';
            Rank = name[0] - '1';
            Index = BitboardHelper.GetIndex(Rank, File);
        }

        public Square(int rank, int file)
        {
            Name = new string(new char[] { (char)(file + 'a'), (char)(rank + '1')}); 
            Rank = rank;
            File = file;
            Index = BitboardHelper.GetIndex(rank, file);
        }

        public Square(int index)
        {
            Index = index;
            Rank = BitboardHelper.GetRank(index);
            File = BitboardHelper.GetFile(index);
            Name = new string(new char[] { (char)(File + 'a'), (char)(Rank + '1') });
        }
    }
}
