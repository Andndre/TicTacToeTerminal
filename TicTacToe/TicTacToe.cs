using System;

namespace TicTacToe
{
    // State yang ada pada game
    public enum State
    {
        O = 'O',
        X = 'X',
        NONE = ' ',
        DRAW = '^',
        X_WINNER = '1',
        O_WINNER = '0'
    }

    internal class TicTacToe
    {
        // Jika game selesai
        public bool gameOver = false;
        // State awal
        public State state = State.O;
        // Kursor dimana pengguna akan bergerak
        public int row = 0;
        public int column = 0;
        // Ukuran board
        public int GRID_SIZE = 3;
        // Board (default kosong)
        public readonly State[,] board = {
            { State.NONE, State.NONE, State.NONE },
            { State.NONE, State.NONE, State.NONE },
            { State.NONE, State.NONE, State.NONE },
        };

        // Mengecek apakah ada pemenang
        public State CheckWinner()
        {
            State candidate;
            bool win;
            // Baris
            for (int i = 0; i < GRID_SIZE; i++)
            {
                // jika masih kosong, tidak ada pemenang pada baris ini
                if (board[i, 0] != State.NONE)
                {
                    // anggap dia sebagai pemenang
                    candidate = board[i, 0];
                    win = true;
                    for (int j = 1; j < GRID_SIZE; j++)
                    {
                        var current = board[i, j];
                        // jika ditemukan dari satu baris yang tidak sama dengan kandidat
                        // bukan dia pemenangnya
                        if (current != candidate)
                        {
                            // lanjut cek baris berikutnya
                            win = false;
                            break;
                        }
                    }
                    if (win) {
                        return candidate; 
                    }
                }
            }

            // Kolom
            for (int i = 0; i < GRID_SIZE; i++)
            {
                // anggap dia sebagai pemenang
                candidate = board[0, i];
                if (candidate != State.NONE)
                {
                    win = true;
                    for (int j = 1; j < GRID_SIZE; j++)
                    {
                        var current = board[j, i];
                        // jika ditemukan dari satu kolom yang tidak sama dengan kandidat
                        // bukan dia pemenangnya
                        if (current != candidate)
                        {
                            // lanjut cek kolom berikutnya
                            win = false;
                            break;
                        }
                    }
                    if (win) 
                    {
                        return candidate; 
                    }
                }
            }

            // Diagonal
            // 1
            candidate = board[0, 0];
            if (candidate != State.NONE)
            {
                win = true;
                for (int i = 1; i < GRID_SIZE; i++)
                {
                    var current = board[i, i];
                    if (current != candidate)
                    {
                        win = false;
                        break;
                    }
                }

                if (win) 
                {
                    return candidate; 
                }
            }

            // 2
            candidate = board[0, GRID_SIZE - 1];
            if (candidate != State.NONE)
            {
                win = true;
                for (int i = 1; i < GRID_SIZE; i++)
                {
                    var current = board[i, GRID_SIZE - 1 - i];
                    if (current != candidate)
                    {
                        win = false;
                        break;
                    }
                }

                if (win) 
                {
                    return candidate; 
                }
            }

            // Jika full, maka game seri. Jika tidak, permainan belum berakhir
            return IsFull() ? State.DRAW : State.NONE;
        }

        // Mengisi board pada Kursor dengan state saat ini (player O/X)
        public bool SetValue()
        {
            if (state == State.NONE) return false;
            if (state == State.DRAW) return false;
            if (board[row, column] != State.NONE) return false;
            board[row, column] = state;
            NextTurn();
            return true;
        }

        // Reset game (clear board)
        public void Reset()
        {
            gameOver = false;
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    board[i, j] = State.NONE;
                }
            }
            state = State.O;
        }

        // Mengecek apakah board penuh
        public bool IsFull()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (board[i, j] == State.NONE) return false;
                }
            }
            return true;
        }

        // Dipanggil setelah player membuat gerakan. Mengecek apakah ada pemenang, kemudian menentukan state game
        private void NextTurn()
        {
            State winner = CheckWinner();
            if (winner == State.DRAW)
            {
                gameOver = true;
                state = State.DRAW;
                return;
            }
            if (winner != State.NONE)
            {
                state = winner == State.X ? State.X_WINNER : State.O_WINNER;
                gameOver = true;    
                return;
            }
            if (state != State.O && state != State.X)
            {
                throw new Exception("This shouldn't happened");
            }
            if (state == State.O)
            {
                state = State.X;
            }
            else
            {
                state = State.O;
            }
        }

        // Menggerakkan kursor dengan offset r dan c
        public void MoveCursor(int r, int c)
        {
            if (row + r == GRID_SIZE || row + r < 0 || column + c == GRID_SIZE || column + c < 0)
            {
                return;
            }
            row += r;
            column += c;
        }
    }
}

// Referensi: 
// - The coding train youtube channnel
