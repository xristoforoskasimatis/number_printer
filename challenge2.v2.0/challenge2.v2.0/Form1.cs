using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace challenge2.v2._0
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;// otan anoigei i forma epilegmeno control einai to textbox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int z;
            if (int.TryParse(textBox1.Text, out z) == true)//elegxos an einai integer
            {
                richTextBox1.Clear();//an nai adeiazei to textbox kai 
                z = int.Parse(textBox1.Text);//dinei timi
            }
            int[] pin = new int[z];//dimiourgei pinaka megeyhous isou me ton arthmo pou evale o xristis
            List<int> n = new List<int>();//dimiourgia listas integer
            Stopwatch watch = new Stopwatch();//dimiourgia rologia gia metrisi
            watch.Start();//enerksi xronou
            for (int i = 0; i < z;)//enarksi epanalipsis gia ola ta stixia apo to 1-z
            {
            label1: int ra = r.Next(1, z + 1);//tixaios ari8mos sto diastima [1,z]
                if (n.Contains(ra))//an periexetai stin lista
                {
                    goto label1;//ksanaepilegei tixaio ari8mo
                }
                else
                {
                    n.Add(ra);//allios ton prosthetei stin lista
                    pin[i] = ra;  //ton topothetei stin thesi tou pinaka                 
                    i++;//kai ayksanei tin epanalipsi
                }
            }
            watch.Stop();//stamataei to roloi
            label3.Text = watch.ElapsedMilliseconds.ToString();//emfanisi xronou
            for (int y = 0; y < z; y++)
                richTextBox1.AppendText(pin[y] + Environment.NewLine);//emfanisei stoixewn pinaka

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//an pati8ei enter
            {
                button1_Click(sender, e);//klisi sinartisis gia to koumpi
            }
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Δημιουργός: ΚΑΣΙΜΑΤΗΣ ΧΡΙΣΤΟΦΟΡΟΣ-ΝΙΚΗΤΑΣ." + Environment.NewLine +
                "Τμήμα πληροφορικής, Πανεπιστημίο Πειραιά");//emfanisi dimiourgou
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ΒΑΛΕ ΕΝΑΝ ΑΚΕΡΑΙΟ ΣΤΟ ΠΕΔΙΟ ΕΙΣΑΓΩΓΗΣ. ΣΤΗΝ ΣΥΝΕΧΕΙΑ ΠΑΤΗΣΕ ΤΟ ΚΟΥΜΠΙ ΚΑΙ " +
                "ΘΑ ΕΜΦΑΝΙΣΤΟΥΝ ΣΤΟ ΑΡΙΣΤΕΡΟ ΜΕΡΟΣ ΤΗΣ ΟΘΟΝΗΣ ΟΛΟΙ ΑΡΙΘΜΟΙ ΑΠΟ ΤΟ 1 ΜΕΧΡΙ ΤΟΝ ΑΡΙΘΜΟ ΠΟΥ ΕΒΑΛΕΣ" +
                "ΜΕ ΤΥΧΑΙΑ ΣΕΙΡΑ.ΤΕΛΟΣ ΕΜΦΑΝΙΖΕΤΑΙ Ο ΧΡΟΝΟΣ ΠΟΥΥ ΧΡΕΙΑΣΤΗΚΕ ΓΙΑ ΝΑ ΟΛΟΚΛΗΡΩΘΕΙ Η ΔΙΑΔΙΚΑΣΙΑ. ");
            // emfanisi voitheias
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT?", "EXIT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {//emfanisi minimatos gia klisimo
                //an o xristis patisie nai kleinei

                this.Close();
            }
        }
    }
}
