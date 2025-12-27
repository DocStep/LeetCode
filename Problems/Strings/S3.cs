namespace P3;

/// 3. Longest Substring Without Repeating Characters
public class S3 {
    public void Test () {
        this.s = "pwwkew";
        if (s.Length <= 1) { Console.WriteLine(s.Length); return; }

        for (int i = 0; i < s.Length-1; i++) Check(s[i].ToString(), i+1);

        Console.WriteLine(max);
    }

    string s;
    int max = 0;

    void Check (string str, int newi) {
        Console.WriteLine($"{str,-6} {newi,2} {max}");

        if (!str.Contains(s[newi])) {
            str += s[newi];
            if (max < str.Length) max = str.Length;
            if (newi+1 < s.Length) Check(str, newi+1);
        }
    }
}