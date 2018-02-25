namespace LeetCode
{
    public class SwapNodesInPairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;
            ListNode ret = head.next == null ? head : head.next;
            ListNode current = head;
            ListNode last = new ListNode(-1);
            while (current != null)
            {
                ListNode p = current;
                ListNode q = current.next;
                if (q == null) break;
                ListNode tmp = q.next;
                q.next = p;
                p.next = tmp;
                last.next = q;
                last = current;
                current = p.next;
            }
            return ret;
        }

        public static void Test()
        {
            var solution = new SwapNodesInPairs();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            var result = solution.SwapPairs(l1);
        }
    }
}
