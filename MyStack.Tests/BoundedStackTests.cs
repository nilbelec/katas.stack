using NUnit.Framework;
using FluentAssertions;

namespace MyStack.Tests
{
    [TestFixture]
    public class BoundedStackTests
    {
        private const int CAPACITY = 2;

        private BoundedStack _boundedStack;

        [SetUp]
        public void SetUp()
        {
            _boundedStack = BoundedStack.Make(CAPACITY);
        }

        [Test]
        public void WhenCreatingAStackThenItShouldBeEmpty()
        {
            _boundedStack.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void WhenCreatingAStackThenItsSizeMustBeZero()
        {
            _boundedStack.GetSize().Should().Be(0);
        }

        [Test]
        public void WhenPushingAnElementThenGetSizeShouldReturnsOne()
        {
            _boundedStack.Push(1);
            _boundedStack.GetSize().Should().Be(1);
        }

        [Test]
        public void WhenPushingAnElementThenGetSizeShouldNotBeEmpty()
        {
            _boundedStack.Push(1);
            _boundedStack.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void AfterOnePushAndOnePopThenStackShouldBeEmpty()
        {
            _boundedStack.Push(1);
            _boundedStack.Pop();
            _boundedStack.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void AfterOnePushAndOnePopThenStackSizeMustBeZero()
        {
            _boundedStack.Push(1);
            _boundedStack.Pop();
            _boundedStack.GetSize().Should().Be(0);
        }

        [Test, ExpectedException(typeof(BoundedStack.OverflowException))]
        public void WhenPushPastsCapacityThenItShouldThrowOverflowException()
        {
            CAPACITY.Should().Be(2);

            _boundedStack.Push(1);
            _boundedStack.Push(2);
            _boundedStack.Push(3);
        }

        [Test, ExpectedException(typeof(BoundedStack.UnderflowException))]
        public void WhenPoppingAnEmptyStackThenItShouldThrowUnderflowException()
        {
            _boundedStack.Pop();
        }

        [Test]
        public void WhenOneIsPushedThenOneIsPopped()
        {
            _boundedStack.Push(1);
            _boundedStack.Pop().Should().Be(1);
        }

        [Test]
        public void WhenOneAndTwoArePushedThenTwoAndOneArePopped()
        {
            _boundedStack.Push(1);
            _boundedStack.Push(2);
            _boundedStack.Pop().Should().Be(2);
            _boundedStack.Pop().Should().Be(1);
        }

        [Test, ExpectedException(typeof(BoundedStack.IllegalCapacityException))]
        public void WhenCreatingStackWithNegativeSizeThenItShouldThrowIllegalCapacity()
        {
            BoundedStack.Make(-1);
        }

        [Test]
        public void WhenPushingOneAndTwoThenFindingTwoPositionShouldReturnZero()
        {
            _boundedStack.Push(1);
            _boundedStack.Push(2);
            _boundedStack.FindPosition(2).Should().Be(0);
        }

        [Test]
        public void WhenPushingOneAndTwoThenFindingOnePositionShouldReturnOne()
        {
            _boundedStack.Push(1);
            _boundedStack.Push(2);
            _boundedStack.FindPosition(1).Should().Be(1);
        }

        [Test]
        public void WhenFindingUnexistingElementPositionThenItShouldReturnNull()
        {
            _boundedStack.Push(1);
            _boundedStack.FindPosition(2).Should().Be(null);
        }
    }
}
