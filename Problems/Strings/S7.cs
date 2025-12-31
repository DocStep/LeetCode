/// 7. Reverse Integer

public class S7 {
    public void Test () {
        int x = 123;

        Reverse(x);
    }

    public int Reverse (int x) {
        int sign = x < 0 ? -1 : 1;
        return int.TryParse(x.ToString().Trim('-').Reverse().ToArray(), out x) ? sign*x : 0;
    }

}
