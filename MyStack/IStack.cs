namespace MyStack
{
    public interface IStack
    {
        bool IsEmpty();
        int GetSize();
        void Push(int element);
        int Pop();
        int? FindPosition(int element);
    }
}