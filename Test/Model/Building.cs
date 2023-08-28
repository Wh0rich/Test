using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;


namespace Test.Model
{
    internal class Building
    {
        Texture2D obj;
        Vector2 pos/*,newpos*/;
        private float Scale;
        
        public Rectangle ObjRec;
        public Building(Vector2 pos, float scale) //รับค่า posกับscaleมา
        {
            this.pos = pos;
            //newpos = pos * 2;
            this.Scale = scale;
            Scale= (Scale * 100);
        }
        internal void Load(ContentManager Content, string asset)
        {
            this.obj = Content.Load<Texture2D>(asset);
            ObjRec = new Rectangle((int)pos.X, (int)pos.Y/*+ (int)newpos.Y*/, obj.Width * (int)Scale / 100, obj.Height * (int)Scale / 100)/*-(int)newpos.Y)*/; // hitboxของobject
        }
        internal void Update()
        {
           
        }
        internal void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(obj, pos, new Rectangle(0, 0, obj.Width, obj.Height), Color.White, 0, Vector2.Zero, Scale / 100, 0,1);
        }

    }
}
