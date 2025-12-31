/// 125. Valid Palindrome

public class S125 {
    public void Test () {

    }

    public bool IsPalindrome (string s) {
        char[] arr = Array.FindAll<char>(s.ToLower().ToCharArray(), c => char.IsLetterOrDigit(c));
        for (int i = 0; i < arr.Length/2; i++) if (arr[i] != arr[arr.Length-1-i]) return false;
        return true;
    }

}
