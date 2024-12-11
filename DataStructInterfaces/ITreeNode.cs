namespace DataStructInterfaces;

public interface ITreeNode<T>
{
    ITreeNode<T>? Left { get; set; }
    ITreeNode<T>? Right { get; set; }
    T? Value { get; init; }
}