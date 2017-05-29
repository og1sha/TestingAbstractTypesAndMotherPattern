using Domain;
using Xunit;

namespace Tests
{
    public abstract class MessageQueueTests
    {
        [Fact]
        public void IMessageQueue_IsEmpty_Empty()
        {
            IMessageQueue messageQueue = CreateMessageQueue();
            Assert.True(messageQueue.IsEmpty);
        }

        [Fact]
        public void IMessageQueue_IsActive_Active()
        {
            IMessageQueue messageQueue = CreateMessageQueue();
            Assert.True(messageQueue.IsActive);
        }

        [Fact]
        public void IMessageQueue_IsNotEmpty_NotEmpty()
        {
            IMessageQueue messageQueue = CreateMessageQueueWithCollection();
            Assert.False(messageQueue.IsEmpty);
        }

        [Fact]
        public void Deactivate_DeactivateQueue_ReadOnly()
        {
            IMessageQueue messageQueue = CreateMessageQueueWithCollection();
            messageQueue.Deactivate(true);
            Assert.True(messageQueue.IsReadonly);
        }

        [Fact]
        public void IMessageQueue_IsReadOnly_ReadOnly()
        {
            IMessageQueue messageQueue = CreateMessageQueueWithReadOnlyCollection();
            Assert.True(messageQueue.IsReadonly);
        }

        protected abstract IMessageQueue CreateMessageQueue();

        protected abstract IMessageQueue CreateMessageQueueWithCollection();

        protected abstract IMessageQueue CreateMessageQueueWithReadOnlyCollection();
    }
}