using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAudioTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> wavlist = new List<string>();
            wavlist.Add(@"C:\Users\eser.kuru\source\repos\NAudioTest\NAudioTest\stretched\do1.wav");
            wavlist.Add(@"C:\Users\eser.kuru\source\repos\NAudioTest\NAudioTest\stretched\Re1.wav");
            foreach (string file in wavlist)
            {
                AudioFileReader audio = new AudioFileReader(file)
                {
                    Volume = 1
                };
                IWavePlayer player = new WaveOut(WaveCallbackInfo.FunctionCallback());
                player.Init(audio);
                player.Play();
                System.Threading.Thread.Sleep(audio.TotalTime);
                player.Stop();
                player.Dispose();
                audio.Dispose();
                player = null;
                audio = null;
            }
        }
    }
}
