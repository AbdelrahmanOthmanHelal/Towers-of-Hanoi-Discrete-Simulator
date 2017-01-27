using System.Collections.Generic;

namespace Towers.Of.Hanoi.Bottom.Up
{
    public class Column
    {
        int maxColBase = 90, minColBase = 320, maxPlateWidth = 120;
        public int ColBorderFromX;
        public List<Plate> Plates = new List<Plate>();
        
        public void addPlate()
        {
            Plates.Add(new Plate());
            Plates[Plates.Count - 1].setHeight(20);
            Plates[Plates.Count - 1].setWidth(maxPlateWidth);
            Plates[Plates.Count - 1].setXCoord(ColBorderFromX - (maxPlateWidth/2)); // Devide by 2 to center the plate.
            Plates[Plates.Count - 1].setYCoord(minColBase);
            minColBase -= 23; // 20 as the height + 3 as a padding ratio.
            maxPlateWidth -= 12;
        }

        public void addPlate(Plate p)
        {
            p.setXCoord(ColBorderFromX - (p.getWidth() / 2)); // Devide by 2 to center the plate.
            p.setYCoord(minColBase);
            Plates.Add(p);
            minColBase -= 23;
        }

        public void removePlate()
        {
            Plates.RemoveAt(Plates.Count - 1);
            minColBase += 23; // 20 as the height + 3 as a padding ratio.
            maxPlateWidth += 12;
        }
    }
}
