using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using Test.Model;
using Test.Scenes;

namespace Test.Manager
{
    
    internal partial class GameStateManager : Component // เรียกใช้แต่ละscene
    {
        
        private Scene1 s1 = new Scene1();
        private Scene2 s2 = new Scene2();
        private Scene3 s3 = new Scene3();
        private Scene4 s4 = new Scene4();
        private Scene5 s5 = new Scene5();
        private Scene6 s6 = new Scene6();
        internal override void LoadContent(ContentManager Content)
        {
           s1.LoadContent( Content);
           s2.LoadContent( Content);
           s3.LoadContent( Content);
           s4.LoadContent( Content);
           s5.LoadContent( Content);
           s6.LoadContent( Content);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.scene1:

                    s1.Update(gameTime);
                    
                    break;
                case Data.Scenes.scene2: 
                    s2.Update(gameTime);
                    break;
                case Data.Scenes.scene3:
                    s3.Update(gameTime);
                    break;
                case Data.Scenes.scene4:
                    s4.Update(gameTime);
                    break;
                case Data.Scenes.scene5:
                    s5.Update(gameTime);
                    break;
                case Data.Scenes.scene6:
                    s6.Update(gameTime);
                    break;
            }
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.scene1:
                    s1.Draw(spriteBatch);

                    break;
                case Data.Scenes.scene2:
                    s2.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene3:
                    s3.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene4:
                    s4.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene5:
                    s5.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene6:
                    s6.Draw(spriteBatch);
                    break;
            }
        }

    }
}
