	public static Node insert(Node root,int data) {
        
        if(root == null)
        {
            return new Node(data);
        }
        
        if(data < root.data)
        {
            if(root.left == null)
            {
                root.left =  new Node(data);
            }
            else{
                 insert(root.left, data);
            }
        }
        else{
            if(root.right == null)
            {
                root.right =  new Node(data);
            }
            else{
                insert(root.right, data);
            }
        }
    	
        return root;
    }