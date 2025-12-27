namespace P25;

/// 25. Reverse Nodes in k-Group
public class T25 {
    public void Test () {
        ListNode head;
        int k;
        switch (0) {
            case 0:
                // [1,2,3,4,5]
                head = new(1);
                head.next = new(2);
                head.next.next = new(3);
                head.next.next.next = new(4);
                head.next.next.next.next = new(5);
                k = 2;
                break;
            case 1:
                // [1,2,3,4,5]
                head = new(1);
                head.next = new(2);
                head.next.next = new(3);
                head.next.next.next = new(4);
                head.next.next.next.next = new(5);
                k = 3;
                break;
            case 2:
                // [1,2,3,4,5]
                head = new(1);
                head.next = new(2);
                k = 2;
                break;
        }

        ReverseKGroup(head, k);

    }


    public ListNode ReverseKGroup (ListNode head, int k) {
        ListNode newHead = null;
        ListNode last = null;
        ListNode next = null;
        bool reverse = false;
        bool ended = false;
        GoNode(null, head, 0);
        return newHead;

        void GoNode (ListNode prev, ListNode node, int count) {
            if (node == null) return;

            if (++count == k) reverse = true;
            else GoNode(node, node.next, count%k);

            if (reverse) {
                if (last != null) last.next = node;
                else last = node;
                last = node;

                if (count == k) { /// last
                    next = node.next;
                    if (newHead == null) newHead = node; /// new head
                } else if (count == 1) { /// 1st
                    reverse = false;
                    node.next = null;
                    GoNode(null, next, 0);
                }
            } else {
                if (!ended) {
                    ended = true;

                    if (last != null) last.next = next;
                    else newHead = next;
                    last = next;
                }
            }
        }
    }
    

    void write (ListNode head) {
        if (head == null) return;
        Console.WriteLine(head.val);
        write(head.next);
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
