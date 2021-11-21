using System;
namespace FlyweightPattern
{
    // Run in VS Debug Console
    class Program{
        static void Main(string[] args){
            var drinkFactory = new DrinkFactory();

            var largeEspresso = drinkFactory.GetDrink("Espresso");
            largeEspresso.Serve("Large");

            var mediumMangoLassi = drinkFactory.GetDrink("Mango Lassi");
            mediumMangoLassi.Serve("Medium");

            // The real power of Flyweight pattern appears when you request a drink object that has already been cached: it will be served with no object creation memory footprint.
            // The existing cached drink is used to share its intrinsic name while accepting an extrinsic size.
            var smallEspresso = drinkFactory.GetDrink("Espresso");
            largeEspresso.Serve("Small");

            drinkFactory.ListDrinks();

            // Giveaway test: comment out above code
            var sizes = new string[] {"Small", "Medium", "Large"};
            foreach(var size in sizes){
                var giveaway = drinkFactory.CreateGiveaway();
                giveaway.Serve(size);
            }
        }
    }
}