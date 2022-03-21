using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.SharedKernel
{
    public class EnumUtil
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        //StatusEnum MyStatus = EnumUtil.ParseEnum<StatusEnum>("Active");
    }
}
