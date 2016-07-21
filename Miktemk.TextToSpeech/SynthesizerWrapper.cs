using SpeechLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miktemk;

namespace Miktemk.TextToSpeech
{
    public class SynthesizerWrapper
    {
        public class ConfigMeLang
        {
            public string LangCode { get; set; }
            public string LangWildcard { get; set; }
            public int Rate { get; set; }
        }
        public class ConfigMe
        {
            public IEnumerable<ConfigMeLang> Languages;
        }

        private string[] voiceNames;
        private ConfigMe config;
        public MultiPhrasing CurMultiPhrasing { get; private set; }
        public SpVoice Vox { get; private set; }

        public event VoidHandler PhraseDone;

        public SynthesizerWrapper(ConfigMe config)
        {
            this.config = config;
            init_vox();
        }

        public SynthesizerWrapper() : base()
        {
        }

        private void init_vox()
        {
            Vox = new SpVoice();
            var voices = Vox.GetVoices();
            voiceNames = new string[voices.Count];
            for (int i = 0; i < voices.Count; i++)
            {
                var voice = voices.Item(i);
                var name = voice.GetDescription();
                voiceNames[i] = name;
            }
            Vox.Word += Vox_Word;
            Vox.EndStream += Vox_EndStream;
        }

        public void SayManyPhrasesInManyLanguages(IEnumerable<UniLangPhrase> fragments, Action<UniLangPhrase> funcNextFragment)
        {
            CurMultiPhrasing = new MultiPhrasing(this, fragments.GetEnumerator(), funcNextFragment);
            CurMultiPhrasing.Start();

            //synth.PhraseDone += () =>
            //{
            //    if (!enumerator.MoveNext())
            //        return;
            //    sayCurPhrase();
            //};
            //sayCurPhrase();
        }

        public void SayIt(UniLangPhrase phrase) { SayIt(phrase.Lang, phrase.Text); }
        public void SayIt(string langCode, string textToSay)
        {
            var configLang = config.Languages.FirstOrDefault(x => x.LangCode == langCode);
            if (configLang == null)
                throw new Exception("incorrect langCode! " + langCode);
            var languageIndex = voiceNames.IndexOf(x => x.ContainsNoCase(configLang.LangWildcard));
            Vox.Voice = Vox.GetVoices().Item(languageIndex);
            Vox.Rate = configLang.Rate;
            try
            {
                var options = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                Vox.Speak(textToSay, options);
            }
            catch (Exception ex) { }
        }

        public void SayItToFile(int languageIndex, int rate, string textToSay, string filenameOut)
        {
            Vox.Voice = Vox.GetVoices().Item(languageIndex);
            Vox.Rate = rate;
            try
            {
                var options = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                var stream = new SpFileStream();
                stream.Open(filenameOut, SpeechStreamFileMode.SSFMCreateForWrite, true);
                Vox.AudioOutputStream = stream;
                Vox.Speak(textToSay, options);
                Vox.WaitUntilDone(100000);
                stream.Close();
                Vox.AudioOutputStream = null;
            }
            catch (Exception ex) { }
        }

        public void StopCurVox()
        {
            Vox.Pause();
            Vox.Resume();
            Vox.Skip("Sentence", Int32.MaxValue);
        }
        public void StopAll()
        {
            StopCurVox();
            if (CurMultiPhrasing != null)
            {
                CurMultiPhrasing.StopAndDispose();
                CurMultiPhrasing = null;
            }
        }

        private void Vox_Word(int StreamNumber, object StreamPosition, int CharacterPosition, int Length)
        {
            //TODO: word-by-word updates
        }

        private void Vox_EndStream(int StreamNumber, object StreamPosition)
        {
            PhraseDone?.Invoke();
        }

        public bool IsPlaying
        {
            get
            {
                var voxPlaying = Vox.Status.RunningState == SpeechRunState.SRSEIsSpeaking;
                return voxPlaying || (CurMultiPhrasing != null && CurMultiPhrasing.IsPlaying);
            }
        }
    }

    public class MultiPhrasing
    {
        private SynthesizerWrapper voxWrapper;
        private IEnumerator<UniLangPhrase> enumerator;
        private Action<UniLangPhrase> funcNextFragment;
        private SpVoice vox;
        private bool isStarted = false;
        private bool isDisposed = false;

        public MultiPhrasing(SynthesizerWrapper voxWrapper, IEnumerator<UniLangPhrase> enumerator, Action<UniLangPhrase> funcNextFragment)
        {
            this.voxWrapper = voxWrapper;
            this.enumerator = enumerator;
            this.funcNextFragment = funcNextFragment;
            vox = voxWrapper.Vox;
            vox.EndStream += PhraseEnded;
        }

        private void PhraseEnded(int StreamNumber, object StreamPosition)
        {
            SayNextPhrase();
        }

        public void Start()
        {
            isStarted = true;
            SayNextPhrase();
        }
        private void SayNextPhrase()
        {
            if (isDisposed)
                return;
            enumerator.MoveNext();
            if (enumerator.Current == null)
            {
                StopAndDispose();
                return;
            }
            var phrase = enumerator.Current;
            funcNextFragment(enumerator.Current);
            voxWrapper.SayIt(phrase);
        }
        public void StopAndDispose()
        {
            voxWrapper.StopCurVox();
            vox.EndStream -= PhraseEnded;
            isDisposed = true;
            isStarted = false;
        }

        public bool IsPlaying { get { return isStarted && !isDisposed; } }
    }
}
