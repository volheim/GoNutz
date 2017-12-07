using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    partial class GameObject
    {
        #region Fields;
        float scaleFactor;
        float animationSpeed = 5;
        float currentFrameIndex;
        #endregion


        public void UpdateAnimations(float fps)
        {
            float factor = 1 / fps;

            currentFrameIndex += (factor * animationSpeed);

            if(currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;

            }

            sprite = animationFrames[(int)currentFrameIndex];
        }




    }
}
