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
    class PrinterMake : Database
    {

        private StoredProcedureParameters[] parameters;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string printerMakeName;
        public string PrinterMakeName
        {
            get { return printerMakeName; }
            set { printerMakeName = value; }
        }

        private string printerMakeDescription;
        public string PrinterMakeDescription
        {
            get { return printerMakeDescription; }
            set { printerMakeDescription = value; }
        }


        public PrinterMake(int id, string userPrinterMakeName, string userPrinterMakeDescription)
        {
            Id = id;
            PrinterMakeName = userPrinterMakeName;
            PrinterMakeDescription = userPrinterMakeDescription;

        }

        public PrinterMake() { }

        public int AddNew()
        {
            string[,] myParams = new string[2, 2] {
                    { "_printerMakeName", PrinterMakeName },
                    { "_printerMakeDescription", PrinterMakeDescription }
            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }

            return GetNewIdFromStoredProcedure("PrinterMake_Create", parameters);

        }
        public bool Update()
        {
            string[,] myParams = new string[3, 2] {
                    { "_id", Id.ToString() },
                    { "_printerMakeName", PrinterMakeName },
                    { "_printerMakeDescription", PrinterMakeDescription }
            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }


            return RunStoredProcedure("PrinterMake_Update", parameters);

        }

        public bool Remove()
        {
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());

            return RunStoredProcedure("PrinterMake_Remove", parameters);
        }
        public bool Read()
        {
            return ReadTable("PrinterMake_Get");
        }

    }
}
