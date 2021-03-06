/*
 VehicleGlobalPosition
 

 Copyright (C) 2016-2017  Northrup Grumman Collaboration Project.
 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.
  
 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.
  
 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Comnet;
using Comnet.Serialization;

namespace NGCP
{
  /**
   * VehicleGlobalPosition Packet Template. 
   */
  class VehicleGlobalPosition : ABSPacket
  {
    public VehicleGlobalPosition(UInt16 vehicle_id = 0,
      Int32 latitude = 0,
      Int32 longitude = 0,
      Int32 altitude = 0,
      Int16 x_speed = 0,
      Int16 y_speed = 0,
      Int16 z_speed = 0)
      : base("VehicleGlobalPosition")
    {
      this.vehicle_id = vehicle_id;
      this.latitude = latitude;
      this.longitude = longitude;
      this.altitude = altitude;
      this.x_speed = x_speed;
      this.y_speed = y_speed;
      this.z_speed = z_speed;
    }

    public override ABSPacket Create()
    {
      return new VehicleGlobalPosition();
    }

    public override void Pack(ObjectStream obj)
    {
      obj.Input(vehicle_id);
      obj.Input(latitude);
      obj.Input(longitude);
      obj.Input(altitude);
      obj.Input(x_speed);
      obj.Input(y_speed);
      obj.Input(z_speed);
    }

    public override void Unpack(ObjectStream obj)
    {
      z_speed = obj.OutputInt16();
      y_speed = obj.OutputInt16();
      x_speed = obj.OutputInt16();
      altitude = obj.OutputInt32();
      longitude = obj.OutputInt32();
      latitude = obj.OutputInt32();
      vehicle_id = obj.OutputUInt16();
    }

    #region Data
    public UInt16 vehicle_id { get; set; }
    public Int32 latitude { get; set; }
    public Int32 longitude { get; set; }
    public Int32 altitude { get; set; }
    public Int16 x_speed { get; set; }
    public Int16 y_speed { get; set; }
    public Int16 z_speed { get; set; }
    #endregion
  }
}

