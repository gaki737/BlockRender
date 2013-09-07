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
    class CameraRotate
    {
        public float CameraRotationX = 0.0f;
        public float CameraRotationY = 0.0f;
        public int MousePositionX;
        public int MousePositionY;
        public int MouseMoveX = 0;
        public int MouseMoveY = 0;

        public void Rotate(Game gme)
        {
            MousePositionX = gme.Window.ClientBounds.Width / 2;
            MousePositionY = gme.Window.ClientBounds.Height / 2;
            MouseMoveX = (Mouse.GetState().X - MousePositionX);
            MouseMoveY = (Mouse.GetState().Y - MousePositionY);
            Mouse.SetPosition(MousePositionX, MousePositionY);
        }
        public int[] getOffset()
        {
            return new int[] { MouseMoveX, MouseMoveY };
        }
    }
}
