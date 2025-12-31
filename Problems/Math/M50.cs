/// 50. Pow(x, n)

public class M50 {
    public double Test () {
        double x = 2.00000;
        int n = -2147483648;
        if (x == 1) return x;
        if (n == 0) return 1;

        double m = 1d;

        if (0 < n) for (int i = -n; i < 0; i++) m *= x;
        else for (int i = n; i < 0; i++) m /= x;

        return MyPow(x, n);
    }

    public double MyPow (double x, int n) {
        return Math.Pow(x, n);
    }

}
