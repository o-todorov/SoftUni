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
        /// <summary>
        /// Generic parse string to Enum type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns>Enum value if applicable, otherwise throw error</returns> 
        /// <exception cref="ArgumentException">Failed to parse string to enum</exception>
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
