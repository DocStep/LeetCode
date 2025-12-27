namespace P2225;

/// 2225. Find Players With Zero or One Losses
public class M2225 {
    public void Test () {
        int[][] matches;
        switch (0) {
            case 0:
                // [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
                matches = new int[10][];
                matches[0] = new int[2] { 1, 3 };
                matches[1] = new int[2] { 2, 3 };
                matches[2] = new int[2] { 3, 6 };
                matches[3] = new int[2] { 5, 6 };
                matches[4] = new int[2] { 5, 7 };
                matches[5] = new int[2] { 4, 5 };
                matches[6] = new int[2] { 4, 8 };
                matches[7] = new int[2] { 4, 9 };
                matches[8] = new int[2] { 10, 4 };
                matches[9] = new int[2] { 10, 9 };
                // [[1,2,10],[4,5,7,8]]
                break;
            case 1:
                // [[2,3],[1,3],[5,4],[6,4]]
                matches = new int[4][];
                matches[0] = new int[2] { 2, 3 };
                matches[1] = new int[2] { 1, 3 };
                matches[2] = new int[2] { 5, 4 };
                matches[3] = new int[2] { 6, 4 };
                // [[1,2,5,6],[]]
                break;
            case 2:
                //[[1,2],[2,1],[1,3],[3,1],[2,3],[3,2]]
                matches = new int[6][];
                matches[0] = new int[2] { 1, 2 };
                // 1  2   0
                matches[1] = new int[2] { 2, 1 };
                // 0  12  0
                matches[2] = new int[2] { 1, 3 };
                // 0  123 0
                matches[3] = new int[2] { 3, 1 };
                // 0  23  1
                matches[4] = new int[2] { 2, 3 };
                // 0  2   13
                matches[5] = new int[2] { 3, 2 };
                // 0  0   123
                // [[],[]]
                break;
        }

        FindWinners(matches);

    }


    public IList<IList<int>> FindWinners (int[][] matches) {
        HashSet<int> players0 = new HashSet<int>();
        HashSet<int> players1 = new HashSet<int>();
        HashSet<int> players2 = new HashSet<int>();

        for (int i = 0; i < matches.Length; i++) {
            if (!players0.Contains(matches[i][0]) && !players1.Contains(matches[i][0]) &&
                !players2.Contains(matches[i][0])) {
                players0.Add(matches[i][0]);
            }

            if (!players2.Contains(matches[i][1])) {
                if (players1.Contains(matches[i][1])) {
                    players1.Remove(matches[i][1]);
                    players2.Add(matches[i][1]);
                } else if (players0.Contains(matches[i][1])) {
                    players0.Remove(matches[i][1]);
                    players1.Add(matches[i][1]);
                } else players1.Add(matches[i][1]);
            }

            //Console.Write($"\nLose0 ");
            //for (int k = 0; k < players0.Count; k++) Console.Write($" {players0.ElementAt(k),2}");
            //Console.Write($"\nLose1 ");
            //for (int k = 0; k < players1.Count; k++) Console.Write($" {players1.ElementAt(k),2}");
            //Console.Write($"\nLose2 ");
            //for (int k = 0; k < players2.Count; k++) Console.Write($" {players2.ElementAt(k),2}");
            //Console.WriteLine("\n");
        }

        return new List<int>[] { new SortedSet<int>(players0).ToList(), new SortedSet<int>(players1).ToList() };
    }

}