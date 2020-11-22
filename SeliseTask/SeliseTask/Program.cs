using Moq;
using System;
using Unity;
using Unity.Injection;

namespace SeliseTask
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
