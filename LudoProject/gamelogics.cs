using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LudoProject
{
    internal class gamelogics
    {
        private static int pt = 0;
        private int current;
        int thisturn;
        private Point[] point = new Point[52];
        Point[] bpoints = new Point[7];
        Point[] ypoints = new Point[7];
        Point[] gpoints = new Point[7];
        Point[] rpoints = new Point[7];
        private PictureBox pb;
        public gamelogics(PictureBox pictureBox)
        {
            pb = pictureBox;
            assign();
        }
        public int turn()
        {   
            dicenum();
            thisturn = pt % 4;
            pt++;
            return thisturn;
        }
        public void movement(PictureBox overall, ref int curr, int max, ref bool condition)
        {
            for (int i = 0; i < currentnum(); i++)
            {
                if(condition)
                {
                    if (((currentnum() - i) > (6 - curr)) || curr == 6)
                    {
                        break;
                    }
                    else
                    {
                        if (thisturn == 0)
                        {
                            curr++;
                            overall.Location = bpoints[curr];
                        }
                        else if (thisturn == 1)
                        {
                            curr++;
                            overall.Location = ypoints[curr];
                        }
                        else if (thisturn==2)
                        {
                            curr++;
                            overall.Location = gpoints[curr];
                        }
                        else if(thisturn == 3)
                        {
                            curr++;
                            overall.Location = rpoints[curr];
                        }
                    }
                }
                else
                {
                    curr++;
                    if (curr == 52)
                    {
                        curr = 0;
                        overall.Location = point[curr];
                    }
                    else if (curr == max)
                    {
                        condition = true;
                        overall.Location = point[curr];
                        curr = 0;
                    }
                    else
                    {
                        overall.Location = point[curr];
                    }
                }
            }
        }
        public int currentnum()
        {
            return current;
        }
        private void dicenum()
        {
            Random num = new Random();
            int value = num.Next(1, 7);
            current = value;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = Image.FromFile(@"C:\Users\Hp\source\repos\LudoProject\LudoProject\Resources\" + value + ".jpg");       
        }
        private void assign()
        {
            point[0]  = new Point(237, 378);
            point[1]  = new Point(237, 348);
            point[2]  = new Point(237, 318);
            point[3]  = new Point(237, 288);
            point[4]  = new Point(237, 258);

            point[5]  = new Point(197, 230);
            point[6]  = new Point(157, 230);
            point[7]  = new Point(120, 230);
            point[8]  = new Point(80, 230);
            point[9]  = new Point(40, 230);
            point[10] = new Point(0, 230);
            point[11] = new Point(0, 203);
            point[12] = new Point(0, 170);
            point[13] = new Point(40, 170);
            point[14] = new Point(80, 170);
            point[15] = new Point(120, 170);
            point[16] = new Point(160, 170);
            point[17] = new Point(200, 170);

            point[18] = new Point(237, 142);
            point[19] = new Point(237, 112);
            point[20] = new Point(237, 82);
            point[21] = new Point(237, 52);
            point[22] = new Point(237, 22);
            point[23] = new Point(237, 0);
            point[24] = new Point(277, 0);
            point[25] = new Point(317, 0);
            point[26] = new Point(317, 22);
            point[27] = new Point(317, 52);
            point[28] = new Point(317, 82);
            point[29] = new Point(317, 112);
            point[30] = new Point(317, 142);

            point[31] = new Point(354, 170);
            point[32] = new Point(394, 170);
            point[33] = new Point(434, 170);
            point[34] = new Point(474, 170);
            point[35] = new Point(514, 170);
            point[36] = new Point(554, 170);
            point[37] = new Point(554, 200);
            point[38] = new Point(554, 230);
            point[39] = new Point(514, 230);
            point[40] = new Point(474, 230);
            point[41] = new Point(434, 230);
            point[42] = new Point(394, 230);
            point[43] = new Point(354, 230);

            point[44] = new Point(316, 260);
            point[45] = new Point(316, 290);
            point[46] = new Point(316, 320);
            point[47] = new Point(316, 350);
            point[48] = new Point(316, 380);
            point[49] = new Point(316, 410);
            point[50] = new Point(276, 410);
            point[51] = new Point(236, 410);
            //blue final points
            bpoints[0] = new Point(276, 378);
            bpoints[1] = new Point(276, 378);   
            bpoints[2] = new Point(276, 347);   
            bpoints[3] = new Point(276, 319);   
            bpoints[4] = new Point(276, 289);   
            bpoints[5] = new Point(276, 263);   
            bpoints[6] = new Point(276, 229);
            //yellow final points
            ypoints[0] = new Point(512, 200);
            ypoints[1] = new Point(512, 200);
            ypoints[2] = new Point(472, 200);
            ypoints[3] = new Point(432, 200);
            ypoints[4] = new Point(392, 200);
            ypoints[5] = new Point(352, 200);
            ypoints[6] = new Point(312, 200);
            
            //green final points
            gpoints[0] = new Point(276, 27);
            gpoints[1] = new Point(276, 27);
            gpoints[2] = new Point(276, 57);
            gpoints[3] = new Point(276, 87);
            gpoints[4] = new Point(276, 117);
            gpoints[5] = new Point(276, 147);
            gpoints[6] = new Point(276, 179);
            //red final points
            rpoints[0] = new Point(40, 200);
            rpoints[1] = new Point(40, 200);
            rpoints[2] = new Point(80, 200);
            rpoints[3] = new Point(120, 200);
            rpoints[4] = new Point(160, 200);
            rpoints[5] = new Point(200, 200);
            rpoints[6] = new Point(240, 200);
            
        }
    } 
}