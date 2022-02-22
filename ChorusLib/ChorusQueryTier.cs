using System;

namespace ChorusLib
{
    public class ChorusQueryTier
    {
        public const string GT = "gt";
        public const string LT = "lt";

        public string Relation { get; }
        public int Value { get; }

        public ChorusQueryTier(string relation, int value)
        {
            if(relation != GT && relation != LT)
                throw new ArgumentException("Relation should be either \"gt\" or \"lt\".", nameof(relation));

            if(value < 0 || value > 6)
                throw new ArgumentException("Tier value must be in the range 0-6.", nameof(value));

            Relation = relation;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Relation}{Value}";
        }
    }
}