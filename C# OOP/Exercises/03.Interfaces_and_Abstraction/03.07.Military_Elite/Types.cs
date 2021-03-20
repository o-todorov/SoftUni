using System;

namespace MilitaryElite
{
    public enum Corps
    {
        Airforces,
        Marines
    }
    public enum MissionState
    {
        inProgress,
        Finished
    }

    public static class Enums
    {
        public static T EnumParse<T>(string str) where T:struct
        {
            T corp;

            if(Enum.TryParse<T>(str, out corp))
            {
                return corp;
            }

            throw new ArgumentException($"Failed to parse string to enum");
        }

    }

}
