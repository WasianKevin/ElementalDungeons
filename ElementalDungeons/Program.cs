using System;
using Raylib_cs;
using System.Numerics;
using System.Threading;

//Creation of the window
Raylib.InitWindow(1300, 1000, "Elemental Dungeons");
Raylib.SetTargetFPS(60);

// kollar senaste directionen och gör default direction till höger. DÅ den är x= 1 y = 0
Vector2 lastPlayerDirection = new Vector2(1, 0);


Texture2D background = Raylib.LoadTexture("DungeonBackground.png");
Texture2D MainScreen = Raylib.LoadTexture("DungeonHomeScreen.png");
Texture2D ElementDecision = Raylib.LoadTexture("DungeonElement.png");
Texture2D playerImage = Raylib.LoadTexture("obama.png");
Texture2D goblin = Raylib.LoadTexture("goblin.png");
Texture2D fireball = Raylib.LoadTexture("fireball.png");
Texture2D waterball = Raylib.LoadTexture("Waterball.png");




string room = "HomeScreen";
float speed = 5f;
float velocity = 0;
float gravity = 2;
bool isGrounded = false;



//Creation of the character and obstacles
Rectangle playerRect = new Rectangle(60, 875, playerImage.width, playerImage.height);


List<Fireball> fireballs = new List<Fireball>();
List<Waterball> waterballs = new List<Waterball>();

while (!Raylib.WindowShouldClose())
{



    //Changing direction of Obama depending on what way he's walking
    Vector2 movement = ReadMovement(speed);
    playerRect.x += movement.X;
    playerRect.y += movement.Y;

    //if Obama hits the floor he stops falling
    velocity += gravity;
    if (playerRect.y >= 875 - playerRect.height)
    {
        velocity = 0;
        isGrounded = true;
        playerRect.y = 875 - playerRect.height;
    }

    else
    {
        isGrounded = false;
    }





    //Obama direction
    if (movement.X > 0)
    {
        playerImage = Raylib.LoadTexture("obama2.png");
    }
    else if (movement.X < 0)
    {
        playerImage = Raylib.LoadTexture("obama.png");
    }


    //If Obama leaves the ground he falls down
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && isGrounded)
    {
        velocity = -20;
    }

    playerRect.y += velocity;





    // X-borders
    if (playerRect.x < 30 || playerRect.x + playerRect.width > Raylib.GetScreenWidth() - 30)
    {
        playerRect.x -= movement.X;
    }

    // Y-borders
    if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
        playerRect.y -= movement.Y;
    }












    if (room == "HomeScreen")
    {
        //Allows me to draw a room
        Raylib.BeginDrawing();

        //Draws the background
        Raylib.DrawTexture(MainScreen, 0, 0, Color.WHITE);

        //I switch room if i press ENTER
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            room = "Element";
        }

        Raylib.EndDrawing();
    }










    if (room == "Element")
    {
        //Allows me to draw a room
        Raylib.BeginDrawing();

        //Draws the background
        Raylib.DrawTexture(ElementDecision, 0, 0, Color.WHITE);

        //If i press 2, i enter the fire domain.
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
        {
            room = "DungeonFire";
        }

        //If i press 1, i enter the water domain.
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
        {
            room = "DungeonWater";
        }

        Raylib.EndDrawing();
    }









































    if (room == "DungeonFire")
    {
        //Allows me to draw a room
        Raylib.BeginDrawing();

        //Draws the background
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);

        //goblin spawn
        Raylib.DrawTexture(goblin, 820, 725, Color.WHITE);
        Raylib.DrawTexture(goblin, 900, 725, Color.WHITE);
        Raylib.DrawTexture(goblin, 980, 725, Color.WHITE);

        //Draws the character
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        Vector2 movement2 = ReadMovement(speed);
        // Den under uppdaterar för att se om jag har rtört mig
        if (movement2.Length() > 0)
        {
            // Den här gör vectorn till 1 alltså normalizar
            lastPlayerDirection = Vector2.Normalize(movement2);
        }


        //make fireball travel forwards
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Fireball b1 = new Fireball();
            b1.brect = new Rectangle(playerRect.x, playerRect.y, 50, 30);
            b1.isAlive = true;
            b1.direction = lastPlayerDirection;
            fireballs.Add(b1);

        }
        // En for loop om att kolla listan och rita skott och kolla vilken riktning dom är/får dom att röra sig
        for (int i = 0; i < fireballs.Count; i++)
        {
            fireballs[i].Update();
            fireballs[i].Draw();
        }

        fireballs.RemoveAll(x => x.isAlive == false);




        Raylib.EndDrawing();
    }










































    if (room == "DungeonWater")
    {
        //Allows me to draw a room
        Raylib.BeginDrawing();

        //Draws the background
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);

        //goblin spawn
        Raylib.DrawTexture(goblin, 820, 725, Color.WHITE);
        Raylib.DrawTexture(goblin, 900, 725, Color.WHITE);
        Raylib.DrawTexture(goblin, 980, 725, Color.WHITE);

        //Draws the character
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        Vector2 movement2 = ReadMovement(speed);
        // Den under uppdaterar för att se om jag har rtört mig
        if (movement2.Length() > 0)
        {
            // Den här gör vectorn till 1 alltså normalizar
            lastPlayerDirection = Vector2.Normalize(movement2);
        }


        //make fireball travel forwards
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Waterball b0 = new Waterball();
            b0.brect = new Rectangle(playerRect.x, playerRect.y, 50, 30);
            b0.isAlive = true;
            b0.direction = lastPlayerDirection;
            waterballs.Add(b0);

        }
        // En for loop om att kolla listan och rita skott och kolla vilken riktning dom är/får dom att röra sig
        for (int i = 0; i < waterballs.Count; i++)
        {
            waterballs[i].Update();
            waterballs[i].Draw();
        }

        waterballs.RemoveAll(x => x.isAlive == false);




        Raylib.EndDrawing();
    }













//Fix enemies move towards player
//Fix enemies health
//


























    //Movement
    static Vector2 ReadMovement(float speed)
    {
        Vector2 movement = new Vector2();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;

        return movement;
    }


}



