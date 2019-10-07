using System;

namespace tiktaktoe
{
    class Game
    {
        int[,] field = new int[3, 3];
        int player = 0;

        /* Liefert einen String zur Darstellung im Spielfeld für ein bestimmtes Feld */
        private string getFieldString(int x, int y)
        {
            if (field[x, y] == 1) { return "X"; }
            if (field[x, y] == 2) { return "O"; }

            return " ";
        }

        /* EIngabe der Koordinaten für die Y-Achse */
        private int getYAxis()
        {
            var yString = string.Empty;

            while (
                    yString == string.Empty ||
                    (yString != "a" && yString != "b" && yString != "c"))
            {
                
                Console.WriteLine();
                Console.Write("Y Achse: ");
                yString = (Console.ReadKey().KeyChar).ToString().ToLower();
            }

            // Berechnen des Wertes anhand der ASCII-Tabelle
            return ((int)yString[0]) - 97;
        }

        /* Eingabe der Koordinaten für die X-Achse */
        private int getXAxis()
        {
            int x = -1;

            while (x < 0 | x > 2)
            {
                Console.WriteLine();
                Console.Write("X Achse: ");
                try
                {
                    x = int.Parse((Console.ReadKey()).KeyChar.ToString()) - 1;
                }
                catch { }
            }

            return x;
        }

        /* Zeichnen des Spielfeldes mit dem aktuellen Status */
        private void Draw()
        {
            string[] lines = {
                "   1   2   3 ",
                "A  " + getFieldString(0,0) + " | " + getFieldString(1,0) + " | " + getFieldString(2,0) + " ",
                "  -----------",
                "B  " + getFieldString(0,1) + " | " + getFieldString(1,1) + " | " + getFieldString(2,1) + " ",
                "  -----------",
                "C  " + getFieldString(0,2) + " | " + getFieldString(1,2) + " | " + getFieldString(2,2) + " ",
            };

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }

        /* Eine neue Instanz startet ein neues Spiel */
        public Game()
        {
            for (int i = 0; i < 9; i++)
            {
                this.Draw();

                int y = getYAxis();
                int x = getXAxis();

                Console.WriteLine();
                Console.WriteLine(x + "," + y);

                this.field[x, y] = player + 1;
                player = (player + 1) % 2;
            }
        }
    }
}
