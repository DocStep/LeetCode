/// 21.Merge Two Sorted Lists

public class T21 {
    public void Test () {
        ListNode list1;
        ListNode list2;

        //[1,2,4] [1,3,4]
        list1 = new(1);
        list1.next = new(2);
        list1.next.next = new(4);

        list2 = new(1);
        list2.next = new(3);
        list2.next.next = new(4);

        ListNode list3 = MergeTwoLists(list1, list2);
    }


    public ListNode MergeTwoLists (ListNode list1, ListNode list2) {
        return GoNode(list1, list2, null);


        ListNode GoNode (ListNode list1, ListNode list2, ListNode list3) {
            if (list1 != null && list2 != null) {
                if (list2.val < list1.val) {
                    list3 = new(list2.val);
                    list3.next = GoNode(list1, list2.next, list3.next);
                } else {
                    list3 = new(list1.val);
                    list3.next = GoNode(list1.next, list2, list3.next);
                }
            } else {
                if (list1 != null && list2 == null) {
                    list3 = new(list1.val);
                    list3.next = GoNode(list1.next, null, list3.next);
                }
                if (list1 == null && list2 != null) {
                    list3 = new(list2.val);
                    list3.next = GoNode(null, list2.next, list3.next);
                }
            }

            return list3;
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
