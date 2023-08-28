﻿using lungpae;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Test.Core;

namespace Test.Model
{
    internal class Chin 
    {
        AnimatedTexture chin;
        Dialog dialog;
        
        public Rectangle chinRec;
        public Vector2 chinPos;
        public int speed;
        public int row = 1;
        int prvrow;
        
        private const int Frame = 4;
        private const int FramePerSec = 3;
        private const int FrameRow = 4;
        private const float Rotation = 0;
        private  float Scale = 0.6f;
        private const float Depth = 1f;

        public bool Talk = false;
        
        

        public Chin()
        {
            chinPos = new Vector2(400,150);
            chin = new AnimatedTexture(Vector2.Zero,Rotation,Scale,Depth);
            Scale = Scale * 100;
            dialog = new Dialog();
        }

        internal void Load(ContentManager content)
        {
          chin.Load(content, "ChinPantiesThief", 4, 4, 3);
            dialog.LoadContent(content);
            speed = 1;
        }
        internal void Update(GameTime gameTime)
        {
            
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            chinRec = new Rectangle((int)chinPos.X,(int)chinPos.Y,chin.FrameWidth * (int)Scale/100 ,chin.FrameHeight * (int)Scale/100);

            
            if(Talk == true)
            {
                speed = 0;
                chin.Stop();
                chin.UpdateFrame(0);
                dialog.Update(gameTime);
            }

            if (Data.CanControl == true)
            {
                chinPos.Y += speed;
                chin.Play();
                chin.UpdateFrame(elapsed);
                if (chinPos.Y < 64)
                {
                    speed = 1;
                    row = 1;
                    prvrow = row;
                }
                if (chinPos.Y > 299 )
                {
                    speed = -1;
                    row = 3;
                    prvrow = row;
                }
                

            }
            if(Data.CanControl == false)
            {
                speed = 0;
                chin.Stop();
                chin.UpdateFrame(0);
            }

        }
        internal void Draw(SpriteBatch Batch)
        {
            chin.DrawFrame(Batch, chinPos, row);
           
        }
        //ขึ้นตอนพูด
        public void ChinDialog(SpriteBatch Batch)
        {
            // พูดแบบมีเควส
            if (Talk == true && Data.Quest1 == true) 
            {
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("You want kid's panties back!?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.ChangeDialog("Alright, I'll give you if all the questions answered correctly");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:
                        dialog.ChangeDialog("1. 1+1 = ?");
                        dialog.Answer("2", "1");
                        dialog.DrawAns(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                           Data.DialogCount++;

                        }

                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                           Data.DialogCount=7;
                        }

                        Data.Oldms = Data.ms;
                        break;
                    case 3:
                        dialog.ChangeDialog("Correct");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:
                        dialog.ChangeDialog("2. 2+2 = ?");
                        dialog.Answer("4", "3");
                        dialog.DrawAns(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                          Data.DialogCount++;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount=7;

                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 5:
                        dialog.ChangeDialog("Correct");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;

                    case 6:
                        dialog.ChangeDialog("Alright,I'll give you back");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.Quest1 = false;
                            Data.Panties = true;
                            Data.Q1Finish = true;
                            Data.CanControl = true;
                            Data.DialogCount = 0;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 7:
                        dialog.ChangeDialog("Haha Wrong!!! ");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.DialogCount = 0;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }

            }
            //คุยตอนไม่มีเควส
            if(Talk == true && Data.Quest1 == false) 
            {
                dialog.Draw(Batch);
                dialog.ChangeDialog("Hello");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                    row = prvrow;
                }
                Data.Oldms = Data.ms;
            }
        }

        public void Play()
        {
            chin.Play();
        }
        public void Stop()
        {
            chin.Stop();
        }

        
    }
}
