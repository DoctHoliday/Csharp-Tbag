using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game.player
{
    public class Player
    {
        private String Name;
        private int Hp;
        private int Atk;
        private int Gold;

        public Player(String Name, int Hp, int Atk, int Gold)
        {
            this.Name = Name;
            this.Hp = Hp;
            this.Atk = Atk;
            this.Gold = Gold;
        }

        public String GetName() { return Name; }

        public int GetHp() { return Hp; }

        public int GetAtk() { return Atk; }

        public int GetGold() { return Gold; }

        public void SetName(String Name) { this.Name = Name; }
        
        public void SetHp(int Hp) { this.Hp = Hp; }

        public void SetAtk(int Atk) { this.Atk = Atk; }

        public void SetGold(int Gold) { this.Gold = Gold; }

        public String GetStats()
        {
            return String.Format("Name: {0}, Health: {1}, Attack: {2}, Gold: {3}", GetName(), GetHp(), GetAtk(), GetGold());
        }

        public void IncreaseGold(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount is less than 0");
           SetGold(Gold += amount);
        }

        public void RemoveGold(int amount)
        {
            if (Gold < 0)
                throw new ArgumentOutOfRangeException("Current gold is less than 0, cannot go negative");
            SetGold(Gold -= amount);
        }
    }
}
