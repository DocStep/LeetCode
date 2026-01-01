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
            Console.WriteLine(digits[l]);
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
        if (add) digits = Prepend(digits, 1);
        return digits;

        int[] Prepend (int[] arr, int value) {
            int[] result = new int[arr.Length + 1];
            result[0] = value;
            Array.Copy(arr, 0, result, 1, arr.Length);
            return result;
        }
    }

}
