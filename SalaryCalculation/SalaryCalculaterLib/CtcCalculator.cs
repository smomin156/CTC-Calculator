using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculaterLib
{
    public class CtcCalculator
    {
        #region Property
        public int CtcMonthly { get; set; }
        public int CtcAnnual { get; set; }
        public int BasicMonthly { get; set; }
        public int BasicAnnual { get; set; }
        public int BasicPercent { get; set; }
        public int HraMonthly { get; set; }
        public int HraAnnual { get; set; }
        public int HraPercent { get; set; }
        public int ConvMonthly { get; set; }
        public int ConvAnnual { get; set; }
        public int ConvAmount { get; set; }
        public int MediMonthly { get; set; }
        public int MediAnnual { get; set; }
        public int MediAmount { get; set; }
        public int PfMonthly { get; set; }
        public int PfAnnual { get; set; }
        public int PfLimit { get; set; }
        public int PfPercent { get; set; }
        public int PfAmount { get; set; }
        public int EsicMonthly { get; set; }
        public int EsicAnnual { get; set; }
        public int EsicLimit { get; set; }
        public decimal EsicPercent { get; set; }
        public int SpMonthly { get; set; }
        public int SpAnnual { get; set; }
        public int LtaMonthly { get; set; }
        public int LtaAnnual { get; set; }
        public int TotalMonthlyCtc { get; set; }
        public int totalAnnualCtc { get; set; }

        #endregion

        #region Constructor
        public CtcCalculator(int ctcAnnual,int basicPercent,int hraPercent,int convAmount,int mediAmount,int pfPercent,int pfLimit,int pfAmount,int esicLimit,decimal esicPercent)
        {
            CtcAnnual = ctcAnnual;
            BasicPercent = basicPercent;
            HraPercent = hraPercent;
            ConvAmount = convAmount;
            MediAmount = mediAmount;
            PfPercent = pfPercent;
            PfLimit = pfLimit;
            PfAmount = pfAmount;
            EsicLimit = esicLimit;
            EsicPercent = esicPercent;
        }
        #endregion

        #region Methods
        private void CtcCalculatortotal()
        {
            CtcMonthly = Convert.ToInt32( Math.Round((double)CtcAnnual/12));
        }
        private void BasicCalculator()
        {
            BasicAnnual = Convert.ToInt32(Math.Round((double)(CtcAnnual * BasicPercent) / 100));
            BasicMonthly = Convert.ToInt32(Math.Round((double)BasicAnnual / 12));
        }
        private void HraCalculator()
        {
            HraAnnual = Convert.ToInt32(Math.Round((double)(BasicAnnual * HraPercent) / 100));
            HraMonthly = Convert.ToInt32(Math.Round((double)HraAnnual / 12));
        }
        private void ConvCalculator()
        {
            ConvMonthly = ConvAmount;
            ConvAnnual = Convert.ToInt32(Math.Round((double)ConvMonthly * 12));
        }
        private void MediCalculator()
        {
            MediMonthly = MediAmount;
            MediAnnual = Convert.ToInt32(Math.Round((double)MediMonthly * 12));
        }
        private void PfCalculator()
        {
            if(BasicMonthly < PfLimit)
            {
                PfAnnual = Convert.ToInt32(Math.Round((double)(BasicAnnual * PfPercent) / 100));
                PfMonthly = Convert.ToInt32(Math.Round((double)PfAnnual / 12));
            }
            else
            {
                PfAnnual = PfAmount;
                PfMonthly = Convert.ToInt32(Math.Round((double)PfAnnual / 12));
            }
        }
        private void LtaCalculator()
        {
            LtaAnnual = BasicMonthly;
            LtaMonthly = Convert.ToInt32(Math.Round((double)LtaAnnual / 12));
        }
        private void EsicCalculator()
        {
            EsicAnnual = Convert.ToInt32(Math.Round((double)((CtcAnnual - PfAnnual - LtaAnnual) / (1 + (EsicPercent / 100))) * (double)(EsicPercent / 100)));
            EsicMonthly = Convert.ToInt32(Math.Round((double)EsicAnnual / 12));
            SpAnnual = Convert.ToInt32(Math.Round((double)CtcAnnual - BasicAnnual - HraAnnual - ConvAnnual - MediAnnual - LtaAnnual - PfAnnual - EsicAnnual));
            SpMonthly = Convert.ToInt32(Math.Round((double)SpAnnual / 12));
            int esicNew = Convert.ToInt32(Math.Round((double)BasicMonthly + HraMonthly + ConvMonthly + MediMonthly + SpMonthly));
            if(esicNew > EsicLimit)
            {
                EsicAnnual = 0;
                EsicMonthly = 0;
            }
            SpAnnual = Convert.ToInt32(Math.Round((double)CtcAnnual - BasicAnnual - HraAnnual - ConvAnnual - MediAnnual - LtaAnnual - PfAnnual - EsicAnnual));
            SpMonthly = Convert.ToInt32(Math.Round((double)SpAnnual / 12));
        }
        private void TotalResultCalculator()
        {
            totalAnnualCtc = BasicAnnual + HraAnnual + ConvAnnual + MediAnnual + PfAnnual + EsicAnnual + SpAnnual + LtaAnnual;
            TotalMonthlyCtc = BasicMonthly + HraMonthly + ConvMonthly + MediMonthly + PfMonthly + EsicMonthly + SpMonthly + LtaMonthly;
        }
        public void CalculateCtcBreakup()
        {
            CtcCalculatortotal();
            BasicCalculator();
            HraCalculator();
            ConvCalculator();
            MediCalculator();
            PfCalculator();
            LtaCalculator();
            EsicCalculator();
            TotalResultCalculator();
        }
        public override string ToString()
        {
            return string.Format($"CTC : {CtcAnnual}\t\t{CtcMonthly}\nBasic : {BasicAnnual}\t\t{BasicMonthly}\nHRA : {HraAnnual}\t\t{HraMonthly}\nConv : {ConvAnnual}\t\t{ConvMonthly}\nMedical : {MediAnnual}\t\t{MediMonthly}" +
                $"\nPF : {PfAnnual}\t\t{PfMonthly}\nEsic : {EsicAnnual}\t\t{EsicMonthly}\nSp : {SpAnnual}\t\t{SpMonthly}\nLta : {LtaAnnual}\t\t{LtaMonthly}\nTotalAnnual : {totalAnnualCtc}\t{TotalMonthlyCtc}");
        }
        #endregion

    }
}
