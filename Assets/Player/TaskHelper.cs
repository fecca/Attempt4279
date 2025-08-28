using System;
using System.Threading.Tasks;

namespace Player
{
    public class TaskHelper
    {
        public static void Run(Task task, Action callback)
        {
            Task.Run(async () =>
            {
                try
                {
                    await task;
                    callback.Invoke();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });
        }
    }
}