using System.Numerics;
using Raylib_cs;


public class Fireball
{
    public Vector2 direction;
    public Rectangle brect;
    public bool isAlive;
    public Texture2D fireball = Raylib.LoadTexture("fireball.png");

    public void Update()
    {
        float speed = 15;

        // Tar riktningen som är 1 om jag har rört och gångrar den med speed. 
        brect.x += direction.X * speed;



        if (brect.x > Raylib.GetScreenWidth() - 100)
        {
            isAlive = false;
        }

    }

    public void Draw()
    {
        Raylib.DrawTexture(fireball, (int)brect.x, (int)brect.y, Color.WHITE);
    }

}