namespace DataStructInterfaces;

public interface ITreeNode
{
    ITreeNode? Left { get; set; }
    ITreeNode? Right { get; set; }
    int Value { get; init; }
}