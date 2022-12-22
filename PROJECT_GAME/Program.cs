global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1024, 780, "spel");
Raylib.SetTargetFPS(60);

int size = 60;
int hm = 30;

float rotation = 0;

float rotationSpeed = 5;

Rectangle player = new Rectangle(
    Raylib.GetScreenWidth() / 2,
    Raylib.GetScreenHeight() / 2,
    size, size
    );

Vector2 playerOffset = new Vector2(size / 2, size / 2);

Enemy e = new Enemy();
Enemy e2 = new Enemy();

e2.rect.x = 600;
Enemy e3 = new Enemy();

e3.rect.y = 200;
List<Enemy> enemies = new();

enemies.Add(e);
enemies.Add(e2);
enemies.Add(e3);

// Rectangle enemy = new Rectangle(10, 10, 50, 50);
// bool enemyAlive = true;


// Pseudo
// Skapa en rektangel & en vektor

Rectangle bullet = new Rectangle(
Raylib.GetScreenWidth() / 2,
Raylib.GetScreenHeight() / 2,
hm, hm
);

Vector2 bulletoffset = new Vector2(hm / 2, hm / 2);

float bulletRotation = 0;
float bulletSpeed = 10;
Vector2 bulletMovement = Vector2.Zero;


while (!Raylib.WindowShouldClose())
{

    //LOGIK
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

    if (Raylib.CheckCollisionRecs(bullet, e.rect) && e.isAlive)
    {
        e.isAlive = false;
    }

    // Flytta rektangeln med vector 
    bullet.x += bulletMovement.X;
    bullet.y += bulletMovement.Y;

    //GRAFIK

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.BLACK);

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



    Raylib.EndDrawing();

}


