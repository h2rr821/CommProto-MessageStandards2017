/**
  VehicleWaypointCommand Packet Template.
  
  Copyright (C) 2016-2017 Northrup Grumman Collaboration Project.
  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (At your option) any later version.
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#ifndef NGCP_Vehicle_Waypoint_Command_HPP
#define NGCP_Vehicle_Waypoint_Command_HPP


#include <CommProto/commproto.h>


namespace ngcp {
  
struct VehicleWaypointCommand : INHERITS_ABSPACKET {
  VehicleWaypointCommand(uint16_t vehicle_id = 0,
		float latitude = 0,
		float longitude = 0,
		float altitude = 0) 
    : CHAIN_ABSPACKET(VehicleWaypointCommand)
    , vehicle_id(vehicle_id)
		, latitude(latitude)
		, longitude(longitude)
		, altitude(altitude)
    { }
  
  
  /**
    Pack data into the stream for sending out.
  */
  void Pack(comnet::ObjectStream &obj) override {
    obj << vehicle_id;
		obj << latitude;
		obj << longitude;
		obj << altitude;
  }
  
  
  /**
    Unpack data back into this packet when receiving data.
  */
  void Unpack(comnet::ObjectStream &obj) override {
		obj >> altitude;
		obj >> longitude;
		obj >> latitude;
		obj >> vehicle_id;
  }
  
  
  /**
    Tells CommProtocol how to recreate the VehicleWaypoint packet
    when receiving data.
  */
  comnet::AbstractPacket *Create() override {
    return new VehicleWaypointCommand();
  }
    
  /**
    Data.
  */
  uint16_t vehicle_id;
	float latitude;
	float longitude;
	float altitude;
};
} // ngcp
#endif // NGCP_Vehicle_Waypoint_Command_HPP
