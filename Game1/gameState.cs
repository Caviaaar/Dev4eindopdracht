using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
      creators.Add(new ConcreteLabelButton("Button1", whitePixel, 50, 100, 50, 200, Color.Blue, Color.Black, font));
      creators.Add(new ConcreteLabelButton("Button 2", whitePixel, 50, 5, 50, 200, Color.GreenYellow, Color.Red, font));
      creators.Add(new ConcreteLabelButton("Button 3", whitePixel, 50, 250, 50, 200, Color.YellowGreen, Color.Red, font));
      creators.Add(new ConcreteLabel("De kat krapt de krullen van de trap",50,150,Color.DarkCyan,font));
      creators.Add(new ConcreteButton(whiteTexture2D,250,135,20,155,Color.Black));

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
