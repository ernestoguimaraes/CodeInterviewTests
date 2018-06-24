using System;

namespace CodeInterview.bts
{
    public class Node
    {
        public int data;
        public Node left, right;
        public int x, y;

        public Node(int value)
        {
            data = value;
            left = null;
            right = null;
        }

    }

    public class tree
    {
        Node root, current;

        public tree()
        {
            root = null;
        }

        public Node ReturnRoot()
        {
            return root;
        }

        public void AddValue(int data)
        {

            Node newNode = new Node(data);

            if (root == null)
            {
                root = newNode;
                root.x = Console.WindowWidth / 2;
                root.y = 10;
            }
            else
            {
                insertNode(root, newNode);
            }
        }

        public void insertNode(Node node, Node newNode)
        {
            if (newNode.data < node.data)
            {
                if (node.left == null)
                {

                    node.left = newNode;
                    node.left.x += node.x - 2;
                    node.left.y += node.y + 2;
                }
                else
                {
                    insertNode(node.left, newNode);
                }
            }
            else if (newNode.data > node.data)
            {
                if (node.right == null)
                {
                    node.right = newNode;
                    node.right.x += node.x +2;
                    node.right.y += node.y + 2;
                }
                else
                {
                    insertNode(node.right, newNode);
                }
            }

        }


        public void Search(Node node, int value)
        {
            if (node.data == value)
            {
                Console.WriteLine("Found");
            }
            else if (value < node.data && node.left != null)
            {
                Search(node.left, value);
            }
            else if (value > node.data && node.left != null)
            {
                Search(node.right, value);
            }

        }

        

        public void Transverse(Node node)
        {
            if (node != null)
            {                
                Console.SetCursorPosition(node.x, node.y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(node.data);
                Transverse(node.left);
                Transverse(node.right);
            }
        }
        


    }
}
