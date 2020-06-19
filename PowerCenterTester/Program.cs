using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossBeeze.CrossTest.Process.PowerCenter;

namespace PowerCenterTester
{
    class Program
    {
        static void Main(string[] args)
        {
            PowerCenterExecutor pce = new PowerCenterExecutor();
            pce.ExecuteWorkflow("ExampleDWH", "wf_m_load_H_Order");
            Console.ReadKey();
        }
    }
}
