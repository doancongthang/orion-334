using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orion_334.Model
{
    enum BoardID
    {
        Board1,
        Board2,
        Board3
    }

    class Machine
    {
        #region Signal start
        public  bool sw_start_auto;             //SW choose mode start. Lựa chọn chế độ khởi động
        public  bool btn_start;                 //Button start
        public  bool _status_autostart;
        public  bool btn_on_preminary_pump;     //Bt bật Bơm sơ bộ
        public  bool btn_off_preminary_pump;    //Bt tắt bơm sơ bộ
        public  bool btn_on_low_airpressure;    //Bật quay áp thấp
        public  bool btn_on_hig_airpressure;    //Mở van khí khởi động (Bật khí cao áp)

        public  bool sig_mpa;                   //Signal MPA    Áp suất dầu nhờn đạt 4KG/cm2
        public  bool sig_vnd;                   //Tín hiệu khí thấp áp
        public  bool sig_count_rotate;          //Tín hiệu đếm đủ số vòng quay. 
        public  bool sig_vvd;                   //Tín hiệu khí cao áp

        public  bool sig_starting_forbidden;    //Tín hiệu cấm khởi động
        public  bool sig_upper_oil;             //Tín hiệu cao áp suất dầu nhờn
        public  bool sig_oil_supply;            //Tín hiệu cung cấp dầu.
        #endregion

        #region Signal and controll speed
        public  bool sig_highspeed;             //Signal high speed
        public  bool sig_goahead;               //Signal up
        public  bool sig_gobehind;              //Signal down
        public  bool sig_park;                  //Signal park at position  //Dừng đỗ

        public  bool sig_nopressure;            //Signal no pressure

        public  bool btn_up;                    //Bt Up
        public  bool btn_down;                  //Bt Down
        public  bool btn_quickdown;             //Bt giảm nhanh
        public  bool btn_estop;                 //Bt Emergency Stop
        #endregion

        #region Signal controll pump
        public  bool sw_zero_fuel_supply;       //SW zero fuel supply

        public  bool sig_pumping_out;           //Signal Pumping out
        public  bool sig_oil_isnot_pumpingout;  //Signal Oil is not pumping out
        public  bool sw_pumpout;                //Bơm hút dầu nhờn
        #endregion

        #region Signal Alarm and protect
        // 8 Den canh bao
        public  bool sig_pressure_oil;          //Canh bao ap suat dau
        public  bool sig_temperature_oil;       //Canh bao nhiet do dau
        public  bool sig_pressure_water;        //Canh bao ap suat nuoc
        public  bool sig_temperature_water;     //Canh bao nhiet do nuoc
        public  bool sig_protect_on;            //Den bao ve bat tat
        public  bool sig_phi_s1;                //Canh bao mạt sắt 1
        public  bool sig_phi_s2;                //Canh bao mạt sắt 2
        public  bool sig_phi_s3;                //Canh bao mạt sắt 3

        public  bool btn_burn;                  //Nut nhan đốt mạt sắt
        public  bool sw_protect;                //SW bảo vệ Auto/Manual
        #endregion

        #region Signal After start to main show
        // 3 giá trị
        public  int vl_temperature_gas;     //Giá trị nhiệt độ 
        public  int vl_speed_engine;        //Giá trị tốc độ vòng quay động cơ
        public  int vl_mainlineoilpressure; //Giá trị áp suất đường dẫn chính
        #endregion

        public Machine()
        {
            sw_start_auto = false;
            btn_start = false;
            btn_on_preminary_pump = false;
            btn_off_preminary_pump = false;
            btn_on_low_airpressure = false;
            btn_on_hig_airpressure = false;

            sig_mpa = false;
            sig_vnd = false;
            sig_count_rotate = false;
            sig_vvd = false;

            sig_starting_forbidden = false;
            sig_upper_oil = false;
            sig_oil_supply = false;

            sig_highspeed = false;
            sig_goahead = false;
            sig_gobehind = false;
            sig_park = false;

            sig_nopressure = false;

            btn_up = false;
            btn_down = false;
            btn_quickdown = false;
            btn_estop = false;

            sw_zero_fuel_supply = false;

            sig_pumping_out = false;
            sig_oil_isnot_pumpingout = false;
            sw_pumpout = false;

            sig_pressure_oil = false;
            sig_temperature_oil = false;
            sig_pressure_water = false;
            sig_temperature_water = false;
            sig_protect_on = false;
            sig_phi_s1 = false;
            sig_phi_s2 = false;
            sig_phi_s3 = false;

            btn_burn = false;
            sw_protect = false;


            vl_temperature_gas = 0;
            vl_speed_engine = 0;
            vl_mainlineoilpressure = 0;
        }
        //public Machine(bool sw_start_auto)
        //{

        //}
        #region Khối chức năng
        public bool startauto(bool sw_start_auto, bool btn_start)
        {
            if (sw_start_auto == true & btn_start == true)
            {
                _status_autostart = true;
            }
            return _status_autostart;
        }
        public bool startmanual()
        {
            return btn_start;
        }
        public bool controlspeed()
        {
            return sig_nopressure;
        }
        public int presenttomain()
        {
            return vl_speed_engine;        //Tốc độ vòng quay động cơ
        }
        #endregion
    }

    public class Orionsystem
    {
        #region Maincontrol
        // Tong so 11 bien
        public static bool SW_power;           //SW Power

        public static bool SW1;                //SW1 Switch mode Oil, Water
        public static bool SW2;                //SW2 Switch mode on Energy
        public static bool SW3;                //SW3 Switch mode Pump

        public static bool btn_checklight;     //Bt check all light
        public static bool btn_oilafterfil;    //Bt check oil after fil

        public static bool rswleft;            //Rotate SW position left
        public static bool rswright;           //Rotate SW position right
        public static bool rswmid;             //Rotate SW position middle

        public static bool btn_callbehindcabin;    //Bt call KMO   Gọi khoang máy sau
        public static bool btn_callheadcabin;      //Bt call HMO   Gọi khoang máy trước
        public static bool btn_wheelhouse;         //Bt ходоб рубка
        #endregion

        #region Main show
        // Hien thi len dong ho 9 bien + 1 bien thoi gian                      
        public static int vl_temperature_water_in;     //Temperature water input           
        public static int vl_temperature_water_out;    //Temperature water out             
        public static int vl_temperature_oil_in;       //Temperature oil in                
        public static int vl_temperature_oil_out;      //Temperature oil output            
        public static int vl_reverse_air_pressure;     //Reverse air pressure              
        public static int vl_hydraulics;               //Pressure hydraulics               
        public static int vl_pressurefuel;             //Pressure fuel                     
        public static int vl_pressureptk;              //Pressure ptk                      
        public static int vl_oilafterfilter;           //Value oil after filter 
        public static int vl_oilbeforefilter;          //Value oil before filter         

        public static int vl_time_hours;
        public static int vl_time_minute;
        public static int vl_time_second;
        public static int vl_time_month;

        public static int sig_main_pump;          //Lamp main pump                    
        public static int sig_remote_pump;        //Lamp remote pump                  
        public static int sig_mainhas_pressure;   //Lamp main has pressure            
        public static int sig_mainno_pressure;    //Lamp main has no pressure         
        public static int sig_mainKMO;            //Lamp main KMO                     
        public static int sig_mainHMO;            //Lamp main HMO                     
        public static int sig_mainOK;             //Lamp main has Power               
        public static int sig_main_hobbyshirt;    //Lamp main Ходоб рубка
        #endregion
    }
}
