using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JiangH.Kernels.Mods
{
    public class InteactiveLogic
    {
        internal IEnumerable<Type> personInteractives;


        public static InteactiveLogic Load(Assembly assembly)
        {
            return new InteactiveLogic()
            {
                personInteractives = assembly.GetTypes().Where(x => x.BaseType == typeof(IPersonInterActive))
            };
        }
    }
}