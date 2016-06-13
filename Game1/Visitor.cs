using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
  interface IGui
  {
    void Visit(IGuiVisitor visitor);
  }

  interface IGuiVisitor
  {
    void onMyLabelButton(LabelButton button, MouseState mouse, Rectangle buttonshape, string name);
    void onMyLabel(Label label);
    void onMyButton(Button button, MouseState mouse, Rectangle buttonshape);
  }

  class Guivisitor : IGuiVisitor
  {
    private Vector2 MousePosition;
    MouseState mouse;


    public void onMyLabelButton(LabelButton button, MouseState mouse, Rectangle buttonshape, string name)
    {
      this.mouse = mouse;
      mouse = Mouse.GetState();
      this.MousePosition = new Vector2(mouse.X, mouse.Y);
      OnClickLabelButton(mouse, MousePosition, buttonshape, name);
      
    }
    public void onMyLabel(Label label)
    {
      
    }

    public void OnClickLabelButton(MouseState mouse, Vector2 MousePosition, Rectangle buttonshape, string Name)
    {
      if (MousePosition.X >= buttonshape.X && MousePosition.X <= (buttonshape.X + buttonshape.Width) &&
          MousePosition.Y >= buttonshape.Y && MousePosition.Y <= (buttonshape.Y + buttonshape.Height) && mouse.LeftButton == ButtonState.Pressed)
      {
        System.Diagnostics.Debug.WriteLine(Name);
        Wait();
      }
      
    }



    public void onMyButton(Button button, MouseState mouse, Rectangle buttonshape)
    {
      this.mouse = mouse;
      mouse = Mouse.GetState();
      this.MousePosition = new Vector2(mouse.X, mouse.Y);
      onClickButton( mouse, MousePosition,  buttonshape);
      
    }

    public void onClickButton(MouseState mouse, Vector2 MousePosition, Rectangle buttonshape)
    {
     
      if (MousePosition.X >= buttonshape.X && MousePosition.X <= (buttonshape.X + buttonshape.Width) &&
          MousePosition.Y >= buttonshape.Y && MousePosition.Y <= (buttonshape.Y + buttonshape.Height) &&
          mouse.LeftButton == ButtonState.Pressed)
      {
        System.Diagnostics.Debug.WriteLine(buttonshape.X.ToString());
        System.Diagnostics.Debug.WriteLine(buttonshape.Y.ToString());
        Wait();
      }
      
    }

    public void Wait()
    {
      Thread.Sleep(100);
    }


  }
}

