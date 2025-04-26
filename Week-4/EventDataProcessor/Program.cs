using System.Collections;
using System.Data;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;

namespace DSA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DataProcessor dp = new DataProcessor() { Name="Data Processor 1 "};
            Subscriber sub = new Subscriber();

            sub.Subscribe(dp);
            dp.ReceiveData(222); 

        }
        


    }
   
    
}
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int v)
        {
            val = v;
        }
    }
//    static TreeNode Insert(TreeNode root,int val)
//    {
//        if (root == null)
//            return new TreeNode(val);
//        if (val > root.val)
//            root.right = Insert(root.right,val);
//        else if(val < root.val)
//            root.left = Insert(root.left,val);
//        return root;
//    }
//    static TreeNode Min(TreeNode root)
//    {
//        while(root != null && root.left != null)
//            root = root.left;
//        return root;
//    }
//    static TreeNode Remove(TreeNode root,int val)
//    {
//        if (val > root.val)
//            root.right = Remove(root.right, val);
//        else if (val < root.val)
//            root.left = Remove(root.left, val);
//        else
//        {
//            if (root.right == null)
//                return root.left;
//            else if (root.left == null)
//                return root.right;
//            else
//            {
//                root.val = Min(root.right).val;
//                root.right = Remove(root.right,root.val);
//            }
//        }
//        return root;
//    }
//    static void DFS(TreeNode root)
//    {
//        if (root == null)
//            return;
//        DFS(root.left);
//        Console.WriteLine(root.val);
//        DFS(root.right);
//    }
//    static void BFS(TreeNode root)
//    {
//        Queue<TreeNode> q = new Queue<TreeNode>();
//        TreeNode cur;
//        int count = 0;
//        int level = 0;
//        q.Enqueue(root);
//        while (q.Count > 0)
//        {
//            level++;
//            count = q.Count;
//            for(int i=0;i<level;i++)
//                Console.Write(" ");
//            for(int i = 0; i < count; i++)
//            {
//                cur = q.Dequeue();
//                Console.Write(cur.val);
//                if (cur.left != null)
//                    q.Enqueue(cur.left);
//                if (cur.right != null)
//                    q.Enqueue(cur.right);
//            }
//            Console.WriteLine();
//        }
//    }
//    static bool SearchForPath(TreeNode root,Stack<TreeNode> path)
//    {
//        if (root == null || root.val == 0)
//            return false;
//        path.Push(root);
//        if (root.left == null && root.right == null)
//            return true;
//        if (SearchForPath(root.left, path))
//            return true;
//        if (SearchForPath(root.right, path))
//            return true;
//        path.Pop();
//        return false;
//    }
#region BackTracking

//    TreeNode root = new TreeNode(6);
//    TreeNode four = new TreeNode(4);
//    TreeNode one = new TreeNode(1);
//    TreeNode zero = new TreeNode(0);
//    TreeNode five = new TreeNode(5);
//    TreeNode two = new TreeNode(2);
//    TreeNode three = new TreeNode(3);
//    root.left = zero;
//    zero.left = new TreeNode(7);
//    root.right = one;
//    one.right = five;
//    five.right = two;
//    one.left = three;
//    three.right = new TreeNode(0);
//Stack<TreeNode> revPath = new Stack<TreeNode>();
//Stack<TreeNode> path = new Stack<TreeNode>();
//SearchForPath(root, revPath);
//while (revPath.Count != 0)
//    path.Push(revPath.Pop());
//foreach(TreeNode i in path)
//    Console.WriteLine(i.val);
// BFS(root); 
#endregion

