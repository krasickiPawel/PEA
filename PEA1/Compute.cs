using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PEA1
{
    class Compute
    {
        public static void RunBF(FileHolder fileHolder, List<double> times, Label label3, Label label4, Dictionary<int, int[]> results = null)
        {
            BruteForce bruteForce = new BruteForce(fileHolder);
            Stopwatch stopWatch = new Stopwatch();  //sprawne obliczanie czasu w C#
            
            stopWatch.Start();
            bruteForce.FindBestSolution();
            stopWatch.Stop();

            if (results != null)
            {
                int minVal = bruteForce.GetBestCost();
                int[] minPath = bruteForce.GetBestPath();
                if (results.Keys.Count > 0)
                {
                    if (minVal < results.Keys.Min())
                    {
                        results.Clear();
                        results.Add(minVal, minPath);
                    }
                }
                else results.Add(minVal, minPath);
            }

            TimeSpan ts = stopWatch.Elapsed;
            times.Add(ts.TotalMilliseconds);
            label4.Text = "Czas wykonania algorytmu BF: " + ts.TotalMilliseconds.ToString() + " ms";

            int bestCost = bruteForce.GetBestCost();
            int[] bestPath = bruteForce.GetBestPath();
            label3.Text = "Najlepsza droga: " + bestCost.ToString() + " dla ścieżki: ";
            foreach (int city in bestPath)
            {
                label3.Text += city.ToString() + " ";
            }
            label3.Text += "0";

        }

        public static void RunDP(FileHolder fileHolder, List<double> times, Label label3, Label label4, Dictionary<int, int[]> results = null)
        {
            DynamicProgramming dynamicProgramming = new DynamicProgramming(fileHolder);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            dynamicProgramming.FindBestSolution();
            stopWatch.Stop();

            if (results != null)
            {
                int minVal = dynamicProgramming.GetBestCost();
                int[] minPath = dynamicProgramming.GetBestPath();
                if (results.Keys.Count > 0)
                {
                    if (minVal < results.Keys.Min())
                    {
                        results.Clear();
                        results.Add(minVal, minPath);
                    }
                }
                else results.Add(minVal, minPath);
            }

            TimeSpan ts = stopWatch.Elapsed;
            times.Add(ts.TotalMilliseconds);
            label4.Text = "Czas wykonania algorytmu DP: " + ts.TotalMilliseconds.ToString() + " ms";

            int bestCost = dynamicProgramming.GetBestCost();
            int[] bestPath = dynamicProgramming.GetBestPath();
            label3.Text = "Najlepsza droga: " + bestCost.ToString() + " dla ścieżki: ";
            foreach (int city in bestPath)
            {
                label3.Text += city.ToString() + " ";
            }
            label3.Text += "0";
        }

        public static void RunSA(FileHolder fileHolder, List<double> times, Label label3, Label label4, double givenTime, string neighbourType, Dictionary<int, int[]> results = null)
        {
            SimulatedAnnealing simulatedAnnealing = new SimulatedAnnealing(fileHolder, givenTime, neighbourType);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            simulatedAnnealing.FindBestSolution();
            stopWatch.Stop();

            if (results != null)
            {
                int minVal = simulatedAnnealing.GetBestCost();
                int[] minPath = simulatedAnnealing.GetBestPath();
                if (results.Keys.Count > 0)
                {
                    if(minVal < results.Keys.Min())
                    {
                        results.Clear();
                        results.Add(minVal, minPath);
                    }
                }
                else results.Add(minVal, minPath);
            }

            TimeSpan ts = stopWatch.Elapsed;
            times.Add(ts.TotalMilliseconds);
            label4.Text = "Czas wykonania algorytmu SA: " + ts.TotalMilliseconds.ToString() + " ms";

            int bestCost = simulatedAnnealing.GetBestCost();
            int[] bestPath = simulatedAnnealing.GetBestPath();
            label3.Text = "Najlepsza droga: " + bestCost.ToString() + " dla ścieżki: ";
            foreach (int city in bestPath)
            {
                label3.Text += city.ToString() + " ";
            }
            label3.Text += "0";
        }

        public static void RunTS(FileHolder fileHolder, List<double> times, Label label3, Label label4, double givenTime, string neighbourType, bool diversification, Dictionary<int, int[]> results = null)
        {
            TabuSearch tabuSearch = new TabuSearch(fileHolder, givenTime, neighbourType, diversification);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            tabuSearch.FindBestSolution();
            stopWatch.Stop();

            if (results != null)
            {
                int minVal = tabuSearch.GetBestCost();
                int[] minPath = tabuSearch.GetBestPath();
                if (results.Keys.Count > 0)
                {
                    if (minVal < results.Keys.Min())
                    {
                        results.Clear();
                        results.Add(minVal, minPath);
                    }
                }
                else results.Add(minVal, minPath);
            }

            TimeSpan ts = stopWatch.Elapsed;
            times.Add(ts.TotalMilliseconds);
            label4.Text = "Czas wykonania algorytmu TS: " + ts.TotalMilliseconds.ToString() + " ms";

            int bestCost = tabuSearch.GetBestCost();
            int[] bestPath = tabuSearch.GetBestPath();
            label3.Text = "Najlepsza droga: " + bestCost.ToString() + " dla ścieżki: ";
            foreach (int city in bestPath)
            {
                label3.Text += city.ToString() + " ";
            }
            label3.Text += "0";
        }

        public static void RunBnB(FileHolder fileHolder, List<double> times, Label label3, Label label4, Dictionary<int, int[]> results = null)
        {
            BranchAndBound branchAndBound = new BranchAndBound(fileHolder);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            branchAndBound.FindBestSolution();
            stopWatch.Stop();

            if (results != null)
            {
                int minVal = branchAndBound.GetBestCost();
                int[] minPath = branchAndBound.GetBestPath();
                if (results.Keys.Count > 0)
                {
                    if (minVal < results.Keys.Min())
                    {
                        results.Clear();
                        results.Add(minVal, minPath);
                    }
                }
                else results.Add(minVal, minPath);
            }

            TimeSpan ts = stopWatch.Elapsed;
            times.Add(ts.TotalMilliseconds);
            label4.Text = "Czas wykonania algorytmu: " + ts.TotalMilliseconds.ToString() + " ms";

            int[] bestPath = branchAndBound.GetBestPath();
            int bestCost = branchAndBound.GetBestCost();
            label3.Text = "Najlepsza droga: " + bestCost.ToString() + " dla ścieżki: ";
            foreach (int city in bestPath)
            {
                label3.Text += city.ToString();
            }
            label3.Text += "0";

        }

    }
}
