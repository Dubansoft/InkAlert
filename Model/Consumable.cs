
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
    class Consumable : Database
    {

        private StoredProcedureParameters[] parameters;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string consumableType;
        public string ConsumableType
        {
            get { return consumableType; }
            set { consumableType = value; }
        }

        private string consumableTypeName;
        public string ConsumableTypeName
        {
            get { return consumableTypeName; }
            set { consumableTypeName = value; }
        }

        private int consumableTypeId;
        public int ConsumableTypeId
        {
            get { return consumableTypeId; }
            set { consumableTypeId = value; }
        }

        private string consumableModelName;
        public string ConsumableModelName
        {
            get { return consumableModelName; }
            set { consumableModelName = value; }
        }

        private int consumableMakeId;
        public int ConsumableMakeId
        {
            get { return consumableMakeId; }
            set { consumableMakeId = value; }
        }
        private int maxLife;
        public int MaxLife
        {
            get { return maxLife; }
            set { maxLife = value; }
        }

        public Consumable() { }

        public int AddNew()
        {
            string[,] myParams = new string[4, 2] {
                    { "_consumableTypeId", ConsumableTypeId.ToString() },
                    { "_consumableModelName",  ConsumableModelName},
                    { "_consumableMakeId",  ConsumableMakeId.ToString()},
                    { "_maxLife", MaxLife.ToString()
                    }

            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }

            return GetNewIdFromStoredProcedure("Consumable_Create", parameters);

        }
        public bool Update()
        {
            string[,] myParams = new string[5, 2] {
                    { "_id", Id.ToString() },
                    { "_consumableTypeId", ConsumableTypeId.ToString() },
                    { "_consumableModelName",  ConsumableModelName},
                    { "_consumableMakeId",  ConsumableMakeId.ToString()},
                    { "_maxLife", MaxLife.ToString()
                    }

            };

            parameters = new StoredProcedureParameters[myParams.Length / 2];

            for (int i = 0; i < (myParams.Length / 2); i++)
            {
                parameters[i] = new StoredProcedureParameters(myParams[i, 0], myParams[i, 1]);
            }


            return RunStoredProcedure("Consumable_Update", parameters);

        }

        public bool Remove()
        {
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());

            return RunStoredProcedure("Consumable_Remove", parameters);
        }
        public bool Read()
        {   
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_consumableNameFilter", "");

            return ReadTable("Consumable_Get","dtConsumables",null,parameters);
        }

        public bool AddConsumableToPrinterModel()
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
