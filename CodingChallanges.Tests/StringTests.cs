using CodingChallenges.Strings;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenges.Tests;

[TestClass]
public class StringTests
{
    [TestMethod]
    [DataRow(1, "1 * 1 = 1\n2 * 1 = 2\n3 * 1 = 3\n4 * 1 = 4\n5 * 1 = 5\n6 * 1 = 6\n7 * 1 = 7\n8 * 1 = 8\n9 * 1 = 9\n10 * 1 = 10")]
    [DataRow(5, "1 * 5 = 5\n2 * 5 = 10\n3 * 5 = 15\n4 * 5 = 20\n5 * 5 = 25\n6 * 5 = 30\n7 * 5 = 35\n8 * 5 = 40\n9 * 5 = 45\n10 * 5 = 50")]
    public void MultiTable_ReturnsExpectedResult(int number, string expectedOutput)
    {
        MultiplicationTable.MultiTable(number).Should().BeEquivalentTo(expectedOutput);
    }

    [TestMethod]
    [DataRow(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "3:1", "4:1", "3:2", "4:2", "4:3" }, 30)]
    [DataRow(new[] { "1:1", "2:2", "3:3", "4:4", "2:2", "3:3", "4:4", "3:3", "4:4", "4:4" }, 10)]
    public void TotalPoints_ReturnsExpectedResult(string[] games, int expectedOutput)
    {
        TotalPoints.GetTotalPoints(games).Should().Be(expectedOutput);
    }
}
