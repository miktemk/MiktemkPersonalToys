using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Miktemk;
using Miktemk.TextToSpeech;
using PropertyChanged;
using System;
using System.Windows.Input;
using TTSingMultiLang.Services;

namespace TTSingMultiLang.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITtsService ttsService;
        private MultiLanguageText allText;
        private string outputLang;

        [DoNotNotify]
        public RelayCommand PlayStopCommand { get; private set; }
        [DoNotNotify]
        public RelayCommand<KeyEventArgs> PreviewKeyDownCommand { get; private set; }
        public string CurText { get; set; }
        public int CurIndex { get; set; }
        public string OutputLog { get; set; }

        public MainViewModel(ITtsService ttsService)
        {
            this.ttsService = ttsService;

            //TODO: use config file maybe
            var xmlFile = @"C:\OtherMiktemk\datafiles\german-grammar\german-grammar-split.xml";
            outputLang = "de";
            CurIndex = 900;

            allText = XmlFactory.LoadFromFile<MultiLanguageText>(xmlFile);

            PlayStopCommand = new RelayCommand(PlayStop, () => true);

            PreviewKeyDownCommand = new RelayCommand<KeyEventArgs>((args) => {
                if (args.Key == Key.Left)
                    CurIndex--;
                if (args.Key == Key.Right)
                    CurIndex++;
                if (args.Key == Key.Space)
                    PlayStop();
            });
        }

        private void PlayStop()
        {
            if (ttsService.IsPlaying)
            {
                ttsService.StopCurrentSynth();
                return;
            }
            //CurText = "WTF????";
            ttsService.SayItAllTestAsync(allText, CurIndex, (curPhrase, index) => {
                if (curPhrase.Lang == outputLang)
                {
                    if (!string.IsNullOrEmpty(CurText))
                        OutputLog = String.Concat(CurText, "\n", OutputLog);
                    CurText = curPhrase.Text;
                }
                CurIndex = index;
            });
        }
    }
}