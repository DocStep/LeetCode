/// 20. Valid Parentheses

public class S20 {
    public void Test () {

    }

    public bool IsValid (string s) {
        if (s.Length % 2 == 1) return false;
        string[] par = new string[] { "()", "{}", "[]" };
        Stack<int> cons = new Stack<int>();

        bool open;
        bool ok = true;
        for (int i = 0; i < s.Length; i++) {
            open = false;
            for (int f = 0; f < par.Length; f++) {
                if (s[i] == par[f][0]) {
                    open = true;
                    cons.Push(f);
                    break;
                }
            }

            if (!open) {
                if (cons.Count > 0) {
                    if (s[i] == par[cons.Peek()][1]) {
                        cons.Pop();
                    } else {
                        ok = false;
                        break;
                    }
                } else return false;
            }
        }

        return cons.Count == 0 && ok;
    }

}
