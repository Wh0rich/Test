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

namespace Test.Scenes
{
    internal class Scene4 : Component
    {
        Player player;
        Texture2D tx;
        
        public Scene4()
        {
            player = new Player();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            tx = Content.Load<Texture2D>("Char01");
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tx, Vector2.Zero, Color.AliceBlue);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 5, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 5, 5);
            
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene3;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene5;
                Data.Plypos.Y = 0 + 10;
            }
            player.Draw(_spriteBatch);
        }
    }
}
