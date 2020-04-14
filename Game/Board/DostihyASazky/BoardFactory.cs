using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Board.DostihyASazky
{
    class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard()
        {
            var places = new LinkedList<IPlace>();
            places.AddLast(new Place(ConcretePlace.Start, "Start"));
            places.AddLast(new Place(ConcretePlace.Fantome, "Fantome"));
            places.AddLast(new Place(ConcretePlace.Finance1, "Finance"));
            places.AddLast(new Place(ConcretePlace.Gavora, "Gavora"));
            places.AddLast(new Place(ConcretePlace.Clinic1, "Klinika"));
            places.AddLast(new Place(ConcretePlace.Trainer1, "1. Trenér"));
            places.AddLast(new Place(ConcretePlace.LadyAnne, "LAdy Anne"));
            places.AddLast(new Place(ConcretePlace.Chance1, "Náhoda"));
            places.AddLast(new Place(ConcretePlace.Pasek, "Pasek"));
            places.AddLast(new Place(ConcretePlace.Koran, "Koran"));
            places.AddLast(new Place(ConcretePlace.Distanc, "Distanc"));
            places.AddLast(new Place(ConcretePlace.Neklan, "Neklan"));
            places.AddLast(new Place(ConcretePlace.Transportation, "Přeprava"));
            places.AddLast(new Place(ConcretePlace.Portlanc, "Portlanc"));
            places.AddLast(new Place(ConcretePlace.Japan, "Japan"));
            places.AddLast(new Place(ConcretePlace.Trainer2, "2. Trenér"));
            places.AddLast(new Place(ConcretePlace.Kostrava, "Kostrava"));
            places.AddLast(new Place(ConcretePlace.Finance2, "Finance"));
            places.AddLast(new Place(ConcretePlace.Lukava, "Lukava"));
            places.AddLast(new Place(ConcretePlace.Melak, "Melák"));
            places.AddLast(new Place(ConcretePlace.Parking, "Parkoviště"));
            places.AddLast(new Place(ConcretePlace.Grifel, "Grifel"));
            places.AddLast(new Place(ConcretePlace.Chance2, "Náhoda"));
            places.AddLast(new Place(ConcretePlace.Mohyla, "Mohyla"));
            places.AddLast(new Place(ConcretePlace.Metal, "Metál"));
            places.AddLast(new Place(ConcretePlace.Trainer3, "3. Trenér"));
            places.AddLast(new Place(ConcretePlace.Tara, "Tara"));
            places.AddLast(new Place(ConcretePlace.Furioso, "Furioso"));
            places.AddLast(new Place(ConcretePlace.Staje, "Stáje"));
            places.AddLast(new Place(ConcretePlace.Genius, "Genius"));
            places.AddLast(new Place(ConcretePlace.Doping, "Podezření z dopingu"));
            places.AddLast(new Place(ConcretePlace.Shagga, "Shagga"));
            places.AddLast(new Place(ConcretePlace.Dahoman, "Dahoman"));
            places.AddLast(new Place(ConcretePlace.Finance3, "Finance"));
            places.AddLast(new Place(ConcretePlace.Gira, "Gira"));
            places.AddLast(new Place(ConcretePlace.Trainer4, "4. Trenér"));
            places.AddLast(new Place(ConcretePlace.Chance3, "Náhoda"));
            places.AddLast(new Place(ConcretePlace.Narcius, "Narcius"));
            places.AddLast(new Place(ConcretePlace.Clinic2, "Klinika"));
            places.AddLast(new Place(ConcretePlace.Napoli, "Napoli"));
            return new Board(places);
        }
    }
}
