using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pollakszimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int intelligence=10;
        int happiness=10;
        int sleep=10;
        int hunger=10;
        int smell=10;
        int hours=24;
        int hoursPlayed;
        int intelligencetmp;
        int happinesstmp;
        int sleeptmp;
        int hungertmp;
        int smelltmp;
        int day;
        int dtmp = 0;
        bool in_event = false;
        int date = 0;
        int eventnum = 0;

        public void random_encounter()
        {
            if (in_event == false )
            {
                Random rnd = new Random();
                int random = rnd.Next(0, 5);
                storylbl.Text = "Egy átlagos nap :(";
                outcome.Visible = false;
                if (random == 0)
                    first();
                if (random == 1)
                {
                    second();
                }
            }
            else if(eventnum==1)
            {
                if (eventnum == 1)
                    first();
                if (eventnum == 2)
                    second();
                
            }

        }

        public void first()
        {
            in_event = true;
            eventnum = 1;
            if (dtmp == 0)
            {
                storylbl.Text = "Az iskolába menet megpillantassz egy gyönyörű lányt";
                happiness += 10;
                
            }
            if (dtmp == 1)
            {
                storylbl.Text = "Elhatározod hogy odamész hozzá";
                outcome.Visible = true;
                if (smell > 50&&in_event==true)
                {
                    outcome.Text = "Ahogy megközelítetted elhányta magát.(lehet meg kéne fürdeni)";
                    in_event = false;
                }
                if (intelligence < 30&&in_event==true)
                {
                    outcome.Text = "Sajnos nem sikerült egy értelmes beszélgetést folyatnotok mert retardált vagy";
                    in_event = false;
                }
                else
                {
                    outcome.Text = "Sikeresen megbeszélsz vele egy randit ami 6 nap múlva lesz";
                    date = day + 6;
                    in_event = false;
                }

            }
        }
        public void second()
        {
            in_event = true;
            eventnum = 2;
            storylbl.Text = "Az iskolában meghallod hogy Kovi Ati szeretné ha befáradnál az igazgatóiba";
            Random rnd = new Random();
            int rnb = rnd.Next(0, 3);
            if (rnb == 0)
            {
                outcome.Visible = true;
                outcome.Text = "Az iskolát degradáló mémek készítéséért kirugnak bruh";
                in_event = false;
            }
            if(rnb==1||intelligence>50)
            {
                outcome.Visible = true;
                outcome.Text = "Kovi Ati megdicsér a jó iskolai tanulmányaid miatt(nem tudja hogy be se jársz a suliba xd)";
                in_event = false;
            }
            else {
                outcome.Visible = true;
                outcome.Text = "Kovi Ati leszidott mert a wc ben maszturbáltál nyitott ajtónál";
                in_event = false;
            }

        }
        public void datefn()
        {
            Random rnd = new Random();
            storylbl.Text = "Randiiii nap<3";
            int a = rnd.Next(0, 1);
            if (a == 0)
            {
                outcome.Text = "A randin fény derült a lány értelmi fogyatékosságaira(rá ürített az asztalraxd)";
                happiness -= 50;
                in_event = false;
            }
            if (a== 1){
                outcome.Text = "A randi nagyszerűen sikerült";
                happiness += 50;
                in_event = false;
            }
        }
        private void studybtn_Click(object sender, EventArgs e)
        {
            try
            {
                intelligencetmp = (int.Parse(studytb.Text) / 2) + (sleep / 3) - (hunger / 2)-(happiness/6);
                hours -= int.Parse(studytb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
                studybtn.Enabled = false;
            }
            catch (Exception)
            {
                studytb.Text = "egy számot írj be";
                
            }
           
        }

        private void playbtn_Click(object sender, EventArgs e)
        {
            try
            {
                happinesstmp = int.Parse(playetb.Text)/3 - (hoursPlayed / 10) - (hunger / 2) + (sleep / 3);
                playbtn.Enabled = false;
                hours -= int.Parse(playetb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
            }
            catch (Exception)
            {

                playetb.Text = "egy számot írj be";
            }
        }

        private void endDaybtn_Click(object sender, EventArgs e)
        {
            if (hours == 0)
            {
                day++;
                daycount.Text = day + ".nap";
                hours = 24;
                hoursPlayed += int.Parse(playetb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
                studybtn.Enabled = true;
                playbtn.Enabled = true;
                partybtn.Enabled = true;
                eatbtn.Enabled = true;
                showerbtn.Enabled = true;
                sleepbtn.Enabled = true;
                studytb.Text = "";
                playetb.Text = "";
                partytb.Text = "";
                eattb.Text = "";
                showertb.Text = "";
                sleeptb.Text = "";
                if (in_event == true)
                {
                    dtmp++;
                }
                else
                {
                    outcome.Visible = false;
                    outcome.Text = "";
                    storylbl.Text = "Egy átlagos nap(:";
                }
                hunger -= hungertmp;
                if (hunger < 0)
                {
                    hunger = 0;
                }
                intelligence += intelligencetmp;
                happiness += happinesstmp;
                smell = smelltmp;
                sleep = sleeptmp;
                intelligencelbl.Text="inteligencia: "+intelligence;
                happinesslbl.Text="boldogság: "+happiness;
                hungerlbl.Text="éhség: "+hunger;
                showerlbl.Text="tisztaság: "+smell;
                sleeplbl.Text="álmosság: "+sleep;
                if (hunger>10)
                {
                    storylbl.Text = "Éhenhaltál xd";
                }
                if (day == date)
                {
                    in_event = true;
                    datefn();
                }
                random_encounter();
            }
        }

        private void partybtn_Click(object sender, EventArgs e)
        {
            try
            {
                partybtn.Enabled = false;
                happinesstmp = int.Parse(partytb.Text) / 3 - (hunger / 2) + (sleep / 3);
                hunger += 2;
                hours -= int.Parse(partytb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
                
            }
            catch (Exception)
            {
                partytb.Text = "egy számot adj meg";
                throw;
            } 
        }

        private void eatbtn_Click(object sender, EventArgs e)
        {
            try
            {
                eatbtn.Enabled = false;
                hours -= int.Parse(eattb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
                if (hunger > 0)
                {
                    hungertmp = int.Parse(eattb.Text) * 5;
                }
            }
            catch
            {
                eattb.Text = "egy számot adj meg";
            }
        }

        private void showerbtn_Click(object sender, EventArgs e)
        {
            
                showerbtn.Enabled = false;
                hours -= int.Parse(showertb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
            try
            {
                if (int.Parse(showertb.Text) > 0)
                {
                    smelltmp = 0;
                }
                else
                {
                    smelltmp += 10;
                }
            }
            catch
            {
                showertb.Text = "egy számot adj meg";
            }
        
        }

        private void sleepbtn_Click(object sender, EventArgs e)
        {
            sleepbtn.Enabled = false;
            try
            {
                hours -= int.Parse(sleeptb.Text);
                hoursleftlbl.Text = hours + "óra van hátra";
                if (int.Parse(sleeptb.Text) > 8)
                {
                    sleeptmp = 100;

                }
                if (int.Parse(sleeptb.Text) > 4 && int.Parse(sleeptb.Text) < 8)
                {
                    sleeptmp = 50;

                }
                if (int.Parse(sleeptb.Text) > 2 && int.Parse(sleeptb.Text) < 4)
                {
                    sleeptmp = 25;

                }
            }
            catch
            {
                showertb.Text = "egy számot adj meg";
            }
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            intelligencelbl.Text = "inteligencia: " + intelligence;
            happinesslbl.Text = "boldogság: " + happiness;
            hungerlbl.Text = "éhség: " + hunger;
            showerlbl.Text = "tisztaság: " + smell;
            sleeplbl.Text = "álmosság: " + sleep;
            hoursleftlbl.Text = hours + "óra van hátra";
            daycount.Text = day + ".nap";
        }
    }
}
