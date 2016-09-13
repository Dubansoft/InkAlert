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
    class Oid : Database
    {

        private StoredProcedureParameters[] parameters;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int printerModelId;
        public int PrinterModelId
        {
            get { return printerModelId; }
            set { printerModelId = value; }
        }

        private int oidTypeId;
        public int OidTypeId
        {
            get { return oidTypeId; }
            set { oidTypeId = value; }
        }

        private string oidTypeName;
        public string OidTypeName
        {
            get { return oidTypeName; }
            set { oidTypeName = value; }
        }

        private string oidAddress;
        public string OidAddress
        {
            get { return oidAddress; }
            set { oidAddress = value; }
        }

        private string oidAddressId;
        public string OidAddressId
        {
            get { return oidAddressId; }
            set { oidAddressId = value; }
        }

        private int oidReturnDataTypeId;
        public int OidReturnDataTypeId
        {
            get { return oidReturnDataTypeId; }
            set { oidReturnDataTypeId = value; }
        }

        private int oidPrinterMakeId;
        public int OidPrinterMakeId
        {
            get { return oidPrinterMakeId; }
            set { oidPrinterMakeId = value; }
        }

        private int printerConnectionTypeId;
        public int PrinterConnectionTypeId
        {
            get { return printerConnectionTypeId; }
            set { printerConnectionTypeId = value; }
        }

        public Oid() { }

        public int AddNew()
        {
            string[,] myParams = new string[5, 2] {
                    { "_oidTypeId", OidTypeId.ToString() },
                    { "_oidAddress", OidAddress },
                    { "_oidReturnDataTypeId", oidReturnDataTypeId.ToString() },
                    { "_oidPrinterMakeId", OidPrinterMakeId.ToString() },
                    { "_printerConnectionTypeId", PrinterConnectionTypeId.ToString() }

            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }

            return GetNewIdFromStoredProcedure("Oid_Create", parameters);

        }
        public bool Update()
        {
            string[,] myParams = new string[6, 2] {
                    { "_id", Id.ToString() },
                    { "_oidTypeId", OidTypeId.ToString() },
                    { "_oidAddress", OidAddress },
                    { "_oidReturnDataTypeId", OidReturnDataTypeId.ToString() },
                    { "_oidPrinterMakeId", OidPrinterMakeId.ToString() },
                    { "_printerConnectionTypeId", PrinterConnectionTypeId.ToString() }

            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }


            return RunStoredProcedure("Oid_Update", parameters);

        }

        public bool Remove()
        {
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());

            return RunStoredProcedure("Oid_Remove", parameters);
        }
        public bool Read()
        {
            return ReadTable("Oid_Get");
        }

        public bool AddOidToPrinterModel()
        {

            try
            {



                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
            
        }

    }
}
