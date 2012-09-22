using System.Web.Mvc;
using Machine.Fakes;
using Machine.Specifications;

namespace UnitTestingAsyncController
{
    [Subject(typeof(SampleAsyncController))]
    public class When_calling_square_of : WithSubject<SampleAsyncController>
    {
        It should_return_square_number_of_input_value = () =>
            ((int)Result.Data).ShouldEqual(TestValue * TestValue);

        Because of = () =>
            Subject.ExecuteAsync(
                () => Subject.SquareOfAsync(TestValue),
                () => Result = Subject.SquareOfCompleted((int)Subject.AsyncManager.Parameters["result"]));

        static JsonResult Result;
        const int TestValue = 5;
    }
}
