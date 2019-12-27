using System;
using System.Threading.Tasks;

namespace AsyncApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1");
            var a = async1();
            Console.WriteLine("2; won't come up immediately");
            //var a = async2();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main");
                System.Threading.Thread.Sleep(1000);
            }
            a.Wait(); //block/wait until the async call returns //missing it will go on without waitng async thread
            Console.WriteLine("Main-end");
        }

        static async Task<int> async1()
        {
            Console.WriteLine("ASYN-start");
            /* AWAIT means to yield back the control back to the caller
             and I continue*/
            var result = await Task.Run(() =>
            {
                for (int i=0; i< 10; i++)
                {
                    Console.WriteLine("ASYN");
                    System.Threading.Thread.Sleep(1000);

                }
                return 888;
            });

            Console.WriteLine("ASYN-end");
            return 777;
        }

        static async Task<int> async2()
        {
            /* async keyword only has 1 usage: allowing you to use await keyword inside */
            /* this function is = sync function cause we don't use await keyword here */
            Console.WriteLine("ASYN2-start");
            
                for (int i = 0; i < 2000; i++)
                {
                    System.Threading.Thread.Sleep(5);
                }

            Console.WriteLine("ASYN2-end");
            return 777;
        }
    }
}