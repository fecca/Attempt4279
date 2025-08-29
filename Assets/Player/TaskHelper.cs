using System;
using System.Threading.Tasks;
using UnityEngine;

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
                    Debug.Log(e);
                    throw;
                }
            }).ContinueWith(t =>
            {
                if (!t.IsFaulted) return;
                if (t.Exception != null) throw t.Exception;
            });
        }
    }
}