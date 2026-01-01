/// . 

public class M66 {
    public void Test () {
        int[] digits;

        switch (1) {
            case 0:
                digits = [1, 2, 3];
                break;
            case 1:
                digits = [9];
                break;
        }

        digits = PlusOne(digits);

        for (int l = 0; l < digits.Length; l++)
            Console.Write(digits[l]);
    }


    public int[] PlusOne (int[] digits) {
        int length = digits.Length;
        bool add = true;
        for (int i = length-1; 0 <= i; i--) {
            if (!add) break;
            if (digits[i] == 9) {
                digits[i] = 0;
            } else {
                digits[i]++;
                add = false;
            }
        }
        if (add) {
            int[] result = new int[digits.Length + 1];
            result[0] = 1;
            Array.Copy(digits, 0, result, 1, length);
            digits = result;
        }
        return digits;
    }

}
