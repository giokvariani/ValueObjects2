using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace ValueObjects.Wrappers
{
    public class DoWrapper
    {
        public static async Task<DoWrapper<T2>> Create<T2>(Func<T2> funcT)
        {
            return await Task.Run(() => new DoWrapper<T2>(funcT));
        }

        public static DoWrapper<T2> CreateNonAsync<T2>(Func<T2> funcT)
        {
            return new DoWrapper<T2>(funcT);
        }


    }


    [DebuggerDisplay("{" + nameof(ResultValue) + "}")]
    public class DoWrapper<T> : ValueObject
    {
        public DoWrapper(Func<T> funcT)
        {
            ResultValue = Result.Try(funcT, exception => exception.Message);
        }

        public bool IsSuccess => ResultValue.IsSuccess;
        public bool IsFailure => !IsSuccess;
        public Result<T> ResultValue { get; }
        public T Value => ResultValue.Value;
        public override string ToString() =>
            ResultValue.IsSuccess
                ? $"S[{ResultValue.Value}]"
                : $"F[{ResultValue.Error}]";


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ResultValue;
        }
    }

    public static class DoWrapperExtensions
    {
        
    }
}
