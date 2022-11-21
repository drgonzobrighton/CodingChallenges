using CodingChallenges.Collections;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenges.Tests;

[TestClass]
public class CollectionsTests
{
    [TestMethod]
    [DataRow(new[] { -1, -2, -3, -4, -5 }, new[] { 1, 2, 3, 4, 5 })]
    [DataRow(new[] { -1, 2, -3, 4, -5 }, new[] { 1, -2, 3, -4, 5 })]
    [DataRow(new int[] { }, new int[] { })]
    [DataRow(new[] { 0 }, new[] { 0 })]
    public void ArrayInversion_ReturnsExpectedResult(int[] input, int[] expectedOutput)
    {
        ArraysInversion.InvertValues(input).Should().BeEquivalentTo(expectedOutput);
    }

    [TestMethod]
    [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 }, new[] { 10, -65 })]
    [DataRow(new[] { 0, 2, 3, 0, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14 }, new[] { 8, -50 })]
    [DataRow(null, new int[] { })]
    [DataRow(new int[] { }, new int[] { })]
    public void CountPositivesSumNegatives_ReturnsExpectedResult(int[] input, int[] expectedOutput)
    {
        CountPositivesSumNegatives.Execute(input).Should().BeEquivalentTo(expectedOutput);
    }

    [TestMethod]
    [DataRow(35231, new long[] { 1, 3, 2, 5, 3 })]
    [DataRow(45762893920, new long[] { 0, 2, 9, 3, 9, 8, 2, 6, 7, 5, 4 })]
    [DataRow(548702838394, new long[] { 4, 9, 3, 8, 3, 8, 2, 0, 7, 8, 4, 5 })]
    [DataRow(0, new long[] { 0 })]
    public void Digitizer_ReturnsExpectedResult(long input, long[] expectedOutput)
    {
        Digitizer.Digitize(input).Should().BeEquivalentTo(expectedOutput);
    }

}
