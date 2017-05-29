using Domain;

namespace Tests
{
    public class MessageQueueTester : MessageQueueTests
    {
        private readonly string[] testData = { "First Message", "Second Message", "Third Message" };

        protected override IMessageQueue CreateMessageQueue() => new MessageQueue();

        protected override IMessageQueue CreateMessageQueueWithCollection() => new MessageQueue(testData);

        protected override IMessageQueue CreateMessageQueueWithReadOnlyCollection() => new MessageQueue(testData, true);
    }
}