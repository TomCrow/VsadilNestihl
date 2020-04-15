using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Exceptions;

namespace VsadilNestihl.Game.Board
{
    class Board : IBoard
    {
        public LinkedList<IPlace> Places { get; private set; }

        public Board(LinkedList<IPlace> places)
        {
            Places = places;
        }

        public IPlace GetStartPlace()
        {
            return Places.First.Value;
        }

        public IPlace GetNextPlace(IPlace place)
        {
            var placeNode = Places.Find(place);
            if (placeNode == null)
                throw new FatalGameException("Place not found on board.");

            if (placeNode.Next != null)
                return placeNode.Next.Value;

            return Places.First.Value;
        }
    }
}
