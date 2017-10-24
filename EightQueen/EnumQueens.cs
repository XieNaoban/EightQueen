using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueen
{
    class EnumQueens
    {
        private int[] Board;

        public EnumQueens()
        {
            Board = new int[8];
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < 8; ++i)
            {
                Board[i] = i;
            }
        }

        public bool Next()
        {
            for (int i = Board.Length - 1; i > 0; --i)
            { 
                if (Board[i] > Board[i - 1])
                {
                    int val = Board[i - 1];
                    int j = Board.Length - 1;
                    for (; j >= i; --j)
                    {
                        if (Board[j] > val)
                            break;
                    }
                    SwapBoard(i - 1, j);
                    int l = i;
                    int r = Board.Length - 1;
                    while (l < r)
                    {
                        SwapBoard(l, r);
                        l++;
                        r--;
                    }
                    return true;
                }
            }
            Reset();
            return false;
        }

        public Point Check()
        {
            Point ans = new Point();
            for (int i = 0; i < Board.Length; ++i)
            {
                for (int j = i + 1; j < Board.Length; ++j)
                {
                    if (Math.Abs(i - j) == Math.Abs(Board[i] - Board[j]))
                    {
                        ans.X = i;ans.Y = j;
                        return ans;
                    }
                }
            }
            ans.X = -1; ans.Y = -1;
            return ans;
        }

        public int Get(int i)
        {
            return Board[i];
        } 

        private void SwapBoard(int i, int j)
        {
            int t = Board[i];
            Board[i] = Board[j];
            Board[j] = t;
        }
    }
}
