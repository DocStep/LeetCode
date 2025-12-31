/// 2385. Amount of Time for Binary Tree to Be Infected

public class T2385 {
    public void Test () {
        TreeNode root = null;
        int start = 0;
        switch (0) {
            case 0:
                root = new TreeNode(1);
                root.left = new TreeNode(5);
                root.right = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.left = new TreeNode(10);
                root.right.right = new TreeNode(6);
                root.left.right.left = new TreeNode(9);
                root.left.right.right = new TreeNode(2);
                start = 3;
                break;
            case 1:
                root = new TreeNode(1);
                root.left = new TreeNode(5);
                root.right = new TreeNode(3);
                root.left.right = new TreeNode(4);
                root.right.left = new TreeNode(10);
                root.right.right = new TreeNode(6);
                root.left.right.left = new TreeNode(9);
                root.left.right.right = new TreeNode(2);
                start = 3;
                break;
            case 2:
                // 
                root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.left.left = new TreeNode(4);
                root.left.left.left.left = new TreeNode(5);
                start = 4;
                break;
            case 22:
                // 
                root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.left.left = new TreeNode(4);
                root.left.left.left.left = new TreeNode(5);
                start = 2;
                break;
            case 222:
                //[1,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]
                root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.left.left = new TreeNode(4);
                root.left.left.left.left = new TreeNode(5);
                root.left.left.left.left.left = new TreeNode(6);
                root.left.left.left.left.left.left = new TreeNode(7);
                root.left.left.left.left.left.left.left = new TreeNode(8);
                root.left.left.left.left.left.left.left.left = new TreeNode(9);
                start = 7;
                // 6
                break;
            case 3:
                root = new TreeNode(16);
                root.right = new TreeNode(20);
                root.right.left = new TreeNode(7);
                root.right.left.right = new TreeNode(15);
                root.right.left.right.right = new TreeNode(1);
                root.right.right = new TreeNode(12);
                root.right.right.right = new TreeNode(19);
                root.right.right.right.left = new TreeNode(2);
                start = 1;
                break;
            case 4:
                //[19,4,6,9,11,18,1,null,null,null,17,null,8,null,null,null,null,null,20]
                root = new TreeNode(19);
                root.left = new TreeNode(4);
                root.right = new TreeNode(6);
                root.left.left = new TreeNode(9);
                root.left.right = new TreeNode(11);
                root.left.right.right = new TreeNode(17);

                root.right = new TreeNode(6);
                root.right.left = new TreeNode(18);
                root.right.right = new TreeNode(1);
                root.right.left.right = new TreeNode(8);
                root.right.left.right.right = new TreeNode(20);
                start = 1;
                break;
            case 5:
                //[5,2,3,4,null,null,null,1]
                root = new TreeNode(5);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.left.left = new TreeNode(1);
                start = 4;
                // 3
                break;
            case 6:
                //[3,2,1,null,null,null,4]
                root = new TreeNode(3);
                root.left = new TreeNode(2);
                root.right = new TreeNode(1);
                root.right.right = new TreeNode(4);
                start = 4;
                // 3
                break;
        }
        
        AmountOfTime(root, start);
    }


    public int AmountOfTime (TreeNode root, int start) {
        int startDist = 0;
        int max = 0;
        //int distClear = 0;
        int distInfected = 0;

        GetNodePath(root, 0, 0);
        return Math.Max(max, Math.Max(startDist, distInfected));


        void InfNode (TreeNode node, int dist) {
            if (distInfected < dist) distInfected = dist;
            //Console.WriteLine($"inf{node.val,2}  dist{dist,2}  distInf{distInf,2}");

            if (node.left != null) InfNode(node.left, dist+1);
            if (node.right != null) InfNode(node.right, dist+1);
        }
        (bool inPath, int maxDist) GetNodePath (TreeNode node, int dist, int maxLength) {
            if (node.val == start) {
                startDist = dist;
                InfNode(node, 0);
                return (true, 0);
            }

            bool inPath = false;
            int maxLengthChild = 0;
            if (node.left != null) {
                (bool inPath, int maxDist) resultL = GetNodePath(node.left, dist+1, 0);
                if (resultL.inPath) inPath = true;
                else maxLengthChild = Math.Max(maxLengthChild, resultL.maxDist+1);
            }

            if (node.right != null) {
                (bool inPath, int maxDist) resultR = GetNodePath(node.right, dist+1, 0);
                if (resultR.inPath) inPath = true;
                else maxLengthChild = Math.Max(maxLengthChild, resultR.maxDist+1);
            }

            maxLength = Math.Max(maxLength, maxLengthChild);
            if (max < maxLength+startDist-dist) max = maxLength+startDist-dist;

            return (inPath, maxLength);
        }
    }


    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}