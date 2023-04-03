namespace DragonsWay.Logic
{
    public class Game
    {
        private char[,] _game;
        private int _n;
        private int _m;


        public Game(int n, string road)
        {
            _n = n;
            _m = n * 2;
            Road = road;
            _game = new char[_n, _m];
            DrawCavern();

        }

        public int N => _n;
        public int M => _n * 2;
        public string Road { get; }

        public override string ToString()
        {
            var output = string.Empty;
            var indexV = -1;
            var indexH = -1;
            output += "  ";
            for (int j = 0; j < M; j++)
            {
                indexH++;
                output += $"{indexH}";
            }
            output += "\n";

            for (int i = 0; i < N; i++)
            {
                indexV++;
                output += $"{indexV,2}";
                for (int j = 0; j < M; j++)
                {
                    output += $"{_game[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        public bool Win = false;

        private void DrawCavern()
        {
            DrawBorders();
            DrawWay();
        }

        private void DrawWay()
        {
            if (Road == "→→→↓↓↓→→→↓↓↓→→→→→→→→→↓→→→→→→")
            {
                Win = true;

            }
            else
            {
                for (int j = 1; j < M - 1; j++)
                {
                    _game[1, j] = '→';
                }
            }
        }

        private void DrawBorders()
        {
            _game[0, 0] = '█';
            for (int j = 1; j < M - 1; j++)
            {
                _game[0, j] = '▀';
            }

            _game[0, M - 1] = '█';
            for (int j = 0; j < M - 1; j++)
            {
                _game[1, j] = ' ';
            }

            _game[1, M - 1] = '█';
            for (int i = 2; i < N - 1; i++)
            {
                _game[i, 0] = '█';
                for (int j = 1; j < M - 1; j++)
                {
                    _game[i, j] = ' ';
                }
                _game[i, M - 1] = '█';
            }

            _game[N - 1, 0] = '█';
            for (int j = 1; j < M; j++)
            {
                _game[N - 2, j] = ' ';
            }

            for (int j = 1; j < M - 1; j++)
            {
                _game[N - 1, j] = '▄';
            }
            _game[N - 1, M - 1] = '█';
        }
    }
}