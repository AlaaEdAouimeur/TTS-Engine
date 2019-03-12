using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech;
using System.Speech.Synthesis;
using System.Runtime.Remoting.Messaging;

namespace book
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
     
   public    SpeechSynthesizer Reader = new SpeechSynthesizer();


    


        private void button_play_Click(object sender, RoutedEventArgs e)
        {

            Reader.Dispose();
            Reader = new SpeechSynthesizer();
            var SelectedComboBox = sender as ComboBox;
            if (checkBox.IsChecked ?? true)
            {

                Reader.SelectVoiceByHints(VoiceGender.Male);
                
                    
                Reader.SpeakAsync(textBox.Text);
            }
            else if (checkBox1.IsChecked ?? true)
            {

                Reader.SelectVoiceByHints(VoiceGender.Female);
                Reader.SpeakAsync(textBox.Text);
            }

            else MessageBox.Show("Please Select The Voice Gender", "No Gender Is Selected");




        }

       

        private void button_pause_Click(object sender, RoutedEventArgs e)
        {
            if (Reader != null)
            {
                if (Reader.State == SynthesizerState.Speaking)
                    Reader.Pause();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text != "")
            {
                button_play.IsEnabled = true;
                button_resume.IsEnabled = true;
                button_stop.IsEnabled = true;
                button_pause.IsEnabled = true;
            }
            else
            {
                button_play.IsEnabled = false;
                button_resume.IsEnabled = false;
                button_stop.IsEnabled = false;
                button_pause.IsEnabled = false;
            }



        }

        private void button_resume_Click(object sender, RoutedEventArgs e)
        {
            if (Reader != null)
            {
                if (Reader.State == SynthesizerState.Paused) Reader.Resume();
            }
        }

        private void button_stop_Click(object sender, RoutedEventArgs e)
        {
            if (Reader != null)
            {
                Reader.Dispose();
            }
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
         
            System.Diagnostics.Process.Start("https://github.com/AlaaDz31");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("English");
            data.Add("French");
            data.Add("Arabic");
            var combo = sender as ComboBox;
            combo.ItemsSource = data;
        }
    }
}
