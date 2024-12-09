namespace DataStructInterfaces;

public interface ITreeNode<T>
{
    ITreeNode<T>? Left { get; set; }
    ITreeNode<T>? Right { get; set; }
    int Value { get; init; }
}