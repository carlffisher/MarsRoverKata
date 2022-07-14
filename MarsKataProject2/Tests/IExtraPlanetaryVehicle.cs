using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKataProject
{
    public interface IExtraPlanetaryVehicle
    {
         string MoveVehicle(SquareMartianPlateauArea plateau, IExtraPlanetaryVehicle extraplanetaryvehicle, char[] movevehiclecoords);
    }
}