using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Land_of_Tanks
{
    public partial class Form1 : Form
    {
        private Point startPos;
        private bool mouseIsDown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tank_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;
            mouseIsDown = true;
        }

        private void tank_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                PictureBox temp = sender as PictureBox;
                int dx = e.X - startPos.X;
                int dy = e.Y - startPos.Y;
                //if ()
                temp.Location = new Point(temp.Left + dx, temp.Top + dy);
                //tankLeftLight.Location = new Point(tankLeftLight.Left + dx, tankLeftLight.Top + dy);
            }
        }

        private void tank_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            FormClosed += (o, a) => new Form1().ShowDialog();
            Hide();
            Close();
        }
    }

    public abstract class Hero
    {
        protected static Hero instance;
        protected List<CombatUnit> list;

        protected Hero()
        {
            //Защищённый конструктор нужен, чтобы предотвратить создание экземпляра класса Hero
        }

        protected void AddObserver(CombatUnit unit)
        {
            list.Add(unit);
        }
        protected void RemoveObserver(CombatUnit unit)
        {
            list.Remove(unit);
        }
        protected void NotifyObserver()
        {
            foreach (CombatUnit unit in list)
            {
                unit.Reposition();
            }
        }
    }

    public class LeftHero : Hero
    {
        public Hero Instance()
        {
            list = new List<CombatUnit>();

            if (instance != null)
            {
                return instance;
            }

            return new LeftHero();
        }
    }

    public class RightHero : Hero
    {
        public Hero Instance()
        {
            list = new List<CombatUnit>();

            if (instance != null)
            {
                return instance;
            }

            return new RightHero();
        }
    }

    public class Director
    {
        public void Army()
        {

        }
    }

    public abstract class Builder
    {

    }

    public class LeftBuilder : Builder
    {

    }

    public class RightBuilder : Builder
    {

    }

    public abstract class CombatUnit
    {
        protected int positonX;
        protected int positionY;

        public void Reposition()
        {

        }
    }

    public abstract class Warrior : CombatUnit
    {

    }

    public abstract class Vehicle : CombatUnit
    {

    }

    public class Lieutenant : Warrior
    {

    }

    public class Captain : Warrior
    {

    }

    public class Maj : Warrior
    {

    }

    public class LightTank : Vehicle
    {

    }

    public class HeavyTank : Vehicle
    {

    }

    public abstract class Bomb
    {

    }

    public class SmallBomb : Bomb
    {

    }

    public class MiddleBomb : Bomb
    {

    }

    public class LargeBomb : Bomb
    {

    }
}
