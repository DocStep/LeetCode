/// 2405. Optimal Partition of String

public class S2405 {
    public void Test () {
        string s = "abacaba";

        PartitionString(s);
    }


    public int PartitionString (string s) {
        if (s.Length == 0) return 0;

        string subs = s[0].ToString();
        int count = 1;
        for (int i = 1; i < s.Length; i++)
            if (subs.Contains(s[i])) {
                subs = s[i].ToString();
                count++;
            } else subs += s[i];

        return count;
    }

}