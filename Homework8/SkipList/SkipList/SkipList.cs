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

namespace Lists;

using System.Collections;

/// <summary>
/// Class that implement Skip list data struct, that takes advantages of list and array.
/// </summary>
/// <typeparam name="T">Type of Skip list elements</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable
{
    private readonly SkipListNode tail = new (default, Array.Empty<SkipListNode>());

    private SkipListNode head = new (default, new SkipListNode[1]);

    private int currentListVersion;

    /// <inheritdoc/>
    bool ICollection<T>.IsReadOnly => false;

    /// <inheritdoc/>
    public bool Contains(T value)
    {
        var resultOfSearch = GetPreviousOfSearchedByValue(value);

        return resultOfSearch[0].Next[0] != tail && value.CompareTo(resultOfSearch[0].Next[0].Value) == 0;
    }

    /// <inheritdoc/>
    public void Insert(int index, T value)
            => throw new NotSupportedException("Insert by a specific index not supported in Skip List data struct");

    /// <inheritdoc/>
    public void Add(T value)
    {
        var previousNodes = GetPreviousOfSearchedByValue(value);

        var newNodeSize = GetRandomSkipListNodeHeight();

        var newSkipListNode = new SkipListNode(value, new SkipListNode[newNodeSize]);

        for (int i = 0; i < newNodeSize && i < head.Next.Length; ++i)
        {
            newSkipListNode.Next[i] = previousNodes[i].Next[i];
            previousNodes[i].Next[i] = newSkipListNode;
        }

        if (newNodeSize > head.Next.Length)
        {
            var newHeadNext = new SkipListNode(default, new SkipListNode[newNodeSize]);
            head.Next.CopyTo(newHeadNext.Next, 0);
            newHeadNext.Next[newNodeSize - 1] = newSkipListNode;
            head = newHeadNext;

            newSkipListNode.Next[newNodeSize - 1] = tail;
        }

        ++currentListVersion;
        ++Count;
    }

    /// <inheritdoc/>
    public bool Remove(T value)
    {
        var resultOfSearch = GetPreviousOfSearchedByValue(value);

        var nextNode = resultOfSearch[0].Next[0];

        if (nextNode != tail && value.CompareTo(nextNode.Value) == 0)
        {
            for (int i = 0; i < nextNode.Next.Length; ++i)
            {
                resultOfSearch[i].Next[i] = nextNode.Next[i];
            }

            --Count;
            ++currentListVersion;

            return true;
        }

        return false;
    }

    /// <inheritdoc/>
    public void Clear()
    {
        head = new(default, new SkipListNode[1]);
        head.Next[0] = tail;

        ++currentListVersion;

        Count = 0;
    }

    private int GetRandomSkipListNodeHeight()
    {
        const int increaseNumber = 1;

        var random = new Random();

        var currentSize = 1;

        while (currentSize <= head.Next.Length)
        {
            if (random.Next(0, 2) != increaseNumber)
            {
                break;
            }

            ++currentSize;
        }

        return currentSize;
    }

    /// <inheritdoc/>
    public int IndexOf(T value)
    {
        var currentNode = head.Next[0];

        var currentIndex = 0;

        while (currentNode != tail)
        {
            if (value.CompareTo(currentNode.Value) == 0)
            {
                return currentIndex;
            }

            currentNode = currentNode.Next[0];

            ++currentIndex;
        }

        return -1;
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
            => Remove(this[index]);

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(array), "Array index less than zero");
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Skip List larger than gap to copy in.", nameof(arrayIndex));
        }

        var currentNode = head.Next[0];

        var currentIndex = arrayIndex;

        while (currentNode != tail)
        {
            array[currentIndex] = currentNode.Value ?? throw new InvalidOperationException("List contains null");

            currentNode = currentNode.Next[0];
            ++currentIndex;
        }
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public class Enumerator : IEnumerator<T>
    {
        private readonly int enumeratorListVersion;

        SkipListNode currentNode;

        private readonly SkipList<T> skipList;

        public Enumerator(SkipList<T> skipList)
        {
            this.skipList = skipList ?? throw new ArgumentNullException(nameof(skipList));

            enumeratorListVersion = skipList.currentListVersion;

            currentNode = skipList.head;
        }

        /// <inheritdoc/>
        public T Current
        {
            get
            {
                if (currentNode == skipList.head)
                {
                    throw new InvalidOperationException("Can't to get current before the first MoveNext");
                }

                return currentNode.Value!;
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current => Current;

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (enumeratorListVersion != skipList.currentListVersion)
            {
                throw new InvalidOperationException("After the enumerator was created, the data struct was changed.");
            }

            if (currentNode == skipList.tail || currentNode.Next[0] == skipList.tail)
            {
                return false;
            }

            currentNode = currentNode.Next[0];

            return true;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            if (enumeratorListVersion != skipList.currentListVersion)
            {
                throw new InvalidOperationException("After the enumerator was created, the data struct was changed.");
            }

            currentNode = skipList.head;
        }
    }

    /// <inheritdoc/>
    public int Count { get; private set; } = 0;

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = head.Next[0];

            for (int i = 0; i < index; ++i)
            {
                currentNode = currentNode.Next[0];
            }

            return currentNode.Value!;
        }
        set => throw new NotSupportedException("Can't change value by indexer.");
    }

    private SkipListNode[] GetPreviousOfSearchedByValue(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), "Can't to add null in list");
        }

        var currentNode = head;

        var lastLevelPreviousNodesList = new SkipListNode[head.Next.Length];

        for (var currentLevel = head.Next.Length - 1; currentLevel >= 0; --currentLevel)
        {
            var compareResult = value.CompareTo(currentNode.Next[currentLevel].Value);
            while (compareResult == 1 && currentNode.Next[currentLevel] != tail)
            {
                currentNode = currentNode.Next[currentLevel];
                compareResult = value.CompareTo(currentNode.Next[currentLevel].Value);
            }

            lastLevelPreviousNodesList[currentLevel] = currentNode;
        }

        return lastLevelPreviousNodesList;
    }

    private record SkipListNode(T? Value, SkipListNode[] Next);

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    public SkipList()
    {
        head.Next[0] = tail;
    }
}