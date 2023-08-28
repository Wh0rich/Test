using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    internal class Dialog
    {
        Texture2D DialogBox;
        String msg = "",ans1,ans2;
        SpriteFont Myfont;
        Vector2 DialogPos;
        Vector2 Ans1Pos, Ans2Pos;
        public Rectangle Ans1Rec, Ans2Rec;
        public Rectangle DialogRec;
        
        
        public Rectangle MRec;
        public Dialog() 
        {
            DialogPos = new Vector2(175,400);

        } 
        internal void LoadContent(ContentManager content)
        {
            DialogBox = content.Load<Texture2D>("DialogBox");
            Myfont = content.Load<SpriteFont>("Font");
            
        }

        internal void Update(GameTime gameTime)
        {
            Ans1Pos = new Vector2(DialogPos.X + 350, DialogPos.Y + 50);
            Ans2Pos = new Vector2(DialogPos.X + 400, DialogPos.Y + 50);
            DialogRec = new Rectangle((int)DialogPos.X, (int)DialogPos.Y, DialogBox.Width, DialogBox.Height);
            Ans1Rec = new Rectangle((int)Ans1Pos.X,(int)Ans1Pos.Y,30,30);
            Ans2Rec = new Rectangle((int)Ans2Pos.X, (int)Ans2Pos.Y, 30, 30);
        }

        internal void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(DialogBox, DialogPos, new Rectangle(0,0, DialogBox.Width, DialogBox.Height), Color.White);
            spriteBatch.DrawString(Myfont, msg, new Vector2(DialogPos.X + 50,DialogPos.Y + 50), Color.White);
        }
        internal void DrawAns(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(Myfont, ans1, Ans1Pos, Color.White);
            spriteBatch.DrawString(Myfont, ans2, Ans2Pos, Color.White);
            if (MRec.Intersects(Ans1Rec))
            {
                spriteBatch.DrawString(Myfont, ans1, Ans1Pos, Color.Gray);
            }
            if (MRec.Intersects(Ans2Rec))
            {
                spriteBatch.DrawString(Myfont, ans2, Ans1Pos, Color.Gray);
            }


        }
        internal void ChangeDialog( String msg) //รับstringมาเปลี่ยนข้อความ
        {
            this.msg = msg; 
        }
        internal void Answer(string ans1, string ans2)
        {
            this.ans1 = ans1;
            this.ans2 = ans2;
        }
    }
}
