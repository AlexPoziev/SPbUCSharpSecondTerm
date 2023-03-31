namespace MapFilterFold;

public static class LINQMinusMinus
{
    public static List<R> Map<T, R>(List<T> list, Func<T, R> expression)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        var result = new List<R>();

        foreach (var element in list)
        {
            result.Add(expression(element));
        }

        return result;
    }

    public static List<T> Filter<T>(List<T> list, Func<T, bool> expression)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        var result = new List<T>();

        foreach (var element in list)
        {
            if (expression(element))
            {
                list.Add(element);
            }
        }

        return result;
    }

    public static TAccumulator Fold<TElement, TAccumulator>(List<TElement> list, TAccumulator accumulator, Func<TAccumulator, TElement, TAccumulator> expression)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        var result = accumulator;

        foreach (var element in list)
        {
            result = expression(accumulator, element);
        }

        return result;
    }
}

