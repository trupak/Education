using System.Collections.Generic;

namespace DataStructures
{
    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }

         public ListNode(IEnumerable<int> collection)
         {
             var temp = this;
             var valIsSet = false;
             foreach (var i in collection)
             {
                 if (!valIsSet)
                 {
                     temp.val = i;
                     valIsSet = true;
                     continue;
                 }
                 
                 temp.next = new ListNode(i);
                 temp = temp.next;
             }
         }
         
         public List<int> ToList()
         {
             var result = new List<int>();
             var temp = this;
             while (temp != null)
             {
                 result.Add(temp.val);
                 temp = temp.next;
             }
             
             return result;
         }
    }
}