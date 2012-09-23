using System.Web.Mvc;
using NUnit.Framework;

namespace UnitTestingAsyncController
{
    [TestFixture]
    public class SampleAsyncControllerTests
    {
        [Test]
        public void When_calling_square_of_it_should_retrun_square_number_of_input()
        {
            var controller = new SampleAsyncController();
            var result = new JsonResult();
            const int number = 5;

            controller.ExecuteAsync(() => controller.SquareOfAsync(number),
                                    () => result = controller.SquareOfCompleted((int)controller.AsyncManager.Parameters["result"]));

            Assert.AreEqual((int)(result.Data), number * number);
        }
    }
}