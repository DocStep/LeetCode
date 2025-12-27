namespace P849;

/// 849. Maximize Distance to Closest Person
public class M849 {
    public void Test () {
        int[] seats;
        seats = new int[] { 1, 0, 0, 0, 1, 0, 1 };
        seats = new int[] { 0, 0, 0, 1, 1, 0, 1 };
        seats = new int[] { 1, 0, 1 };
        seats = new int[] { 1, 0, 1, 0, 0, 1 };

        MaxDistToClosest(seats);
    }


    public int MaxDistToClosest (int[] seats) {
        bool onEdge = seats[0] == 0;
        int max = 0;
        int row = 0;

        for (int i = 0; i < seats.Length; i++)
            if (seats[i] == 0) row++;
            else {
                if (onEdge) {
                    if (max < row-1) max = row-1;
                    onEdge = false;
                } else if (max < (row-1)/2) max = (row-1)/2;
                row = 0;
            }

        if (seats[seats.Length-1] == 0) {
            if (max < row-1) max = row-1;
        } else if (max < (row-1)/2) max = (row-1)/2;

        return max+1;
    }

}
