using System;
using System.Collections.Generic;
using System.Linq;

public enum CandyType
{
    Hard,
    Soft,
    Chewy,
    Gummy
}

public struct CandyPackaging
{
    public string Material { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public CandyPackaging(string material, double width, double height)
    {
        Material = material;
        Width = width;
        Height = height;
    }

    public override string ToString()
    {
        return $"Material: {Material}, Width: {Width} cm, Height: {Height} cm";
    }
}

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
    public CandyType Type { get; set; }  
    public CandyPackaging Packaging { get; set; }  
    public double SugarContent { get; set; }

    public CandyProduct(string name, double weight, CandyType type, CandyPackaging packaging, double sugarContent)
    {
        Name = name;
        Weight = weight;
        Type = type;
        Packaging = packaging;
        SugarContent = sugarContent;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}, Type: {Type}, Packaging: {Packaging}");
    }

    public override void DoClone()
    {
        Console.WriteLine("DoCloneMethod");
    }

    public abstract void Eat();

    public override string ToString()
    {
        return $"Type: {GetType()}, Name: {Name}, Weight: {Weight}, Candy Type: {Type}, Packaging: {Packaging}";
    }

    public override bool Equals(object obj)
    {
        return obj is CandyProduct other && Name == other.Name && Weight == other.Weight && Type == other.Type;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Name.GetHashCode();
        hash = hash * 23 + Weight.GetHashCode();
        hash = hash * 23 + Type.GetHashCode();
        return hash;
    }
}

public class Candy : CandyProduct
{
    public string Flavor { get; set; }

    public Candy(string name, double weight, string flavor, CandyType type, CandyPackaging packaging, double sugarContent)
        : base(name, weight, type, packaging, sugarContent)
    {
        Flavor = flavor;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}, Flavor: {Flavor}, Type: {Type}, Packaging: {Packaging}");
    }

    public override void Eat()
    {
        Console.WriteLine($"You are eating {Flavor} flavored candy");
    }
}

public class Caramel : Candy
{
    public Caramel(string name, double weight, string flavor, CandyPackaging packaging, double sugarContent)
        : base(name, weight, flavor, CandyType.Chewy, packaging, sugarContent) { }

    public override void Eat()
    {
        Console.WriteLine($"You are eating {Flavor} flavored caramel");
    }
}

public class ChocolateCandy : Candy
{
    public ChocolateCandy(string name, double weight, string flavor, CandyPackaging packaging, double sugarContent)
        : base(name, weight, flavor, CandyType.Soft, packaging, sugarContent) { }
}

public sealed class Cookie : CandyProduct
{
    public string Flavor { get; set; }

    public Cookie(string name, double weight, string flavor, CandyPackaging packaging, double sugarContent)
        : base(name, weight, CandyType.Soft, packaging, sugarContent)
    {
        Flavor = flavor;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}, Flavor: {Flavor}, Packaging: {Packaging}");
    }

    public override void Eat()
    {
        Console.WriteLine($"You are eating {Flavor} flavored cookie.");
    }
}

public class Printer
{
    public void IAmPrinting(CandyProduct candyProduct)
    {
        Console.WriteLine(candyProduct.ToString());
    }
}

public class ChildrensGift
{
    private List<CandyProduct> candies = new List<CandyProduct>();


    public void AddCandy(CandyProduct candy)
    {
        candies.Add(candy);
    }

    public void RemoveCandy(CandyProduct candy)
    {
        candies.Remove(candy); 
    }

    public void DisplayAllCandies()
    {
        foreach (CandyProduct candy in candies) 
        {
            candy.DisplayInfo();
        }
    }

    public double GetTotalWeight()
    {
        return candies.Sum(candy => candy.Weight);
    }

    public void SortCandies()
    {
        candies = candies.OrderBy(candy => candy.Weight).ToList();
    }

    public void FindCandyBySugarContent(double minSugar, double maxSugar)
    {
        var foundCandies = candies.Where(candy => candy.SugarContent >= minSugar && candy.SugarContent <= maxSugar).ToList();

        if (foundCandies.Any())
        {
            Console.WriteLine($"Candies with sugar content between {minSugar}% and {maxSugar}%:");
            foreach (var candy in foundCandies)
            {
                candy.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("No candies found.");
        }
    }
}

public class GiftController
{
    private ChildrensGift giftBox;

    public GiftController(ChildrensGift gift)
    {
        giftBox = gift;
    }

    public void AddCandy(CandyProduct candy)
    {
        giftBox.AddCandy(candy);
    }

    public void RemoveCandy(CandyProduct candy)
    {
        giftBox.RemoveCandy(candy);
    }

    public void DisplayAllCandies()
    {
        giftBox.DisplayAllCandies();
    }

    public void SortCandiesByWeight()
    {
        giftBox.SortCandies();
    }

    public void FindCandyBySugarContent(double minSugar, double maxSugar)
    {
        giftBox.FindCandyBySugarContent(minSugar, maxSugar);
    }


    public double GetTotalWeight()
    {
        return giftBox.GetTotalWeight();
    }
}

namespace OOP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CandyPackaging caramelPackaging = new CandyPackaging("Plastic", 5, 2);
            CandyProduct caramel = new Caramel("Toffee", 25, "Caramel", caramelPackaging, 15);

            CandyPackaging chocolatePackaging = new CandyPackaging("Foil", 6, 3);
            CandyProduct chocolate = new ChocolateCandy("Milk Chocolate", 15, "Chocolate", chocolatePackaging, 20);

            CandyPackaging cookiePackaging = new CandyPackaging("Paper", 7, 1.5);
            CandyProduct cookie = new Cookie("Chocolate Chip Cookie", 20, "Chocolate Chip", cookiePackaging, 10);

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


            Console.WriteLine("================");

            ChildrensGift childrenGift = new ChildrensGift();

            childrenGift.AddCandy(caramel);
            childrenGift.AddCandy(chocolate);
            childrenGift.AddCandy(cookie);

            Console.WriteLine("All candies:");
            childrenGift.DisplayAllCandies();

            Console.WriteLine($"Total weight of the gift box: {childrenGift.GetTotalWeight()}g");

            childrenGift.SortCandies();
            Console.WriteLine("Sorted candies:");
            childrenGift.DisplayAllCandies();

            Console.WriteLine("Finding candies with sugar content between 10% and 45%:");
            childrenGift.FindCandyBySugarContent(10, 15);
        }


    }
}
