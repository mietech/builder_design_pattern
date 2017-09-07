using System;

namespace Builder_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            director.HouseBuilder = new WoodenHouseBuilder();
            director.BuildHouse();
            var woodenHouse = director.House;
            if (woodenHouse != null)
                Console.WriteLine(string.Format("First house: {0}, {1}, {2}, {3}", woodenHouse.Wall, woodenHouse.Roof, woodenHouse.Door, woodenHouse.Window));

            director.HouseBuilder = new MudHouseBuilder();
            director.BuildHouse();
            var mudHouse = director.House;

            if (mudHouse != null)
                Console.WriteLine(string.Format("Second house: {0}, {1}, {2}, {3}", mudHouse.Wall, mudHouse.Roof, mudHouse.Door, mudHouse.Window));
            Console.ReadKey();
        }
    }

    //obiekt naszego produktu - domu
    public class House
    {
        public string Roof { get; set; }
        public string Wall { get; set; }
        public string Door { get; set; }
        public string Window { get; set; }
    }

    //klasa abstrakcyjna budowniczego
    public abstract class HouseBuilder : IHouseBuilder
    {
        public House House { get; private set; }
        public void BuildNewHouse() => House = new House();

        public abstract void BuildRoof();
        public abstract void BuildWall();
        public abstract void BuildWindow();
        public abstract void BuildDoor();
    }

    //alternatywne podejście z interfejsem budowniczego, klasa abstrakcyjna budowniczego moze ale nie musi go implementowac
    public interface IHouseBuilder
    {
        House House { get; }
        void BuildNewHouse();
        void BuildRoof();
        void BuildWall();
        void BuildWindow();
        void BuildDoor();
    }

    //konkretny budowniczy domu z drewna
    public class WoodenHouseBuilder : HouseBuilder
    {
        public override void BuildDoor() => House.Door = "Wooden door";
        public override void BuildRoof() => House.Roof = "Wooden roof";
        public override void BuildWall() => House.Wall = "Wooden wall";
        public override void BuildWindow() => House.Window = "Wooden window";
    }

    //konkretny budowniczy domu z cegly
    public class BrickHouseBuilder : HouseBuilder
    {
        public override void BuildDoor() => House.Door = "Wooden door";
        public override void BuildRoof() => House.Roof = "Tile roof";
        public override void BuildWall() => House.Wall = "Brick wall";
        public override void BuildWindow() => House.Window = "Wooden window";
    }

    //konkretny budowniczy ziemianki
    public class MudHouseBuilder : HouseBuilder
    {
        public override void BuildDoor() => House.Door = "Sticks door";
        public override void BuildRoof() => House.Roof = "Mud roof";
        public override void BuildWall() => House.Wall = "Mud wall";
        public override void BuildWindow() => House.Window = "No window";
    }

    //nadzorca budowy
    public class Director
    {
        public HouseBuilder HouseBuilder { get; set; }
        public House House => HouseBuilder.House;
        public void BuildHouse()
        {
            HouseBuilder.BuildNewHouse();
            HouseBuilder.BuildWall();
            HouseBuilder.BuildRoof();
            HouseBuilder.BuildWindow();
            HouseBuilder.BuildDoor();
        }
    }
}
