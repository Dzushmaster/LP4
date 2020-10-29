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
        public Transformer(Engine vehicle_Engine, string name, string typeOfTransformer)
        {
            this.vehicle_Engine = vehicle_Engine;
            this.name = name;
            this.typeOfTransformer = typeOfTransformer;
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
            return "Name of this engine is " + this.name + "\ntypeOfTransformer :" + this.typeOfTransformer+ "\n";
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
    class Program
    {
        static void Pause()
        {
            Console.Read();
        }
        static void Main(string[] args)
        {
            Transformer a = new Transformer();
            if(a.ICanRun())
                Console.WriteLine("I can run");
            else
                Console.WriteLine("I can't run");

            if(((IRuning)a).ICanRun()) Console.WriteLine("I can run");
            else Console.WriteLine("I can't run");
            Cars cars = new Cars();
            //"I can run"
            int weightHuman = 54;
            int lifespanHuman = 65;
            int iq = 100;
            int years = 40;
            Driving drive = new Driving(true);
            Human human = new Human(iq, years,lifespanHuman,weightHuman,drive);
            int weight = 72;
            int lifespan = 100;
            //Beast beast = new Beast(weight, lifespan);
            Beast beast = human as Beast;
            if(beast == null) Console.WriteLine("Beast!=Human");
            else Console.WriteLine("Beast==Human");
            Beast beast1 = new Beast(lifespan, weight);
            Human human1 = beast1 as Human;
            if (human1 == null) Console.WriteLine("Human!=Beast");
            else Console.WriteLine("Human == Beast");
            Engine vehicle = new Engine(350, 720);
            if(human is Beast)
            {
                Beast beast2 = (Beast)human;
                Console.WriteLine(beast2);
            }
            else { Console.WriteLine("human isn't Beast"); }
            Print printing = new Print();
            object[] arr = {a,cars ,printing};
            foreach (object item in arr)
            {
                printing.IAmPrinting((Vehicle)item);
            }
            //обычный массив в котором находятся все классы( в самом конце Printing)
            Pause();
        }
    }
}
