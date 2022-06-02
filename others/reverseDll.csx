class DoublyLinkedListNode {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

public void Do()
{
    var nd = new DoublyLinkedListNode(1);
    var head = nd;

    for(int i = 2; i <= 5; i++)
    {
        var newNd = new DoublyLinkedListNode(i);
        nd.next = newNd;
        newNd.prev = nd;
        nd = newNd;
    }

    nd = head;

    while(nd.next != null)
    {
        Console.WriteLine(nd.data);
        nd = nd.next;
    }
    Console.WriteLine(nd.data);

    var newHead = new DoublyLinkedListNode(nd.data);
    var n = newHead;

    while(nd.prev != null)
    {
        var ne
    }
}

Do();
