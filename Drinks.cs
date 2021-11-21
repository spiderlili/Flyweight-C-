using System;
using System.Collections.Generic.
using System.Text;

namespace FlyweightPattern
{
    // Implement the Flyweight interface blueprint
    public interface IDrinkFlyweight
    {
        // Intrinsic state - shared / readonly private. Example: each drink has an intrinsic name & ingredidents list
        string Name { get; } 
        // Extrinsic state: require every flyweight implement a Serve method. Each drink is going to have a different size based on the order 
        void Serve(string size);
    }

    public class Espresso: IDrinkFlyweight{
        private string _name;
        public string Name { get {return _name;} }
        private IEnumerable<string> _ingredients;

        // Set intrinsic values using constructor
        public Espresso{
            _name = "Espresso";
            _ingredients = new List<string>(){
                "Coffee Beans",
                "Hot Water"
            };
        }
        
        public void Serve(string size){
            Console.WriteLine($"Order: {size} {_name} with {string.Join(", ", _ingredients)} coming up!");
        }
    }

    public class MangoLassi: IDrinkFlyweight{
        private string _name;
        public string Name { get {return _name;} }
        private IEnumerable<string> _ingredients;

        public MangoLassi{
            _name = "Mango Lassi";
            _ingredients = new List<string>(){
                "Mango",
                "Yoghurt",
                "Vanilla Extract"
            };
        }

        public void Serve(string size){
            Console.WriteLine($"Order: {size} {_name} with {string.Join(", ", _ingredients)} coming up!");
        }

        // Unshared concrete flyweight example: randomly selected drink for giveaway event
        public class DrinkGiveaway : IDrinkFlyweight{
            // All state: since not sharing this giveaway drink, we can store all of its state, including its extrinsic values
            // More akin to normal object creation but with the added benefit of being treated like a flyweight object
            public string Name { get {return _randomDrink.Name;} }
            private IDrinkFlyweight[] _eligibleGiveawayDrinks = new IDrinkFlyweight[]{
                new Espresso(),
                new MangoLassi()
            };

            private IDrinkFlyweight _randomDrink;
            private string _size; // Intrinsic state is not going to be shared: can save the size in this case only

            public DrinkGiveaway(){
                var randomIndex = new Random().Next(0, _eligibleGiveawayDrinks.Count);
                _randomDrink = _eligibleGiveawayDrinks[randomIndex];
            }

            // Extrinsic state
            public void Serve(string size){
                _size = size;
                Console.WriteLine($"Free Drink Giveaway!");
                Console.WriteLine($"Free Drink: {_size} {_randomDrink.Name} coming up!");
            }

            // Return a new instance of a giveaway drink whenever it's queried: as it's unshared it won't go through the factory method - requires new method
            // Unshared concrete classes are still implementing IDrinkFlyweight
            public IDrinkFlyweight CreateGiveaway(){
                return new DrinkGiveaway();
            }
        }
    }    
}