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

namespace InkAlert
{
    class PrinterModel : Database
    {

        private StoredProcedureParameters[] parameters;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string printerModelName;
        public string PrinterModelName
        {
            get { return printerModelName; }
            set { printerModelName = value; }
        }

        private int printerMakeId;
        public int PrinterMakeId
        {
            get { return printerMakeId; }
            set { printerMakeId = value; }
        }

        private int printerSeriesId;
        public int PrinterSeriesId
        {
            get { return printerSeriesId; }
            set { printerSeriesId = value; }
        }

        private int printerTypeId;
        public int PrinterTypeId
        {
            get { return printerTypeId; }
            set { printerTypeId = value; }
        }

        private int printerColorId;
        public int PrinterColorId
        {
            get { return printerColorId; }
            set { printerColorId = value; }
        }

        private string standardFunctions;
        public string StandardFunctions
        {
            get { return standardFunctions; }
            set { standardFunctions = value; }
        }

        private int printingCapacityId;
        public int PrintingCapacityId
        {
            get { return printingCapacityId; }
            set { printingCapacityId = value; }
        }

        private int monthlyDuty;
        public int MonthlyDuty
        {
            get { return monthlyDuty; }
            set { monthlyDuty = value; }
        }

        private int ramMemory;
        public int RamMemory
        {
            get { return ramMemory; }
            set { ramMemory = value; }
        }

        private int hddCapacity;
        public int HddCapacity
        {
            get { return hddCapacity; }
            set { hddCapacity = value; }
        }

        private int duplexUnitId;
        public int DuplexUnitId
        {
            get { return duplexUnitId; }
            set { duplexUnitId = value; }
        }

        private string urlSettings;
        public string UrlSettings
        {
            get { return urlSettings; }
            set { urlSettings = value; }
        }

        private string urlConsumables;
        public string UrlConsumables
        {
            get { return urlConsumables; }
            set { urlConsumables = value; }
        }

        private string urlUsage;
        public string UrlUsage
        {
            get { return urlUsage; }
            set { urlUsage = value; }
        }


        public PrinterModel() { }

        public int AddNew()
        {
            string[,] myParams = new string[14, 2] {
                        { "_printerModelName", PrinterModelName }, 
                        { "_printerMakeId", PrinterMakeId.ToString()},
                        { "_printerSeriesId", PrinterSeriesId.ToString()},
                        { "_printerTypeId", PrinterTypeId.ToString()},
                        { "_printerColorId", PrinterColorId.ToString()},
                        { "_standardFunctions", StandardFunctions },
                        { "_printingCapacityId", PrintingCapacityId.ToString()},
                        { "_monthlyDuty", MonthlyDuty.ToString() },
                        { "_ramMemory", RamMemory.ToString() },
                        { "_hddCapacity", HddCapacity.ToString() },
                        { "_duplexUnitId", DuplexUnitId.ToString()},
                        { "_urlSettings", UrlSettings },
                        { "_urlConsumables", UrlConsumables },
                        { "_urlUsage", UrlUsage }
            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }

            return GetNewIdFromStoredProcedure("PrinterModel_Create", parameters);

        }
        public bool Update()
        {
            string[,] myParams = new string[15, 2] {
                        { "_id", Id.ToString() },
                        { "_printerModelName", PrinterModelName }, 
                        { "_printerMakeId", PrinterMakeId.ToString()},
                        { "_printerSeriesId", PrinterSeriesId.ToString() },
                        { "_printerTypeId", PrinterTypeId.ToString()},
                        { "_printerColorId", PrinterColorId.ToString()},
                        { "_standardFunctions", StandardFunctions },
                        { "_printingCapacityId", PrintingCapacityId.ToString()},
                        { "_monthlyDuty", MonthlyDuty.ToString() },
                        { "_ramMemory", RamMemory.ToString() },
                        { "_hddCapacity", HddCapacity.ToString() },
                        { "_duplexUnitId", DuplexUnitId.ToString()},
                        { "_urlSettings", UrlSettings },
                        { "_urlConsumables", UrlConsumables },
                        { "_urlUsage", UrlUsage }
            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }

            return RunStoredProcedure("PrinterModel_Update", parameters);
        }
        public bool Read()
        {
            return ReadTable("PrinterModel_Get");
        }

    }
}
