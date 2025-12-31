/// 703. Kth Largest Element in a Stream

public class M703 {
    public void Test () {
        //KthLargest kth = new KthLargest(3, new int[] { 4, 5, 8, 2 });
        KthLargest kth = new KthLargest(3, new int[] { });
        kth.Add(3);
        kth.Add(5);
        kth.Add(10);
        kth.Add(9);
        kth.Add(4);

        Console.WriteLine($"{1}");
    }


    public class KthLargest {
        public KthLargest (int k, int[] nums) {
            this.k = k;
            numsSorted = nums.ToList();
            numsSorted.Sort();
        }

        List<int> numsSorted;
        int k;

        public int Add (int val) {
            if (numsSorted.Count == 0) {
                numsSorted.Add(val);
                return val;
            }

            bool added = false;
            for (int i = 0; i < numsSorted.Count; i++) {
                if (val < numsSorted[i]) {
                    added = true;
                    numsSorted.Insert(i, val);
                    break;
                }
            }
            if (!added) numsSorted.Add(val);
            return numsSorted[numsSorted.Count-k];
        }
    }

}
