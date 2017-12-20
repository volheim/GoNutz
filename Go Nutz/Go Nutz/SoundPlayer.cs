using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace Go_Nutz.IrrKlang
{
    public static class SoundPlayer
    {
        //Creates a new soundengine using IrrKlang
        static ISoundEngine soundEngine = new ISoundEngine();

        //a Callable metode to play a soundfile, mp3 prefered
        public static void playSound(string soundpath)
        {
            
            soundEngine.Play2D(soundpath,false);
        }
    }
}
