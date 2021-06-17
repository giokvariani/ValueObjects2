using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using ValueObjects.ExtensionMethods;

namespace ValueObjects.Wrappers
{
    public interface IHavePeriod
    {
        PeriodBase Period { get; }
    }
    public class Active
    {
        public static Active<T> CreateNonAsync<T>(T source, bool condition) where T : IHavePeriod => new(source, condition);
        public static Task<Active<T>> CreateAsync<T>(T source, bool condition) where T : IHavePeriod => Task.Run(() => new Active<T>(source, condition));
    }
    public class Active<T> where T : IHavePeriod
    {
        public Active(T source, bool condition)
        {
            if (!condition) return;
            MaybeValue = source;
            IsSuccess = true;
        }
        public Maybe<T> MaybeValue { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => IsSuccess.Opposite();
    }
}
