using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stufkan.Game;
using System.Drawing;

namespace Chess
{
    public class Piece : Stufkan.Game.Piece
    {
        private Func<Point , Team, Piece[,]> move;

        public Func<Point, Team, Piece[,]> Move
        {
            get { return move; }
            set { move = value; }
        }

        public Piece(string name, Team team, Bitmap model, Func<Point, Team, Piece[,]> move)
            : base(name, team, model)
        {
            this.move = move;
        }
    }
}
