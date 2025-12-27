namespace P24;

/// 24. Swap Nodes in Pairs
public class T24 {
    public void Test () {
        ListNode head;

        /// [1,2,4] [1,3,4]
        head = new(1);
        head.next = new(2);
        head.next.next = new(3);
        head.next.next.next = new(4);

        ListNode list = SwapPairs(head);

    }


    public ListNode SwapPairs (ListNode head) {
        return GoNode(head);

        ListNode GoNode (ListNode node) {
            if (node != null && node.next != null) {
                ListNode t1 = node;
                ListNode t3 = node.next.next;
                node = node.next;
                node.next = t1;
                node.next.next = GoNode(t3);
            }
            return node;
        }
    }
    

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode (int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }

}
