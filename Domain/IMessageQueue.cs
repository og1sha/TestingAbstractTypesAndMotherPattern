namespace Domain
{
    public interface IMessageQueue
    {
        bool IsEmpty { get; }
        bool IsActive { get; }
        bool IsReadonly { get; }
        int MessageCount { get; }

        string ReadMessage();

        void PutMessage(string message);

        void Deactivate(bool isReadOnly);

        void ClearQueue();
    }
}