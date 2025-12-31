/// 931. Minimum Falling Path Sum

public class M931 {
    public void Test () {
        int[][] matrix;
        matrix = new int[][] { 
            new int[3] { 2, 1, 3 }, 
            new int[3] { 6, 5, 4 }, 
            new int[3] { 7, 8, 9 } };
        //matrix = new int[][] { 
        //    new int[4] { 2, 1, 3, 6 }, 
        //    new int[4] { 6, 5, 4, 7 }, 
        //    new int[4] { 7, 8, 9, 9 }, 
        //    new int[4] { 4, 3, 2, 1 } };

        MinFallingPathSum(matrix);
    }


    public int MinFallingPathSum (int[][] matrix) {
        if (matrix.Length == 0) return 0;
        if (matrix.Length == 1) return matrix[0][0];

        int[] paths = new int[matrix[0].Length];
        int[] _paths = new int[matrix[0].Length];
        int n = matrix.Length-1;
        int t;
        int l;
        int r;
        for (int i = n; 0 <= i; i--) {
            paths[0] = matrix[i][0] + (_paths[0] < _paths[1] ? _paths[0] : _paths[1]);

            for (int f = 1; f < n; f++) {
                t = _paths[f];
                l = _paths[f-1];
                r = _paths[f+1];
                if (l < t) t = l;
                if (r < t) t = r;
                paths[f] = matrix[i][f] + t;
            }

            l = _paths[n-1];
            r = _paths[n];
            paths[n] = matrix[i][n] + (l < r ? l : r);

            Array.Copy(paths, _paths, paths.Length);
        }

        return paths.Min();
    }

}
