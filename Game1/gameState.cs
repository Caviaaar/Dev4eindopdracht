using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
  class gameState : IComponent
  {
    private List<Creator> creators = new List<Creator>();
    Guivisitor guivisitor = new Guivisitor();
    
 

    
   
    Texture2D whitePixel;
    public gameState(Texture2D whiteTexture2D, SpriteFont font)
    { 
      this.whitePixel = whiteTexture2D;
      creators.Add(new ConcreteButton("The", whitePixel, 50, 100, 50, 200, Color.Blue, Color.Black, font));
      creators.Add(new ConcreteButton("World", whitePixel, 50, 5, 50, 200, Color.GreenYellow, Color.Red, font));// = new ConcreteButton("hello world", whitePixel, 50 , 5 , 50, 200, Color.GreenYellow, Color.Red, font);
     // creators[1] = new ConcreteLabel("BYE BYE My DARLING", 250, 150, Color.Black, font);
     // creators[2] = new ConcreteButton("This Ends Now", whitePixel, 50, 250, 50, 200, Color.Blue, Color.Red, font);
      creators.Add(new ConcreteButton("ends", whitePixel, 50, 250, 50, 200, Color.Blue, Color.Red, font));
      creators.Add(new ConcreteLabel("This is the world we life in",50,150,Color.DarkCyan,font));

    }

    public void Update(float dt)
    {
      
      MouseState state = Mouse.GetState();
      Vector2 mouse = new Vector2(state.X, state.Y);
      foreach (Creator c in creators)
      {
        IElement Element =  c.Factory();
        Element.Visit(guivisitor);
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      foreach (Creator c in creators)
      {
        IElement Element = c.Factory();
        Element.Draw(spriteBatch);
      }

    }
  }
}
