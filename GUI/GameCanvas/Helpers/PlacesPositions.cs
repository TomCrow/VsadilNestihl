using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.GUI.GameCanvas.Helpers
{
    public static class PlacesPositions
    {
        private static readonly Dictionary<ConcretePlace, Dictionary<int,Point>> _placesPositions = new Dictionary<ConcretePlace, Dictionary<int, Point>>
        {
            {ConcretePlace.Start, new Dictionary<int, Point>{{0, new Point(592, 592)}}},
            {ConcretePlace.Fantome, new Dictionary<int, Point>{{0, new Point(541, 592)}}},
            {ConcretePlace.Finance1, new Dictionary<int, Point>{{0, new Point(490, 592)}}},
            {ConcretePlace.Gavora, new Dictionary<int, Point>{{0, new Point(439, 592)}}},
            {ConcretePlace.Clinic1, new Dictionary<int, Point>{{0, new Point(388, 592)}}},
            {ConcretePlace.Trainer1, new Dictionary<int, Point>{{0, new Point(337, 592)}}},
            {ConcretePlace.LadyAnne, new Dictionary<int, Point>{{0, new Point(286, 592)}}},
            {ConcretePlace.Chance1, new Dictionary<int, Point>{{0, new Point(235, 592)}}},
            {ConcretePlace.Pasek, new Dictionary<int, Point>{{0, new Point(184, 592)}}},
            {ConcretePlace.Koran, new Dictionary<int, Point>{{0, new Point(133, 592)}}},
            {ConcretePlace.Distanc, new Dictionary<int, Point>{{0, new Point(82, 592)}}},
            {ConcretePlace.Neklan, new Dictionary<int, Point>{{0, new Point(82, 541)}}},
            {ConcretePlace.Transportation, new Dictionary<int, Point>{{0, new Point(82, 490)}}},
            {ConcretePlace.Portlanc, new Dictionary<int, Point>{{0, new Point(82, 439)}}},
            {ConcretePlace.Japan, new Dictionary<int, Point>{{0, new Point(82, 388)}}},
            {ConcretePlace.Trainer2, new Dictionary<int, Point>{{0, new Point(82, 337)}}},
            {ConcretePlace.Kostrava, new Dictionary<int, Point>{{0, new Point(82, 286)}}},
            {ConcretePlace.Finance2, new Dictionary<int, Point>{{0, new Point(82, 235)}}},
            {ConcretePlace.Lukava, new Dictionary<int, Point>{{0, new Point(82, 184)}}},
            {ConcretePlace.Melak, new Dictionary<int, Point>{{0, new Point(82, 133)}}},
            {ConcretePlace.Parking, new Dictionary<int, Point>{{0, new Point(82, 82)}}},
            {ConcretePlace.Grifel, new Dictionary<int, Point>{{0, new Point(133, 82)}}},
            {ConcretePlace.Chance2, new Dictionary<int, Point>{{0, new Point(184, 82)}}},
            {ConcretePlace.Mohyla, new Dictionary<int, Point>{{0, new Point(235, 82)}}},
            {ConcretePlace.Metal, new Dictionary<int, Point>{{0, new Point(286, 82)}}},
            {ConcretePlace.Trainer3, new Dictionary<int, Point>{{0, new Point(337, 82)}}},
            {ConcretePlace.Tara, new Dictionary<int, Point>{{0, new Point(388, 82)}}},
            {ConcretePlace.Furioso, new Dictionary<int, Point>{{0, new Point(439, 82)}}},
            {ConcretePlace.Staje, new Dictionary<int, Point>{{0, new Point(490, 82)}}},
            {ConcretePlace.Genius, new Dictionary<int, Point>{{0, new Point(541, 82)}}},
            {ConcretePlace.Doping, new Dictionary<int, Point>{{0, new Point(592, 82)}}},
            {ConcretePlace.Shagga, new Dictionary<int, Point>{{0, new Point(592, 133)}}},
            {ConcretePlace.Dahoman, new Dictionary<int, Point>{{0, new Point(592, 184)}}},
            {ConcretePlace.Finance3, new Dictionary<int, Point>{{0, new Point(592, 235)}}},
            {ConcretePlace.Gira, new Dictionary<int, Point>{{0, new Point(592, 286)}}},
            {ConcretePlace.Trainer4, new Dictionary<int, Point>{{0, new Point(592, 337)}}},
            {ConcretePlace.Chance3, new Dictionary<int, Point>{{0, new Point(592, 388)}}},
            {ConcretePlace.Narcius, new Dictionary<int, Point>{{0, new Point(592, 439)}}},
            {ConcretePlace.Clinic2, new Dictionary<int, Point>{{0, new Point(592, 490)}}},
            {ConcretePlace.Napoli, new Dictionary<int, Point>{{0, new Point(592, 541)}}},
        };

        public static Point GetByPlaceAndPosition(ConcretePlace place, int position)
        {
            if (!_placesPositions.ContainsKey(place))
                return Point.Empty;

            if (!_placesPositions[place].ContainsKey(position))
                return Point.Empty;

            return _placesPositions[place][position];
        }
    }
}
