using lungpae;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

using Microsoft.Xna.Framework.Input;

namespace Test.Core
{
    public static class Data
    {
        public static int ScreenW = 1280;
        public static int ScreenH = 720;
        public static bool Exit = false;
        public enum Scenes { scene1, scene2, scene3, scene4, scene5, scene6, scene7, scene8, scene9, scene10 }
        public static Scenes CurrentState = Scenes.scene1;
        public static int DialogCount = 0 ;

        public static bool CanControl = true; //การควบคุมการเดินplayer
        public static bool cutscene1 = true;

        //Quests
        public static bool Quest1 = false, Q1Finish = false, Panties = false;


        public static Rectangle MRec;
        public static Rectangle TpRec, TpRec2 ;

        public static Vector2 Plypos;


        public static MouseState ms, Oldms;
        
    }
}
