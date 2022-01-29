using System;

namespace deligate
{
    public delegate void Player(string message);
    interface IPlayer
    {
        static string player1;
        static string player2;
    }
    class Ping : IPlayer
    {
        public event Player Notify;
        public void Send() => Notify?.Invoke($"{IPlayer.player1} sent Ping ");
        public void Recived() => Notify?.Invoke($"{IPlayer.player1} received Pong.");
        public void Finish() => Notify?.Invoke($"{IPlayer.player1} не отбил,Игра завешинна!!! \n");
    }
    class Pong : IPlayer
    {
        public event Player Notify;
        public void Send() => Notify?.Invoke($"{IPlayer.player2} sent Pong ");
        public void Recived() => Notify?.Invoke($"{IPlayer.player2} received Ping.");
        public void Finish() => Notify?.Invoke($"{IPlayer.player2} не отбил,Игра завешинна!!! \n");
    }
    class Program
    {
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static int CheckNumber()
        {
            int n;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Ошибка!!!Введите корректные данные");
                }
            }
            while (true);
        }
        public static string CheckString()
        {
            string name;
            uint countofInvalid = 0;
            string symbolInvalid = "1234567890/} {)(|@%$&*!?,.`~=-#";
            string enter = "";
            do
            {
                countofInvalid = 0;
                name = Console.ReadLine();
                if (name == enter)
                {
                    countofInvalid++;
                }
                foreach (char numb1 in name)
                {
                    foreach (char numb2 in symbolInvalid)
                        if (numb1 == numb2)
                        {
                            countofInvalid++;
                        }
                }
                if (countofInvalid > 0)
                {
                    Console.WriteLine("Имя введенно не корректно,ведите имя повторно");
                }
            }
            while (countofInvalid > 0);
            return name;
        }
        static void Main(string[] args)
        {
            Ping ping = new Ping();
            Pong pong = new Pong();
            ping.Notify += DisplayMessage;
            pong.Notify += DisplayMessage;
            Console.WriteLine($"Ввeдите имя первого игрока: ");
            IPlayer.player1 = CheckString();
            Console.WriteLine($"Ввeдите имя второго игрока: ");
            IPlayer.player2 = CheckString();
            Console.WriteLine("Введите число подачь: ");
            int a = CheckNumber();
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine($"\t");
                Console.WriteLine($"{i + 1} подача");
                Console.WriteLine($"\t");
                ping.Send();
                pong.Recived();
                pong.Send();
                ping.Recived();
            }
            Console.WriteLine($"Finish!!!");
            Console.ReadKey();
        }
    }
}
