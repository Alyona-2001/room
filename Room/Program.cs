using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Room
{
    class MyRoom
    {
        public virtual string Name { get; set; }
        public virtual void Furniture() { }
    }

    class BaseRoomDecorator : MyRoom
    {
        protected MyRoom _sourse;
        public BaseRoomDecorator(MyRoom sourse)
        {
            _sourse = sourse;
        }
        public override string Name
        {
            get { return _sourse.Name; }
            set { _sourse.Name = value; }
        }
        public override void Furniture() { _sourse.Furniture(); }

    }

    class BedDecorator : BaseRoomDecorator
    {
        public BedDecorator(MyRoom sourse) : base(sourse) { }
        public override void Furniture()
        {
            _sourse.Furniture();
            Console.Write(" Кроватка");
        }
    }

    class CupboardDecorator : BaseRoomDecorator
    {
        public CupboardDecorator(MyRoom sourse) : base(sourse) { }
        public override void Furniture()
        {
            _sourse.Furniture();
            Console.Write(" Шкафчик");
        }
    }

    class TableDecorator : BaseRoomDecorator
    {
        public TableDecorator(MyRoom sourse) : base(sourse) { }
        public override void Furniture()
        {
            _sourse.Furniture();
            Console.Write(" Столик");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var room = new MyRoom();
            room = new BedDecorator(room);

            var count = 7;
            while (count > 0)
            {
                Thread.Sleep(1000);
                count--;
                room.Furniture();
            }
            Console.WriteLine();
            Console.WriteLine();

            room = new MyRoom();
            room = new CupboardDecorator(room);

            count = 6;
            while (count > 0)
            {
                Thread.Sleep(800);
                count--;
                room.Furniture();
            }
            Console.WriteLine();
            Console.WriteLine();

            room = new MyRoom();
            room = new TableDecorator(room);

            count = 5;
            while (count > 0)
            {
                Thread.Sleep(600);
                count--;
                room.Furniture();
            }
            Console.WriteLine();
            Console.WriteLine();

            room = new MyRoom();
            room = new BedDecorator(room);
            room = new CupboardDecorator(room);
            room = new TableDecorator(room);

            count = 1;
            while (count > 0)
            {
                Thread.Sleep(400);
                count--;
                room.Furniture();
            }
            Console.ReadKey();
        }
    }
}