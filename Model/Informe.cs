//  Copyright 2015 Jhorman Duban Rodríguez Pulgarín
//  
//  This file is part of InkAlert.
//  
//  InkAlert is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  InkAlert is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with InkAlert.  If not, see <http://www.gnu.org/licenses/>.
//  
//  Jhorman Duban Rodríguez., hereby disclaims all copyright interest in 
//  the program "InkAlert" (which makes passes at 
//  compilers) written by Jhorman Duban Rodríguez.
//  
//  Jhorman Duban Rodríguez,
//  5 January 2016
//  For more information, visit <http://www.codigoinnovador.com/projects/inkalert/>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SnmpSharpNet;

namespace InkAlert
{
    class Informe : Database
    {

        private StoredProcedureParameters[] parameters;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string areaName;
        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }

        private int locationId;
        public int LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        private string storyNumber;
        public string StoryNumber
        {
            get { return storyNumber; }
            set { storyNumber = value; }
        }

        private string hostName;
        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }

        private IpAddress ipAddress;
        public IpAddress IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        private string printerQueueName;
        public string PrinterQueueName
        {
            get { return printerQueueName; }
            set { printerQueueName = value; }
        }

        public Informe() { }

        public int AddNew()
        {
            string[,] myParams = new string[6, 2] {
                    { "_areaName", AreaName },
                    { "_areaHostName", HostName },
                    { "_areaIpAddress", Convert.ToString(IpAddress) },
                    { "_areaQueueName", PrinterQueueName  },
                    { "_locationId", LocationId.ToString() },
                    { "_storyNumber", StoryNumber }
            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }

            return GetNewIdFromStoredProcedure("Area_Create", parameters);

        }
        public bool Update()
        {
            string[,] myParams = new string[7, 2] {
                    { "_id", Id.ToString() },
                    { "_areaName", AreaName },
                    { "_areaHostName", HostName },
                    { "_areaIpAddress", Convert.ToString(IpAddress) },
                    { "_areaQueueName", PrinterQueueName  },
                    { "_locationId", LocationId.ToString() },
                    { "_storyNumber", StoryNumber }
            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }


            return RunStoredProcedure("Area_Update", parameters);

        }

        public bool Remove()
        {
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());

            return RunStoredProcedure("Area_Remove", parameters);
        }
        public bool Read()
        {
            return ReadTable("Area_Get");
        }

    }
}
