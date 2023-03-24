namespace Routers;

public class Link : IComparable<Link>
{
    public Link(int firstnumber, int secondNumber, int value)
    {
        FirstNodeNumber = firstnumber;
        SecondNodeNumber = secondNumber;
        LinkValue = value;
    }

    public int FirstNodeNumber { get; }

    public int SecondNodeNumber { get; }

    public int LinkValue { get; }

    public int CompareTo(Link? link)
    {
        if (link == null)
        {
            throw new ArgumentNullException(nameof(link));
        }

        return LinkValue.CompareTo(link.LinkValue);
    }
}