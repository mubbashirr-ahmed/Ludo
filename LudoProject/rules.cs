using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LudoProject
{
    internal class rules
    {
        Point p;
        SqlConnection sqlConnection;
        gamelogics g;
        bool res;
        int numm;
        public rules(PictureBox dice)
        {
            g = new gamelogics(dice);
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Ludo;Integrated Security=True;Pooling=False"); 
        }
        public void letsroll()
        {
            numm = g.turn();
        }
        public bool conditions(PictureBox pb, PictureBox py, PictureBox pg, PictureBox pr, ref bool sb, ref bool sy, ref bool sg, ref bool sr, ref int cpb, ref int cpy, ref int cpg, ref int cpr, int bmax, int ymax, int gmax, int rmax, ref string got, ref int upmoves, ref bool b1condition, ref bool y1condition, ref bool g1condition, ref bool r1condition)
        {
            res = false;
            if (numm == 0)
            {
                p = new Point(237, 378);
                gottimovement(pb, p, ref sb, ref cpb, bmax, ref b1condition);
                got = "blue";
                if(b1condition)
                {
                    upmoves = 56;
                }
                else
                {
                    upmoves = cpb;
                }
            }
            else if (numm == 1)
            {
                p = new Point(512, 230);
                gottimovement(py, p, ref sy, ref cpy, ymax, ref y1condition);
                got = "yellow";
                if (y1condition)
                {
                    upmoves = 56;
                }
                else
                {
                    upmoves = cpy;
                }
            }
            else if (numm == 2)
            {
                p = new Point(316, 26);
                gottimovement(pg, p, ref sg, ref cpg, gmax, ref g1condition);
                got = "green";
                if (g1condition)
                {
                    upmoves = 56;
                }
                else
                {
                    upmoves = cpg;
                }
            }
            else if (numm == 3)
            {
                p = new Point(40, 171);
                gottimovement(pr, p, ref sr, ref cpr, rmax, ref r1condition);
                got = "red";
                if (r1condition)
                {
                    upmoves = 56;
                }
                else
                {
                    upmoves = cpr;
                }
            }
            return res;
        }
        private void gottimovement(PictureBox pb, Point p, ref bool state, ref int moves, int max, ref bool condition)
        {
            
            if (g.currentnum() == 6 && !state)
            {
                pb.Location = p;
                state = true;
                res = false;
            }
            else if (state)
            {
                sqlConnection.Open();
                SqlCommand updateprevposition = new SqlCommand("update position set got1=@g2 where id=@i2", sqlConnection);
                updateprevposition.Parameters.AddWithValue("i2", moves);
                updateprevposition.Parameters.AddWithValue("g2", "empty");
                updateprevposition.ExecuteNonQuery();
                sqlConnection.Close();
                g.movement(pb, ref moves, max, ref condition);
                
                res = true;
            }
           
        }
    }
}
