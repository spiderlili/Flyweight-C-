using System;
using System.Collections.Generic.
using System.Text;

namespace FlyweightPattern
{
    // Act as a lookup helper: return a drink by requested key.
    public class DrinkFactory(){
        private Dictionary<string, IDrinkFlyweight> _drinkCache = new Dictionary<string, IDrinkFlyweight>();
        public int ObjectsCreated = 0;

        public IDrinkFlyweight GetDrink(string drinkKey){
            IDrinkFlyweight drink = null;
            if(_drinkCache.ContainsKey(drinkKey)){
                Console.WriteLine("\nReusing existing flyweight IDrinkFlyweight object");
                return _drinkCache[drinkKey];
            }
            else{
                Console.WriteLine("\nCreating new flyweight IDrinkFlyweight object");
                switch(drinkKey){
                    case "Espresso":
                    drink = new Espresso();
                    break;
                    case "MangoLassi":
                    drink = new MangoLassi();
                    break;
                    default:
                    throw new Exception("This is not a IDrinkFlyweight object!");
                }
                _drinkCache.Add(drinkKey, drink);
                ObjectsCreated++;
            }
            return drink;
        }

        // Debug
        public void ListDrinks(){
            Console.WriteLine($"\nFactory has {_drinkCache.Count} IDrinkFlyweight objects ready to use.");
            Console.WriteLine($"Number of objects created: {ObjectsCreated}");

            foreach(var drink in _drinkCache){
                Console.WriteLine($"\t{drink.Value.Name}"); // Tab
            }
            Console.WriteLine("\n");
        }
    }
}