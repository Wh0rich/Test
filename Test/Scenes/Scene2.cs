using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Test.Model;


namespace Test.Scenes
{
    internal class Scene2 : Component
    {
        Texture2D Floor;       
        Building Shed;
        Player player;
        
        
        public Scene2()
        {
            
            Shed = new Building(new Vector2(350, 150), 2f);
            player = new Player();
            player.row = 4;
            
        }
        internal override void LoadContent(ContentManager Content)
        {
            Floor = Content.Load<Texture2D>("Floor");
            Shed.Load(Content, "Shed");
            
           
            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
           
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            if (Data.CanControl == true)
            {
                player.Collision(Shed.ObjRec);
                player.Update(gameTime);
            }
           
            if(Data.cutscene1 == true )
            {
               
              
            }
           
            if (player.PlayerRec.Intersects(Shed.ObjRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(Shed.ObjRec))
            {
                Data.CanControl = false;
                
            }
            
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 5, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 5, 5);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene1;
                Data.Plypos.Y = 720 -80 ;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene3;
                Data.Plypos.Y = 0 + 10;
            }
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Floor.Width),Color.White);
            Shed.Draw(_spriteBatch);
            
            player.Draw(_spriteBatch);
            if (Data.cutscene1 == true)
            {
               
            }
        }
    }
}
