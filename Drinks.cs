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
    }    
}