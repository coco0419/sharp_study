namespace System
{
    public static class DisposableExtension
    {
        public static void Using<T>(this T source, Action<T> action) where T : IDisposable => source.UsingAndSelect(x =>
        {
            action.Invoke(x);

            return 0;
        });

        public static TResult UsingAndSelect<TSource, TResult>(this TSource source, Func<TSource, TResult> action) where TSource : IDisposable
        {
            using (source)
            {
                return action.Invoke(source);
            }
        }
    }
}
