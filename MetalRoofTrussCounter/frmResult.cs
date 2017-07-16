using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetalRoofTrussCounter
{
    public partial class frmResult : Telerik.WinControls.UI.RadForm
    {
        public frmResult()
        {
            InitializeComponent();
        }

        public frmResult(double Panjang, double Lebar, double Sudut, double Overstek, double LuasBangunan, double LuasAtap)
        {
            InitializeComponent();

            string[] Definisi = new string[]
            {
                "Panjang (M)",
                "Lebar (M)",
                "Sudut (M)",
                "Overstek (M)",
                "Luas Bangunan (M2)",
                "Luas Atap Kemiringan (M2)",
                "C-Truss75 (Batang)",
                "Batten35 (Batang)",
                "DinaBolt (Pcs)"
            };
            string[] ArrayValues = new string[] 
            {
                Panjang.ToString("##0.00"),
                Lebar.ToString("##0.00"),
                Sudut.ToString("##0.00"),
                Overstek.ToString("##0.00"),
                LuasBangunan.ToString("##0.00"),
                LuasAtap.ToString("##0.00")
            };
            string[] Values = new string[2];
            for (int i = 0; i <= 5; i++)
            {
                Values[0] = Definisi[i];
                Values[1] = ArrayValues[i];
                dataGridView1.Rows.Add(Values);
            }
                        
        }

        public frmResult(string[] ArrDef, string[] ArrValues)
        {
            InitializeComponent();
            string[] array = new string[2];
            for (int i = 0; i < ArrDef.Length; i++)
            {
                array[0] = ArrDef[i];
                array[1] = ArrValues[i];
                dataGridView1.Rows.Add(array);
            }
        }
         
        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
