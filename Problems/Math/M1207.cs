namespace P1207;

/// 1207. Unique Number of Occurrences
public class M1207 {
    public void Test () {
        int[] arr = new int[] { 1, 2, 2, 1, 1, 3 };
        UniqueOccurrences(arr);
    }

    public bool UniqueOccurrences (int[] arr) {
        Dictionary<int, int> nums = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++) {
            if (nums.ContainsKey(arr[i])) nums[arr[i]]++;
            else nums.Add(arr[i], 1);
        }

        return nums.Count == new HashSet<int>(nums.Values).Count;
    }

}
