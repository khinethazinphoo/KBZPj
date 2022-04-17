using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KBZPj_Web.Service
{
    public static class DevCode
    {
        public static T CheckEntityItem<T>(this object obj)
        {
            T res = default(T);
            try
            {
                if (obj != null && !string.IsNullOrEmpty(obj.ToString()) && obj is string)
                    res = (T)Convert.ChangeType(obj.ToString().Trim(), typeof(T));
                else if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                    res = (T)Convert.ChangeType(obj, typeof(T));
            }
            catch (Exception ex)
            {

             }
            return res;
        }
    }
}