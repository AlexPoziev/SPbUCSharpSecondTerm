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

namespace PriorityQueue;

/// <summary>
/// Priority queue, a containter for integers values
/// with int value of priority.
/// elements with high priority are served before elements with low priority.
/// </summary>
/// <typeparam name="T">Type of PriorityQueue elements.</typeparam>
public class PriorityQueue<T>
{
    private PriorityQueueElement? head;

    /// <summary>
    /// Gets a value indicating whether queue is empty.
    /// </summary>
    public bool Empty => head == null;

    /// <summary>
    /// Method to add value to priority queue.
    /// </summary>
    /// <param name="value">Value that need to be added in queue.</param>
    /// <param name="priority">Priority of value, with which it will be added to priority queue.</param>
    public void Enqueue(T value, int priority)
    {
        var newElement = new PriorityQueueElement(value, priority);

        if (head == null)
        {
            head = newElement;

            return;
        }

        var elementToAddAfterIt = LastElementWithPriorityMoreThanOrEqualsGiven(priority);

        if (elementToAddAfterIt == null)
        {
            newElement.NextElement = head;
            head = newElement;
        }
        else
        {
            newElement.NextElement = elementToAddAfterIt.NextElement;
            elementToAddAfterIt.NextElement = newElement;
        }
    }

    /// <summary>
    /// Method to get value from queue by its priority. From more to less.
    /// </summary>
    /// <returns>the value with the highest priority.</returns>
    /// <exception cref="InvalidOperationException">Can't to get value from empty queue.</exception>
    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Can't to get value from empty queue");
        }

        var result = head.Value;
        head = head.NextElement;

        return result;
    }

    private PriorityQueueElement? LastElementWithPriorityMoreThanOrEqualsGiven(int priority)
    {
        if (head == null)
        {
            return null;
        }

        var currentElement = head;
        PriorityQueueElement? previousElement = null;

        while (currentElement != null && currentElement.Priority >= priority)
        {
            previousElement = currentElement;
            currentElement = currentElement.NextElement;
        }

        return previousElement;
    }

    private class PriorityQueueElement
    {
        public PriorityQueueElement(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public T Value { get; }

        public int Priority { get; }

        public PriorityQueueElement? NextElement { get; set; }
    }
}