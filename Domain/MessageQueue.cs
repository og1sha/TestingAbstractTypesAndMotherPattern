using System.Collections;

namespace Domain
{
    public class MessageQueue : IMessageQueue
    {
        private Queue messageQueue;
        public bool IsEmpty => MessageCount == 0;

        public bool IsActive { get; private set; }

        public bool IsReadonly { get; private set; }

        public int MessageCount => messageQueue.Count;

        public MessageQueue()
        {
            messageQueue = new Queue();
            IsActive = true;
            IsReadonly = false;
        }

        public MessageQueue(ICollection messageCollection)
        {
            messageQueue = new Queue(messageCollection);
            IsActive = true;
            IsReadonly = false;
        }

        public MessageQueue(ICollection messageCollection, bool isReadOnly)
        {
            messageQueue = new Queue(messageCollection);
            IsActive = true;
            IsReadonly = isReadOnly;
        }

        public void ClearQueue()
        {
            if (IsActive && !IsReadonly)
            {
                messageQueue.Clear();
            }
        }

        public void Deactivate(bool isReadOnly)
        {
            IsReadonly = isReadOnly;
            IsActive = false;
        }

        public void PutMessage(string message)
        {
            if (!string.IsNullOrEmpty(message) && IsActive && !IsReadonly)
            {
                messageQueue.Enqueue(message);
            }
        }

        public string ReadMessage()
        {
            if (IsActive && !IsEmpty)
            {
                return messageQueue.Dequeue().ToString();
            }

            return string.Empty;
        }
    }
}