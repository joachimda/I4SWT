using Team16104ATM;
using TransponderReceiver;

namespace Team16104ATM_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestVelocity test = new TestVelocity();
            //test.getData();
            //while (true)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //}
            
            Radartower radartower = new Radartower(TransponderReceiverFactory.CreateTransponderDataReceiver());

            while (true)
            {
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
