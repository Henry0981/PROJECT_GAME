global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1024, 780, "spel");
Raylib.SetTargetFPS(60);

string scene = "start";


int size = 60;
int hm = 30;
int hp = 4;


float rotation = 0;
float rotationSpeed = 5;


Random generator = new();

Rectangle player = new Rectangle(
    Raylib.GetScreenWidth() / 2,
    Raylib.GetScreenHeight() / 2,
    size, size
    );

Vector2 playerOffset = new Vector2(size / 2, size / 2);


// enemy spawning things
List<Enemy> enemies = new();
int howManyEnemiesAtOne = 6;

// Rectangle enemy = new Rectangle(10, 10, 50, 50);
// bool enemyAlive = true;

// int timerMax = 190
// int timer = timerMax

int timerMax = 190;
int timer = timerMax;

int bulletTimerMax = 190;
int bulletTimer = bulletTimerMax;


// Pseudo
// Skapa en rektangel & en vektor

Rectangle bullet = new Rectangle(
Raylib.GetScreenWidth() / 2,
Raylib.GetScreenHeight() / 2,
hm, hm
);

Vector2 bulletoffset = new Vector2(hm / 2, hm / 2);

float bulletSpeed = 10;
Vector2 bulletMovement = Vector2.Zero;


while (!Raylib.WindowShouldClose())
{

    //LOGIK

    // skapa secne varible i en if sats.
    // gör en if sats i if satsen där om man trycker space bar gör scene till "game".

    if (scene == "start")
    {

        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            scene = "game";
        }

    }
    else if (scene == "game")
    {

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            rotation += rotationSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            rotation -= rotationSpeed;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            bullet.x = Raylib.GetScreenWidth() / 2;
            bullet.y = Raylib.GetScreenHeight() / 2;

            float radians = (float)(rotation * (Math.PI / 180));
            // Räkna ut vektorn
            bulletMovement.X = MathF.Cos(radians) * bulletSpeed;
            bulletMovement.Y = MathF.Sin(radians) * bulletSpeed;

        }

        // timer--
        // om timer == 0
        // skapa ny fiender, lägg till i listan, återställ timern till timerMax

        timer--;
        if (timer <= 0)
        {
            for (int i = 0; i < howManyEnemiesAtOne; i++)
            {
                enemies.Add(new Enemy());
            }

            timer = timerMax;
        }


        foreach (Enemy enemy in enemies)
        {
            if (Raylib.CheckCollisionRecs(bullet, enemy.rect) && enemy.isAlive)
            {
                enemy.isAlive = false;
            }
        }

        foreach (Enemy enemy in enemies)

        {
            if (Raylib.CheckCollisionRecs(player, enemy.rect) && enemy.isAlive)
            {
                hp--;
                enemy.isAlive = false;
            }
            else if (hp == 0)
            {

                scene = "end";

            }


        }

    

        Vector2 playerpros = new Vector2(player.x, player.y);
        foreach (var enemy in enemies)
        {
            Vector2 enemyPos = new Vector2(enemy.rect.x, enemy.rect.y);

            Vector2 diff = playerpros - enemyPos;

            Vector2 enemyDirection = Vector2.Normalize(diff);

            Vector2 enemyMovement = enemyDirection * enemy.enemyMovementSpeed;

            enemy.rect.x += enemyMovement.X;
            enemy.rect.y += enemyMovement.Y;


        }



        // Flytta rektangeln med vector 
        bullet.x += bulletMovement.X;
        bullet.y += bulletMovement.Y;
    }

    else if (scene == "end")
    {

        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            scene = "start";
        }

    }

    //GRAFIK


    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("Press Enter to start", 185, 200, 60, Color.BLUE);
    }

    else if (scene == "game")
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText($"hp={hp}", 970, 0, 20, Color.GREEN);

        Raylib.DrawRectanglePro(player, playerOffset, rotation, Color.BEIGE);

        // Rita ut rektangeln

        Raylib.DrawRectanglePro(bullet, bulletoffset, rotation, Color.RED);

        foreach (Enemy enemy in enemies)
        {
            if (enemy.isAlive)
            {
                Raylib.DrawRectangleRec(enemy.rect, Color.BLUE);
            }

        }
    }

    else if (scene == "end")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("You lose!!!!!!!!!!!!!!!!", 4300, 275, 60, Color.RED);
    }


    Raylib.EndDrawing();


}




