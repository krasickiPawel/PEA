using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA1
{
    public partial class Form1 : Form
    {
        FileHolder fileHolder;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[4];
            comboBoxCrossMethod.SelectedItem = comboBoxCrossMethod.Items[0];
            neighbourComboBox.SelectedItem = neighbourComboBox.Items[0];
            textBoxMutationValue.Text = "0,2";
            textBoxCrossValue.Text = "0,8";
            textBoxPopulationSize.Text = "10";
            labelAlgorithmWorking.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //wczytywanie przygotowanych plikow
        {
            try
            {
                FileReader fileReader = new FileReader();
                var filePath = string.Empty;
                var writeList = new List<string>();

                //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.filedialog?view=windowsdesktop-5.0
                using (OpenFileDialog openFileDialog = new OpenFileDialog())    //metoda wczytywania pliku z dokumentacji C# - docs.microsoft.com/
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        fileHolder = fileReader.Read(fileStream, writeList); //moze sie wysypac, dlatego try catch
                    }
                    //var fileText = File.ReadAllText(filePath);
                    //MessageBox.Show(fileText);
                }

                label2.Text = "";
                label2.Text = filePath + "\n";
            }
            catch(Exception ex)
            {
                var result = MessageBox.Show(ex.StackTrace, "Problem z odczytem pliku!", MessageBoxButtons.RetryCancel);
                if (result.Equals(DialogResult.Retry)) button1_Click(sender, e);
            }

        }

        private void button2_Click(object sender, EventArgs e)  //jednokrotne uruchomienie poszukiwania najkrotszej sciezki danym algorytmem
        {
            if(fileHolder != null && fileHolder.GetCityAmount() != 0)
            {
                var times = new List<double>(); // nie uzywane tutaj ale potrzebne do x100 wiec jest tu bo w arg funkcji wymagane
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        times.Clear();
                        try
                        {
                            var givenTime = Convert.ToDouble(timeTextBox.Text);
                            givenTime *= 1000;

                            labelAlgorithmWorking.Visible = true;
                            labelAlgorithmWorking.Refresh();
                            if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[0])
                            {
                                Compute.RunSA(fileHolder, times, label3, label4, givenTime, "Swap");
                                labelAlgorithmWorking.Visible = false;
                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[1])
                            {
                                Compute.RunSA(fileHolder, times, label3, label4, givenTime, "Invert");
                                labelAlgorithmWorking.Visible = false;
                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            labelAlgorithmWorking.Refresh();
                        }
                        catch
                        {
                            MessageBox.Show("Podaj czas we właściwym formacie!", "Brak czasu", MessageBoxButtons.OK);
                        }
                        break;
                    case 1:
                        times.Clear();
                        try
                        {
                            var givenTime = Convert.ToDouble(timeTextBox.Text);
                            givenTime *= 1000;

                            labelAlgorithmWorking.Visible = true;
                            labelAlgorithmWorking.Refresh();
                            if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[0] && !checkBoxDiversyfication.Checked)
                            {
                                Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Swap", false);
                                labelAlgorithmWorking.Visible = false;
                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if(neighbourComboBox.SelectedItem == neighbourComboBox.Items[0] && checkBoxDiversyfication.Checked)
                            {
                                Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Swap", true);
                                labelAlgorithmWorking.Visible = false;
                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[1] && !checkBoxDiversyfication.Checked)
                            {
                                Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Invert", false);
                                labelAlgorithmWorking.Visible = false;
                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[1] && checkBoxDiversyfication.Checked)
                            {
                                Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Invert", true);
                                labelAlgorithmWorking.Visible = false;
                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            labelAlgorithmWorking.Refresh();
                        }
                        catch
                        {
                            MessageBox.Show("Podaj czas we właściwym formacie!", "Brak czasu", MessageBoxButtons.OK);
                        }
                        break;
                    case 2:
                        labelAlgorithmWorking.Visible = true;
                        labelAlgorithmWorking.Refresh();
                        times.Clear();
                        Compute.RunBF(fileHolder, times, label3, label4);
                        labelAlgorithmWorking.Visible = false;
                        MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                        labelAlgorithmWorking.Refresh();
                        break;
                    case 3:
                        labelAlgorithmWorking.Visible = true;
                        labelAlgorithmWorking.Refresh();
                        times.Clear();
                        Compute.RunDP(fileHolder, times, label3, label4);
                        labelAlgorithmWorking.Visible = false;
                        MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                        labelAlgorithmWorking.Refresh();
                        break;
                    case 4:
                        if (timeTextBox.Text == "")
                        {
                            MessageBox.Show("Nie podano czasu!", "Brak czasu", MessageBoxButtons.OK);
                            break;
                        }
                        var givenTime1 = Convert.ToDouble(timeTextBox.Text);
                        givenTime1 *= 1000;
                        if (givenTime1 <= 0)
                        {
                            MessageBox.Show("Czas nie może być równy 0!", "Zerowy czas", MessageBoxButtons.OK);
                            break;
                        }
                        var populationSize = Convert.ToInt32(textBoxPopulationSize.Text);
                        if (populationSize < 2)
                        {
                            MessageBox.Show("Populacja nie może być mniejsza niż 2!", "Za mała populacja", MessageBoxButtons.OK);
                            break;
                        }
                        var mutationProbability = Convert.ToDouble(textBoxMutationValue.Text);
                        var crossProbability = Convert.ToDouble(textBoxCrossValue.Text);

                        labelAlgorithmWorking.Visible = true;
                        labelAlgorithmWorking.Refresh();

                        Compute.RunGenetic(fileHolder, times, label3, label4, givenTime1, neighbourComboBox.SelectedItem.ToString(),
                            comboBoxCrossMethod.SelectedItem.ToString(), populationSize, mutationProbability, crossProbability);

                        labelAlgorithmWorking.Visible = false;
                        MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                        labelAlgorithmWorking.Refresh();

                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Zgłoszono wyjątek!", MessageBoxButtons.OK);
                        }
                        break;
                    default:
                        MessageBox.Show("Wybierz poprawny algorytm z rozsuwanej listy", "", MessageBoxButtons.OK);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wybierz właściwy plik do przeanalizowania!", "Brak właściwego pliku", MessageBoxButtons.OK);
            }

        }

        private void button3_Click(object sender, EventArgs e)  //wielookrotne uruchomienie poszukiwania najkrotszej sciezki danym algorytmem
        {
            int howManyTimes = trackBarExecuteTimes.Value;
            if (fileHolder != null && fileHolder.GetCityAmount() != 0)
            {
                var times = new List<double>();
                var results = new Dictionary<int, int[]>();     //to byla bledna decyzja, ktorej nie chcialo mi sie juz poprawic (da sie zrobic optymalniej bo słownik jest niepotrzebny, ale nie wpływa negatywnie na kod, po prostu jest to overkill, jak strzelanie z armaty do muchy)
                double avgTime;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        times.Clear();
                        try
                        {
                            var givenTime = Convert.ToDouble(timeTextBox.Text);
                            givenTime *= 1000;

                            if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[0])
                            {
                                labelAlgorithmWorking.Visible = true;
                                labelAlgorithmWorking.Refresh();
                                for (int i = 0; i < howManyTimes; i++)
                                {
                                    Compute.RunSA(fileHolder, times, label3, label4, givenTime, "Swap", results);
                                }
                                labelAlgorithmWorking.Visible = false;
                                labelAlgorithmWorking.Refresh();
                                int minCostSA = results.Keys.Min();
                                label3.Text = "Najlepsza droga: " + minCostSA + " dla ścieżki: ";
                                foreach (int city in results[minCostSA])
                                {
                                    label3.Text += city.ToString() + " ";
                                }
                                label3.Text += "0";
                                avgTime = times.Average();
                                label4.Text = "Średni czas wykonania algorytmu SA: " + avgTime.ToString() + " ms";

                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[1])
                            {
                                labelAlgorithmWorking.Visible = true;
                                labelAlgorithmWorking.Refresh();
                                for (int i = 0; i < howManyTimes; i++)
                                {
                                    Compute.RunSA(fileHolder, times, label3, label4, givenTime, "Invert", results);
                                }
                                labelAlgorithmWorking.Visible = false;
                                labelAlgorithmWorking.Refresh();
                                int minCostSA = results.Keys.Min();
                                label3.Text = "Najlepsza droga: " + minCostSA + " dla ścieżki: ";
                                foreach (int city in results[minCostSA])
                                {
                                    label3.Text += city.ToString() + " ";
                                }
                                label3.Text += "0";
                                avgTime = times.Average();
                                label4.Text = "Średni czas wykonania algorytmu SA: " + avgTime.ToString() + " ms";

                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            labelAlgorithmWorking.Refresh();
                        }
                        catch
                        {
                            MessageBox.Show("Podaj czas we właściwym formacie!", "Brak czasu", MessageBoxButtons.OK);
                        }
                        break;
                    case 1:
                        times.Clear();
                        try
                        {
                            var givenTime = Convert.ToDouble(timeTextBox.Text);
                            givenTime *= 1000;

                            if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[0] && !checkBoxDiversyfication.Checked)
                            {
                                labelAlgorithmWorking.Visible = true;
                                labelAlgorithmWorking.Refresh();
                                for (int i = 0; i < howManyTimes; i++)
                                {
                                    Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Swap", false, results);
                                }
                                labelAlgorithmWorking.Visible = false;
                                labelAlgorithmWorking.Refresh();
                                int minCostTS = results.Keys.Min();
                                label3.Text = "Najlepsza droga: " + minCostTS + " dla ścieżki: ";
                                foreach (int city in results[minCostTS])
                                {
                                    label3.Text += city.ToString() + " ";
                                }
                                label3.Text += "0";
                                avgTime = times.Average();
                                label4.Text = "Średni czas wykonania algorytmu TS: " + avgTime.ToString() + " ms";

                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[0] && checkBoxDiversyfication.Checked)
                            {
                                labelAlgorithmWorking.Visible = true;
                                labelAlgorithmWorking.Refresh();
                                for (int i = 0; i < howManyTimes; i++)
                                {
                                    Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Swap", true, results);
                                }
                                labelAlgorithmWorking.Visible = false;
                                labelAlgorithmWorking.Refresh();
                                int minCostTS = results.Keys.Min();
                                label3.Text = "Najlepsza droga: " + minCostTS + " dla ścieżki: ";
                                foreach (int city in results[minCostTS])
                                {
                                    label3.Text += city.ToString() + " ";
                                }
                                label3.Text += "0";
                                avgTime = times.Average();
                                label4.Text = "Średni czas wykonania algorytmu TS: " + avgTime.ToString() + " ms";

                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[1] && !checkBoxDiversyfication.Checked)
                            {
                                labelAlgorithmWorking.Visible = true;
                                labelAlgorithmWorking.Refresh();
                                for (int i = 0; i < howManyTimes; i++)
                                {
                                    Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Invert", false, results);
                                }
                                labelAlgorithmWorking.Visible = false;
                                labelAlgorithmWorking.Refresh();
                                int minCostTS = results.Keys.Min();
                                label3.Text = "Najlepsza droga: " + minCostTS + " dla ścieżki: ";
                                foreach (int city in results[minCostTS])
                                {
                                    label3.Text += city.ToString() + " ";
                                }
                                label3.Text += "0";
                                avgTime = times.Average();
                                label4.Text = "Średni czas wykonania algorytmu TS: " + avgTime.ToString() + " ms";

                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                            else if (neighbourComboBox.SelectedItem == neighbourComboBox.Items[1] && checkBoxDiversyfication.Checked)
                            {
                                labelAlgorithmWorking.Visible = true;
                                labelAlgorithmWorking.Refresh();
                                for (int i = 0; i < howManyTimes; i++)
                                {
                                    Compute.RunTS(fileHolder, times, label3, label4, givenTime, "Invert", true, results);
                                }
                                labelAlgorithmWorking.Visible = false;
                                labelAlgorithmWorking.Refresh();
                                int minCostTS = results.Keys.Min();
                                label3.Text = "Najlepsza droga: " + minCostTS + " dla ścieżki: ";
                                foreach (int city in results[minCostTS])
                                {
                                    label3.Text += city.ToString() + " ";
                                }
                                label3.Text += "0";
                                avgTime = times.Average();
                                label4.Text = "Średni czas wykonania algorytmu TS: " + avgTime.ToString() + " ms";

                                MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Podaj czas we właściwym formacie!", "Brak czasu", MessageBoxButtons.OK);
                        }
                        break;
                    case 2:
                        times.Clear();
                        labelAlgorithmWorking.Visible = true;
                        labelAlgorithmWorking.Refresh();
                        for (int i = 0; i < howManyTimes; i++)
                        {
                            Compute.RunBF(fileHolder, times, label3, label4, results);
                        }
                        labelAlgorithmWorking.Visible = false;
                        labelAlgorithmWorking.Refresh();
                        int minCostBF = results.Keys.Min();
                        label3.Text = "Najlepsza droga: " + minCostBF + " dla ścieżki: ";
                        foreach (int city in results[minCostBF])
                        {
                            label3.Text += city.ToString() + " ";
                        }
                        label3.Text += "0";
                        avgTime = times.Average();
                        label4.Text = "Średni czas wykonania algorytmu BF: " + avgTime.ToString() + " ms";

                        MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                        break;
                    case 3:
                        times.Clear();
                        labelAlgorithmWorking.Visible = true;
                        labelAlgorithmWorking.Refresh();
                        for (int i = 0; i < howManyTimes; i++)
                        {
                            Compute.RunDP(fileHolder, times, label3, label4, results);
                        }
                        labelAlgorithmWorking.Visible = false;
                        labelAlgorithmWorking.Refresh();
                        int minCostDP = results.Keys.Min();
                        label3.Text = "Najlepsza droga: " + minCostDP + " dla ścieżki: ";
                        foreach (int city in results[minCostDP])
                        {
                            label3.Text += city.ToString() + " ";
                        }
                        label3.Text += "0";
                        avgTime = times.Average();
                        label4.Text = "Średni czas wykonania algorytmu DP: " + avgTime.ToString() + " ms";

                        MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);

                        break;

                    case 4:
                        times.Clear();

                        try
                        {
                            var givenTime1 = Convert.ToDouble(timeTextBox.Text);
                            givenTime1 *= 1000;
                            var populationSize = Convert.ToInt32(textBoxPopulationSize.Text);
                            var mutationProbability = Convert.ToDouble(textBoxMutationValue.Text);
                            var crossProbability = Convert.ToDouble(textBoxCrossValue.Text);

                            labelAlgorithmWorking.Visible = true;
                            labelAlgorithmWorking.Refresh();

                            for (int i = 0; i < howManyTimes; i++)
                                Compute.RunGenetic(fileHolder, times, label3, label4, givenTime1, neighbourComboBox.SelectedItem.ToString(),
                                comboBoxCrossMethod.SelectedItem.ToString(), populationSize, mutationProbability, crossProbability, results);

                            labelAlgorithmWorking.Visible = false;
                            labelAlgorithmWorking.Refresh();

                            List<int> savedCostsGenetic = results.Keys.ToList();
                            savedCostsGenetic.Sort();
                            int medianCostGenetic = savedCostsGenetic[Convert.ToInt32((savedCostsGenetic.Count - 1) / 2)];

                            label3.Text = "Najlepsza (uśredniona) droga: " + medianCostGenetic + " dla ścieżki: ";
                            foreach (int city in results[medianCostGenetic])
                            {
                                label3.Text += city.ToString() + " ";
                            }
                            label3.Text += "0";
                            avgTime = times.Average();
                            label4.Text = "Średni czas wykonania algorytmu Genetycznego: " + avgTime.ToString() + " ms";

                            MessageBox.Show(label3.Text + "\n" + label4.Text, "Znaleziono rozwiązanie!", MessageBoxButtons.OK);
                            labelAlgorithmWorking.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Zgłoszono wyjątek!", MessageBoxButtons.OK);
                        }
                        break;
                    default:
                        MessageBox.Show("Wybierz poprawny algorytm z rozsuwanej listy", "", MessageBoxButtons.OK);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wybierz plik do przeanalizowania!", "Brak właściwego pliku", MessageBoxButtons.OK);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void readRawButton_Click(object sender, EventArgs e)    //przycisk stworzony nieco na wyrost - zeby czytac bezposrednio pliki .atsp
        {
            try
            {
                FileReader fileReader = new FileReader();
                var filePath = string.Empty;
                var writeList = new List<string>();

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "atsp files (*.atsp)|*.atsp|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        fileHolder = fileReader.ReadRaw(fileStream, writeList); //moze sie wysypac, zrobic try catch
                    }
                }

                label2.Text = "";
                label2.Text = filePath + "\n";

            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(ex.StackTrace, "Problem z odczytem pliku!", MessageBoxButtons.RetryCancel);
                if (result.Equals(DialogResult.Retry)) button1_Click(sender, e);
            }
        }

        private void trackBarExecuteTimes_Scroll(object sender, EventArgs e)
        {
            button3.Text = "Wykonaj x" + trackBarExecuteTimes.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3)
            {
                timeLabel.Visible = false;
                timeTextBox.Visible = false;
                neighbourLabel.Visible = false;
                neighbourComboBox.Visible = false;
                checkBoxDiversyfication.Visible = false;

                labelPopulationSize.Visible = false;
                textBoxPopulationSize.Visible = false;
                labelMutationValue.Visible = false;
                textBoxMutationValue.Visible = false;
                labelMutationMethod.Visible = false;
                comboBoxCrossMethod.Visible = false;
                labelCrossValue.Visible = false;
                textBoxCrossValue.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                timeLabel.Visible = true;
                timeTextBox.Visible = true;
                neighbourLabel.Text = "Sąsiedztwo:";
                neighbourLabel.Visible = true;
                neighbourComboBox.Visible = true;
                checkBoxDiversyfication.Visible = true;

                labelPopulationSize.Visible = false;
                textBoxPopulationSize.Visible = false;
                labelMutationValue.Visible = false;
                textBoxMutationValue.Visible = false;
                labelMutationMethod.Visible = false;
                comboBoxCrossMethod.Visible = false;
                labelCrossValue.Visible = false;
                textBoxCrossValue.Visible = false;
            }
            else
            {
                timeLabel.Visible = true;
                timeTextBox.Visible = true;
                neighbourLabel.Visible = true;
                neighbourLabel.Text = "Mutacja:";
                neighbourComboBox.Visible = true;
                checkBoxDiversyfication.Visible = false;

                labelPopulationSize.Visible = true;
                textBoxPopulationSize.Visible = true;
                labelMutationValue.Visible = true;
                textBoxMutationValue.Visible = true;
                labelMutationMethod.Visible = true;
                comboBoxCrossMethod.Visible = true;
                labelCrossValue.Visible = true;
                textBoxCrossValue.Visible = true;
            }
        }
    }
}
