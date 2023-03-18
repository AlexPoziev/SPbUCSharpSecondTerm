using System.Collections.Generic;
using Lists;

var list = new Lists.UniqueList<int>();

var data = new int[] { 1, 2, 3, 4, 5 };

var position = new int[] { 0, 1, 2, 1, 0 };

for (var i = 0; i < data.Length; ++i)
{
    list.Add(position[i], data[i]);
}

var ewkere = 0;
