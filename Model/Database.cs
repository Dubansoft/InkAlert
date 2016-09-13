
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


using MySql.Data.MySqlClient;
using System;
using System.Data;
using MySqlDatabaseHelper;

namespace InkAlert
{
    ///<summary>
    ///<para>Performs operations and data transactions between MySql Server and the application.</para>
    ///</summary>
    public class Database : MySqlDatabaseHelper.Database
    {
        public Database()
        {
            this.DataBaseName = GlobalSetup.DataBaseName;
            this.DataBasePassword = GlobalSetup.DataBasePassword;
            this.DataBaseServerPort = GlobalSetup.DataBaseServerPort;
            this.DataBaseUserName = GlobalSetup.DataBaseUserName;
            this.DataBaseServerName = GlobalSetup.DataBaseServerName;

            this.UpdateCmdString();
        }
        
    }
}
