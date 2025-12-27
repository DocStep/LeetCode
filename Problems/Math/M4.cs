namespace P4;

/// 4. Median of Two Sorted Arrays
public class M4 {
    public void Test () {

    }

    public double FindMedianSortedArrays (int[] nums1, int[] nums2) {
        int n = nums1.Length + nums2.Length;
        int[] arr = new int[n];

        int last1 = 0, last2 = 0;
        int i = 0;
        while (i < n) {
            if (last1 < nums1.Length && last2 < nums2.Length) {
                if (nums1[last1] < nums2[last2]) {
                    arr[i] = nums1[last1];
                    last1++;
                } else {
                    arr[i] = nums2[last2];
                    last2++;
                }
            } else {
                if (last1 < nums1.Length) {
                    arr[i] = nums1[last1];
                    last1++;
                }
                if (last2 < nums2.Length) {
                    arr[i] = nums2[last2];
                    last2++;
                }
            }
            i++;
        }

        return arr.Length % 2 == 0 ? (arr[arr.Length/2-1] + arr[arr.Length/2])/2d : arr[arr.Length/2];
    }
}
