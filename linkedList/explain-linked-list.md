# Introduction to linked list 
**what is a linked list**: is a list of elements . we can call this elements <Node> , which are conected to each other`s to make up a linked list 
- each node is an object that belongs to a particular class .
- each node node consist of two attributes next (or link) and data .

  
###  Data
  - Stores the value of the node.
    
### Next (or Link)
   - A reference to the next node in the sequence.
   - its type is the same type of the object , which means its holds an address of other object of the same type.
   
  ## visual explanation 
  ![alt text](https://github.com/yosefther/data-structure-implementation/blob/master/assets/LinkedList.PNG?raw=true)
# FUNCTION EXPLAIN 
In this section, we explain the core functions implemented in the LinkedList class. 

# Add(T data) 
This method is used to add a new node or value at the start of the LinkedList.
- A new node containing the specified data is created.
- he Next pointer of the new node is set to the current head of the list.
- The head is updated to the new node, effectively inserting it at the beginning.
  
# Empty()
This method is used to check whether the LinkedList is empty.
- Returns true if there are no nodes in the list.
- Returns false if the list contains one or more nodes.
- It determines this by checking the value of Count or head.
  
# Clear()
this method is used to remove all nodes from the LinkedList.
- The head is set to null, severing all links between nodes.
- The Count is reset to indicate an empty list.
- Effectively, all nodes become unreachable and are garbage-collected by the runtime.

# DisplayList
This method is used to traverse and print all elements in the LinkedList.

### **Start from the Head:**
The traversal begins with the head node of the list.

### **Iterate Through Nodes:**

A temporary pointer (c) is used to move through each node in the list.
The loop continues until the pointer becomes null, indicating the end of the list.

### **Print Data:**

For each node, the Data attribute is printed to the console.

