using System;
using Xunit;
using Stack;

namespace DataStructureTests.Unit
{
    public class StackTests
    {
        [Fact]
        public void ArrayStack_PushPop_ReturnsItemsInLifoOrder()
        {
            var stack = new ArrayStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.Empty());
        }

        [Fact]
        public void ArrayStack_Pop_WhenEmpty_Throws()
        {
            var stack = new ArrayStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void LinkedListStack_PushPop_ReturnsItemsInLifoOrder()
        {
            var stack = new StackLinkedListBase<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void LinkedListStack_Pop_WhenEmpty_Throws()
        {
            var stack = new StackLinkedListBase<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
    }
}
