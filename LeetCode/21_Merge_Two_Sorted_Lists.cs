namespace LeetCode
{
    public class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode p = l1;
            ListNode q = l2;
            ListNode node = new ListNode(1);
            ListNode result = node;
            while (p != null || q != null)
            {
                if (p != null && q == null)
                {
                    node.next = p;
                    break;
                }
                else if (p == null && q != null)
                {
                    node.next = q;
                    break;
                }
                else if (p.val < q.val)
                {
                    node.next = p;
                    p = p.next;
                    node = node.next;
                }
                else
                {
                    node.next = q;
                    q = q.next;
                    node = node.next;
                }
            }
            return result.next;
        }
    }
}
