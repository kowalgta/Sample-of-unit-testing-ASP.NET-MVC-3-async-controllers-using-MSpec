using System.Threading;
using System.Web.Mvc;

namespace UnitTestingAsyncController
{
    public class SampleAsyncController : AsyncController
    {
        public void SquareOfAsync(int number)
        {
            AsyncManager.OutstandingOperations.Increment();

            // here goes asynchronous operation
            new Thread(() =>
            {
                Thread.Sleep(100);

                // do some async long operation like ... 
                // calculate square number
                AsyncManager.Parameters["result"] = number * number;
                
                // decrementing OutstandingOperations to value 0 
                // will execute Finished EventHandler on AsyncManager
                AsyncManager.OutstandingOperations.Decrement();
            }).Start();
        }

        public JsonResult SquareOfCompleted(int result)
        {
            return Json(result);
        }
    }
}
