using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    public class LRUCache
    {

        Dictionary<int, int> keyAndValue = new Dictionary<int, int>();
        Dictionary<int, LinkedListNode<int>> keyAndNode = new Dictionary<int, LinkedListNode<int>>();
        LinkedList<int> linkedList = new LinkedList<int>();

        int capacity;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!keyAndValue.ContainsKey(key))
            {
                return -1;
            }

            var result = keyAndValue[key];

            var node = keyAndNode[key];
            linkedList.Remove(node);
            linkedList.AddFirst(node);

            return result;
        }

        public void Put(int key, int value)
        {
            if (!keyAndValue.ContainsKey(key))
            {
                // new
                if (capacity == linkedList.Count)
                {
                    var last = linkedList.Last;
                    linkedList.RemoveLast();
                    keyAndValue.Remove(last.Value);
                    keyAndNode.Remove(last.Value);
                }

                linkedList.AddFirst(key);
                keyAndNode[key] = linkedList.First;
                keyAndValue[key] = value;
            }
            else
            {
                //update
                keyAndValue[key] = value;
                var node = keyAndNode[key];
                linkedList.Remove(node);
                linkedList.AddFirst(node);
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
