/// 904. Fruit Into Baskets

public class _M904 {
    public void Test () {
        int[] fruits;

        switch (3) {
            case 0:
                fruits = [1, 2, 1];
                break;
            case 1:
                fruits = [0, 1, 2, 2];
                break;
            case 2:
                fruits = [1, 2, 3, 2, 2];
                break;
            case 3:
                fruits = [3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4];
                break;
            default:
                break;
        }


        int val = TotalFruit(fruits);

        Console.WriteLine(val);
    }


    public int TotalFruit (int[] fruits) {

        return 0;
    }

}
