using System;

namespace LeetCode
{
    public class AddTwoNumbersSolution
    {
        public ListNode AddTwoNumbersGoodSolution(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }

        //my solution is too verbose and inefficient
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            bool carry = false;
            ListNode lastNode = new ListNode(-1);
            ListNode lResult = lastNode;
            while (l1 != null || l2 != null)
            {
                ListNode currentNode;
                if (l1 == null)
                {
                    lastNode.next = l2;
                    while (carry && l2 != null)
                    {
                        if (l2.val == 9)
                        {
                            l2.val = 0;
                        }
                        else
                        {
                            l2.val++;
                            carry = false;
                        }
                        l2 = l2.next;
                    }
                    break;
                }
                if (l2 == null)
                {
                    lastNode.next = l1;
                    while (carry && l1 != null)
                    {
                        if (l1.val == 9)
                        {
                            l1.val = 0;
                        }
                        else
                        {
                            l1.val++;
                            carry = false;
                        }
                        l1 = l1.next;
                    }
                    break;
                }
                int addedResult = carry ? l1.val + l2.val + 1 : l1.val + l2.val;
                if (addedResult > 9)
                {
                    currentNode = new ListNode(Convert.ToInt32(addedResult.ToString().Substring(1)));
                    carry = true;
                }
                else
                {
                    currentNode = new ListNode(addedResult);
                    carry = false;
                }
                lastNode.next = currentNode;
                l1 = l1.next;
                l2 = l2.next;
                lastNode = currentNode;
            }
            if (carry)
            {
                while (lastNode.next != null)
                {
                    lastNode = lastNode.next;
                }
                lastNode.next = new ListNode(1);
            }
            return lResult.next;
        }
    }
}
