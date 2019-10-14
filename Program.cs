using System;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            SpreadSheet spreadSheet = new SpreadSheet(4, 3);
            spreadSheet.Update(0, 1, "bob");
            spreadSheet.Update(0, 2, "a");
            spreadSheet.Update(2, 1, "b");
            spreadSheet.Update(3, 0, "3242");
            spreadSheet.Print();
            Console.Read();
        }
    }

    class SpreadSheet
    {
        int RowCount;
        int ColCount;
        string[,] Cells;
        int[] MaxColCount;
        public SpreadSheet(int row, int col)
        {
            RowCount = row;
            ColCount = col;
            Cells = new string[row, col];
            MaxColCount = new int[col];
        }

        public void Update(int row, int col, string value)
        {
            this.Cells[row, col] = value;
            MaxColCount[col] = Math.Max(MaxColCount[col], value.Length);
        }

        public void Print()
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int col = 0; col < ColCount; col++)
                {
                    PrintValueWithMaxColCount(row, col);
                    if (col != ColCount - 1)
                        Console.Write("|");
                }
                Console.Write("\n");
            }
        }

        private void PrintValueWithMaxColCount(int row, int col)
        {
            Console.Write(Cells[row, col]);
            int spaceCount = MaxColCount[col] - (Cells[row, col] == null ? 0 : Cells[row, col].Length);
            while(spaceCount-- > 0)
                Console.Write(" ");
        }
    }
}
