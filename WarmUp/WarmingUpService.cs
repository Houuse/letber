using System.Text;

namespace WarmUp;

public class WarmingUpService
{
    public static bool IsPowerOfTwo(int bookId)
    {
        if (bookId < 1)
        {
            return false;
        }
        else if (bookId == 1)
        {
            return true;
        }
        else if (bookId % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string ReverseString(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return title;
        }
        else
        {
            return new string(title.ToCharArray().Reverse().ToArray());
        }
    }

    public static string ReplicateString(string title, int numberOfReplicas)
    {
        if (numberOfReplicas == 0)
        {
            return "";
        }
        else if (numberOfReplicas == 1)
        {
            return title;
        }
        else
        {
            var sb = new StringBuilder(title.Length * numberOfReplicas);
            
            for (int i = 0; i < numberOfReplicas; i++)
            {
                sb.Append(title);
            }
            return sb.ToString();
        }
    }
}