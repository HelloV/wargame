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
            player1.AddBomb(new SmallBomb("lS1"));
            player1.AddBomb(new SmallBomb("lS2"));
            player1.AddBomb(new SmallBomb("lS3"));
            player1.AddBomb(new MiddleBomb("lM1"));
            player1.AddBomb(new MiddleBomb("lM2"));
            player1.AddBomb(new LargeBomb("lL1"));

            //Бомбы для правого героя
            player2.AddBomb(new SmallBomb("rS1"));
            player2.AddBomb(new SmallBomb("rS2"));
            player2.AddBomb(new SmallBomb("rS3"));
            player2.AddBomb(new MiddleBomb("rM1"));
            player2.AddBomb(new MiddleBomb("rM2"));
            player2.AddBomb(new LargeBomb("rL1"));

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
            int shotX = (1200 / 2) + Math.Abs((1200 / 2) - e.X);
            int shotY = e.Y;

            HandlerShot(player2, shotX, shotY);
        }

        private void panelPlayer_2_MouseUp(object sender, MouseEventArgs e)
        {
            int shotX = (1200 / 2) - Math.Abs((1200 / 2) - (e.X + 700));
            int shotY = e.Y;

            HandlerShot(player1, shotX, shotY);

        }

        public void tank_LocationChanged(object sender, EventArgs e)
        {
            PictureBox tempPB = sender as PictureBox;
            foreach (Vehicle heroItem in player1.GetList())
            {
                if (tempPB == heroItem.Item)
                {
                    heroItem.Title.Location = tempPB.Location;
                    return;
                }
            }
            foreach (Vehicle heroItem in player2.GetList())
            {
                if (tempPB == heroItem.Item)
                {
                    //currentVehicle = heroItem;
                    heroItem.Title.Location = tempPB.Location;
                    break;
                }
            }
        }

        private void HandlerShot(Hero player, int shotX, int shotY)
        {
            Random tempRand = new Random();
            Track(new Point(shotX, shotY));

            foreach (CombatUnit tank in player.GetList())
            {
                if (tank is Vehicle)
                {
                    PictureBox tempUnit = (tank as Vehicle).Item;
                    int locX = tempUnit.Location.X;
                    int locY = tempUnit.Location.Y;
                    int sizX = tempUnit.Width;
                    int sizY = tempUnit.Height;

                    //Проверка на попадание
                    if ((shotX >= locX && shotX <= locX + sizX) && (shotY >= locY && shotY <= locY + sizY))
                    {
                        bool check = false;
                        Bomb item = null;
                        if (player is LeftHero && bombSelectRight.SelectedItem != null)
                        {
                            check = true;
                            item = bombSelectRight.SelectedItem as Bomb;
                        }
                        else if (player is RightHero && bombSelectLeft.SelectedItem != null)
                        {
                            check = true;
                            item = bombSelectLeft.SelectedItem as Bomb;
                        }

                        if (check)
                        {
                            int totalDamage = item.damage;
                            foreach (Warrior unit in (tank as Vehicle).Items)
                            {
                                if (!unit.killed)
                                {
                                    if (unit.hp <= totalDamage)
                                    //if (totalDamage - unit.Damage() >= 0)
                                    {
                                        totalDamage -= unit.Damage();
                                        unit.killed = true;
                                    }
                                    else
                                    {
                                        
                                        unit.hp -= totalDamage;
                                        totalDamage = 0;
                                    }
                                }
                            }

                            //Проверка на полное уничтожение
                            if (tank.Damage() <= totalDamage)
                            {
                                (tank as Vehicle).killed = true;
                                tempUnit.BackColor = Color.Red;

                                if (player is LeftHero)
                                {
                                   (player as LeftHero).NotifyObserver();
                                }
                                else if (player is RightHero)
                                {
                                    (player as RightHero).NotifyObserver();
                                }

                            }
                        }

                        (tank as Vehicle).Title.Text = (tank as Vehicle).Damage().ToString();

                        return;
                    }
                }
            }
        }

        private void Track(Point p)
        {
            PictureBox Item = new System.Windows.Forms.PictureBox();
            Item.BackColor = Color.Black;

            Item.Location = p;

            Item.Name = "Shot";
            Item.Size = new System.Drawing.Size(5, 5);
            Item.TabStop = false;

            Item.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tank_MouseDown);
            Item.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tank_MouseMove);
            Item.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tank_MouseUp);

            this.Controls.Add(Item);
            Item.BringToFront();
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
            if (!killed)
            {
                return hp;
            }
            else
            {
                return 0;
            }
        }
    }

    public abstract class Warrior : CombatUnit
    {

    }

    public abstract class Vehicle : CombatUnit
    {
        public PictureBox Item = new System.Windows.Forms.PictureBox();
        public Label Title = new Label();
        public Form1 Form;
        public List<Warrior> Items = new List<Warrior>();
        public string flank;
        protected Color bg;
        protected bool stop = false;

        public new int Damage()
        {
            if (!killed)
            {
                int total = hp;

                foreach (CombatUnit component in Items)
                {
                    total += component.Damage();
                }

                return total;
            }
            else
            {
                return 0;
            }
        }

        public void Reposition(Point point)
        {
            int total = 0;

            foreach (CombatUnit component in Items)
            {
                total += component.Damage();
            }

            if (total == 0)
            {
                stop = true;
            }

            if (!killed && !stop)
            {
                Item.Location = point;
            }
        }

        protected void show(Size size)
        {
            if (flank.Equals("right"))
            {
                Item.Location = new System.Drawing.Point(640, 250 - 100);
            }
            else if (flank.Equals("left"))
            {
                Item.Location = new System.Drawing.Point(517, 250 - 100);
            }
            Item.BackColor = bg;
            Item.Name = "Vehicle";
            Item.Size = size;
            Item.TabStop = false;

            Item.MouseDown += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseDown);
            Item.MouseMove += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseMove);
            Item.MouseUp += new System.Windows.Forms.MouseEventHandler(Form.tank_MouseUp);
            Item.LocationChanged += new System.EventHandler(Form.tank_LocationChanged);

            Form.Controls.Add(Item);
            Item.BringToFront();

            Title.Text = Damage().ToString();
            Title.Location = Item.Location;
            Title.BackColor = System.Drawing.Color.Transparent;
            Title.BackColor = System.Drawing.Color.White;
            Title.Width = 13;
            Title.Height = 13;
            Form.Controls.Add(Title);
            Title.BringToFront();
        }
    }

    public class Lieutenant : Warrior
    {
        public Lieutenant()
        {
            hp = 1;
        }
    }

    public class Captain : Warrior
    {
        public Captain()
        {
            hp = 2;
        }
    }

    public class Maj : Warrior
    {
        public Maj()
        {
            hp = 3;
        }
    }

    public class LightTank : Vehicle
    {

        public LightTank(Form1 parrentForm, string flankLoc)
        {
            hp = 2;
            Form = parrentForm;
            flank = flankLoc;
            if (flank.Equals("left"))
            {
                bg = Color.Green;
            }
            else if (flank.Equals("right"))
            {
                bg = Color.Blue;
            }

            Items.Add(new Lieutenant());
            Items.Add(new Maj());

            show(new Size(45, 35));
        }
    }

    public class HeavyTank : Vehicle
    {
        public HeavyTank(Form1 parrentForm, string flankLoc)
        {
            hp = 3;
            Form = parrentForm;
            flank = flankLoc;
            if (flank.Equals("left"))
            {
                bg = Color.Brown;
            }
            else if (flank.Equals("right"))
            {
                bg = Color.Orange;
            }

            Items.Add(new Lieutenant());
            Items.Add(new Captain());
            Items.Add(new Maj());

            show(new Size(51, 37));
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
            return name + ":" + damage;
        }
    }

    public class SmallBomb : Bomb
    {
        public SmallBomb(string nameValue)
            : base(nameValue)
        {
            damage = 2;
        }
    }

    public class MiddleBomb : Bomb
    {
        public MiddleBomb(string nameValue)
            : base(nameValue)
        {
            damage = 4;
        }
    }

    public class LargeBomb : Bomb
    {
        public LargeBomb(string nameValue)
            : base(nameValue)
        {
            damage = 6;
        }
    }
}
