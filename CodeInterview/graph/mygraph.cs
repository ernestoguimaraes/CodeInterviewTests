using System;
using System.Collections.Generic;

namespace CodeInterview.graph
{

    public class Node
    {
        public int data;
        public Node left, right;
        public bool visited;

        public Node(int value)
        {
            data = value;
            left = right = null;
            visited = false;
        }
    }

    public class TreeGraph
    {
        public Node Root;

        public void AddValue(int value)
        {
            Node newNode = new Node(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                InsertNode(Root, newNode);
            }

        }

        public void InsertNode(Node node, Node newNode)
        {
            if (newNode.data < node.data)
            {
                if (node.left == null)
                {
                    node.left = newNode;
                }
                else
                {
                    InsertNode(node.left, newNode);
                }
            }
            else if (newNode.data > node.data)
            {
                if (node.right == null)
                {
                    node.right = newNode;
                }
                else
                {
                    InsertNode(node.right, newNode);
                }
            }

        }

        //SEARCH
        //BFS
        public void BreathFirstSearch(int value)
        {
            if (Root == null)
                return;

            Queue<Node> _searchQueue = new Queue<Node>();

            _searchQueue.Enqueue(Root);

            while (_searchQueue.Count != 0)
            {
                Node _current = _searchQueue.Dequeue();
                Console.WriteLine("Deq:" + _current.data);

                _current.visited = true;

                if (_current.data == value)
                {
                    Console.WriteLine("FOUND");
                    return;
                }
                else
                {
                    if (_current.left != null && !_current.left.visited)
                        _searchQueue.Enqueue(_current.left);

                    if (_current.right != null && !_current.right.visited)
                        _searchQueue.Enqueue(_current.right);
                }
            }

            Console.WriteLine("NOT FOUND");

        }

    }


}

