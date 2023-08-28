using lungpae;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Test.Core;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Test.Model
{
    internal class NPC
    {
        AnimatedTexture npc;
        Chin chin;
        public Rectangle NpcRec;
        public Vector2 Pos;
        public int row=1;
        float scale;
        
        public NPC(float Rotation,float Scale, float Depth,Vector2 Pos)
        {
            npc = new AnimatedTexture(Vector2.Zero,Rotation,Scale,Depth);
            this.Pos = Pos;
            this.scale = Scale;
            scale = scale * 100;
            chin = new Chin();
        }

        internal void Load(ContentManager content,string name,int Frame ,int FrameRow,int FramePerSec)
        {
            npc.Load(content, name, Frame, FrameRow, FramePerSec);
            
        }
        internal void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            npc.UpdateFrame(elapsed);  
            NpcRec = new Rectangle((int)Pos.X, (int)Pos.Y, npc.FrameWidth*(int)scale / 100 , npc.FrameHeight);

           

        }
        internal void StopAni()
        {
            npc.Pause();
           
        }
        
        internal void Draw(SpriteBatch spriteBatch)
        {
            npc.DrawFrame(spriteBatch, Pos, row);
        }
    }
}
