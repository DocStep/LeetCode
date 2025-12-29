namespace P2402;

/// 2402. Meeting Rooms III
public class _M2402 {
    public void Test () {
        int n;
        int[][] meetings;


        switch (0) {
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
        }



        //int value = MostBooked(n, meetings);
        int value = 1;

        Console.WriteLine();
        Console.WriteLine(value);
    }


    public int MostBooked (int n, int[][] meetings) {
        int meetingsCount = meetings.GetLength(0);
        for (int i = 1; i < meetingsCount; i++) {
            for (int m = 0; m < meetingsCount-1; m++) {
                if (meetings[m+1][0] < meetings[m][0]) {
                    int[] t = meetings[m+1];
                    meetings[m+1] = meetings[m];
                    meetings[m] = t;
                }
            }
        }

        List<int[]>[] rooms = new List<int[]>[n];
        for (int r = 0; r < n; r++) rooms[r] = new List<int[]>();
        int[] roomsCount = new int[n];

        for (int m = 0; m < meetingsCount; m++) {
            int[] meeting = meetings[m];
            Console.WriteLine($"Meeting: {meetings[m][0]}-{meetings[m][1]}");
            int length = meetings[m][1] - meetings[m][0];
            int min = int.MaxValue;
            int minR = 0;
            int minRM = 0;
            /// check All Rooms
            for (int rL = 0; rL < n; rL++) {
                //bool found = false;
                if (rooms[rL].Count == 0) {
                    /// empty Room
                    if (meeting[0] < min) {
                        min = meeting[0];
                        minR = rL;
                        minRM = -1;
                    }
                    break;
                }
                if (Math.Max(meeting[0], rooms[rL][rooms[rL].Count-1][1]) < min) {
                    min = Math.Max(meeting[0], rooms[rL][rooms[rL].Count-1][1]);
                    minR = rL;
                    minRM = rooms[rL].Count-1;
                }

                /// check Meetings in Room
                for (int rM = 0; rM < rooms[rL].Count-1; rM++) {
                    int startCheck = Math.Max(meeting[0], rooms[rL][rM][1]);
                    if (rooms[rL][rM+1][0] - rooms[rL][rM][1] < length) continue;
                    for (int h = 0; h < length; h++) {
                        Console.Write($"{rL} {rM} ");
                        if (isMeetingsIntersect(startCheck + h, rooms[rL][rM+1])) break;
                    }
                    if (isMeetingsIntersect(length + rooms[rL][rM+1][0], rooms[rL][rM+1])) {
                        break;
                    } else {
                        if (startCheck < min) {
                            min = startCheck;
                            minR = rL;
                            minRM = rM;
                        }
                    }
                }
            }

            int start = Math.Max(meeting[0], min);
            int end = start + length;
            Console.WriteLine($"Min: ({minR}/{minRM}) {min}");
            if (0 <= minRM) {
                bool left = minRM < rooms[minR].Count && rooms[minR][minRM][1] == start;
                bool right = minRM+1 < rooms[minR].Count && end == rooms[minR][minRM+1][0];
                if (left && right) {
                    rooms[minR][minRM][1] = rooms[minR][minRM+1][1];
                    rooms[minR].RemoveAt(minRM+1);
                } else {
                    if (right) {
                        rooms[minR][minRM][1] = end;
                    } else if (right) {
                        rooms[minR][minRM+1][0] = start;
                    } else {
                        addNew();
                    }
                }
            } else {
                addNew();
            }

            void addNew () {
                int[] meetingAdd = new int[2] { start, end };
                rooms[minR].Add(meetingAdd);
            }
            roomsCount[minR]++;

            Console.WriteLine("Rooms:");
            for (int r = 0; r < n; r++) {
                string s = $"({rooms[r].Count}): ";
                for (int mm = 0; mm < rooms[r].Count; mm++)
                    s += $" {rooms[r][mm][0]}-{rooms[r][mm][1]}";
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }


        int maxR = 0;
        int max = roomsCount[maxR];
        for (int r = 1; r < n; r++) 
            if (max < roomsCount[r]) {
                maxR = r;
                max = roomsCount[r];
            }
        return maxR;

        bool isMeetingsIntersect (int meetingStart, int[] meetingRunning) {
            bool intersect = meetingRunning[0] <= meetingStart && meetingStart < meetingRunning[1];
            if (intersect)
                Console.WriteLine($"checkIntersect {meetingStart} {meetingRunning[0]}-{meetingRunning[1]}");
            else
                Console.WriteLine($"checkOK {meetingStart} {meetingRunning[0]}-{meetingRunning[1]}");
            return intersect;
        }
    }

}
