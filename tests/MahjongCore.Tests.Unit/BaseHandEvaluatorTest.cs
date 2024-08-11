namespace MahjongCore.Tests.Unit;

using Application;
using Domain.Models;
using FluentAssertions;
using TestSets.Common;
using Xunit;

public class BaseHandEvaluatorTest
{
    private readonly BaseHandEvaluator _sut;

    public BaseHandEvaluatorTest()
    {
        _sut = new BaseHandEvaluator();
    }

    /*[Theory]
    [ClassData(typeof(BaseHandEvaluatorWhenItExists))]
    public void Run_ReturnsExpectedYaku_WhenItExists(GameState state, List<Yaku> expected)
    {
        // Act
        var result = _sut.Run(state);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }*/
}