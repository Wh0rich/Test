using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using Microsoft.Xna.Framework.Content;
using Test.Model;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;

namespace Test.Scenes
{
    internal class Scene5 : Component
    {
        Player player;
        Kid kid;
        Dialog dialog;
        public Scene5()
        {
            player = new Player();
            kid = new Kid();
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            dialog.LoadContent(Content);
            kid.Load(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            player.Collision(kid.dekRec);
            kid.Update(gameTime);
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            if (player.PlayerRec.Intersects(kid.dekRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(kid.dekRec))
            {
                dialog.Update(gameTime);
                kid.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    kid.row = 3;
                }
                if (player.row == 2)
                {
                    kid.row = 2;
                }
                if (player.row == 3)
                {
                    kid.row = 1;
                }
                if (player.row == 4)
                {
                    kid.row = 4;
                }

            }
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            // จุดเปลี่ยนแมพ
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 5, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW-5, Data.ScreenH/2 , 5, 5);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene1;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene6;
                Data.Plypos.X = 0 + 10;
            }
            // วาดเด็กถ้าเควสยังไม่เสด
            if(Data.Q1Finish == false||Data.Panties == true)
            {
                kid.Draw( _spriteBatch );
            }
            if(kid.Talk==true)
            {
                kid.DekDialog(_spriteBatch);
            }
            player.Draw(_spriteBatch);
        }
    }
}
