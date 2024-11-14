//using static System.Net.Mime.MediaTypeNames;
//using System.Text;

//sing System.Text;

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var fraction1 = new Fraction(2, 5);
        var fraction2 = new Fraction(4, 5);
        var result = fraction1 + fraction2;

        Console.WriteLine(result.ToString());
    }
}

public class Fraction
{
    private double _numerator;
    private double _denominator;

    public Fraction(double numerator, double denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException();

        _numerator = numerator;
        _denominator = denominator;
    }

    public static Fraction operator +(Fraction fraction1, Fraction fraction2)
    {
        var denominator = LCM((int)fraction1._denominator, (int)fraction2._denominator);
        var numerator = (denominator / fraction1._denominator * fraction1._numerator) + (denominator / fraction2._denominator * fraction2._numerator);
        var gcd = GCD(denominator, (int)numerator);

        return new Fraction(numerator / gcd, denominator / gcd);
    }

    public static bool operator ==(Fraction fraction1, Fraction fraction2)
    {
        return (fraction1._numerator == fraction2._numerator) && (fraction1._denominator == fraction2._denominator);
    }

    public static bool operator !=(Fraction fraction1, Fraction fraction2)
    {
        return !(fraction1 == fraction2);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(_numerator);
        stringBuilder.Append('/');
        stringBuilder.Append(_denominator);

        return stringBuilder.ToString();
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }
}