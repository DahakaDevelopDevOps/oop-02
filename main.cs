
using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;

namespace oop2
{
    public partial class BoolVector
    {
        private readonly int ID;
        private string name;
        private long Value;
        public long length { private set; get; }
        public const int SpeedOfsound = 300; // m per sec.
        private long weight { get; set; }
        private static string about = "Класс для работы с булевыми вектарами";
        //private Boolvector() { }// не допускает других конструкторов по умолчанию
        static int counter = 0;
        public static int Counter => counter; //для подсчета создпнных объектов
        static BoolVector()
        {
            if (DateTime.Now.Day == 30)
                Console.WriteLine("It's time to study " );
        }

        public BoolVector()
        {
            ID = GetHashCode();
            name = "noName";
            Value = 0;
            length = 0;
            weight = 0;
            counter++;
        }
        public BoolVector(string name, long value, long length, long weight)
        {
            this.name = name;
            this.value = value;
            this.length = length;   
            this.weight = weight;   
        }
        public BoolVector(string name = "Necto", long value = 0)
        {
            this.name = name;
            this.value = value;
        }
        public BoolVector( long value )
        {
            this.value = value;
        }
        public BoolVector(BoolVector boolvector)
        {
            ID = boolvector.GetHashCode();
            Console.WriteLine("Vector's ID: " + ID);
        }
        public long value //public string value { get; set; }
        {
            get { return Value; }
            set { Value = value; }
        }

        public void setname(string name)
        {
            if (name.Length > 0)
                this.name = name;
            else
                Console.WriteLine("Некорректный ввод");

        }
        public string getname()
        {
            return name;
        }
        public static string GetInfo() { return about; }
        internal void Balance(long l, out long weight)
        {
            long w = 0;
            string len = l.ToString();
            for (int i = 0; i < len.Length; i++)
            {
                if (len[i] == 49) // код 1 - 49
                    w++;
            }
            weight = w;
            Console.WriteLine("weight: " + weight);
        }
        public string ChangeName(ref string vec)
        {
            return "new" + vec;
        }
        //

        public void CountZeroesNOnes(long value)
        {
            long o = 0;
            long z = 0;
            Console.WriteLine($"Вектор: {value}");
            string len = value.ToString();
            for (int i = 0; i < len.Length; i++)
            {
                if (len[i] == 49) // код 1 - 49
                    o++;
                else z++;
            }
            Console.WriteLine($"Кол-во 1: {o}");
            Console.WriteLine($"Кол-во 0: {z}");
        }
        public void Conuction(long value1, long value)
        {

                Console.WriteLine($"Результат поразрядной конъюнкции: {value1&value} " );
        }
        public void Disuction(long value1, long value)
        {

                Console.WriteLine($"Результат поразрядной дизъюкции: {value1|value}" );
        }
        public void Inversion(long value)
        {
            Console.WriteLine($"Результат поразрядной : {~value}" );
        }   
        public void Count(long num,long value) //скобочка а
        {
            long w = 0;
            long z = 0;
            string len = value.ToString();
            for (int i = 0; i < len.Length; i++)
            {
                if (len[i] == 49) // код 1 - 49
                    w++;
                else z++;
            }
            if (w == num) Console.WriteLine(value);
        }
        public void FindVect(BoolVector[] vector) //скобочка a (для перебора все векторов)
        {
            Console.Write("Количество единиц в векторе ");
            long limit = Convert.ToInt64(Console.ReadLine());
            for (int i = 0; i < vector.Length; i++)
            {
                vector[0].Count(limit, vector[i].value);
            }
        }

        public void EqualsVectors(long value2, long value) // b)
        {
            if (value == value2)
            {
                Console.WriteLine($"Вектора равны {value}");
            }
        }
        public void EqualsV( BoolVector[] vector) //продолжение б)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = 1; j < vector.Length; j++)
                {
                    if (i != j && i > j)
                        vector[0].EqualsVectors(vector[i].value, vector[j].value);
                }
            }
        }


    }
        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BoolVector.GetInfo());
            BoolVector[] vector = new BoolVector[4];
            vector[0] = new BoolVector(11100010);
            vector[1] = new BoolVector("a");
            vector[2] = new BoolVector(vector[0]);
            vector[3] = new BoolVector(10101);
            vector[0].Balance(11011110101010100, out long result);
            string vec = "myname";
            Console.WriteLine(vec);
            Console.WriteLine(vector[0].ChangeName(ref vec));
            vector[0].value = 10101010;
            vector[1].value = 101;
            vector[2].value = 101;
            vector[2].CountZeroesNOnes(vector[2].value);
            var vector1 = new { name = "Avec" };
            Console.WriteLine(vector1.name.GetType()); // 
            var vector2 = new { name = "Bvec" };
            var vector3 = new { name = "Avec" };
            bool pEqualsP2 = vector1.Equals(vector2);   // false
            bool pEqualsP3 = vector1.Equals(vector3);   // true
            Console.WriteLine(pEqualsP2);
            Console.WriteLine(pEqualsP3);
            BoolVector vectors = new BoolVector();
            Console.WriteLine($"Вектор {vector[0].value}");
            vector[2].Conuction(vector[3].value, vector[0].value);
            vector[2].Disuction(vector[3].value, vector[0].value);
            vector[2].Inversion(vector[2].value);
            vectors.FindVect(vector);
            vectors.EqualsV(vector);
        }
    }
}
