using System;
using System.Collections.Generic;
using System.Linq;

class Topping
{
    public string Name { get; }
    public double Price { get; }

    public Topping(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class Pizza
{
    public string Size { get; }
    public double BasePrice { get; }
    private readonly List<Topping> toppings = new();

    public Pizza(string size, double basePrice)
    {
        Size = size;
        BasePrice = basePrice;
    }

    public void AddTopping(Topping topping)
    {
        toppings.Add(topping);
    }

    public double CalculatePrice()
    {
        return BasePrice + toppings.Sum(t => t.Price);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"pizza {Size}, baza: {BasePrice} zl");
        if (toppings.Count > 0)
        {
            Console.WriteLine("dodatki:");
            foreach (var t in toppings)
                Console.WriteLine($" - {t.Name} ({t.Price} zl)");
        }
        else
        {
            Console.WriteLine("Brak dodatkow");
        }
        Console.WriteLine($"calkowita cena: {CalculatePrice()} zl\n");
    }
}

class Order
{
    private readonly List<Pizza> pizzas = new();

    public void AddPizza(Pizza pizza)
    {
        pizzas.Add(pizza);
    }

    public double CalculateTotal()
    {
        return pizzas.Sum(p => p.CalculatePrice());
    }

    public void DisplaySummary()
    {
        Console.WriteLine("Podsumowanie:");
        for (int i = 0; i < pizzas.Count; i++)
        {
            Console.WriteLine($"Pizza #{i + 1}:");
            pizzas[i].DisplayInfo();
        }
        Console.WriteLine($"Do zaplaty: {CalculateTotal()} zl");
    }
}

class Program
{
    static void Main()
    {
        var cheese = new Topping("ser", 3.0);
        var ham = new Topping("szynka", 4.0);
        var mushrooms = new Topping("pieczarki", 2.5);

        var pizza1 = new Pizza("M", 20.0);
        pizza1.AddTopping(cheese);
        pizza1.AddTopping(ham);

        var pizza2 = new Pizza("L", 25.0);
        pizza2.AddTopping(mushrooms);

        var order = new Order();
        order.AddPizza(pizza1);
        order.AddPizza(pizza2);

        order.DisplaySummary();
    }
}

