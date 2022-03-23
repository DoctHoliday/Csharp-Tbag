using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game.player
{
    public class Player
    {
        private String name;
        private int vitality;
        private int hp;
        private int atk;
        private int gold;

        public Player(String name, int vitality, int hp, int atk, int gold)
        {
            Name = name;
            Vitality = vitality;
            Hp = hp;
            Atk = atk;
            Gold = gold;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    throw new Exception("Name cannot be empty");
                else
                    name = value;
            }
        }

        public int Hp
        {
            get { return hp; }
            set
            {
                if (value < 0)
                    hp = 0;
                else
                    hp = value;
            }
        }

        // Fix vitality, think I'm stupid
        public int Vitality
        {
            get { return vitality; }
            set
            {
                if (value < 0)
                    Vitality = vitality;
                else
                    Vitality = value;
            }
        }

        public int Atk
        {
            get { return Atk; }
            set
            {
                Atk = value;
            }
        }

        public int Gold
        {
            get { return gold; }
            set 
            {
                if (value < 0)
                    Gold = 0;
                else
                    Gold = value;
            }
        }

        public String GetStats()
        {
            return String.Format("Name: {0}, Health: {1}, Attack: {2}, Gold: {3}", Name, Hp, Atk, Gold);
        }

        public void IncreaseVitality(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Cannot increase vitality by negative");
            else
                Vitality += amount;
        }

        public void RestoreHp(int amount)
        {
            if (Hp + amount >= Vitality)
                Hp = Vitality;
            else
                Hp += amount;
        }

        public void DiminishHp(int amount)
        {
            if (Hp - amount <= 0)
                Hp = 0;
            else
                Hp -= amount;
        }

        public void LevelAtk(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Cannot level up a character negatively");
            else
                Atk += amount;
        }

        public void IncreaseGold(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount is less than 0, cannot increase gold");
            else
                Gold += amount;
        }

        public void RemoveGold(int amount)
        {
            if (Gold - amount <= 0)
                Gold = 0;
            else
                Gold -= amount;
        }
    }
}
