using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
  interface IGui
  {
    void Visit(IGuiVisitor visitor);
  }

  interface IGuiVisitor
  {
    void onMyButton(Button button, MouseState mouse, Rectangle buttonshape, string name);
    void onMyLabel(Label label);
  }

  class Guivisitor : IGuiVisitor
  {
    private Vector2 MousePosition;
    MouseState mouse;


    public void onMyButton(Button button, MouseState mouse, Rectangle buttonshape, string name)
    {
      this.mouse = mouse;
      mouse = Mouse.GetState();
      this.MousePosition = new Vector2(mouse.X, mouse.Y);
      OnClick(mouse, MousePosition, buttonshape, name);
    }

    public void OnClick(MouseState mouse, Vector2 MousePosition, Rectangle buttonshape, string Name)
    {
      if (MousePosition.X >= buttonshape.X && MousePosition.X <= (buttonshape.X + buttonshape.Width) &&
          MousePosition.Y >= buttonshape.Y && MousePosition.Y <= (buttonshape.Y + buttonshape.Height) && mouse.LeftButton == ButtonState.Pressed)
      {
        System.Diagnostics.Debug.WriteLine(Name);
      }
    
    }

    public void onMyLabel(Label label)
    {
     

    }

  }
}

