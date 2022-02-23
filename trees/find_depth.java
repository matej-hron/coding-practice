private static int height(Node root, int depth)
    {
        if(root.left == null && root.right == null)
        {
            return depth;
        }
        
        int leftDepth = root.left == null ? depth : height(root.left, depth + 1);
        int rightDepth = root.right == null ? depth : height(root.right, depth + 1);
        
        return leftDepth > rightDepth ? leftDepth : rightDepth;
    }