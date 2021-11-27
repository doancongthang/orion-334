using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using orion_334.Model;

namespace orion_334.Services
{
    class ModbusServices
    {
        private ModbusClient modbusClient;
        string receiveData = null;
        int boardId = 1;
        private Machine mc1;
        private Machine mc2;
        private Machine mc3;
        public ModbusServices(Machine _mc1, Machine _mc2, Machine _mc3 )
        {
            mc1 = _mc1;
            mc2 = _mc2;
            mc3 = _mc3;
            modbusClient = new EasyModbus.ModbusClient();
            modbusClient.SerialPort = "COM8";
            modbusClient.Baudrate = 9600;
            modbusClient.UnitIdentifier = 1;
            modbusClient.ReceiveDataChanged += new ModbusClient.ReceiveDataChangedHandler(UpdateReceiveData);
            //modbusClient.SendDataChanged += new EasyModbus.ModbusClient.SendDataChangedHandler(UpdateSendData);
            //modbusClient.ConnectedChanged += new EasyModbus.ModbusClient.ConnectedChangedHandler(UpdateConnectedChanged);
            modbusClient.LogFileFilename = "logFiletxt.txt";

        }

        private async void loopUpdateModbus()
        {
            while (true)
            {
                Console.WriteLine("Update modbus");
                if(modbusClient.Connected)
                {
                    try
                    {
                        switch (boardId)
                        {
                            case 1:
                                modbusClient.UnitIdentifier = 1;
                                bool[] result = modbusClient.ReadDiscreteInputs(0, 8);
                                Orionsystem.SW_power = result[0];
                                Orionsystem.SW1 = result[1];
                                Orionsystem.SW2 = result[2];
                                Orionsystem.SW3 = result[3];
                                Orionsystem.btn_checklight = result[4];
                                Orionsystem.btn_oilafterfil = result[5];
                                break;
                            case 2:
                                modbusClient.UnitIdentifier = 2;
                                bool[] result2 = modbusClient.ReadDiscreteInputs(0, 8);
                                Orionsystem.rswleft = result2[0];
                                Orionsystem.rswright = result2[1];
                                Orionsystem.rswmid = result2[2];
                                break;
                            case 3:
                                modbusClient.UnitIdentifier = 3;
                                break;
                        }
                        
                        Console.WriteLine("Send");
                        
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Error read");
                    }
                }

                boardId++;
                if (boardId > 2) boardId = 1;
                await Task.Delay(100);
            }
        }

        private async void loopUpdateCoilsModbus()
        {
            while (true)
            {
                if (modbusClient.Connected)
                {
                    try
                    {
                        switch (boardId)
                        {
                            case 1:
                                modbusClient.UnitIdentifier = 1;
                                bool[] serverResponse = modbusClient.ReadCoils(0, 8);


                                modbusClient.WriteSingleCoil(2, mc1.sig_mpa);
                                modbusClient.WriteSingleCoil(3, mc1.sig_mpa);
                                modbusClient.WriteSingleCoil(5, mc1.sig_vnd);
                                modbusClient.WriteSingleCoil(6, mc1.sig_count_rotate);
                                modbusClient.WriteSingleCoil(7, mc1.sig_vvd);
                                break;
                            case 2:
                                modbusClient.UnitIdentifier = 2;

                                break;
                            case 3:
                                modbusClient.UnitIdentifier = 3;

                                break;
                        }

                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Error write coils");
                    }
                }

                boardId++;
                if (boardId > 2) boardId = 1;
                await Task.Delay(200);
            }
        }

        public void UpdateReceiveData(object sender)
        {
            receiveData = "Rx: " + BitConverter.ToString(modbusClient.receiveData).Replace("-", " ");
            Console.WriteLine("Nhận dữ liệu");
        }

        public void Subcribe()
        {
            Task control = Task.Run(() => loopUpdateModbus());  // Khởi chạy loop services
            Task controlLight = Task.Run(() => loopUpdateCoilsModbus());  // Khởi chạy loop services
        }
        
        public void Connect()
        {
            try
            {
                if(modbusClient.Connected)
                {
                    modbusClient.Disconnect();
                }
                modbusClient.Connect();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Unable to connect to Server");
            }     
        }
    }
}
