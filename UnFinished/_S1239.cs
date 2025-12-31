/// 1239. Maximum Length of a Concatenated String with Unique Characters

public class _S1239 {
    public void Test () {
        IList<string> arr;
        //arr = new List<string>() { "un", "iq", "ue" };
        arr = new List<string>() { "cha", "r", "act", "ers" };
        //arr = new List<string>() { "ab", "cd", "cde", "cdef", "efg", "fgh", "abxyz" };
        arr = new List<string>() { "a", "b", "c", "d", "e", "l", "g", "h", "l", "j", "k", "l", "m", "n", "o", "p" };

        MaxLength(arr);
    }


    public int MaxLength (IList<string> arr) {
        int max = 0;

        if (arr.Count == 1) return arr[0].Length;

        int k = 0;
        while (k < arr.Count) {
            for (int f = 0; f < arr[k].Length; f++) {
                char c = arr[k][f];
                if (arr[k].IndexOf(c) != arr[k].LastIndexOf(c)) {
                    arr.Remove(arr[k]);
                    k--;
                    break;
                }
            }
            k++;
        }

        for (int i = 0; i < arr.Count; i++) {
            GoList(arr, arr[i], "");
        }

        return max;

        void GoList (IList<string> list, string strPart, string strMax) {
            List<string> _list = new List<string>();
            _list.AddRange(list);
            _list.Remove(strPart);

            //Console.WriteLine($"{list.Count,3}  {strPart,3} {uniq}");

            for (int i = 0; i < _list.Count; i++) {
                bool uniq = true;
                for (int l = 0; l < strPart.Length; l++) {
                    if (0 <= strMax.IndexOf(strPart[l])) {
                        uniq = false;
                        break;
                    }
                }
                if (uniq) {
                    strMax += strPart;
                    if (max < strMax.Length) max = strMax.Length;
                    GoList(_list, _list[i], strMax);
                }

            }
        }
    }

}
