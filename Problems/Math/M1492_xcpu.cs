namespace P1492;

/// 1492. The kth Factor of n
public class M1492_xcpu {
    public void Test () {
        int n = 12;
        int k = 3;

        KthFactor(n, k);
    }


    public int KthFactor (int n, int k) {
        if (n < k) return -1;

        List<int> f = new List<int>() { 1 };
        if (2 < n) for (int i = 2; i <= n/2; i++) if (n % i == 0) f.Add(i);
        f.Add(n);

        if (f.Count < k) return -1;
        return f[k-1];
    }

}