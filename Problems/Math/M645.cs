/// 645. Set Mismatch

public class M645 {
    public void Test () {
        int[] nums = new int[] { 1, 2, 2, 4 };

        FindErrorNums(nums);
    }


    public int[] FindErrorNums (int[] nums) {
        HashSet<int> set = new HashSet<int>();
        int lost = 0;
        int rep = 0;
        for (int i = 0; i < nums.Length; i++)
            if (set.Contains(nums[i])) rep = nums[i];
            else set.Add(nums[i]);

        for (int i = 1; i <= nums.Length; i++)
            if (!set.Contains(i)) {
                lost = i;
                break;
            }

        return new int[] { rep, lost };
    }

}
