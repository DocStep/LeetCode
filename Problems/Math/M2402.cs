namespace P2402;

/// 2402. Meeting Rooms III
public class M2402 {
    public void Test () {
        int n;
        int[][] meetings;


        switch (2) {
            case 2:
                n = 2;
                meetings = [[0, 10], [1, 5], [2, 7], [3, 4]];
                break;
            case 21:
                n = 2;
                meetings = [[0, 10], [1, 5], [2, 7], [3, 4], [8, 11], [9, 12]];
                break;
            case 22:
                n = 2;
                meetings = [[0, 10], [1, 5], [2, 7], [3, 4]];
                break;
            case 23:
                n = 2;
                meetings = [[0, 10], [1, 2], [12, 14], [13, 15]];
                break;
            case 24:
                n = 2;
                meetings = [[0, 10], [1, 2], [12, 14], [15, 16]];
                break;

            case 3:
                n = 3;
                //meetings = [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]];
                meetings = [[0, 10], [1, 9], [2, 8], [3, 7], [4, 6]];
                break;
            case 31:
                n = 3;
                meetings = [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]];
                break;
            case 32:
                n = 3;
                meetings = [[39, 49], [28, 39], [9, 29], [10, 36], [22, 47], [2, 3], [4, 49], [46, 50], [45, 50], [17, 33]];
                meetings = [[2, 3], [4, 49], [9, 29], [10, 36], [17, 33], [22, 47], [28, 39], [39, 49], [45, 50], [46, 50]];
                break;

            case 4:
                n = 4;
                meetings = [[18, 19], [3, 12], [17, 19], [2, 13], [7, 10]];
                break;
            case 41:
                n = 4;
                meetings = [[19, 20], [14, 15], [13, 14], [11, 20]];
                break;
            case 10:
                n = 10;
                meetings = [[1, 300001],[2, 300002],[3, 300003],[4, 300004],[5, 300005],[6, 300006],[7, 300007],[8, 300008],[9, 300009],[10, 300010],[11, 300011],[12, 300012],[13, 300013],[14, 300014],[15, 300015],[16, 300016],[17, 300017],[18, 300018],[19, 300019],[20, 300020],[21, 300021],[22, 300022],[23, 300023],[24, 300024],[25, 300025],[26, 300026],[27, 300027],[28, 300028],[29, 300029],[30, 300030],[31, 300031],[32, 300032],[33, 300033],[34, 300034],[35, 300035],[36, 300036]];
                break;

            case 102:
                n = 10;
                meetings = [[1,300001],[2,300002],[3,300003],[4,300004],[5,300005],[6,300006],[7,300007],[8,300008],[9,300009],[10,300010],[11,300011],[12,300012],[13,300013],[14,300014],[15,300015],[16,300016],[17,300017],[18,300018],[19,300019],[20,300020],[21,300021],[22,300022],[23,300023],[24,300024],[25,300025],[26,300026],[27,300027],[28,300028],[29,300029],[30,300030],[31,300031],[32,300032],[33,300033],[34,300034],[35,300035],[36,300036],[37,300037],[38,300038],[39,300039],[40,300040],[41,300041],[42,300042],[43,300043],[44,300044],[45,300045],[46,300046],[47,300047],[48,300048],[49,300049],[50,300050],
                [80002, 80003], [80003, 80004], [80004, 80005], [80005, 80006], [80006, 80007], [80007, 80008], [80008, 80009], [80009, 80010], [80010, 80011], [80011, 80012]];
                break;
				
        }



        int value = MostBooked(n, meetings);
        //int value = 1;

        Console.WriteLine(value);
    }


    public int MostBooked (int n, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        long[] roomsBusyTime = new long[n];
        int[] roomsCounts = new int[n];

        /// Check All Meetings
        int meetingsCount = meetings.GetLength(0);
        for (int m = 0; m < meetingsCount; m++) {
            int[] meeting = meetings[m];
            long minStart = long.MaxValue;
            int minR = 0;

            /// Check All Rooms
            for (int rL = 0; rL < n; rL++) {
                long meetingStartClipped = Math.Max(meeting[0], roomsBusyTime[rL]);
                if (meetingStartClipped < minStart) {
                    minStart = meetingStartClipped;
                    minR = rL;
                }
            }

            roomsBusyTime[minR] = Math.Max(meeting[0], minStart) + meeting[1] - meeting[0];
            roomsCounts[minR]++;
        }

        int max = 0;
        int maxR = 0;
        for (int r = 0; r < n; r++) {
            if (max < roomsCounts[r]) {
                max = roomsCounts[r];
                maxR = r;
            }
        }

        return maxR;
    }

}
