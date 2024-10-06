using System;
using System.Collections.Generic;

public interface ICloneable
{
    void DoClone();
}
public abstract class BaseClone
{
    public abstract void DoClone();
}
public interface IEdible
{
    void Eat();
}
public abstract class CandyProduct : BaseClone, ICloneable, IEdible
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public CandyProduct(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}");
    }

    public override void DoClone()
    {
        Console.WriteLine("DoCloneMethod");
    }

    public abstract void Eat();

    public override string ToString()
    {
        return $"Type: {GetType()}, name: {Name}, Weight: {Weight}";
    }

    public override bool Equals(object obj)
    {
        return obj is CandyProduct other && Name == other.Name && Weight == other.Weight;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Name.GetHashCode();
        hash = hash * 23 + Weight.GetHashCode();
        return hash;
    }
}

public class Candy : CandyProduct
{
    public string Flavor { get; set; }

    public Candy(string name, double weight, string flavor) : base(name, weight)
    {
        Flavor = flavor;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}, Flavor: {Flavor}");
    }

    public override string ToString()
    {
        return $"Type: {GetType()}, name: {Name}, Weight: {Weight}";
    }

    public override void Eat()
    {
        Console.WriteLine($"You are eating {Flavor} flavored candy");
    }
}

public class Caramel : Candy
{
    public Caramel(string name, double weight, string flavor) : base(name, weight, flavor) { }

    public override void Eat()
    {
        Console.WriteLine($"You are eating {Flavor} flavored caramel");
    }
}

public class ChocolateCandy : Candy
{
    public ChocolateCandy(string name, double weight, string flavor) : base(name, weight, flavor) { }
}

public sealed class Cookie : CandyProduct
{
    public string Flavor { get; set; }

    public Cookie(string name, double weight, string flavor) : base(name, weight)
    {
        Flavor = flavor;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}, Flavor: {Flavor}");
    }

    public override void Eat()
    {
        Console.WriteLine($"You are eating {Flavor} flavored cookie.");
    }
}

public class BoxOfCandy
{
    List<CandyProduct> Candies { get; set; } = new List<CandyProduct>();

    public void AddCandy(CandyProduct candy)
    {
        Candies.Add(candy);
    }

    public void DisplayCandies()
    {
        foreach (CandyProduct candy in Candies)
        {
            candy.DisplayInfo();
        }
    }
}

public class Printer
{
    public void IAmPrinting(CandyProduct candyProduct)
    {
        Console.WriteLine(candyProduct.ToString());
    }


}

namespace OOP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CandyProduct caramel = new Caramel("Toffee", 10, "Caramel");
            CandyProduct chocolate = new ChocolateCandy("Milk Chocolate", 15, "Chocolate");
            CandyProduct cookie = new Cookie("Chocolate Chip Cookie", 20, "Chocolate Chip");

            BoxOfCandy candyBox = new BoxOfCandy();

            candyBox.AddCandy(caramel);
            candyBox.AddCandy(chocolate);
            candyBox.AddCandy(cookie);

            candyBox.DisplayCandies();
            
            Console.WriteLine();

            if (caramel is Candy)
            {
                Console.WriteLine("The caramel is a type of Candy");
            }


            if (chocolate as ChocolateCandy != null)
            {
                Console.WriteLine("The chocolate is a type of ChocolateCandy");
            }

            
            Console.WriteLine();

            CandyProduct[] candyProducts = { caramel, chocolate, cookie };

            Printer printer = new Printer();

            foreach (CandyProduct product in candyProducts)
            {
                printer.IAmPrinting(product);
            }
        }
    }
}
