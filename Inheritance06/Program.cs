using System;
using System.Collections.Generic;

namespace Inheritance06
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player() { Name = "Bob", Strength = 20 };
            var warrior = new Warrior() { Name = "Baltek", Strength = 100, Bonus = 10 };
            var wizard = new Wizard() { Name = "Pentagorn", Strength = 50, Energy = 50 };

            var players = new List<Player>();
            players.Add(player);
            players.Add(warrior);
            players.Add(wizard);

            DoBattle(players);

            Console.ReadLine();
        }

        static void DoBattle(List<Player> players)
        {
            foreach (var player in players)
            {
                player.Attack();
                Console.WriteLine("");
            }
        }
    }
    
    class Player
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        Random random = new Random();
        //can be overriden using override keyword in derived class
        public virtual void Attack()
        {
            int damage = random.Next(0, Strength);
            Console.WriteLine($"{Name} attacked for {damage} damage");
        }
    }

    class Warrior : Player
    {
        public int Bonus { get; set; }
        //overrides base class implementation
        public override void Attack()
        {
            Random random = new Random();
            int damage = random.Next(0, Strength) + Bonus;
            Console.WriteLine($"{Name} charges for {damage} damage (includes +{Bonus} bonus)");
        }
    }

    class Wizard : Player
    {
        public int Energy { get; set; }
        //overrides base class implementation
        public override void Attack()
        {
            Random random = new Random();
            int energy = random.Next(0, 10);
            Energy -= energy;
            //implements base class method and extends it.
            base.Attack();
            Console.WriteLine($"    (Wizard {Name} depleted {energy} energy)");
        }
    }
}

