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
using SnmpSharpNet;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace InkAlert
{
    class PrinterSnmpUpdate : Database
    {

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        private int printerAreaId;
        public int PrinterAreaId
        {
            get { return printerAreaId; }
            set { printerAreaId = value; }
        }

        private int printerModelId;
        public int PrinterModelId
        {
            get { return printerModelId; }
            set { printerModelId = value; }
        }

        private int printerConnectionTypeId;
        public int PrinterConnectionTypeId
        {
            get { return printerConnectionTypeId; }
            set { printerConnectionTypeId = value; }
        }

        private int printerStatus;
        public int PrinterStatus
        {
            get { return printerStatus; }
            set { printerStatus = value; }
        }

        public PrinterSnmpUpdate() { }
        
        
        public bool Read()
        {
            return ReadTable("Printer_Get");
        }


        // SNMP METHODS

        public string DefaultIpAddress = "0.0.0.0";
        public string DefaultOid = "1.1.1.1";

        private string communityName = "public";
        private string hostName = "localhost";

        public string CommunityName
        {
            get { return communityName; }
            set
            {
                if (value != null)
                {
                    communityName = value;
                }
            }
        }

        public string HostName
        {
            get { return hostName; }
            set
            {
                if (value != null)
                {
                    hostName = value;
                }
            }
        }

        public IpAddress HostNameToIpAddress(string hostName)
        {
            IpAddress agent = new IpAddress(DefaultIpAddress);

            try
            {
                return new IpAddress(hostName);
            }
            catch (Exception e)
            {
                EventLogger.LogEvent(this, e.Message, e);
                return agent;
            }
        }


        private Pdu pduOidList;
        public Pdu PduOidList
        {
            get { return pduOidList; }
            set { pduOidList = value; }
        }
     

        public VbCollection GetPrinterInfo()
        {
            VbCollection returnedValues;
            returnedValues = null;

            // SNMP community name
            OctetString community = new OctetString(communityName);

            // Define agent parameters class
            AgentParameters param = new AgentParameters(community);
            
            // Set SNMP version to 1 (or 2)
            param.Version = SnmpVersion.Ver1;
            // Construct the agent address object
            // IpAddress class is easy to use here because
            //  it will try to resolve constructor parameter if it doesn't
            //  parse to an IP address

            IpAddress agent = new IpAddress(DefaultIpAddress);

            try
            {
                agent = new IpAddress(HostName);
            }
            catch (Exception e)
            {
                EventLogger.LogEvent(this, e.Message,e);
            }



            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, GlobalSetup.SnmpRequestTimeOut, GlobalSetup.SnmpRequestRetry);

            // Make SNMP request

            SnmpV1Packet result = null;
            VbCollection vbReturnError = new VbCollection();

            try
            {


                int timeout = 120;
                Ping pingSender = new Ping();

                PingReply reply = pingSender.Send(agent.ToString(), timeout);

                if (reply.Status != IPStatus.Success)
                {
                    EventLogger.LogEvent(this, "Failed to contact ip " + agent.ToString() + ". Reply was \"" + reply.Status.ToString() + "\"",null);
                    vbReturnError.Add("Null");
                    returnedValues = vbReturnError;

                    goto CloseRequest;
                }

                result = (SnmpV1Packet)target.Request(PduOidList, param);
            }
            catch (Exception e)
            {
                EventLogger.LogEvent(this, "There has been an error: " + e.Message,e);

            }

            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                //ErrorStatus other then 0 is an error returned by
                //the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                    {
                        // agent reported an error with the request
                        EventLogger.LogEvent(this, "Error in SNMP reply. Error " + result.Pdu.ErrorStatus + " index " + result.Pdu.ErrorIndex, null);

                        vbReturnError.Add("Null");
                        returnedValues = vbReturnError;
                    
                    }
                    else
                    {
                    returnedValues = result.Pdu.VbList;
                    //EventLogger.LogEvent(this, result.Pdu.VbList[0].ToString(),null);
                }
            }
            else
            {
                EventLogger.LogEvent(this, "No response received from SNMP agent.",null);

                vbReturnError.Add("Null");
                returnedValues = vbReturnError;
            }

            CloseRequest:

            target.Close();
            return returnedValues;
        }//end GetSnmpValue
    }
}
