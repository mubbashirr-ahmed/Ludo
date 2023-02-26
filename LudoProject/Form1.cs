using System.Data.SqlClient; 
namespace LudoProject
{
    public partial class Form1 : Form
    {
       
        public int cy1 = 39, cy2 = 39, cy3 = 39, cy4 = 39;
        private int cg1 = 26, cg2 = 26, cg3 = 26, cg4 = 26;
        private int cb1 = 0, cb2 = 0, cb3 = 0, cb4 = 0;
        private int cr1 = 13, cr2 = 13, cr3 = 13, cr4 = 13;
        private bool chkb1 = false, chkb2 = false, chkb3 = false, chkb4 = false;
        private bool chky1 = false, chky2 = false, chky3 = false, chky4 = false;
        private bool chkg1 = false, chkg2 = false, chkg3 = false, chkg4 = false;
        private bool chkr1 = false, chkr2 = false, chkr3 = false, chkr4 = false;
        private bool r1condition = false, r2condition = false, r3condition = false, r4condition = false;
        private bool y1condition = false, y2condition = false, y3condition = false, y4condition = false;
        private bool g1condition = false, g2condition = false, g3condition = false, g4condition = false;
        private bool b1condition = false, b2condition = false, b3condition = false, b4condition = false;
        private int bmax = 50, ymax = 37, gmax = 24, rmax = 11;
        private int val = 1;
        private string[] names = { "Blue", "Yellow", "Green", "Red" };
        private string got = "";
        private int upmoves = 0;
        rules r;
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Ludo;Integrated Security=True;Pooling=False");
            sqlConnection.Open();
            SqlCommand cmd;
            for (int i = 1; i < 52; i++)
            {
                cmd = new SqlCommand("update position set got1=@g where Id=@i", sqlConnection);
                cmd.Parameters.AddWithValue("g", null);
                cmd.Parameters.AddWithValue("i", i);
            }
            sqlConnection.Close();
            r = new rules(diceview);
            got1.Visible= false;
            got2.Visible= false;
            got3.Visible= false;
            got4.Visible= false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             
        }
        private void rolldice_Click(object sender, EventArgs e)
        {
            r.letsroll();
           
            rolldice.Visible= false;
            got1.Visible = true;
            got2.Visible = true;
            got3.Visible = true;
            got4.Visible = true;
        }
        private void got1_Click(object sender, EventArgs e)
        {
            if (r.conditions(b1, y1, g1, r1, ref chkb1, ref chky1, ref chkg1, ref chkr1, ref cb1, ref cy1, ref cg1, ref cr1, bmax, ymax, gmax, rmax, ref got, ref upmoves, ref b1condition, ref y1condition, ref g1condition, ref r1condition))
            {
                if(upmoves!=56)
                {
                    updategame();
                }
            }
            buttonlabel();
        }
        private void got2_Click(object sender, EventArgs e)
        {
            if(r.conditions(b2, y2, g2, r2, ref chkb2, ref chky2, ref chkg2, ref chkr2, ref cb2, ref cy2, ref cg2, ref cr2, bmax, ymax, gmax, rmax, ref got, ref upmoves, ref b2condition, ref y2condition, ref g2condition, ref r2condition))
            {
                updategame();
            }
            buttonlabel();
        }
        private void got3_Click(object sender, EventArgs e)
        {
            if (r.conditions(b3, y3, g3, r3, ref chkb3, ref chky3, ref chkg3, ref chkr3, ref cb3, ref cy3, ref cg3, ref cr3, bmax, ymax, gmax, rmax, ref got, ref upmoves, ref b3condition, ref y3condition, ref g3condition, ref r3condition))
            {
                updategame();
            }
            buttonlabel();
        }
        private void got4_Click(object sender, EventArgs e)
        {
            if (r.conditions(b4, y4, g4, r4, ref chkb4, ref chky4, ref chkg4, ref chkr4, ref cb4, ref cy4, ref cg4, ref cr4, bmax, ymax, gmax, rmax, ref got, ref upmoves, ref b4condition, ref y4condition, ref g4condition, ref r4condition))
            {
                updategame();
            }
            buttonlabel();
        }
        private void buttonlabel()
        {
            turn.Text = names[val % 4];
            val++; 
            got1.Visible = false;
            got2.Visible = false;
            got3.Visible = false;
            got4.Visible = false;
            rolldice.Visible = true;
        }
        private void updategame()
        {
            sqlConnection.Open();
            SqlCommand killgot = new SqlCommand("select got1 from position where id=@pos", sqlConnection);
            killgot.Parameters.AddWithValue("pos", upmoves);
            SqlDataReader sqlDataReader = killgot.ExecuteReader();
            if (sqlDataReader.Read())
            {
                if (sqlDataReader["got1"].ToString() == got)
                {
                     //TODO
                }
                else
                {
                    Point p;
                    if (sqlDataReader["got1"].ToString() == "red" && sqlDataReader["got1"].ToString() != got)
                    {
                        if (cr1==upmoves)
                        {
                            p = new Point(99, 35);
                            r1.Location= p;
                            cr1 = 13;
                            chkr1= false;
                        }
                        else if(cr2==upmoves)
                        {
                            p = new Point(144, 63);
                            r2.Location= p;
                            cr2 = 13;
                            chkr2 = false;
                        }
                        else if(cr3==upmoves)
                        {
                            p = new Point(99, 98);
                            r3.Location= p;
                            cr3 = 13;
                            chkr3 = false;
                        }
                        else if (cr4==upmoves)
                        {
                            p = new Point(54, 63);
                            r4.Location = p;
                            cr4 = 13;
                            chkr4 = false;
                        }
                    }
                    else if (sqlDataReader["got1"].ToString() == "blue" && sqlDataReader["got1"].ToString() != got)
                    {
                        if (cb1 == upmoves)
                        {
                            p = new Point(99, 300);
                            b1.Location = p;
                            cb1 = 0;
                            chkb1= false;
                        }
                        else if (cb2 == upmoves)
                        {
                            p = new Point(144, 328);
                            b2.Location = p;
                            cb2 = 0;
                            chkb2 = false;
                        }
                        else if (cb3 == upmoves)
                        {
                            p = new Point(99, 363);
                            b3.Location = p;
                            cb3 = 0;
                            chkb3 = false;
                        }
                        else if (cb4 == upmoves)
                        {
                            p = new Point(54, 328);
                            b4.Location = p;
                            cb4 = 0;
                            chkb4 = false;
                        }
                    }
                    else if (sqlDataReader["got1"].ToString() == "yellow" && sqlDataReader["got1"].ToString() != got)
                    {
                        if (cy1 == upmoves)
                        {
                            p = new Point(454, 300);
                            y1.Location = p;
                            cy1 = 39;
                            chky1 = false;  
                        }
                        else if (cy2 == upmoves)
                        {
                            p = new Point(499, 328);
                            y2.Location = p;
                            cy2 = 39;
                            chky2 = false;
                        }
                        else if (cy3 == upmoves)
                        {
                            p = new Point(454, 363);
                            y3.Location = p;
                            cy3 = 39;
                            chky3 = false;
                        }
                        else if (cy4 == upmoves)
                        {
                            p = new Point(409, 328);
                            y4.Location = p;
                            cy4 = 39;
                            chky4 = false;
                        }
                    }
                    else if (sqlDataReader["got1"].ToString() == "green" && sqlDataReader["got1"].ToString() != got)
                    {
                        if (cg1 == upmoves)
                        {
                            p = new Point(454, 35);
                            g1.Location = p;
                            cg1 = 26;
                            chkg1 = false; 
                        }
                        else if (cg2 == upmoves)
                        {
                            p = new Point(499, 63);
                            g2.Location = p;
                            cg2 = 26;
                            chkg2 = false;
                        }
                        else if (cg3 == upmoves)
                        {
                            p = new Point(454, 98);
                            g3.Location = p;
                            cg3 = 26;
                            chkg3 = false;
                        }
                        else if (cg4 == upmoves)
                        {
                            p = new Point(409, 63);
                            g4.Location = p;
                            cg4 = 26;
                            chkg4 = false;
                        }
                    }
                }
            }
            sqlDataReader.Close();
            SqlCommand cmd = new SqlCommand("update position set got1=@g1 where id=@i1", sqlConnection);
            cmd.Parameters.AddWithValue("i1", upmoves);
            cmd.Parameters.AddWithValue("g1", got);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}