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
        private static readonly Dictionary<ConcretePlace, Rectangle> _placesPositions = new Dictionary<ConcretePlace, Rectangle>
        {
            {ConcretePlace.Start, new Rectangle(592, 592, 50, 50)},
            {ConcretePlace.Fantome, new Rectangle(541, 592, 50, 50)},
            {ConcretePlace.Finance1, new Rectangle(490, 592, 50, 50)},
            {ConcretePlace.Gavora, new Rectangle(439, 592, 50, 50)},
            {ConcretePlace.Clinic1, new Rectangle(388, 592, 50, 50)},
            {ConcretePlace.Trainer1, new Rectangle(337, 592, 50, 50)},
            {ConcretePlace.LadyAnne, new Rectangle(286, 592, 50, 50)},
            {ConcretePlace.Chance1, new Rectangle(235, 592, 50, 50)},
            {ConcretePlace.Pasek, new Rectangle(184, 592, 50, 50)},
            {ConcretePlace.Koran, new Rectangle(133, 592, 50, 50)},
            {ConcretePlace.Distanc, new Rectangle(82, 592, 50, 50)},
            {ConcretePlace.Neklan, new Rectangle(82, 541, 50, 50)},
            {ConcretePlace.Transportation, new Rectangle(82, 490, 50, 50)},
            {ConcretePlace.Portlanc, new Rectangle(82, 439, 50, 50)},
            {ConcretePlace.Japan, new Rectangle(82, 388, 50, 50)},
            {ConcretePlace.Trainer2, new Rectangle(82, 337, 50, 50)},
            {ConcretePlace.Kostrava, new Rectangle(82, 286, 50, 50)},
            {ConcretePlace.Finance2, new Rectangle(82, 235, 50, 50)},
            {ConcretePlace.Lukava, new Rectangle(82, 184, 50, 50)},
            {ConcretePlace.Melak, new Rectangle(82, 133, 50, 50)},
            {ConcretePlace.Parking, new Rectangle(82, 82, 50, 50)},
            {ConcretePlace.Grifel, new Rectangle(133, 82, 50, 50)},
            {ConcretePlace.Chance2, new Rectangle(184, 82, 50, 50)},
            {ConcretePlace.Mohyla, new Rectangle(235, 82, 50, 50)},
            {ConcretePlace.Metal, new Rectangle(286, 82, 50, 50)},
            {ConcretePlace.Trainer3, new Rectangle(337, 82, 50, 50)},
            {ConcretePlace.Tara, new Rectangle(388, 82, 50, 50)},
            {ConcretePlace.Furioso, new Rectangle(439, 82, 50, 50)},
            {ConcretePlace.Staje, new Rectangle(490, 82, 50, 50)},
            {ConcretePlace.Genius, new Rectangle(541, 82, 50, 50)},
            {ConcretePlace.Doping, new Rectangle(592, 82, 50, 50)},
            {ConcretePlace.Shagga, new Rectangle(592, 133, 50, 50)},
            {ConcretePlace.Dahoman, new Rectangle(592, 184, 50, 50)},
            {ConcretePlace.Finance3, new Rectangle(592, 235, 50, 50)},
            {ConcretePlace.Gira, new Rectangle(592, 286, 50, 50)},
            {ConcretePlace.Trainer4, new Rectangle(592, 337, 50, 50)},
            {ConcretePlace.Chance3, new Rectangle(592, 388, 50, 50)},
            {ConcretePlace.Narcius, new Rectangle(592, 439, 50, 50)},
            {ConcretePlace.Clinic2, new Rectangle(592, 490, 50, 50)},
            {ConcretePlace.Napoli, new Rectangle(592, 541, 50, 50)},
        };

        private static readonly Dictionary<ConcretePlace, Rectangle> _placesIcons = new Dictionary<ConcretePlace, Rectangle>
        {
            //{ConcretePlace.Start, new Rectangle(592, 643, 50, 80)},
            {ConcretePlace.Fantome, new Rectangle(541, 643, 50, 80)},
            //{ConcretePlace.Finance1, new Rectangle(490, 643, 50, 80)},
            {ConcretePlace.Gavora, new Rectangle(439, 643, 50, 80)},
            {ConcretePlace.Clinic1, new Rectangle(388, 643, 50, 80)},
            {ConcretePlace.Trainer1, new Rectangle(337, 643, 50, 80)},
            {ConcretePlace.LadyAnne, new Rectangle(286, 643, 50, 80)},
            //{ConcretePlace.Chance1, new Rectangle(235, 643, 50, 80)},
            {ConcretePlace.Pasek, new Rectangle(184, 643, 50, 80)},
            {ConcretePlace.Koran, new Rectangle(133, 643, 50, 80)},
            //{ConcretePlace.Distanc, new Rectangle(82, 592)},
            {ConcretePlace.Neklan, new Rectangle(1, 541, 80, 50)},
            {ConcretePlace.Transportation, new Rectangle(1, 490, 80, 50)},
            {ConcretePlace.Portlanc, new Rectangle(1, 439, 80, 50)},
            {ConcretePlace.Japan, new Rectangle(1, 388, 80, 50)},
            {ConcretePlace.Trainer2, new Rectangle(1, 337, 80, 50)},
            {ConcretePlace.Kostrava, new Rectangle(1, 286, 80, 50)},
            //{ConcretePlace.Finance2, new Rectangle(1, 235, 80, 50)},
            {ConcretePlace.Lukava, new Rectangle(1, 184, 80, 50)},
            {ConcretePlace.Melak, new Rectangle(1, 133, 80, 50)},
            //{ConcretePlace.Parking, new Rectangle(82, 82)},
            {ConcretePlace.Grifel, new Rectangle(133, 1, 50, 80)},
            //{ConcretePlace.Chance2, new Rectangle(235, 1, 50, 80)},
            {ConcretePlace.Mohyla, new Rectangle(235, 1, 50, 80)},
            {ConcretePlace.Metal, new Rectangle(286, 1, 50, 80)},
            {ConcretePlace.Trainer3, new Rectangle(337, 1, 50, 80)},
            {ConcretePlace.Tara, new Rectangle(388, 1, 50, 80)},
            {ConcretePlace.Furioso, new Rectangle(439, 1, 50, 80)},
            {ConcretePlace.Staje, new Rectangle(490, 1, 50, 80)},
            {ConcretePlace.Genius, new Rectangle(541, 1, 50, 80)},
            //{ConcretePlace.Doping, new Rectangle(592, 82)},
            {ConcretePlace.Shagga, new Rectangle(643, 133, 80, 50)},
            {ConcretePlace.Dahoman, new Rectangle(643, 184, 80, 50)},
            //{ConcretePlace.Finance3, new Rectangle(643, 235, 80, 50)},
            {ConcretePlace.Gira, new Rectangle(643, 286, 80, 50)},
            {ConcretePlace.Trainer4, new Rectangle(643, 337, 80, 50)},
            //{ConcretePlace.Chance3, new Rectangle(643, 388, 80, 50)},
            {ConcretePlace.Narcius, new Rectangle(643, 439, 80, 50)},
            {ConcretePlace.Clinic2, new Rectangle(643, 490, 80, 50)},
            {ConcretePlace.Napoli, new Rectangle(643, 541, 80, 50)},
        };

        public static Rectangle GetPlayerPosition(ConcretePlace place)
        {
            if (!_placesPositions.ContainsKey(place))
                return Rectangle.Empty;

            return _placesPositions[place];
        }

        public static Rectangle GetIconPosition(ConcretePlace place)
        {
            if (!_placesIcons.ContainsKey(place))
                return Rectangle.Empty;

            return _placesIcons[place];
        }
    }
}
