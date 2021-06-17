using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpFunctionalExtensions;

namespace ValueObjects
{
    [DebuggerDisplay("{" + nameof(DistanceInKm) + "}")]
    public class DistanceDl : ValueObject
    {
        public DistanceDl(decimal distanceInKm)
        {
            if (distanceInKm < 0) throw new InvalidOperationException("Distance Can not be Negative Negative Value");
            DistanceInKm = distanceInKm;
        }
        public decimal DistanceInKm { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DistanceInKm;
        }
        public static implicit operator DistanceDl(decimal decimalAmount) => new(decimalAmount);

        public static implicit operator DistanceDl(int distance) => new(distance);
    }
}