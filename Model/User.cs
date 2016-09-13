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

using FileHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkAlert
{
    public class User : Database
    {

        private StoredProcedureParameters[] parameters;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string dateCreated;
        public string DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        private string dateModified;
        public string DateModified
        {
            get { return dateModified; }
            set { dateModified = value; }
        }

        public User(int id, string userUserName, string userFirstName, string userLastName, string dateCreated, string dateModified)
        {
            Id = id;
            Username = userUserName;
            FirstName = userFirstName;
            LastName = userLastName;
            DateCreated = dateCreated;
            DateModified = dateModified;

        }

        public User(string password)
        {
            Password = password;
        }

        public User(string loginUserName, string password)
        {
            Username = loginUserName;
            Password = password;
        }

        public User(){}

        public bool Login()
        {
            try
            {
                //parameters and db query to check if the entered user name and password exist
                parameters = new StoredProcedureParameters[2];
                parameters[0] = new StoredProcedureParameters("_tableName", "users");
                parameters[1] = new StoredProcedureParameters("_condition", "WHERE users.userName='" + Username + "' AND users.password='" + md5(Password)+"'");

                int userLoginCount = CountRows("__Counter", parameters);

                if (userLoginCount > 0)
                {
                    try
                    {
                        //parameters and db query to check if the entered user name and password exist
                        StoredProcedureParameters[] parameters = new StoredProcedureParameters[1];
                        parameters[0] = new StoredProcedureParameters("_userName", Username);

                        Database database = new Database();
                        database.ReadTable("User_GetUserDetails", "dtCurrentUser", null, parameters);

                        if (database.DbDataset1.Tables["dtCurrentUser"].Rows.Count > 0)
                        {
                            User sessionUser = new User();

                            sessionUser.Id = Convert.ToInt32(database.DbDataset1.Tables["dtCurrentUser"].Rows[0]["id"]);
                            sessionUser.Username = Convert.ToString(database.DbDataset1.Tables["dtCurrentUser"].Rows[0]["userName"]);
                            sessionUser.FirstName = Convert.ToString(database.DbDataset1.Tables["dtCurrentUser"].Rows[0]["firstName"]);
                            sessionUser.LastName = Convert.ToString(database.DbDataset1.Tables["dtCurrentUser"].Rows[0]["lastName"]);

                            GlobalSetup.CurrentSessionUser = sessionUser;
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLogger.LogEvent(this, ex.Message.ToString(), ex);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
                return false;
            }

        }

        public int AddNew()
        {
            parameters = new StoredProcedureParameters[6];

            parameters[0] = new StoredProcedureParameters("_userName", Username);
            parameters[1] = new StoredProcedureParameters("_firstName", FirstName);
            parameters[2] = new StoredProcedureParameters("_lastName", LastName);
            parameters[3] = new StoredProcedureParameters("_password", md5(Password));
            parameters[4] = new StoredProcedureParameters("_dateCreated", DateCreated);
            parameters[5] = new StoredProcedureParameters("_dateModified", DateModified);

            return GetNewIdFromStoredProcedure("User_Create", parameters);

        }
        public bool Update()
        {
            parameters = new StoredProcedureParameters[5];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());
            parameters[1] = new StoredProcedureParameters("_userName", Username);
            parameters[2] = new StoredProcedureParameters("_firstName", FirstName);
            parameters[3] = new StoredProcedureParameters("_lastName", LastName);
            parameters[4] = new StoredProcedureParameters("_dateModified", DateModified);
            return RunStoredProcedure("User_Update", parameters);

        }

        public bool UpdatePassword()
        {
            parameters = new StoredProcedureParameters[2];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());
            parameters[1] = new StoredProcedureParameters("_userPassword", md5(Password));
            return RunStoredProcedure("User_PasswordUpdate", parameters);

        }

        public bool Remove()
        {
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_id", Id.ToString());

            return RunStoredProcedure("User_Remove", parameters);
        }
        public bool Read()
        {
            return ReadTable("User_Get");
        }
        private string md5(string password)
        {
            //Declaraciones
            System.Security.Cryptography.MD5 md5;
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //Conversion
            Byte[] encodedBytes = md5.ComputeHash(ASCIIEncoding.Default.GetBytes(password + "loremIpsumDolorSitAmet"));
            //genero el hash a partir de la password original

            //Resultado

            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", "");
            //devuelve el hash continuo y en minuscula. (igual que en php)
        }
    }
}
