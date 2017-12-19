using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace Go_Nutz.IrrKlang
{
   class SoundPlayer
    {
        //Creates a new soundengine using IrrKlang
        ISoundEngine soundEngine = new ISoundEngine();
        //a Callable metode to play a soundfile, mp3 prefered
        public void playSound(string soundpath)
        {
            soundEngine.Play2D(soundpath);
        }
    }
}
