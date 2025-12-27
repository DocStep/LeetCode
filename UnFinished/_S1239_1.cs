namespace P1239;

/// 1239. Maximum Length of a Concatenated String with Unique Characters
public class _S1239_1 {
    public void Test () {
        IList<string> arr;
        arr = new List<string>() { "un", "iq", "ue" };
        //arr = new List<string>() { "cha", "r", "act", "ers" };
        //arr = new List<string>() { "ab", "cd", "cde", "cdef", "efg", "fgh", "abxyz" };
        //arr = new List<string>() { "a", "b", "c", "d", "e", "l", "g", "h", "l", "j", "l", "l", "m", "n", "o", "p" };

        MaxLength(arr);
    }


    public int MaxLength (IList<string> arr) {
        int max = 0;
        List<Node> nodes;

        if (arr.Count == 1) return arr[0].Length;

        nodes = new List<Node>();
        for (int i = 0; i < arr.Count; i++) {
            bool uniq = true;
            char c;
            for (int f = 0; f < arr[i].Length; f++) {
                c = arr[i][f];
                if (arr[i].IndexOf(c) != arr[i].LastIndexOf(c)) {
                    uniq = false;
                    break;
                }
            }
            if (uniq) nodes.Add(new(arr[i]));
        }


        Node check1;
        Node check2;
        for (int i = 0; i < nodes.Count-1; i++) {
            for (int f = i; f < nodes.Count; f++) {
                bool uniq = true;
                check1 = nodes[i];
                check2 = nodes[f];
                for (int k = 0; k < check2.value.Length; k++) {
                    char c = check2.value[k];
                    if (check1.value.Contains(c)) {
                        uniq = false;
                        break;
                    }
                }
                if (uniq) {
                    check1.nodes.Add(check2);
                    check2.nodes.Add(check1);
                }
            }
        }

        for (int i = 0; i < nodes.Count; i++) {
            GoNode(nodes[i], "");
            //Console.WriteLine();
        }
        return max;

        void GoNode (Node node, string s) {
            node.able = false;
            s += node.value;
            if (max < s.Length) max = s.Length;
            Console.WriteLine($"{node.value} {s}");


            bool uniq;
            for (int i = 0; i < node.nodes.Count; i++) {
                if (node.nodes[i].able) {
                    uniq = true;
                    for (int l = 0; l < node.nodes[i].value.Length; l++) {
                        if (0 <= s.IndexOf(node.nodes[i].value[l])) {
                            uniq = false;
                            break;
                        }
                    }
                    if (uniq) {
                        GoNode(node.nodes[i], s);
                    }
                }
            }

            node.able = true;
        }
    }


    public class Node {
        public Node (string value) {
            this.value = value;
        }
        public bool able = true;
        public string value;
        public List<Node> nodes = new List<Node>();
    }
    
}
