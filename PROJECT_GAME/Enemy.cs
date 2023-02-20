
public class Enemy
{
    public Rectangle rect = new Rectangle(10, 10, 50, 50);
    public float enemyMovementSpeed = 0.8f;

    public bool isAlive = true;

    Random generator = new Random();

    // Konstruktor = metod som körs automatiskt när en Enemy skapas (via new)
    public Enemy()
    {
        // Variant 1: y = 0, x = slumpat
        // Variant 2: y = slumpad, x = 0
        // Variant 3: y = skärmmax, x = slumpad
        // Variant 4: y = slumpad, x = skärmmax

        // slumpa tal 0-3
        // om 0:
        //  gör variant 1
        // om 1:
        //  gör variant 2
        // om 2:
        //  gör variant 3

        int poSelector = generator.Next(4);
        {

            if (poSelector == 0)
            {
                rect.x = generator.Next(Raylib.GetScreenWidth() - (int)rect.width);
                rect.y = 0;

            }
            else if (poSelector == 1)
            {
                rect.y = generator.Next(Raylib.GetScreenHeight() - (int)rect.height);
                rect.x = 0;
            }

            else if (poSelector == 2)

            {

                rect.y = generator.Next(Raylib.GetScreenHeight());
                rect.x = 1024 - rect.width;

            }

            else

            {

                rect.x = generator.Next(Raylib.GetScreenWidth());
                rect.y = 780 - rect.height;

            }

        }

    }



}
