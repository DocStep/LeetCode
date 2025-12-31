/// 121. Best Time to Buy and Sell Stock

public class M121 {
    public void Test () {

    }


    public int MaxProfit (int[] prices) {
        int min = prices[0];
        int max = prices[0];
        int newmin = prices[0];
        int newmax = prices[0];

        for (int i = 1; i < prices.Length; i++) {
            if (prices[i] < newmin) {
                newmin = prices[i];
                newmax = newmin;
            } else if (newmax < prices[i]) {
                newmax = prices[i];
                if (max-min < newmax-newmin) {
                    max = newmax;
                    min = newmin;
                }
            }
        }

        return max-min;
    }

}
