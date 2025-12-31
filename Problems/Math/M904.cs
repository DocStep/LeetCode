/// 904. Fruit Into Baskets

public class M904 {
    public void Test () {
        int[] fruits;

        switch (6) {
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
            case 4:
                fruits = [1, 0, 1, 4, 1, 4, 1, 2, 3];
                break;
            case 5:
                fruits = [1, 1];
                break;
            case 6:
                fruits = [1, 0, 1, 4, 1, 4, 1, 2, 3];
                break;
        }


        int val = TotalFruit(fruits);

        Console.WriteLine(val);
    }


    public int TotalFruit (int[] fruits) {
        int fruitsCount = fruits.Length;
        int max = 1;
        int id0 = -1, count0 = 0;
        int id1 = fruits[0], count1 = 1;
        int raw = 1;

        for (int i = 1; i < fruitsCount; i++) {
            int id = fruits[i];
            if (id == id0 || id == id1) {
                /// Repeat
                if (id == id0) {
                    int t = id1;
                    id1 = id0;
                    id0 = t;
                    t = count1;
                    count1 = count0;
                    count0 = t;
                    raw = 1;
                } else raw++;
                count1++;
            } else {
                /// New Type
                id0 = id1;
                count0 = raw;
                id1 = id;
                count1 = 1;
                raw = 1;
            }

            //Console.WriteLine($"{i,2}) {id}: {id0}-{count0} {id1}-{count1}");
            int sum = count0 + count1;
            if (max < sum) max = sum;
        }
        return max;
    }

}
