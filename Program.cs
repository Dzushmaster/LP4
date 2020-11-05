using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

/*
 * 1) Определить иерархию и композицию классов, реализовать классы. В одном из классов переопределите все метода, унаследованные от Object 
 * 2) В проекте должен быть минимум один интерфейс и абстрактный класс. Используйте виртуальные методы и переопределение
 * 3) Сделайте один из классов sealed(нельзя наследовать от него)
 * 4) Добавьте в интерфейсы(интерфейс) и абстрактный класс одноименные методы. Дайте в наследуемом классе им разную реализацию и вызовите эти методы
 * 5) Написать демонстрационную программу, в которой создаются объекты различных классв. Продолжение в методичке
 * 6) Во всех классах переопределить ToString().
 * 7) Создать доп класс Printer с полиморфным методом IAmPrinting(SomeAbstractClassorInterface someobj). Продолжение в методичке
 */
//Транспортное средство
//Управление авто
//Машина
//Двигатель
//Разумное существо
//Человек
//Трансформер

namespace LPLab4
{
    enum soldier
    {
        People=4, Transformer
    };
    struct beries
    {
        public beries(int cost,string name)
        {
            this.cost = cost;
            this.name = name;
        }
        int cost;
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                Name = value;
            }
        }
    }
    class Engine
    {
        public Engine() { }
        public Engine(int capacity, int torque)
        {
            if (capacity < 0)
                Console.WriteLine("Error: capacity can't be negative");
            else
                this.capacity = capacity;
            if (torque< 0)
                Console.WriteLine("Error: torque can't be negative");
            else
                this.torque = torque;
        }
        int capacity;//мощность 
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Error: capacity can't be negative");
                else
                    capacity = value;
            }
        }
        int torque;//крутящий момент
        public int Torque
        {
            get
            {
                return Torque;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Error: torque can't be negative");
                else
                    torque = value;
            }
        }
        public override string ToString()
        {
            return "Capacity of this engine is " + this.capacity + "\ntorque:" + this.torque+ "\n";
        }
    }
    interface IRuning
    {
        bool ICanRun();
    }
    interface IforPrinting
    {
        string ToString();
    }
    abstract class Vehicle
    {
        public abstract bool ICanRun();
        public virtual void DisplaySpeed()
        {
            Console.WriteLine(max_speed);
        }
        protected Engine vehicle_Engine;
        int max_speed;
        protected int Max_Speed
        {
            get
            {
                return max_speed;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Error: in our example speed can't be negative");
                else
                    max_speed = value;
            }
        }
        int fuel_Consumption;
        protected int Fuel_Consumption
        {
            get
            {
                return fuel_Consumption;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Error: fuel consumption can't be negative");
                else
                    fuel_Consumption = value;
            }
        }
        public override string ToString()
        {
            return "Max_speed of this engine is " + this.max_speed + "\nfuel_Consumption :" + this.fuel_Consumption + "\n";
        }
    }
    class Transformer : Vehicle,IRuning
    {
        public Transformer(){        }
        public Transformer(Engine vehicle_Engine, string name, string typeOfTransformer,int power, int yearOfCreate)
        {
            this.vehicle_Engine = vehicle_Engine;
            this.name = name;
            this.typeOfTransformer = typeOfTransformer;
            this.power = power;
            this.yearOfCreate = yearOfCreate;
        }
        int power;
        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }
        int yearOfCreate;
        public int YearOfCreate
        {
            get
            {
                return yearOfCreate;
            }
            set { yearOfCreate = value; }
        }
        string typeOfTransformer;
        public string TypeOfTransformer
        {
            get
            {
                return typeOfTransformer;
            }
            set
            {
                typeOfTransformer = value;
            }
        }
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        bool IRuning.ICanRun() => false;
        public override bool ICanRun() => true;
        public override string ToString()
        {
            return "Name of this engine is " + this.name + " power " + this.power + " year of creating " + this.yearOfCreate;
        }
    }
    class Cars:Vehicle
    {
        public override bool ICanRun() => false;
        public Cars() { }
        public Cars(Engine vehicle_Engine,string mark, int year_of_create)
        {
            this.vehicle_Engine = vehicle_Engine;
            this.mark = mark;
            if (year_of_create < 1885)
                Console.WriteLine("Error: the year of creation cannot be earlier than the year of manufacture of the first machine");
            else
                this.year_of_create = year_of_create;
        }
        string mark;
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
        int year_of_create;
        public int Year_Of_Create
        {
            get
            {
                return year_of_create;
            }
            set
            {
                if(value<1885)
                    Console.WriteLine("Error: the year of creation cannot be earlier than the year of manufacture of the first machine");
                else
                    year_of_create = value;
            }
        }
        public override string ToString()
        {
            return "Mark of this engine is " + this.mark + "\nyear_of_create :" + this.year_of_create + "\n";
        }
    }
    class Beast
    {
        public Beast() { }
        public Beast(int lifespan,int weight) 
        {
            if (lifespan <= 0)
                Console.WriteLine("Error: lifespan can't be less or equal 0");
            else
                this.lifespan = lifespan;
            if (weight <= 0)
                Console.WriteLine("Error: weight can't be less or equal 0");
            else
                this.weight = weight;
        }
        int lifespan;
        protected int Lifespan
        {
            get
            {
                return lifespan;
            }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Error: lifespan can't be less or equal 0");
                else
                    lifespan = value;
            }
        }
        int weight;
        protected int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Error: weight can't be less or equal 0");
                else
                    weight = value;
            }
        }
        public override string ToString()
        {
            return "Lifespan of this engine is " + this.lifespan + "\nweigth :" + this.weight + "\n";
        }
    }
    class Human:Beast
    {
        public Human(int lifespan, int weight):base(lifespan, weight){}
        public Human(int iq, int years,int weight, int lifespan ,Driving drive):base(lifespan,weight)
        {
            if (iq < 0)
                Console.WriteLine("Error: iq can't be less 0");
            else
                this.iq = iq;
            if (years < 0)
                Console.WriteLine("Error: years can't be less 0");
            else
                this.years = years; 
            this.drive = drive;
        } 
        int iq;
        int years;
        Driving drive;
        public int Iq
        {
            get
            {
                return Iq;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Error: iq can't be less 0");
                else
                    iq = value;
            }
        }
        public int Years
        {
            get
            {
                return years;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Error: years can't be less 0");
                else
                    years = value;
            }
        }
        public override string ToString()
        {
            return "Iq of this human is " + this.iq + " years :" + this.years;
        }
    }
    sealed partial class Driving
    {
        public Driving() { }
        public Driving(bool iCanDrive) { this.iCanDrive = iCanDrive; }
        bool iCanDrive;
        public bool ICanDrive
        {
            get
            {
                return iCanDrive;
            }
            set
            {
                iCanDrive = value;
            }
        }
    }

    class LittileArmy
    {
        public List<Transformer> Transformersarmy = new List<Transformer>();
        public List<Human> HumanArmy = new List<Human>();
        public static int sizeArmy = 0;
        public List<LittileArmy> Army
        {
            get
            {
                return Army;
            }
            set
            {
                Army = value;
            }
        }
        public void AddSoldier(Human human)
        {
            HumanArmy.Add(human);
            sizeArmy++;
        }
        public void deleteSoldier(Human human)
        {
            HumanArmy.Remove(human);
            sizeArmy--;
        }
        public void AddTransformer(Transformer transformer)
        {
            Transformersarmy.Add(transformer);
            sizeArmy++;
        }
        public void deleteTransformer(Transformer transformer)
        {
            Transformersarmy.Remove(transformer);
            sizeArmy--;
        }
        public void PrintHuman()
        {
            for(int i = 0;i<HumanArmy.Count;i++)
                Console.WriteLine(HumanArmy[i]);
        }
        public void PrintTransformers()
        {
            for (int i = 0; i < Transformersarmy.Count; i++)
                Console.WriteLine(Transformersarmy[i]);
        }
    }
    class Controller:LittileArmy
    {
        public void findYear(int year, List<Transformer> Transformersarmy, List<Human> HumanArmy)
        {
            int i = 0;
            while (HumanArmy != null)
            {
                Human human = HumanArmy[i];
                if (human.Years == year)
                    break;
                i++;
            }
            Console.WriteLine("Первый человек с такой датой рождения найден: "+HumanArmy[i]);
            i = 0;
            while (Transformersarmy != null)
            {
                Transformer transformer = Transformersarmy[i];
                if (transformer.YearOfCreate == year)
                    break;
                i++;
            }
            Console.WriteLine("Первый трансформер с таким годом создания найден: "  + Transformersarmy[i]);
        }
        public void findP(int power, List<Transformer> Transformersarmy)
        {
            int i = 0;
            while (Transformersarmy != null)
            {
                Transformer transformer = Transformersarmy[i];
                if (transformer.Power == power)
                    break;
                i++;
            }
            Console.WriteLine("Первый трансформер с такой мощностью найден: " + Transformersarmy[i]);
        }
        public static void SizeArmy()
        {
            Console.WriteLine("Размер армии составляет " + LittileArmy.sizeArmy + " боевых единиц");
        }
    }
    class Program
    {
        static void Pause()
        {
            Console.Read();
        }
        static void Main(string[] args)
        {
            Driving driving = new Driving(true);
            Human human1 = new Human(100,1995,100,70,driving);
            Human human2 = new Human(101, 1990,120,56,driving);
            Human human3 = new Human(106, 1970,89,70,driving);
            Human human4 = new Human(112, 1965,90,80,driving);
            Human human5 = new Human(90, 1983,76,50,driving); 
            Human human6 = new Human(70, 1978,77,45,driving);
            Engine engine = new Engine(780, 1000);
            Engine engine1 = new Engine(1300, 1450);
            Transformer transformer1 = new Transformer(engine, "transformer1", "autobot", 750, 300);
            Transformer transformer2 = new Transformer(engine, "transformer2", "autobot",800,350);
            Transformer transformer3 = new Transformer(engine1, "transformer3", "autobot",1300,1800);
            Transformer transformer4 = new Transformer(engine1, "transformer4", "autobot",1500,1965);
            Transformer transformer5 = new Transformer(engine1, "transformer5", "autobot",800,1900);
            Transformer transformer6 = new Transformer(engine, "transformer6", "autobot",750,450);
            LittileArmy Army= new LittileArmy();
            Army.AddSoldier(human1);
            Army.AddTransformer(transformer1);
            Army.AddSoldier(human2);
            Army.AddTransformer(transformer2);
            Army.AddSoldier(human3);
            Army.AddTransformer(transformer3);
            Army.AddSoldier(human4);
            Army.AddTransformer(transformer4);
            Army.AddSoldier(human5);
            Army.AddTransformer(transformer5);
            Army.AddSoldier(human6);
            Army.AddTransformer(transformer6);
            Console.WriteLine("Люди: ");
            Army.PrintHuman();
            Console.WriteLine("Трансформеры: ");
            Army.PrintTransformers();
            Controller.SizeArmy();
            Controller controller = new Controller();
            controller.findP(750,Army.Transformersarmy);
            controller.findYear(1965,Army.Transformersarmy, Army.HumanArmy);
            Pause();
        }
    }
}
