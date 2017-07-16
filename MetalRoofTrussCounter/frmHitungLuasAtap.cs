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
    public partial class frmHitungLuasAtap : Telerik.WinControls.UI.RadForm
    {
        public frmHitungLuasAtap()
        {
            InitializeComponent();
        }

        private double PanjangBangunan;
        private double LebarBangunan;
        private double SudutKemiringan;
        private double OverstekKemiringan;

        private static double LuasBangunan
        { get; set; }

        private static double LuasAtap
        { get; set; }
                
        public static double HitungLuasAtap(double Panjang, double Lebar, double Sudut, double OverStek = 0.0)
        {
            double luas = 0.00;
            double sudut = Math.Cos(RadianToDegree(Sudut));
            HitungLuasBangunan(Panjang, Lebar);
            luas = (Panjang + (2 * OverStek)) * (Lebar + (2 * OverStek)) / sudut;
            LuasAtap = (Panjang + (OverStek)) * (Lebar + (OverStek)) / sudut;
            LuasAtap = luas;
            return LuasAtap;
        }

        public static double HitungLuasBangunan(double Panjang, double Lebar)
        {
            LuasBangunan = (Panjang) * (Lebar);
            return LuasBangunan;
        }

        private static double RadianToDegree(double Angle)
        {
            return Math.PI * Angle / 180.0;
        }

        private void radBtnHitungLuasAtap_Click(object sender, EventArgs e)
        {
            try
            {
                PanjangBangunan = double.Parse(radTextBoxPanjangBangunan.Text);
                LebarBangunan = double.Parse(radTextBoxLebarBangunan.Text);
                SudutKemiringan = double.Parse(radTextBoxSudut.Text);
                OverstekKemiringan = double.Parse(radTextBoxOverstek.Text);
                double luasBangunan = HitungLuasBangunan(PanjangBangunan, LebarBangunan);
                double luasAtap = HitungLuasAtap(PanjangBangunan, LebarBangunan, SudutKemiringan, OverstekKemiringan);
                double totalTruss = (luasAtap * 4 / 6);
                double totalBatten = (luasAtap * 5 / 6);
                double totalDinabol = PanjangBangunan / double.Parse(radTextBoxJarakRafter.Text) * 2;
                double totalScrew = (((totalTruss * 6 / 4) * 6) + ((totalBatten * 6 / 4) * 4)) * 1.1;
                double totalScrewRoof = (LuasAtap * 12);
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
                    "DinaBolt (Pcs)",
                    "Screw Truss (Pcs)"
                };

                string[] ValuesDef =
            {
                PanjangBangunan.ToString("##0.00"),
                LebarBangunan.ToString("##0.00"),
                SudutKemiringan.ToString("##0.00"),
                OverstekKemiringan.ToString("##0.00"),
                luasBangunan.ToString("##0.00"),
                luasAtap.ToString("##0.00"),
                totalTruss.ToString("##00"),
                totalBatten.ToString("##00"),
                totalDinabol.ToString("##00"),
                totalScrew.ToString("##00")
            };

                frmResult result = new frmResult(Definisi, ValuesDef);
                result.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
