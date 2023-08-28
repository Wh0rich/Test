using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Test.Core;

using Test.Model;

namespace Test.Scenes
{
    internal class Scene1 : Component
    {
        Texture2D grass;
        Chin chin;


        
        

        Player player;

        SpriteFont Font;
        Building obj;
        Dialog dialog;

        int speed = 1;
        public Scene1()
        {
            chin = new Chin();

            Data.Plypos = new Vector2(0, 450);
            obj = new Building(new Vector2(60, 50), 0.3f);
            dialog = new Dialog();
            player = new Player();
            

        }
        internal override void LoadContent(ContentManager Content)
        {
            chin.Load(Content);
            obj.Load(Content, "House1");

            dialog.LoadContent(Content);
            grass = Content.Load<Texture2D>("grass");
            player.LoadContent(Content);
           

        }
        internal override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            player.Update(gameTime);
            chin.Update(gameTime);
            player.Collision(obj.ObjRec);
            
            player.Collision(chin.chinRec);
           

            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);

            //ชนชินแล้วหยุด
           if(player.PlayerRec.Intersects(chin.chinRec))
            {
                chin.Stop();
                chin.speed = 0;
               
            }
            else
            {
                chin.speed = 1;
                if (chin.row == 3)
                {
                    chin.speed = -1;
                }
                chin.Play();
            }

           //ให้ชินหันหน้ามาหาตอนพูด
            if (player.PlayerRec.Intersects(chin.chinRec)&&Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(chin.chinRec))
            {
                dialog.Update(gameTime);
                chin.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    chin.row = 3;
                }
                if (player.row == 2)
                {
                    chin.row = 2;
                }
                if (player.row == 3)
                {
                    chin.row = 1;
                }
                if (player.row == 4)
                {
                    chin.row = 4;
                }
                
            } 
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(grass, new Vector2(Data.ScreenW / 2, Data.ScreenH - grass.Width), Color.White);
            obj.Draw(_spriteBatch);
            chin.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            Data.TpRec = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 5, 5);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene5;
                Data.Plypos.Y = 0 + 10;
            }
            if (chin.Talk == true && Data.Quest1 == true)
            {
                chin.ChinDialog(_spriteBatch);
               
            }
             if (chin.Talk == true && Data.Quest1 == false)
             {
               chin.ChinDialog(_spriteBatch);
                    
             }

            

            
        }
    }
}