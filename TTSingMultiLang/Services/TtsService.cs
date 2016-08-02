using Miktemk.TextToSpeech.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSingMultiLang.Services
{
    public interface ITtsService
    {
        bool IsPlaying { get; }

        void SayItAllTestAsync(MultiLanguageText allText, int startSentence, Action<UniLangPhrase, int> phraseCallback);
        void AddWordCallback(Action<string, int, int> wordCallback);
        void StopCurrentSynth();
    }
    public class TtsService : ITtsService
    {
        private SynthesizerWrapper synth;

        public TtsService()
        {
            synth = new SynthesizerWrapper(new SynthesizerWrapper.ConfigMe
            {
                // TODO: use a config file maybe??
                Languages = new []
                {
                    new SynthesizerWrapper.ConfigMeLang { LangCode="en", Rate=2, LangWildcard="David" },
                    new SynthesizerWrapper.ConfigMeLang { LangCode="ru", Rate=3, LangWildcard="Irina" },
                    new SynthesizerWrapper.ConfigMeLang { LangCode="de", Rate=0, LangWildcard="Hedda" },
                    new SynthesizerWrapper.ConfigMeLang { LangCode="it", Rate=1, LangWildcard="Elsa" },
                    new SynthesizerWrapper.ConfigMeLang { LangCode="fr", Rate=1, LangWildcard="Hortense" },
                }
            });
        }

        public bool IsPlaying { get { return synth.IsPlaying; } }

        public void SayItAllTestAsync(
            MultiLanguageText allText,
            int startFragment,
            Action<UniLangPhrase, int> phraseCallback)
        {
            var fragments = allText.Phrases.Skip(startFragment);
            var curIndex = startFragment;

            synth.SayManyPhrasesInManyLanguages(fragments, (phrase) =>
            {
                // .... called when fragment is completed
                curIndex++;
                phraseCallback(phrase, curIndex);
            });
        }

        public void AddWordCallback(Action<string, int, int> wordCallback)
        {
            synth.PhraseProgress += (text, start, length) => {
                wordCallback(text, start, length);
            };
        }

        public void StopCurrentSynth()
        {
            synth.StopAll();
        }
    }
}
