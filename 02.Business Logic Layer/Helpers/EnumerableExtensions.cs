namespace The_Book_Circle._02.Business_Logic_Layer.Helpers
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection)
        {
            return collection == null || !collection.Any();
        }
        public static bool IsNullOrEmpty<T>(this ICollection<T>? collection)
        {
            return collection == null || collection.Count()==0;
        }
    }
}
