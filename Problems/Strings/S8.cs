namespace P8;

/// 8. String to Integer (atoi)
public class S8 {
    public void Test () {
        string s = "+-42";

        MyAtoi(s);
    }

    public int MyAtoi (string s) {
        string nums = "0123456789";
        string ss = "";
        bool start = false;
        for (int i = 0; i < s.Length; i++) {
            if (start) {
                if (nums.Contains(s[i])) ss += s[i];
                else break;
            } else {
                Console.WriteLine($"i1");
                if (nums.Contains(s[i]) || s[i] == '+' || s[i] == '-' || s[i] == ' ') {
                    if (s[i] == ' ') continue;
                    start = true;
                    ss += s[i];
                } else break;
            }
        }

        if (ss == "+" || ss == "-") return 0;
        if (0 < ss.Length) return (int)Math.Clamp(Convert.ToDouble(ss), -Math.Pow(2, 31), Math.Pow(2, 31)-1);
        else return 0;
    }

}