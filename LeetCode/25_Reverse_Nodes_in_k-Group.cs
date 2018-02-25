namespace LeetCode
{
    public class ReverseNodesInKGroup
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k < 2) return head;
            if (head == null) return null;

            ListNode ret = null;//作为方法返回的list
            ListNode node = head;
            int N = 0;
            while (node != null)//好吧，看了一下discussion里的答案确实有办法可以不用先遍历一遍
            {
                N++;
                if (N == k)
                {
                    ret = node;
                }
                node = node.next;
            }
            if (k > N)
            {
                return head;
            }

            ListNode first = head;//每一组要交换的k个元素中的第一个（交换之前）
            ListNode prevLastAfterSwap = null;//已经交换完毕的k个元素中的最后一个（这里的prev是指上一组）
            ListNode currfirstAfterSwap = null;//当前已经交换完毕后的k个元素中的第一个
            for (int swapTimes = N / k; swapTimes > 0; swapTimes--)
            {
                ListNode prev = null;
                ListNode curr = first;
                ListNode next = null;
                for (int i = 0; i < k; i++)
                {
                    if (i == k - 1)//如果是这一组中的最后一个了，需要记录一下
                    {
                        currfirstAfterSwap = curr;
                    }
                    next = curr.next;
                    curr.next = prev;

                    prev = curr;
                    curr = next;
                }

                //把上一组的最后一个元素的指针指向现在这组的第一个元素
                if (prevLastAfterSwap != null)
                {
                    prevLastAfterSwap.next = currfirstAfterSwap;
                }

                //如果最后一次也交换完毕了，记得还要指向剩余那些不变的元素
                if (swapTimes == 1)
                {
                    first.next = next;
                }

                prevLastAfterSwap = first;
                first = next;
            }

            return ret;
        }

        public static void Test()
        {
            var solution = new ReverseNodesInKGroup();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            l1.next.next.next.next = new ListNode(5);
            l1.next.next.next.next.next = new ListNode(6);
            var result = solution.ReverseKGroup(l1, 3);
        }
    }
}
