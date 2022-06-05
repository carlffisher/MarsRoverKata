using MarsRoverKataProject3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataProject3
{
    public interface IExtraPlanetaryVehicle
    {
        public string MoveVehicle(SquareMartianPlateauArea plateau, IExtraPlanetaryVehicle extraplanetaryvehicle, char[] movevehiclecoords);
    }
}