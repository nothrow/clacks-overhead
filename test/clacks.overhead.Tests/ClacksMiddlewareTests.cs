using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace clacks.overhead.Tests
{
#pragma warning disable CS1701 // Assuming assembly reference matches identity
    public class ClacksMiddlewareTests
    {
        public ClacksMiddlewareTests()
        {
            _onNext = _ =>
            {
                Interlocked.Increment(ref _onNextCalledTimes);
                return _onNextResult;
            };
            _context = new DefaultHttpContext();
        }

        private int _onNextCalledTimes;
        private readonly Task _onNextResult = Task.FromResult(0);
        private readonly RequestDelegate _onNext;
        private readonly DefaultHttpContext _context;

        [Fact]
        public async Task Invoke_AddsHeader()
        {
            // arrange
            var clacks = new ClacksMiddleware(_onNext);

            // act
            await clacks.Invoke(_context);

            // assert
            _context.Response.Headers.Should()
                .Contain("X-Clacks-Overhead", new StringValues("GNU Terry Pratchett"),
                    "purpose of the middleware is to add the header");
        }

        [Fact]
        public async Task Invoke_CallsOnNext()
        {
            // arrange
            var clacks = new ClacksMiddleware(_onNext);

            // act
            await clacks.Invoke(_context);

            // assert
            _onNextCalledTimes.Should().Be(1, "onNext was called exactly once");
        }

        [Fact]
        public async Task Invoke_HandlesCalledTwice()
        {
            // arrange
            var clacks = new ClacksMiddleware(_onNext);
            await clacks.Invoke(_context);

            // act
            Func<Task> action = () => clacks.Invoke(_context);

            // assert
            action.ShouldNotThrow("Invoke handled ArgumentException properly");
        }

        [Fact]
        public void Invoke_ChecksHttpContextForNull()
        {
            // arrange
            var clacks = new ClacksMiddleware(_onNext);

            // act
            // ReSharper disable once AssignNullToNotNullAttribute testing the check
            Func<Task> action = () => clacks.Invoke(null);

            // assert
            action.ShouldThrow<ArgumentNullException>("Invoke checked parameter for null");
        }
    }
}
