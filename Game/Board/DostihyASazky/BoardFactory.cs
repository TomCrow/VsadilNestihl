using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.Horses;

namespace VsadilNestihl.Game.Board.DostihyASazky
{
    class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard()
        {
            var places = new LinkedList<IPlace>();
            places.AddLast(new Place(ConcretePlace.Start, "Start", Color.White));
            places.AddLast(new Fantome());
            places.AddLast(new Place(ConcretePlace.Finance1, "Finance", Color.White));
            places.AddLast(new Gavora());
            places.AddLast(new Place(ConcretePlace.Clinic1, "Klinika", Color.White));
            places.AddLast(new Place(ConcretePlace.Trainer1, "1. Trenér", Color.White));
            places.AddLast(new LadyAnne());
            places.AddLast(new Place(ConcretePlace.Chance1, "Náhoda", Color.White));
            places.AddLast(new Pasek());
            places.AddLast(new Koran());
            places.AddLast(new Place(ConcretePlace.Distanc, "Distanc", Color.White));
            places.AddLast(new Neklan());
            places.AddLast(new Place(ConcretePlace.Transportation, "Přeprava", Color.White));
            places.AddLast(new Portlanc());
            places.AddLast(new Japan());
            places.AddLast(new Place(ConcretePlace.Trainer2, "2. Trenér", Color.White));
            places.AddLast(new Kostrava());
            places.AddLast(new Place(ConcretePlace.Finance2, "Finance", Color.White));
            places.AddLast(new Lukava());
            places.AddLast(new Melak());
            places.AddLast(new Place(ConcretePlace.Parking, "Parkoviště", Color.White));
            places.AddLast(new Grifel());
            places.AddLast(new Place(ConcretePlace.Chance2, "Náhoda", Color.White));
            places.AddLast(new Mohyla());
            places.AddLast(new Metal());
            places.AddLast(new Place(ConcretePlace.Trainer3, "3. Trenér", Color.White));
            places.AddLast(new Tara());
            places.AddLast(new Furioso());
            places.AddLast(new Place(ConcretePlace.Staje, "Stáje", Color.White));
            places.AddLast(new Genius());
            places.AddLast(new Place(ConcretePlace.Doping, "Podezření z dopingu", Color.White));
            places.AddLast(new Shagga());
            places.AddLast(new Dahoman());
            places.AddLast(new Place(ConcretePlace.Finance3, "Finance", Color.White));
            places.AddLast(new Gira());
            places.AddLast(new Place(ConcretePlace.Trainer4, "4. Trenér", Color.White));
            places.AddLast(new Place(ConcretePlace.Chance3, "Náhoda", Color.White));
            places.AddLast(new Narcius());
            places.AddLast(new Place(ConcretePlace.Clinic2, "Klinika", Color.White));
            places.AddLast(new Napoli());
            return new Board(places);
        }
    }
}
