using Moq;
using System;
using Unity;
using Unity.Injection;

namespace SeliseTask_003
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UnityFactory.RegisterComponents();

            
            DatetimeCalculator dtprocessor = UnityFactory.container.Resolve<DatetimeCalculator>();
            
            Console.WriteLine(dtprocessor.CurrentQuarter);
        }
    }
}
