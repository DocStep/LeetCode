/// 931. Minimum Falling Path Sum

public class M931_Tree {
    public void Test () {
        int[][] matrix;
        matrix = new int[][] { new int[3] { 2, 1, 3 }, new int[3] { 6, 5, 4 }, new int[3] { 7, 8, 9 } };

        Node[] roots = CreateTrees(matrix);

        for (int f = 0; f < matrix.Length; f++) {
            int sum = GoNode(roots[f]);
            if (sum < min) min = sum;
        }

        Console.WriteLine(min);
    }

    int min = int.MaxValue;


    Node[] CreateTrees (int[][] matrix) {
        Node[] roots = new Node[matrix[0].Length];
        for (int f = 0; f < matrix[0].Length; f++) 
            roots[f] = new Node(matrix[matrix.Length-1][f], matrix[matrix.Length-1][f]);

        Node[] children;
        int t;
        for (int i = matrix.Length-2; 0 <= i; i--) {
            children = roots;
            roots = new Node[matrix[0].Length];

            roots[0] = new Node(matrix[i][0], matrix[i][0]);

            roots[0].middle = children[0];

            roots[1].left = children[0];


            for (int f = 1; f < roots.Length-1; f++) {
                roots[f] = new Node(matrix[i][f+1]);

                roots[f].middle = children[f];

                roots[f-1].right = children[f];

                roots[f+1].left = children[f];


            }
            roots[children.Length-1].middle = children[children.Length-1];
            roots[children.Length-2].right = children[children.Length-1];

        }
        return roots;
    }

    int GoNode (Node node) {
        if (node.left == null && node.middle == null && node.right == null) return node.value;

        int s = GoNode(node.middle);
        int _s;

        if (node.left != null) {
            _s = GoNode(node.left);
            if (_s < s) s = _s;
        }
        if (node.right != null) {
            _s = GoNode(node.right);
            if (_s < s) s = _s;
        }

        //Console.WriteLine($"(node.value){node.value} (s){s}");
        return node.value + s;
    }


    class Node {
        public Node (int value, int min = 0, Node left = null, Node middle = null, Node right = null) {
            this.value = value;
            this.min = min;
            this.left = left;
            this.middle = middle;
            this.right = right;
        }
        public int value;
        public int min;
        public Node left;
        public Node middle;
        public Node right;
    }

}
