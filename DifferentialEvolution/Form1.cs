using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DifferentialEvolution
{
    public partial class Form1 : Form
    {
        private int PopulationSize = 50;
        private int NumberOfIterations = 50;
        private int NumberOfParameters = 4;
        private int Strategy = 2;
        public static InputStructure S_Infun1;
        public static double[] bestParam;

        const int k = 6;
        int[] m = new int[k] { 5, 4, 3, 6, 17, 55 };
        int[] n = new int[k] { 4, 8, 10, 13, 82, 114 };
        int[] d = new int[k] { 110, 110, 110, 110, 110, 120 };
        int[] t = new int[k] { 21, 21, 21, 21, 21, 21 };
        int[] v = new int[k] { 90, 90, 90, 90, 90, int.MaxValue };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //S_Infun1 = new InputStructure();
            //S_Infun1.valueToReach = -100000; // Lower bound on the objective function

            //S_Infun1.numberOfParameterObjectiveFunction = 2; // number of parameters to optimize

            //S_Infun1.vectorLowerBound = new double[S_Infun1.numberOfParameterObjectiveFunction]; // lower limit
            //S_Infun1.vectorUpperbound = new double[S_Infun1.numberOfParameterObjectiveFunction];

            //for (int i = 0; i < S_Infun1.numberOfParameterObjectiveFunction; i++)
            //{
            //    S_Infun1.vectorLowerBound[i] = -100;
            //    S_Infun1.vectorUpperbound[i] = 100;
            //}

            //S_Infun1.useBoundConstraint = true; // bound by lower and upper limits
            //S_Infun1.numberOfPopulation = PopulationSize;
            //S_Infun1.maxIteration = NumberOfIterations;
            //S_Infun1.weight = 0.85;
            //S_Infun1.crossOverProbability = 1;
            //S_Infun1.strategy = Strategy;
            //S_Infun1.intermediateOutput = 1;

            //S_Infun1.vectorBest = new double[S_Infun1.numberOfParameterObjectiveFunction];
            //S_Infun1.population = new double[S_Infun1.numberOfParameterObjectiveFunction, S_Infun1.numberOfParameterObjectiveFunction];

            //OptimizerOutput Output = new OptimizerOutput();


            //DifferentialEvolution DE_optimizer = new DifferentialEvolution(new
            //    DifferentialEvolution.FunctionPointer(ObjectiveFunction));

            //Output = DE_optimizer.Optimizer(S_Infun1);
            //bestParam = Output.FVr_bestmem;

            //label10.Text = bestParam[0].ToString("0.000");
            //label11.Text = bestParam[1].ToString("0.000");

            //label13.Text = (-Output.S_bestval.FVr_oa[0]).ToString("0.000");
            //MessageBox.Show("Optimization Done");// Configuring Differential evolution optimizer
            S_Infun1 = new InputStructure();
            S_Infun1.F_VTR = -100000; // Lower bound on the objective function

            S_Infun1.I_D = NumberOfParameters; // number of parameters to optimize

            S_Infun1.FVr_minbound = new double[S_Infun1.I_D]; // lower limit
            S_Infun1.FVr_maxbound = new double[S_Infun1.I_D];

            for (int i = 0; i < S_Infun1.I_D; i++)
            {
                S_Infun1.FVr_minbound[i] = -100;
                S_Infun1.FVr_maxbound[i] = 100;
            }

            S_Infun1.I_bnd_constr = true; // bound by lower and upper limits
            S_Infun1.I_NP = PopulationSize;
            S_Infun1.I_itermax = NumberOfIterations;
            S_Infun1.F_weight = 0.85;
            S_Infun1.F_CR = 1;
            S_Infun1.I_strategy = Strategy;
            S_Infun1.I_refresh = 1;

            S_Infun1.FVr_bestmem = new double[S_Infun1.I_D];
            S_Infun1.FM_pop = new double[S_Infun1.I_NP, S_Infun1.I_D];

            OptimizerOutput Output = new OptimizerOutput();


            DifferentialEvolution DE_optimizer = new DifferentialEvolution(new
                DifferentialEvolution.FunctionPointer(ObjectiveFunction));

            Output = DE_optimizer.Optimizer(S_Infun1);
            bestParam = Output.FVr_bestmem;

            MessageBox.Show(bestParam[0].ToString("0.000") + " " + bestParam[1].ToString("0.000"));
            MessageBox.Show((-Output.S_bestval.FVr_oa[0]).ToString("0.000"));
            //label10.Text = bestParam[0].ToString("0.000");
            //label11.Text = bestParam[1].ToString("0.000");

            //label13.Text = (-Output.S_bestval.FVr_oa[0]).ToString("0.000");
            MessageBox.Show("Optimization Done");
        }

        int[,] panjangRute = new int[15, 15];

        public OutputFunction ObjectiveFunction(double[] parameters, InputStructure input)
        {
            ////cost of roster
            ////min for i = 1...m[k] for j = 1...n[k] d[j][k]x[i][j][k]
            //OutputFunction result = new OutputFunction(0, 3);
            //result.vectorConstraintArray[0] = 0;

            //double cost = 0;

            //for (int i = 0; i < 5; i++)
            //{

            //}

            //result.vectorObjectiveArray[0] = -cost;

            //return result;
            OutputFunction result = new OutputFunction();
            result.I_nc = 0; // any constrains??
            result.FVr_ca = new double[1] { 0 };
            result.I_no = 1; // number of outputs

            double x = parameters[0];
            double y = parameters[1];

            //double z = 3 * Math.Pow((1 - x), 2) * Math.Exp(-(Math.Pow(x, 2)) - Math.Pow((y + 1), 2))
            //    - 10 * (x / 5 - Math.Pow(x, 3) - Math.Pow(y, 5)) * Math.Exp(-Math.Pow(x, 2)
            //    - Math.Pow(y, 2)) - 1 / 3 * Math.Exp(-Math.Pow((x + 1), 2) - Math.Pow(y, 2));
            double z = 0.0;
            for (int i = 0; i < S_Infun1.I_D; i++)
            {
                z += parameters[i];
            }

            //VRP
            //Total Biaya=Biaya Sewa Kendaraan + Biaya Perjalanan
            //parameters len = jumlah kendaraan
            //parameters<int> = rute

            //int rute = 0;

            //foreach (List<int> list in parameters)
            //{
            //    for (int i = 0; i < list.Count - 1; i++)
            //    {
            //        rute += panjangRute[list[i], list[i + 1]];
            //    }
            //}

            double solution = ((parameters[0] / 15) * 6500) + (parameters[1] * 150000);

            result.FVr_oa = new double[1] { -solution }; // it is a minimizer
            return result;
        }
        //    const int k = 6;
        //    int[] m = new int[k] { 5, 4, 3, 6, 17, 55 };
        //    int[] n = new int[k] { 4, 8, 10, 13, 82, 114 };
        //    int[] d = new int[k] { 110, 110, 110, 110, 110, 120 };
        //    int[] t = new int[k] { 21, 21, 21, 21, 21, 21 };
        //    int[] v = new int[k] { 90, 90, 90, 90, 90, int.MaxValue };
    }
}
