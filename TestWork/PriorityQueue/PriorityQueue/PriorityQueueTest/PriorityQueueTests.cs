/* Copyright 2023-2024 Aleksey Poziev
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. */

using PriorityQueue;

namespace PriorityQueueTests;

public class PriorityQueueTests
{
    [TestCase(true)]
    [TestCase(false, 1)]
    public void EmptyShouldReturnExpectedResult(bool expectedResult, params int[] elementsToAdd)
    {
        var queue = new PriorityQueue<int>();
        foreach (var element in elementsToAdd)
        {
            queue.Enqueue(element, element);
        }

        Assert.That(queue.Empty, Is.EqualTo(expectedResult));
    }

    [Test]
    public void DequeueFromEmptyQueueuShouldThrowsInvalidOperationException()
    {
        var queue = new PriorityQueue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Test]
    public void EnqueueAndDequeueShouldPerformExpectedResult()
    {
        var priorityQueue = new PriorityQueue<int>();
        var expectedResult = new List<int>() { 0, 7, 6, 5, 10 };

        priorityQueue.Enqueue(0, 3);
        priorityQueue.Enqueue(5, 1);
        priorityQueue.Enqueue(10, 1);
        priorityQueue.Enqueue(6, 2);
        priorityQueue.Enqueue(7, 3);

        var actualResult = new List<int>();
        while (!priorityQueue.Empty)
        {
            actualResult.Add(priorityQueue.Dequeue());
        }

        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
}