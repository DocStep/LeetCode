namespace P576;

/// 576. Out of Boundary Paths
public class _M576 {
    public void Test () {
        int m;
        int n;
        int maxMove;
        int startRow;
        int startColumn;

        switch (1) {
            case 0:
                m = 2;
                n = 2;
                maxMove = 2;
                startRow = 0;
                startColumn = 0;
                break;
            case 1:
                m = 8;
                n = 50;
                maxMove = 23;
                startRow = 5;
                startColumn = 26;
                break;
        }

        this.m = m;
        this.n = n;
        this.maxMove = maxMove;
        this.startRow = startRow;
        this.startColumn = startColumn;

        int res = GoCell(startRow, startColumn, maxMove);

        Console.WriteLine($"{res}");

    }

    int m;
    int n;
    int maxMove;
    int startRow;
    int startColumn;

    int GoCell (int row, int column, int step) {
        if (row < 0 || m <= row || column < 0 || n <= column) return 1;
        if (step <= Math.Min(row, startRow-row) || step <= Math.Min(row, startColumn-column)) return 0;

        int res = 0;
        if (0 < step) {
            Console.WriteLine($"{row,2} {column,2}  {step,2}");
            //if (row-1 < 0) Console.WriteLine($"{row-1,2} {column,2}");
            //if (m <= row+1) Console.WriteLine($"{row+1,2} {column,2}");
            //if (column-1 < 0) Console.WriteLine($"{row,2} {column-1,2}");
            //if (m <= column+1) Console.WriteLine($"{row,2} {column+1,2}");
            step--;
            res += GoCell(row-1, column, step);
            res += GoCell(row+1, column, step);
            res += GoCell(row, column-1, step);
            res += GoCell(row, column+1, step);

            //if (0 <= row-1) res += GoCell(row-1, column, step+1);
            //else res++;
            //if (row+1 < m) res += GoCell(row+1, column, step+1);
            //else res++;
            //if (0 <= column-1) res += GoCell(row, column-1, step+1);
            //else res++;
            //if (column+1 < n) res += GoCell(row, column+1, step+1);
            //else res++;
        }
        return res;
    }

}
