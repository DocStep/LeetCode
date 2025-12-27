namespace P54;

/// 54. Spiral Matrix
public class M54 {
    public void Test () {
        int[][] matrix = new int[][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 } };

        switch (0) {
            case 0:
                matrix = new int[][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 } };
                break;
            case 1:
                matrix = new int[][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 } };
                break;
        }

        SpiralOrder(matrix);
    }


    public IList<int> SpiralOrder (int[][] matrix) {
        int len = matrix.Length*matrix[0].Length;
        int ai = 0;

        IList<int> arr = new int[len];

        int f0 = 0, ff = matrix[0].Length-1;
        int i0 = 0, ii = matrix.Length-1;
        while (ai < len) {
            for (int f = f0; f <= ff; f++) {
                if (ai == len) break;
                arr[ai++] = matrix[i0][f];
            }
            i0++;
            for (int i = i0; i <= ii; i++) {
                if (ai == len) break;
                arr[ai++] = matrix[i][ff];
            }
            ff--;
            for (int f = ff; f0 <= f; f--) {
                if (ai == len) break;
                arr[ai++] = matrix[ii][f];
            }
            ii--;
            for (int i = ii; i0 <= i; i--) {
                if (ai == len) break;
                arr[ai++] = matrix[i][f0];
            }
            f0++;
        }

        return arr;
    }

}
