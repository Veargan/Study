namespace List.Core
{
    public interface IList
    {
        void Init(int[] ar);
        void Clear();
        int[] ToArray();
        int Size();

        void Set(int pos, int val);
        int Get(int pos);

        void AddStart(int val);
        void AddEnd(int val);
        void AddPos(int pos, int val);
        
        int DelStart();
        int DelEnd();
        int DelPos(int pos);

        int Max();
        int Min();
        int IndMax();
        int IndMin();

        void Reverse();
        void HalfReverse();
        void Sort();
    }
}