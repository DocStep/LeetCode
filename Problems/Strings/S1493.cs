/// 1493. Longest Subarray of 1's After Deleting One Element

public class S1493 {
    public void Test () {
        int[] nums;
        //nums = new int[] { 1, 1, 0, 1 };
        //nums = new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 };
        nums = new int[] { 1, 1, 1 };


        LongestSubarray(nums);
    }


    public int LongestSubarray (int[] nums) {
        if (nums.Length == 0) return 0;

        int max = 0;
        int part1 = 0;
        int part2 = 0;
        bool gotZero = false;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 1) {
                part2++;
                if (max < part1 + part2) max = part1 + part2;
            } else {
                part1 = part2;
                part2 = 0;
                gotZero = true;
            }
        }
        if (!gotZero) max--;

        return max;
    }

}
