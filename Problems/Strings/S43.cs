/// 43. Multiply Strings

public class S43 {
    public void Test () {
        string num1 = "65539";
        string num2 = "83314";
        string result = Multiply (num1, num2);
        Console.WriteLine(result);
    }


    public string Multiply (string num1, string num2) {
        if (num1 == "0" || num2 == "0") return "0";

        string result = "";

        int l1 = num1.Length;
        int l2 = num2.Length;

        if (l1 < l2) {
            string t = num1;
            num1 = num2;
            num2 = t;
            l1 = num1.Length;
            l2 = num2.Length;
        }

        int n1;
        int n2;
        int n3;
        int add = 0;
        string sub = "";

        for (int i2 = l2-1; 0 <= i2; i2--) {
            sub = "";
            add = 0;
            for (int i1 = l1-1; 0 <= i1; i1--) {
                n1 = num1[i1] - '0';
                n2 = num2[i2] - '0';
                n3 = n1*n2;
                if (0 < add) n3 += add;
                sub = Convert.ToString(n3%10) + sub;
                add = n3/10;
            }
            if (0 < add) sub = Convert.ToString(add) + sub;

            result = Add(result, sub, l2-1-i2);
        }

        return result;

        string Add (string num1, string num2, int pos) {
            if (num1 == "") return num2;

            int l1 = num1.Length;
            int l2 = num2.Length;
            int n = 0;

            int n1;
            int n2;
            int add = 0;
            string result = num1.Substring(l1-pos, pos);
            for (int i = 0; i < l2; i++) {
                if (0 <= l1-1-(pos+i)) {
                    n1 = num1[l1-1-(pos+i)] - '0';
                    n2 = num2[l2-1-i] - '0';
                    n = n1+n2;
                    if (0 < add) n += add;
                    result = (n%10).ToString() + result;
                    add = n/10;
                } else {
                    result = AddSimple(num2.Substring(0, l2-i), add) + result;
                    add = 0;

                    Console.WriteLine($"f(result){result}");
                    return result;
                }
            }
            if (0 < add) result = add.ToString() + result;

            return result;
        }

        string AddSimple (string num1, int n2) {
            if (n2 == 0) return num1;

            int l1 = num1.Length;
            int n12 = 0;

            int n1;
            int add = 0;
            string result = "";
            for (int i = l1-1; 0 <= i; i--) {
                n1 = num1[i] - '0';
                n12 = n1+n2;
                if (0 < add) n12 += add;
                result = (n12%10).ToString() + result;
                n2 = n2/10;
                add = n12/10;
            }
            if (0 < add) result = add.ToString() + result;

            return result;
        }
    }

}
