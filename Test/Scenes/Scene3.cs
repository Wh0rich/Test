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
    internal class Scene3 : Component
    {
        Player player;
        public Scene3()
        {
            player = new Player();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 5, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 5, 5);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene2;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene4;
                Data.Plypos.Y = 0 + 10;
            }
            player.Draw(_spriteBatch);
        }
    }
}
