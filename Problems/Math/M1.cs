/// 1. Two Sum

public class M1 {
    public void Test () {

    }

    public int[] TwoSum (int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            for (int f = i+1; f < nums.Length; f++) {
                if (nums[i] + nums[f] == target) {
                    return new int[] { i, f };
                }
            }
        }
        return null;
    }

}