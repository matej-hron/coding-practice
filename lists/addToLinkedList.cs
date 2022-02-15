using System;
using System.Linq;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        var lst = new SinglyLinkedListNode
        {
            Data = 1,
            Next = new SinglyLinkedListNode{
                Data = 2,
                Next = new SinglyLinkedListNode{
                    Data = 3,
                    Next = null
                }
            }
        };
        

        //var newList = insertNodeAtPosition(lst, 10, 0);
        //Test(newList, "10, 1, 2, 3");

        
        //var newList = insertNodeAtPosition(lst, 10, 1);
        //Test(newList, "1, 10, 2, 3");
        
        //var newList = insertNodeAtPosition(lst, 10, 2);
        //Test(newList, "1, 2, 10, 3");
        
        //var newList = insertNodeAtPosition(lst, 10, 3);
        //Test(newList, "1, 2, 3, 10");

        var newList = insertNodeAtPosition(lst, 10, 1);
        Test(newList, "1, 2, 3, 10");

        
    }
    
    public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
    {
        var currentNode = llist;
        
        if(position == 0)
        {
            return new SinglyLinkedListNode
            {
                Data = data,
                Next = llist
            };
        }
        
        for(int i = 1; i < position && currentNode.Next != null; i++)
        {
            currentNode = currentNode.Next;
        }
        
        var tail = currentNode.Next;
        
        currentNode.Next = new SinglyLinkedListNode
        {
            Data = data,
            Next = tail
        };
        
        
        return llist;
    }
             
    public static void Test(SinglyLinkedListNode result, string expected)
    {
        var currentNode = result;
        
        Console.Write("Result: ");
        
        while(currentNode.Next != null) {
            Console.Write($"{currentNode.Data}, ");
            currentNode = currentNode.Next;
        }
        
        Console.Write($"{currentNode.Data}, ");
        
        Console.WriteLine($"Expected: {expected}");
    }
                 
}

   
public class SinglyLinkedListNode
{
   public int Data {get; set;}
   public SinglyLinkedListNode Next {get; set;}
}