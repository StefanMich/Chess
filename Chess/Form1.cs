using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Stufkan.Game;

namespace Chess
{
    public partial class Form1 : Form
    {
        Piece movable;
        Piece killable;
        Piece wRook;
        Piece bRook;
        Piece wBishop;
        Piece bBishop;
        Piece wKnight;
        Piece bKnight;
        Piece wKing;
        Piece bKing;
        Piece wQueen;
        Piece bQueen;
        Team neutral;
        Team white;
        Team black;


        public Form1()
        {
            InitializeComponent();

            gameBoard1.bgGrid = chessBoard();
            neutral = new Team("Neutral", 0);
            white = new Team("White", 1);
            black = new Team("Black", 2);

            movable = new Piece("movable", neutral, gameBoard1.solidModel(Color.Gray), null);
            killable = new Piece("killable", neutral, gameBoard1.solidModel(Color.Red), null);

            wRook = new Piece("Rook", white, Properties.Resources.wrook, rookMovement);
            bRook = new Piece("Rook", black, Properties.Resources.brook, rookMovement);

            wBishop = new Piece("Bishop", white, Properties.Resources.wbishop, bishopMovement);
            bBishop = new Piece("Bishop", black, Properties.Resources.bbishop, bishopMovement);

            wKnight = new Piece("Knight", white, Properties.Resources.wknight, knightMovement);
            bKnight = new Piece("Knight", black, Properties.Resources.bknight, knightMovement);

            wKing = new Piece("King", white, Properties.Resources.wking, kingMovement);
            bKing = new Piece("King", black, Properties.Resources.bking, kingMovement);

            wQueen = new Piece("Queen", white, Properties.Resources.wqueen, queenMovement);
            bQueen = new Piece("Queen", black, Properties.Resources.bqueen, queenMovement);

            Piece[,] board = new Piece[8, 8];
            board[0, 0] = wBishop;
            board[0, 3] = bRook;
            board[3, 0] = bKnight;
            board[3, 3] = bQueen;
            board[0, 6] = wBishop;
            board[2, 2] = wKing;

            gameBoard1.grid = board;
        }


        private Piece[,] chessBoard()
        {
            Piece[,] chess = new Piece[8, 8];

            Piece black = new Piece("black", null, gameBoard1.solidModel(Color.Black), null);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                        chess[i, j] = black;
                }
            }

            return chess;
        }

        private Piece[,] rookMovement(Point origin, Team opposingTeam)
        {
            Piece[,] movement = new Piece[8, 8];

            int x = origin.X + 1;
            while (x < 8)
            {

                if (gameBoard1.grid[x, origin.Y] == null)
                    movement[x, origin.Y] = movable;
                else if (gameBoard1.grid[x, origin.Y] != null && gameBoard1.grid[x, origin.Y].Team != opposingTeam)
                    x = 8;
                else if (gameBoard1.grid[x, origin.Y] != null && gameBoard1.grid[x, origin.Y].Team == opposingTeam)
                {
                    movement[x, origin.Y] = killable;
                    x = 8; //break the loop
                }
                x++;
            }

            x = origin.X - 1;
            while (x >= 0)
            {

                if (gameBoard1.grid[x, origin.Y] == null)
                    movement[x, origin.Y] = movable;
                else if (gameBoard1.grid[x, origin.Y] != null && gameBoard1.grid[x, origin.Y].Team != opposingTeam)
                    x = -1;
                else if (gameBoard1.grid[x, origin.Y] != null && gameBoard1.grid[x, origin.Y].Team == opposingTeam)
                {
                    movement[x, origin.Y] = killable;
                    x = -1; // break the loop
                }
                x--;
            }

            int y = origin.Y + 1;
            while (y < 8)
            {
                if (gameBoard1.grid[origin.X, y] == null)
                    movement[origin.X, y] = movable;
                else if (gameBoard1.grid[origin.X, y] != null && gameBoard1.grid[origin.X, y].Team != opposingTeam)
                    y = 8;
                else if (gameBoard1.grid[origin.X, y] != null && gameBoard1.grid[origin.X, y].Team == opposingTeam)
                {
                    movement[origin.X, y] = killable;
                    y = 8; // break the loop
                }
                y++;
            }

            y = origin.Y - 1;
            while (y >= 0)
            {
                if (gameBoard1.grid[origin.X, y] == null)
                    movement[origin.X, y] = movable;
                else if (gameBoard1.grid[origin.X, y] != null && gameBoard1.grid[origin.X, y].Team != opposingTeam)
                    y = -1;
                else if (gameBoard1.grid[origin.X, y] != null && gameBoard1.grid[origin.X, y].Team == opposingTeam)
                {
                    movement[origin.X, y] = killable;
                    y = -1;
                }
                y--;
            }

            return movement;
        }

        private Piece[,] bishopMovement(Point origin, Team opposingTeam)
        {
            Piece[,] movement = new Piece[8, 8];

            int x = origin.X + 1;
            int y = origin.Y + 1;
            while (x.IsInGrid() && y.IsInGrid())
            {

                if (gameBoard1.grid[x, y] == null)
                    movement[x, y] = movable;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team != opposingTeam)
                    x = 8;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team == opposingTeam)
                {
                    movement[x, y] = killable;
                    x = 8; //break the loop
                }
                x++;
                y++;
            }

            x = origin.X + 1;
            y = origin.Y - 1;
            while (x.IsInGrid() && y.IsInGrid())
            {

                if (gameBoard1.grid[x, y] == null)
                    movement[x, y] = movable;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team != opposingTeam)
                    x = 8;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team == opposingTeam)
                {
                    movement[x, y] = killable;
                    x = 8; //break the loop
                }
                x++;
                y--;
            }

            x = origin.X - 1;
            y = origin.Y + 1;
            while (x.IsInGrid() && y.IsInGrid())
            {

                if (gameBoard1.grid[x, y] == null)
                    movement[x, y] = movable;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team != opposingTeam)
                    x = 8;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team == opposingTeam)
                {
                    movement[x, y] = killable;
                    x = 8; //break the loop
                }
                x--;
                y++;
            }

            x = origin.X - 1;
            y = origin.Y - 1;
            while (x.IsInGrid() && y.IsInGrid())
            {

                if (gameBoard1.grid[x, y] == null)
                    movement[x, y] = movable;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team != opposingTeam)
                    x = 8;
                else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team == opposingTeam)
                {
                    movement[x, y] = killable;
                    x = 8; //break the loop
                }
                x--;
                y--;
            }

            return movement;
        }

        private Piece[,] knightMovement(Point origin, Team opposingTeam)
        {
            Piece[,] movement = new Piece[8,8];

            if ((origin.X + 2).IsInGrid() && (origin.Y + 1).IsInGrid())
                moveToField(origin.X + 2, origin.Y + 1, opposingTeam, movement);
            if ((origin.X + 2).IsInGrid() && (origin.Y - 1).IsInGrid())
                moveToField(origin.X + 2, origin.Y - 1, opposingTeam, movement);
            if ((origin.X - 2).IsInGrid() && (origin.Y + 1).IsInGrid())
                moveToField(origin.X - 2, origin.Y + 1, opposingTeam, movement);
            if ((origin.X - 2).IsInGrid() && (origin.Y - 1).IsInGrid())
                moveToField(origin.X - 2, origin.Y - 1, opposingTeam, movement);

            if ((origin.X + 1).IsInGrid() && (origin.Y + 2).IsInGrid())
                moveToField(origin.X + 1, origin.Y + 2, opposingTeam, movement);
            if ((origin.X - 1).IsInGrid() && (origin.Y + 2).IsInGrid())
                moveToField(origin.X -1, origin.Y + 2, opposingTeam, movement);
            if ((origin.X + 1).IsInGrid() && (origin.Y - 2).IsInGrid())
                moveToField(origin.X + 1, origin.Y - 2, opposingTeam, movement);
            if ((origin.X - 1).IsInGrid() && (origin.Y - 2).IsInGrid())
                moveToField(origin.X - 1, origin.Y - 2, opposingTeam, movement);
            return movement;
        }

        private Piece[,] kingMovement(Point origin, Team opposingTeam)
        {
            Piece[,] movement = new Piece[8,8];

            if ((origin.X + 1).IsInGrid() && (origin.Y).IsInGrid())
                moveToField(origin.X + 1, origin.Y, opposingTeam, movement);
            if ((origin.X + 1).IsInGrid() && (origin.Y + 1).IsInGrid())
                moveToField(origin.X + 1, origin.Y+1, opposingTeam, movement);
            if ((origin.X + 1).IsInGrid() && (origin.Y-1).IsInGrid())
                moveToField(origin.X + 1, origin.Y-1, opposingTeam, movement);
            if ((origin.X).IsInGrid() && (origin.Y -1).IsInGrid())
                moveToField(origin.X, origin.Y-1, opposingTeam, movement);
            if ((origin.X).IsInGrid() && (origin.Y+1).IsInGrid())
                moveToField(origin.X, origin.Y+1, opposingTeam, movement);
            if ((origin.X - 1).IsInGrid() && (origin.Y).IsInGrid())
                moveToField(origin.X - 1, origin.Y, opposingTeam, movement);
            if ((origin.X - 1).IsInGrid() && (origin.Y + 1).IsInGrid())
                moveToField(origin.X - 1, origin.Y + 1, opposingTeam, movement);
            if ((origin.X - 1).IsInGrid() && (origin.Y - 1).IsInGrid())
                moveToField(origin.X - 1, origin.Y - 1, opposingTeam, movement);


            return movement;
        }

        private Piece[,] queenMovement(Point origin, Team opposingTeam)
        {
            Piece[,] movement = new Piece[8, 8];

            Piece[,] rook = rookMovement(origin, opposingTeam);
            Piece[,] bishop = bishopMovement(origin, opposingTeam);

            movement = MergeBackgrounds(rook, bishop);

            return movement;
        }

        private Piece[,] pawnMovement(Point origin, Team opposingTeam)
        {
            Piece[,] movement = new Piece[8, 8];

            return movement;
        }

        private void moveToField(int x, int y, Team opposingTeam, Piece[,] movement)
        {
            if (gameBoard1.grid[x, y] == null)
                movement[x, y] = movable;
            else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team != opposingTeam)
                x = 8;
            else if (gameBoard1.grid[x, y] != null && gameBoard1.grid[x, y].Team == opposingTeam)
            {
                movement[x, y] = killable;
            }
        }

        private void gameBoard1_MouseClick(object sender, MouseEventArgs e)
        {
            gameBoard1.bgGrid = chessBoard();
            Point point = gameBoard1.getCellFromPoint(e.Location);
            if (gameBoard1.grid[point.X, point.Y] != null)
            {
                Team team = OpposingTeam(gameBoard1.grid[point.X, point.Y].Team);
                Piece[,] board;
                gameBoard1.grid.CastArray(out board);
                Piece[,] pattern = (gameBoard1.grid[point.X, point.Y] as Piece).Move(point, team);
                gameBoard1.bgGrid.CastArray(out board);
                gameBoard1.bgGrid = MergeBackgrounds(board, pattern);
                gameBoard1.Invalidate();
            }

        }

        public Team OpposingTeam(Team team)
        {
            if (team == black)
                return white;
            else return black;
        }

        public Piece[,] MergeBackgrounds(Piece[,] background, Piece[,] pattern)
        {
            Piece[,] merge = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pattern[j, i] != null)
                        merge[j, i] = pattern[j, i];
                    else merge[j, i] = background[j, i];
                }
            }

            return merge;
        }

    }

    static class IntExtension
    {
        public static bool IsInGrid(this int x)
        {
            if (x >= 0 && x < 8)
                return true;
            else return false;
        }
    }
}
