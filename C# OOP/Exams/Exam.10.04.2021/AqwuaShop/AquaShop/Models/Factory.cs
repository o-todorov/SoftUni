using System;
using System.Linq;
using System.Reflection;

namespace AquaShop.Models
{
    public static class Factory
    {
        public static TType CreateObject<TType>(string objTypeName, string invalidTypeMessage, params Object[] args)
            where TType : class
        {
            Type objType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == objTypeName);

            if (objType == null) { throw new InvalidOperationException(invalidTypeMessage); }


            TType obj = null;

            try
            {
                obj = Activator.CreateInstance(objType, args) as TType;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }

            return obj;

        }
    }
}
