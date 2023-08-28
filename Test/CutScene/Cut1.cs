using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using lungpae;
using Microsoft.Xna.Framework;
using Test.Core;
using Microsoft.Xna.Framework.Input;
using Test.Scenes;

namespace Test.CutScene
{
    internal class Cut1
    {
        NPC Dwarf;
        Vector2 dwarfPos;
        
        
        Dialog dialog;
        public Cut1()
        {
            dwarfPos = new Vector2(445, 360);
            Dwarf = new NPC(0f, 2f, 1f, dwarfPos);
            dialog = new Dialog();
        }
        internal void Load(ContentManager content)
        {
            Dwarf.Load(content, "Dwarf", 4, 5, 8);
            dialog.LoadContent(content);
        }
        internal void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            if (Dwarf.Pos.Y < 480)
            {
                Dwarf.Pos.Y += 1;
                
            }
            if(Dwarf.Pos.Y == 480&& Dwarf.Pos.X > 50)
            {
                Dwarf.Pos.X -= 1;
                
                Dwarf.row = 2;
                dialog.Update(gameTime);
            }
            Dwarf.Update(gameTime);
        }
        internal  void Draw(SpriteBatch Batch)
        {
            
            Dwarf.Draw(Batch);
            if (Dwarf.Pos.X == 50 && Dwarf.Pos.Y == 480)
            {
                Data.ms = Mouse.GetState();
                dialog.Draw(Batch);
                
                if (Data.CanControl == false)
                {
                    switch (Data.DialogCount)
                    {
                        case 0:
                            dialog.ChangeDialog("You Know a cha be hey ?");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount = 1;
                            }
                            Data.Oldms = Data.ms;
                            break;
                        case 1:
                            dialog.ChangeDialog("If you dont know it's Ok Cause I don't know too");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.CanControl = true;
                                Data.DialogCount = 0;
                                Data.cutscene1 = false;
                            }
                            Data.Oldms = Data.ms;
                            break;
                        

                    }
                }
            }
        }
    }

    
}
