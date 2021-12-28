namespace Lanternfish.Extensions
{
    public static class MyExtensions
    {
        public static List<T> Rotate<T>(this List<T> list)
        {
            T first = list[0];
            list.RemoveAt(0);
            list.Add(first);
            return list;
        }
    }
}