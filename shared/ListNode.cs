using System.Collections.Generic;
using Newtonsoft.Json;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

    public static ListNode GetHead(int[] values)
    {
        ListNode head = null;
        ListNode current = null;
        foreach (var val in values)
        {
            if (head == null)
            {
                head = new ListNode(val);
                current = head;
            }
            else
            {
                current.next = new ListNode(val);
                current = current.next;
            }
        }
        return head;
    }

    public static ListNode Deserialize(string content)
    {
        return GetHead(JsonConvert.DeserializeObject<int[]>(content));
    }

    public static string Serialize(ListNode head)
    {
        return JsonConvert.SerializeObject(GetList(head));
    }

    public static IEnumerable<int> GetList(ListNode head)
    {
        while (head != null)
        {
            yield return head.val;
            head = head.next;
        }
    }
}