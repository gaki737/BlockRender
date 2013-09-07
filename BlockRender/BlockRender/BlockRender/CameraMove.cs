using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BlockRender
{
    class CameraMove
    {
        public float CameraPositionX = 0.0f;
        public float CameraPositionY = 0.0f;
        public float CameraPositionZ = 0.0f;


        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                CameraPositionZ -= 0.05f;
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                CameraPositionX -= 0.05f;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                CameraPositionZ += 0.05f;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                CameraPositionX += 0.05f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
                CameraPositionY += 0.05f;
            else if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                CameraPositionY -= 0.05f;

        }
        public float[] getPosition()
        {
            return new float[] { CameraPositionX, CameraPositionY, CameraPositionZ };
        }
    }
}
