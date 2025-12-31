/// 19. Remove Nth Node From End of List

public class T19 {
    public void Test () {
        ListNode head;
        int n;

        head = new(1);
        head.next = new(2);
        head.next.next = new(3);
        n = 3;

        ListNode node = RemoveNthFromEnd(head, n);
    }



    public ListNode RemoveNthFromEnd (ListNode head, int n) {
        int maxDist = 1;
        return GoNode(head, 0);

        ListNode GoNode (ListNode node, int dist) {
            if (maxDist < dist) maxDist = dist;
            if (node.next != null) node.next = GoNode(node.next, dist+1);
            if (--n == 0) node = node.next;
            return (node);
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
