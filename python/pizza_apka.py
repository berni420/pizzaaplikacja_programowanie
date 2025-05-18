class Topping:
    def __init__(self, name, price):
        self.name = name
        self.price = price


class Pizza:
    def __init__(self, size, base_price):
        self.size = size
        self.base_price = base_price
        self.toppings = []

    def add_topping(self, topping):
        self.toppings.append(topping)

    def calculate_price(self):
        return self.base_price + sum(t.price for t in self.toppings)

    def display_info(self):
        print(f"pizza {self.size}, baza: {self.base_price} zl")
        if self.toppings:
            print("dodatki:")
            for t in self.toppings:
                print(f" - {t.name} ({t.price} zl)")
        else:
            print("brak dodatkow")
        print(f"full cena: {self.calculate_price()} zl\n")


class Order:
    def __init__(self):
        self.pizzas = []

    def add_pizza(self, pizza):
        self.pizzas.append(pizza)

    def calculate_total(self):
        return sum(p.calculate_price() for p in self.pizzas)

    def display_summary(self):
        print("Podsumowanie:")
        for i, pizza in enumerate(self.pizzas, 1):
            print(f"Pizza #{i}:")
            pizza.display_info()
        print(f"Do zaplaty: {self.calculate_total()} zl")


# Test
if __name__ == "__main__":
    cheese = Topping("ser", 3.0)
    ham = Topping("szynka", 4.0)
    mushrooms = Topping("pieczarki", 2.5)

    pizza1 = Pizza("M", 20.0)
    pizza1.add_topping(cheese)
    pizza1.add_topping(ham)

    pizza2 = Pizza("L", 25.0)
    pizza2.add_topping(mushrooms)

    order = Order()
    order.add_pizza(pizza1)
    order.add_pizza(pizza2)

    order.display_summary()
