/// 380. Insert Delete GetRandom O(1)

public class M380 {
    public void Test () {
        int val = 1;

        RandomizedSet obj = new RandomizedSet();
        bool param_1 = obj.Insert(val);
        bool param_2 = obj.Remove(val);
        int param_3 = obj.GetRandom();
    }

    public class RandomizedSet {
        HashSet<int> set = new HashSet<int>();

        public bool Insert (int val) {
            if (set.Contains(val) || set.Count == int.MaxValue) return false;
            set.Add(val);
            return true;
        }

        public bool Remove (int val) {
            if (set.Contains(val)) set.Remove(val);
            else return false;
            return true;
        }

        public int GetRandom () {
            if (0 < set.Count) return set.ElementAt(new Random().Next(set.Count));
            return 0;
        }

    }

}
