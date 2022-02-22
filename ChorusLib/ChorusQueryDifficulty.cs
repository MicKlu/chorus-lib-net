using System;

namespace ChorusLib
{
    [Flags]
    public enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 4,
        Expert = 8,
        E = Easy,
        M = Medium,
        H = Hard,
        X = Expert,
        All = E | M | H | X
    }

    public class ChorusQueryDifficulty
    {
        public Difficulty Difficulty { get; }

        public ChorusQueryDifficulty(Difficulty difficulty)
        {
            if((int)difficulty > 15 || (int)difficulty < 0)
                throw new ArgumentException("Incorrect difficulty value.", nameof(difficulty));
            this.Difficulty = difficulty;
        }

        public ChorusQueryDifficulty(bool easy, bool medium, bool hard, bool expert)
        {
            if(easy)
                this.Difficulty |= Difficulty.Easy;
            if(medium)
                this.Difficulty |= Difficulty.Medium;
            if(hard)
                this.Difficulty |= Difficulty.Hard;
            if(expert)
                this.Difficulty |= Difficulty.Expert;
        }
    }
}