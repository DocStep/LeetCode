/// 1704. Determine if String Halves Are Alike

public class S1704 {
    public void Test () {
        string s = "01234";

        // 1 2 3 4 5  6
        // 0 1 2 3 4  5
        // l/2 2 
        // 

        // 1 2 3 4  5
        // 0 1 2 3  4
        // l/2 2
        //

        HalvesAreAlike(s);
    }

    public readonly char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    public bool HalvesAreAlike (string s) {
        int l = s.Length-1;
        int count = 0;
        for (int i = 0; i < s.Length/2; i++) {
            if (vowels.Contains(s[i])) count++;
            if (vowels.Contains(s[l-i])) count--;
        }

        return count == 0;
    }

}