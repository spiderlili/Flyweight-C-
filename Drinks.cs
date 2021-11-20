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
        public string Name { get {return "Espresso";} }
        
        public void Serve(string size){
            Console.WriteLine($"Size: ");
        }
    }

    public class MangoLassi: IDrinkFlyweight{
        public string Name { get {return "Mango Lassie";} }
        
        public void Serve(string size){
            Console.WriteLine($"Size: ");
        }
    }    
}