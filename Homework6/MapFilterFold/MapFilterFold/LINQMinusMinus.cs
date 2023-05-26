namespace MapFilterFold;

/// <summary>
/// Class that performs methods to transform lists
/// </summary>
public static class LINQMinusMinus
{
    /// <summary>
    /// Method that thansform every element of list by expression.
    /// </summary>
    /// <typeparam name="T">Type of origin list elements.</typeparam>
    /// <typeparam name="R">Type of result of the expression.</typeparam>
    /// <param name="list">Original list, with which will create new list.</param>
    /// <param name="expression">function that transforms list elements.</param>
    /// <returns>The list obtained by applying the passed function to each element of the passed list</returns>
    /// <exception cref="ArgumentNullException">list and expression can't be null.</exception>
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

    /// <summary>
    /// Method to remain in list only elements, which expression return true.
    /// </summary>
    /// <typeparam name="T">Type of list's elements</typeparam>
    /// <param name="list">Original list</param>
    /// <param name="expression">Func that take T argument and return bool result</param>
    /// <returns>a list made up of those elements of the passed list for which the passed expression returned true.</returns>
    /// <exception cref="ArgumentNullException">list and expression can't be null</exception>
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
                result.Add(element);
            }
        }

        return result;
    }

    /// <summary>
    /// Method to compute new number by expression, accumulator and given list
    /// </summary>
    /// <typeparam name="T">Type of list's elements</typeparam>a
    /// <typeparam name="A">Type of accumulator</typeparam>
    /// <param name="list">Given List</param>
    /// <param name="accumulator">current accumulated value</param>
    /// <param name="expression">function that takes A and T arguments and returns new A value.</param>
    /// <returns><the accumulated value obtained after the entire passage of the list./returns>
    /// <exception cref="ArgumentNullException">list and expression can't be null.</exception>
    public static A Fold<T, A>(List<T> list, A accumulator, Func<A, T, A> expression)
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
            result = expression(result, element);
        }

        return result;
    }
}

