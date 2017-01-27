using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers.Of.Hanoi.Bottom.Up
{
    static class Board
    {
        static public List<Column> Columns = new List<Column>();

        static public void updateState(int[] colsMove)
        {
            // From col 1 to col 3
            if (colsMove[0] == -1 && colsMove[1] == 0 && colsMove[2] == 1)
            {
                Columns[2].addPlate(Columns[0].Plates[Columns[0].Plates.Count - 1]);
                Columns[0].removePlate();
            }

            // From col 3 to col 1
            if (colsMove[0] == 1 && colsMove[1] == 0 && colsMove[2] == -1)
            {
                Columns[0].addPlate(Columns[2].Plates[Columns[2].Plates.Count - 1]);
                Columns[2].removePlate();
            }

            // From col 1 to col 2
            if (colsMove[0] == -1 && colsMove[1] == 1 && colsMove[2] == 0)
            {
                Columns[1].addPlate(Columns[0].Plates[Columns[0].Plates.Count - 1]);
                Columns[0].removePlate();
            }

            // From col 2 to col 1
            if (colsMove[0] == 1 && colsMove[1] == -1 && colsMove[2] == 0)
            {
                Columns[0].addPlate(Columns[1].Plates[Columns[1].Plates.Count - 1]);
                Columns[1].removePlate();
            }

            // From col 2 to col 3
            if (colsMove[0] == 0 && colsMove[1] == -1 && colsMove[2] == 1)
            {
                Columns[2].addPlate(Columns[1].Plates[Columns[1].Plates.Count - 1]);
                Columns[1].removePlate();
            }

            // From col 3 to col 2
            if (colsMove[0] == 0 && colsMove[1] == 1 && colsMove[2] == -1)
            {
                Columns[1].addPlate(Columns[2].Plates[Columns[2].Plates.Count - 1]);
                Columns[2].removePlate();
            }
        }
    }
}
