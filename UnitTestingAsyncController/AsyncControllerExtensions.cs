using System;
using System.Threading;
using System.Web.Mvc;

namespace UnitTestingAsyncController
{
    static class AsyncControllerExtensions
    {
        /// <summary>
        /// Extension metod that helps in unit testing async controllers. 
        /// When asynchronous operation is called it blocks current thread until
        /// asynchronous operation is finished with processing.
        /// </summary>
        /// <param name="actionAsync">Asynchronous operation</param>
        /// <param name="actionCompleted"></param>
        public static void ExecuteAsync(this AsyncController asyncController, Action actionAsync, Action actionCompleted)
        {
            var trigger = new AutoResetEvent(false);
            asyncController.AsyncManager.Finished += (sender, ev) =>
            {
                actionCompleted();
                trigger.Set();
            };
            actionAsync();
            trigger.WaitOne();
        }
    }
}