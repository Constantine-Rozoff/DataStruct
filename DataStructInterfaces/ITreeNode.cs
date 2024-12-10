namespace DataStructInterfaces;

public interface ITreeNode<TValue>
{
    ITreeNode<TValue>? Left { get; set; }
    ITreeNode<TValue>? Right { get; set; }
    int Value { get; init; }
}