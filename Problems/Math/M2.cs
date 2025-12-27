namespace P2;

/// 2. Add Two Numbers
public class M2 {
    public ListNode AddTwoNumbers (ListNode l1, ListNode l2) {


        return getNode(l1, l2, 0);
    }

    ListNode getNode (ListNode node1, ListNode node2, int add) {
        int val;
        if (node1 != null && node2 != null) {
            val = node1.val + node2.val + add;
            return new ListNode(val % 10, getNode(node1.next, node2.next, val/10));
        } else if (node1 != null) {
            val = node1.val + add;
            return new ListNode(val % 10, getNode(node1.next, null, val/10));
        } else if (node2 != null) {
            val = node2.val + add;
            return new ListNode(val % 10, getNode(null, node2.next, val/10));
        } else if (node1 == null && node2 == null && 0 < add) return new ListNode(add, null);
        return null;
    }

    public class ListNode {
        public ListNode (int value, ListNode nextNode) {
            val = value;
            next = nextNode;
        }
        public int val;
        public ListNode next;
    }
}
