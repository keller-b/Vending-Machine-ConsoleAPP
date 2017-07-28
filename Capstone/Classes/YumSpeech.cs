using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;


namespace Capstone.Classes
{
    public static class YumSpeech
    {
        public static void VerballyEnjoy(string input)
        {
            SpeechSynthesizer Voice = new SpeechSynthesizer();
            Voice.SetOutputToDefaultAudioDevice();
            Voice.Rate = 2;
            Voice.Speak(input);
        }
    }
}
