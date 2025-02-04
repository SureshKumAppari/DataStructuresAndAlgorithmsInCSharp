﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole._11Oct2020
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class AddTwoNumbersClass
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode dummy = new ListNode(0);
            ListNode pre = dummy;

            while(l1 != null || l2 != null || carry == 1)
            {
                int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                carry = sum < 10 ? 0 : 1;
                pre.next = new ListNode(sum % 10);
                pre = pre.next;

                if(l1 != null)
                {
                    l1 = l1.next;
                }
                if(l2 != null)
                {
                    l2 = l2.next;
                }
            }
            return dummy.next;
        }
    }
}
