using System;
using System.Collections;
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
        private LeftHero player1;
        private RightHero player2;

        public Form1()
        {
            InitializeComponent();

            //Создаём героев
            player1 = LeftHero.Instance();
            player2 = RightHero.Instance();

            //Танки для левого героя
            player1.AddObserver(new HeavyTank(this, "left"));
            player1.AddObserver(new HeavyTank(this, "left"));
            player1.AddObserver(new LightTank(this, "left"));
            player1.AddObserver(new LightTank(this, "left"));
            player1.AddObserver(new LightTank(this, "left"));

            //Танки для правого героя
            player2.AddObserver(new HeavyTank(this, "right"));
            player2.AddObserver(new HeavyTank(this, "right"));
            player2.AddObserver(new LightTank(this, "right"));
            player2.AddObserver(new LightTank(this, "right"));
            player2.AddObserver(new LightTank(this, "right"));

            //Бомбы для левого героя
            player1.AddBomb(new SmallBomb("S1L"));
            player1.AddBomb(new SmallBomb("S2"));
            player1.AddBomb(new SmallBomb("S3"));
            player1.AddBomb(new MiddleBomb("M1"));
            player1.AddBomb(new MiddleBomb("M2"));
            player1.AddBomb(new LargeBomb("L1"));

            //Бомбы для правого героя
            player2.AddBomb(new SmallBomb("S1R"));
            player2.AddBomb(new SmallBomb("S2"));
            player2.AddBomb(new SmallBomb("S3"));
            player2.AddBomb(new MiddleBomb("M1"));
            player2.AddBomb(new MiddleBomb("M2"));
            player2.AddBomb(new LargeBomb("L1"));

            //Добавляем бомбы в списки
            foreach (Bomb item in player1.GetBombs())
            {
                bombSelectLeft.Items.Add(item);
            }
            foreach (Bomb item in player2.GetBombs())
            {
                bombSelectRight.Items.Add(item);
            }
        }

        public void tank_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;
            mouseIsDown = true;
        }

        public void tank_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                PictureBox temp = sender as PictureBox;
                int dx = e.X - startPos.X;
                int dy = e.Y - startPos.Y;
                temp.Location = new Point(temp.Left + dx, temp.Top + dy);
            }
        }

        public void tank_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        public void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void buttonNewGame_Click(object sender, EventArgs e)
        {
            FormClosed += (o, a) => new Form1().ShowDialog();
            Hide();
            Close();
        }

        private void panelPlayer_1_MouseUp(object sender, MouseEventArgs e)
        {
            Random tempRand = new Random();
            int shotX = (1200 / 2) + Math.Abs((1200 / 2) - e.X);
            int shotY = e.Y;

            foreach (CombatUnit unit in player2.GetList())
            {
                if (unit is Vehicle)
                {
                    PictureBox tempUnit = (unit as Vehicle).Item;
                    int locX = tempUnit.Location.X;
                    int locY = tempUnit.Location.Y;
                    int sizX = tempUnit.Width;
                    int sizY = tempUnit.Height;

                    //Проверка на попадание
                    if ((shotX >= locX && shotX <= locX + sizX) && (shotY >= locY && shotY <= locY + sizY))
                    {
                        if (bombSelectLeft.SelectedItem != null)
                        {
                            Bomb item = bombSelectLeft.SelectedItem as Bomb;

                            //Проверка на полное уничтожение
                            if (unit.Damage() < item.damage)
                            {
                                (unit as Vehicle).killed = true;
                                tempUnit.BackColor = Color.Red;
                                player2.NotifyObserver();
                            }
                        }

                        return;
                    }
                }
            }
        }

        private void panelPlayer_2_MouseUp(object sender, MouseEventArgs e)
        {
            Random tempRand = new Random();
            int shotX = (1200 / 2) - Math.Abs((1200 / 2) - (e.X + 700));
            int shotY = e.Y;

            foreach (CombatUnit unit in player1.GetList())
            {
                if (unit is Vehicle)
                {
                    PictureBox tempUnit = (unit as Vehicle).Item;
                    int locX = tempUnit.Location.X;
                    int locY = tempUnit.Location.Y;
                    int sizX = tempUnit.Width;
                    int sizY = tempUnit.Height;

                    //Проверка на попадание
                    if ((shotX >= locX && shotX <= locX + sizX) && (shotY >= locY && shotY <= locY + sizY))
                    {
                        if (bombSelectRight.SelectedItem != null)
                        {
                            Bomb item = bombSelectRight.SelectedItem as Bomb;

                            //Проверка на полное уничтожение
                            if (unit.Damage() < item.damage)
                            {
                                (unit as Vehicle).killed = true;
                                tempUnit.BackColor = Color.Red;
                                player1.NotifyObserver();
                            }
                        }

                        return;
                    }
                }
            }
        }
    }

    public abstract class Hero
    {

        protected List<CombatUnit> list = new List<CombatUnit>();
        public List<Bomb> bombs = new List<Bomb>();

        protected Hero()
        {
            //Защищённый конструктор нужен, чтобы предотвратить создание экземпляра класса Hero
        }

        public void AddObserver(CombatUnit unit)
        {
            list.Add(unit);
        }
        public void RemoveObserver(CombatUnit unit)
        {
            list.Remove(unit);
        }

        public List<CombatUnit> GetList()
        {
            return list;
        }

        public void AddBomb(Bomb item)
        {
            bombs.Add(item);
        }
        public void RemoveBomb(Bomb item)
        {
            bombs.Remove(item);
        }

        public List<Bomb> GetBombs()
        {
            return bombs;
        }
    }

    public class LeftHero : Hero
    {
        protected static LeftHero instance;
  
        public static LeftHero Instance()
        {
            if (instance != null)
            {
                return instance;
            }

            return new LeftHero();
        }

        public void NotifyObserver()
        {
            Random tempRand = new Random();
            foreach (CombatUnit unit in list)
            {
                if (unit is Vehicle)
                {
                    (unit as Vehicle).Reposition(new Point(tempRand.Next(0, 500), tempRand.Next(0, 450)));
                }
            }
        }
    }

    public class RightHero : Hero
    {
        protected static RightHero instance;

        public static RightHero Instance()
        {
            if (instance != null)
            {
                return instance;
            }

            return new RightHero();
        }

        public void NotifyObserver()
        {
            Random tempRand = new Random();
            foreach (CombatUnit unit in list)
            {
                if (unit is Vehicle)
                {
                    (unit as Vehicle).Reposition(new Point(tempRand.Next(0 + 722, 450 + 722), tempRand.Next(0, 450)));
                }
            }
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
        public bool killed = false;
        public int hp;
        public int Damage()
        {
            return hp;
        }
    }

    public abstract class Warrior : CombatUnit
    {

    }

    public abstract class Vehicle : CombatUnit
    {
        public PictureBox Item = new System.Windows.Forms.PictureBox();
        public Form1 Form;
        public List<Warrior> Items = new List<Warrior>();

        public new int Damage()
        {
            int total = hp;

            foreach (CombatUnit component in Items)
            {
                total += component.Damage();
            }

            return total;
        }

        public void Reposition(Point point)
        {
            if (!killed)
            {
                Item.Location = point;
            }
        }
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
        public LightTank(Form1 parrentForm, string flank)
        {
            hp = 2;
            Form = parrentForm;
            Item.BackColor = Color.Aqua;

            if (flank.Equals("right"))
            {
                Item.Location = new System.Drawing.Point(640, 250 - 100);
            }
            else
            {
                Item.Location = new System.Drawing.Point(517, 250 - 100);
            }
            Item.Name = "tankRightLight";
            Item.Size = new System.Drawing.Size(45, 35);
            Item.TabStop = false;

            Item.MouseDown += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseDown);
            Item.MouseMove += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseMove);
            Item.MouseUp += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseUp);

            parrentForm.Controls.Add(Item);
            Item.BringToFront();
        }

        public void Reposition()
        {
            if (!killed)
            {
                Random tempRand = new Random();
                Item.Location = new Point(tempRand.Next(10, 400), tempRand.Next(11, 400));
            }
        }
    }

    public class HeavyTank : Vehicle
    {
        public HeavyTank(Form1 parrentForm, string flank)
        {
            hp = 3;
            Form = parrentForm;
            Item.BackColor = Color.Azure;
            if (flank.Equals("right"))
            {
                Item.Location = new System.Drawing.Point(640, 250 - 100);
            }
            else
            {
                Item.Location = new System.Drawing.Point(517, 250 - 100);
            }

            Item.Name = "tankRightHard";
            Item.Size = new System.Drawing.Size(51, 37);
            Item.TabStop = false;

            Item.MouseDown += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseDown);
            Item.MouseMove += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseMove);
            Item.MouseUp += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseUp);

            parrentForm.Controls.Add(Item);
            Item.BringToFront();
        }

        public void Reposition()
        {
            if (!killed)
            {
                Random tempRand = new Random();
                Item.Location = new Point(tempRand.Next(10, 400), tempRand.Next(11, 400));
            }
        }
    }

    public abstract class Bomb
    {
        protected string name;
        public int damage;

        public Bomb(string nameValue)
        {
            this.name = nameValue;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class SmallBomb : Bomb
    {
        public SmallBomb(string nameValue) : base(nameValue)
        {
            damage = 1;
        }
    }

    public class MiddleBomb : Bomb
    {
        public MiddleBomb(string nameValue) : base(nameValue)
        {
            damage = 2;
        }
    }

    public class LargeBomb : Bomb
    {
        public LargeBomb(string nameValue) : base(nameValue)
        {
            damage = 3;
        }
    }
}
