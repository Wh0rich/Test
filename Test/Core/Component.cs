﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
    internal abstract class Component
    {
        internal abstract void LoadContent(ContentManager Content);
        internal abstract void Update(GameTime gameTime);

        internal abstract void Draw(SpriteBatch spriteBatch);
    }
}
