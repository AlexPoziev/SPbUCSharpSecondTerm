// "Licensed to the Apache Software Foundation (ASF) under one or more contributor license agreements;
// and tos You under the Apache License, Version 2.0. "

namespace LINQMinusMinus;

using MapFilterFold;

public class Tests
{
    [Test]
    public static void MapWithSameInAndOutIntTypeShouldReturnExpectedValue() 
    {
        var originalList = new List<int>() { 1, 2, 3 };
        var expectedResult = new List<int>() { 2, 4, 6 };
        var expression = (int it) => it * 2;

        Assert.That(LINQMinusMinus.Map(originalList, expression), Is.EqualTo(expectedResult));
    }

    [Test]
    public static void MapWithSameInAndOutStringTypeShouldReturnExpectedValue()
    {
        var originalList = new List<string>() { "1", "2", "3" };
        var expectedResult = new List<string>() { "11", "21", "31" };
        var expression = (string it) => it + "1";

        Assert.That(LINQMinusMinus.Map(originalList, expression), Is.EqualTo(expectedResult));
    }

    [Test]
    public static void MapWithDifferentInAndOutIntTypeShouldReturnExpectedValue()
    {
        var originalList = new List<int>() { 1, 2, 3 };
        var expectedResult = new List<string>() { "1", "2", "3" };
        var expression = (int it) => it.ToString();

        Assert.That(LINQMinusMinus.Map(originalList, expression), Is.EqualTo(expectedResult));
    }

    [Test]
    public static void MapWithEmptyListShouldReturnEmptyList()
    {
        var originalList = new List<int>();
        var expression = (int it) => it.ToString();

        Assert.That(!LINQMinusMinus.Map(originalList, expression).Any());
    }

    [Test]
    public static void FilterShouldReturnExpectedValue()
    {
        var originalList = new List<int>() { 1, 2, 3, 5, 14, 10 };
        var expectedResult = new List<int>() { 2, 14, 10 };
        var expression = (int it) => it % 2 == 0;

        Assert.That(LINQMinusMinus.Filter(originalList, expression), Is.EqualTo(expectedResult));
    }

    [Test]
    public static void FilterEmptyListShouldReturnEmptyList()
    {
        var originalList = new List<int>();
        var expression = (int it) => it == 2;

        Assert.That(!LINQMinusMinus.Filter(originalList, expression).Any());
    }

    [Test]
    public static void FoldEmptyListShouldReturnAccumulatorWithoutChanges()
    {
        var originalList = new List<int>();
        var accumulator = 10;
        var expression = (int it, int acc) => it * 2 + accumulator;

        Assert.That(LINQMinusMinus.Fold(originalList, accumulator, expression), Is.EqualTo(accumulator));
    }

    [Test]
    public static void FoldWithDifferentAccumulatorAndListTypesShouldReturnExpectedResult()
    {
        var originalList = new List<string>() { "1", "2", "3" };
        var accumulator = 10;
        var expression = (int currentValue, string it) => int.Parse(it) * 2 + currentValue;
        var expectedResult = 22;

        Assert.That(LINQMinusMinus.Fold(originalList, accumulator, expression), Is.EqualTo(expectedResult));
    }

    [Test]
    public static void FoldWithSameAccumulatorAndListTypesShouldReturnExpectedResult()
    {
        var originalList = new List<int>() { 1, 2, 3 };
        var accumulator = 10;
        var expression = (int currentValue, int it) => it * 2 + currentValue;
        var expectedResult = 22;

        Assert.That(LINQMinusMinus.Fold(originalList, accumulator, expression), Is.EqualTo(expectedResult));
    }
}
