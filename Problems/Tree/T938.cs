namespace P938;

/// 938. Range Sum of BST
public class T938 {
    public void Test () {

    }

    public int RangeSumBST (TreeNode root, int low, int high) {
        int res = 0;
        CheckNode(root);
        return res;

        void CheckNode (TreeNode node) {
            if (low <= node.val && node.val <= high) res += node.val;
            if (node.left != null) CheckNode(node.left);
            if (node.right != null) CheckNode(node.right);
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
