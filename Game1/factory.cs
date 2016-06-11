using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
  abstract class Creator
  {
    public abstract  IElement Factory();
  }
  class ConcreteLabelButton : Creator
  {
    private Texture2D rectangle;
    private Color iColor;
    private Color hColor;
    private SpriteFont font;
    private Rectangle buttonshape;
    private string Name;

    public ConcreteLabelButton(string Name, Texture2D rectangle, int posX, int posY, int buttonHeight, int buttonWidth,
      Color iColor, Color hColor, SpriteFont font)
    {
      this.Name = Name;
      this.rectangle = rectangle;
      this.iColor = iColor;
      this.hColor = hColor;
      this.font = font;
      this.buttonshape = new Rectangle(posX, posY, buttonWidth, buttonHeight);
    }

    

    public override IElement Factory()
    {
      return new LabelButton(Name , rectangle, buttonshape, iColor, hColor, font);
    }
  }
  class ConcreteLabel : Creator
  {
    private int posX;
    private int posY;
    private Color iColor;
    private string text;
    private SpriteFont font;
    private Vector2 position;

    public ConcreteLabel(string text, int posX, int posY, Color iColor, SpriteFont font)
    {
      this.posX = posX;
      this.posY = posY;
      this.iColor = iColor;
      this.text = text;
      this.font = font;
      this.position = new Vector2(posX, posY);
    }
    public override IElement Factory()
    {
      return new Label(text , position, iColor, font);
    }
  }
  class ConcreteButton :Creator
  {
    private Color iColor;
    private Rectangle buttonshape;
    private Texture2D rectangle;

    public ConcreteButton(Texture2D rectangle, int posX, int posY, int buttonHeight, int buttonWidth,
      Color iColor)
    {
      this.rectangle = rectangle;
      this.buttonshape = new Rectangle(posX,posY,buttonWidth,buttonHeight);
      this.iColor = iColor;
    }
    public override IElement Factory()
    {
      return new Button(rectangle, buttonshape, iColor);
    }
  }
}
