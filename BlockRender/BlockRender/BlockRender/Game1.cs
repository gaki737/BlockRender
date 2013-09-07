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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Model block;
        Matrix worldMatrix;
        Matrix viewMatrix;
        Matrix projectionMatrix;
        CameraMove moving;
        CameraRotate rotation;
        float CameraPosX = 5.0f;
        float CameraPosY = 5.0f;
        float CameraPosZ = 10.0f;
        float[] CameraPositions;
        float CameraMoveX = 1.0f;
        float CameraMoveY = 1.0f;
        int[] CameraMoves;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rotation = new CameraRotate();
            moving = new CameraMove();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            block = Content.Load<Model>("block");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                rotation.MouseMoveX = 0;
                rotation.MouseMoveY = 0;
                CameraMoveX = 0.0f;
                CameraMoveY = 0.0f;
            }
            
            viewMatrix = Matrix.CreateRotationY(CameraMoveY) * Matrix.CreateLookAt(new Vector3(CameraPosX, CameraPosY, CameraPosZ), new Vector3(1.0f, 1.0f, 1.0f), Vector3.Up);
            
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), 800.0f / 600.0f, 1.0f, 100.0f);

            rotation.Rotate(this);
            CameraMoves = rotation.getOffset();
            CameraMoveX += CameraMoves[0];
            CameraMoveY += CameraMoves[1];
            rotation.MouseMoveX = 0;
            rotation.MouseMoveY = 0;
            Console.WriteLine(CameraMoveX + "         " + CameraMoveY);

            moving.Move();
            CameraPositions = moving.getPosition();
            CameraPosX += CameraPositions[0];
            CameraPosY += CameraPositions[1];
            CameraPosZ += CameraPositions[2];
            moving.CameraPositionX = 0.0f;
            moving.CameraPositionY = 0.0f;
            moving.CameraPositionZ = 0.0f;
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for (float y = 0; y < 2; y++ )
            {
                for (float z = 0; z < 3; z++)
                {
                    for (float x = 0; x < 1; x++)
                    {
                        foreach (ModelMesh mesh in block.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();  // Beleuchtung aktivieren
                                effect.World = Matrix.CreateRotationY(0.0f) * Matrix.CreateTranslation(new Vector3(1.0f + x * 2.0f, 1.0f + y * 2.0f, 1.0f + z * 2.0f));
                                effect.View = viewMatrix;

                                effect.Projection = projectionMatrix;
                            }
                            mesh.Draw();
                        }
                    }
                }
                }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
