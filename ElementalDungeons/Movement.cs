using System.Numerics;
using Raylib_cs;

public class Movement
{
    //Movement
    public static Vector2 ReadMovement(float speed)
    {
        Vector2 movement = new Vector2();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;

        return movement;
    }

}
