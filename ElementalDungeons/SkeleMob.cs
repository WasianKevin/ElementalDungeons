using System.Numerics;
using Raylib_cs;

public class SkeleMob
{

    public Vector2 direction;
    public Rectangle brect;

    public Texture2D skeleton = Raylib.LoadTexture("Skeleton.png");


    public void Update()
    {
        float speed = 5;

        // Tar riktningen som är 1 om jag har rört och gångrar den med speed. 
        brect.x += direction.X * speed;

    }

    public void Draw()
    {
        Raylib.DrawTexture(skeleton, 800, 775, Color.WHITE);
    }


}
