namespace P724;

/// 724. Find Pivot Index
public class M724 {
    public void Test () {
        int[] nums = { 1, 7, 3, 6, 5, 6 };

        PivotIndex(nums);
    }


    public int PivotIndex (int[] nums) {
        int left = 0;
        int right = nums.Sum() - nums[0];
        if (left == right) return 0;

        for (int i = 1; i < nums.Length-1; i++) {
            left += nums[i-1];
            right -= nums[i];
            if (left == right) return i;
        }

        left += nums[nums.Length-2];
        right -= nums[nums.Length-1];
        if (left == right) return nums.Length-1;

        return -1;
    }

}