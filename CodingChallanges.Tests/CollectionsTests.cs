using CodingChallanges.Collections;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallanges.Tests;

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
}
