namespace P1657;

/// 1657. Determine if Two Strings Are Close
public class S1657 {
    public void Test () {
        string word1 = "aaabbbbccddeeeeefffff"; // a3 b4 c2 d2 e5 f5  2 2 3 4 5 5
        string word2 = "aaaaabbcccdddeeeeffff"; // a5 b2 c3 d3 e4 f4  2 3 3 4 4 5
        
        CloseStrings(word1, word2);
    }


    public bool CloseStrings (string word1, string word2) {
        if (word1.Length != word2.Length) return false;

        Dictionary<char, int> dict1 = new Dictionary<char, int>();
        Dictionary<char, int> dict2 = new Dictionary<char, int>();

        for (int i = 0; i < word1.Length; i++) {
            if (dict1.ContainsKey(word1[i])) dict1[word1[i]]++;
            else dict1.Add(word1[i], 1);
            if (dict2.ContainsKey(word2[i])) dict2[word2[i]]++;
            else dict2.Add(word2[i], 1);
        }

        return CheckK(dict1.Keys.ToList(), dict2.Keys.ToList()) &&
            CheckV(dict1.Values.ToList(), dict2.Values.ToList());

        bool CheckK (List<char> set1, List<char> set2) {
            if (set1.Count != set2.Count) return false;

            for (int i = 0; i < set1.Count; i++)
                if (set2.Contains(set1[i])) set2.Remove(set1[i]);
                else return false;

            if (set2.Count == 0) return true;
            else return false;
        }
        bool CheckV (List<int> set1, List<int> set2) {
            if (set1.Count != set2.Count) return false;

            for (int i = 0; i < set1.Count; i++)
                if (set2.Contains(set1[i])) set2.Remove(set1[i]);
                else return false;

            if (set2.Count == 0) return true;
            else return false;
        }
    }

}