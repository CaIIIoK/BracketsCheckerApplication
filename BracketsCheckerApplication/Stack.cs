namespace BracketsCheckerApplication
{
    class Stack
    {
        private int maxSize;
        private char[] stackArray;
        private int top;

        public Stack(int size)
        {
            maxSize = size;
            stackArray = new char[maxSize];
            top = -1;
        }
       
        // Put an item on the top of the stack
        public void Push(char charValue)
        {
            stackArray[++top] = charValue;
        }

        // Take an item from the top of the stack
        public char Pop()
        {
            return stackArray[top--];
        }
        
        // Returns 'true' if stack is empty
        public bool IsEmpty()
        {
            return (top == -1);
        }
    }
}
