namespace P1347;

/// 1347. Minimum Number of Steps to Make Two Strings Anagram
public class S1347 {
    public void Test () {
        string s = "leetcode"; /// etc leeod
        string t = "practice"; /// etc praic

        MinSteps(s, t);
    }


    public int MinSteps (string s, string t) {
        Dictionary<char, int> dict1 = new Dictionary<char, int>();
        Dictionary<char, int> dict2 = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++) {
            if (dict1.ContainsKey(s[i])) dict1[s[i]]++;
            else dict1.Add(s[i], 1);
            if (dict2.ContainsKey(t[i])) dict2[t[i]]++;
            else dict2.Add(t[i], 1);
        }

        int inter = 0;
        for (int i = 0; i < dict1.Count; i++) {
            char c = dict1.ElementAt(i).Key;
            if (dict2.ContainsKey(c)) inter += Math.Min(dict1[c], dict2[c]);
        }

        return s.Length - inter;
    }

}