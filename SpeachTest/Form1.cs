using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeachTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitSpeach();
        }

        private void InitSpeach()
        {
            //Создаем распознаватель с русской локализацией
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ru-RU"));

            string grammarPath = @"d:\test\";
            //Компилируем наше грамматическое правило в файл Маршруты.cfg
            FileStream fs = new FileStream(grammarPath + "Маршруты.cfg", FileMode.Create);
            SrgsGrammarCompiler.Compile(grammarPath + "Маршруты.grxml", (Stream)fs);
            fs.Close();

            Grammar gr = new Grammar(grammarPath + " Маршруты.cfg", "Маршруты");

            //Загружаем скомпилированный файл грамматики
            sre.LoadGrammar(gr);

            //Подписываемся на событие распознавания
            //sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            //Пусть голос поступает с устройства по умолчанию
            sre.SetInputToDefaultAudioDevice();

            //Запускаем асинхронно распознаватель
            sre.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
