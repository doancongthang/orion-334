using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace orion_334
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty SpinSpeedProperty = DependencyProperty.Register("SpinSpeed", typeof(TimeSpan), typeof(MainWindow), new PropertyMetadata(default(TimeSpan)));
        public static readonly DependencyProperty AngleProperty1 = DependencyProperty.Register("Angle1", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double))); public static readonly DependencyProperty AngleProperty2 = DependencyProperty.Register("Angle2", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty AngleProperty3 = DependencyProperty.Register("Angle3", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double))); public static readonly DependencyProperty AngleProperty4 = DependencyProperty.Register("Angle4", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty AngleProperty5 = DependencyProperty.Register("Angle5", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double))); public static readonly DependencyProperty AngleProperty6 = DependencyProperty.Register("Angle6", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty AngleProperty7 = DependencyProperty.Register("Angle7", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double))); public static readonly DependencyProperty AngleProperty8 = DependencyProperty.Register("Angle8", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty AngleProperty9 = DependencyProperty.Register("Angle9", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double))); public static readonly DependencyProperty AngleProperty10 = DependencyProperty.Register("Angle10", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty AngleProperty11 = DependencyProperty.Register("Angle11", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty xRpmProperty1 = DependencyProperty.Register("xRpm1", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public int i = 270, i_new = 0, stt_ang = 0, stt_ang2 = 0, val_ang1;

        
        public MainWindow()
        {
            InitializeComponent();
            Angle1 = Angle2 = Angle3 = Angle4 = Angle5 = Angle6 = Angle7 = Angle8 = Angle9 = Angle10 = Angle11 = 270;


            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000);
            SpinSpeed = TimeSpan.FromMilliseconds(2000);

            dispatcherTimer.Start();
            //modBusTCP_Connect();
            /*
            if (modbusClient.Connected) // Modbus connected
            {
                // read data asyn
                //dispatcherTimer.Stop();
                dispatcherTimer.Start();
            }
            
            

            //modbusClient.ReceiveDataChanged += new EasyModbus.ModbusClient.ReceiveDataChangedHandler(UpdateReceiveData);
            //modbusClient.SendDataChanged += new EasyModbus.ModbusClient.SendDataChangedHandler(UpdateSendData);
            modbusClient.ConnectedChanged += new EasyModbus.ModbusClient.ConnectedChangedHandler(UpdateConnectedChanged);
            */
        }
        

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            angleinput1.Clear();
            var random = new Random();
            int num = random.Next(0, 360);

            Angle1 = Angle2 = Angle3 = Angle4 = Angle5 = Angle6 = Angle7 = Angle8 = Angle9 = Angle10 = Angle11 = num;
            /*
            
            i++;
            if (i > 359)
            {
                i = 0;
                stt_ang = 1;
            }
            if (i > val_ang1 && stt_ang ==1)
            {
                i = val_ang1;stt_ang = 0;
                i_new = i; stt_ang2 = 1;
                dispatcherTimer.Stop();
            }
            if (val_ang1 < i && stt_ang2 == 1)
            {
                i = val_ang1; stt_ang = 0; stt_ang2 = 0;
                 dispatcherTimer.Stop();
            }
            */

            /*
            angleinput1.Text = readHoldingRegisters[9].ToString();

            // reconnect modbus
            
            if (!modbusClient.Connected) // Modbus connected
            {
                angleinput1.Text = "DISCONNECT";
                modBusTCP_Connect();
            }
              */

        }

        private void angle_Click1(object sender, RoutedEventArgs e)
        {


            float val_ang1;
            bool result = float.TryParse(angleinput1.Text, out val_ang1);
            if (!result)
                return;

            Angle1 = Angle2 = Angle3 = Angle4 = Angle5 = Angle6 = Angle7 = Angle8 = Angle9 = Angle10 = Angle11 = convert100ToDegree((float)convertyRPM(val_ang1));

            xRpm1 = convert1KToDegree((int)convertxRPM(val_ang1));

            //angleinput1.Text = Angle1.ToString();
            //dispatcherTimer.Start();
            angleinput1.Clear();

            dispatcherTimer.Start();
            // Console Output
            //for (int i = 0; i < readCoils.Length; i++)
            //{
            //Console.WriteLine("Value of Coil " + (9 + i + 1) + " " + readCoils[i].ToString());
            //angleinput1.Text = readCoils[i].ToString();
            //}
            //angleinput1.Text = readCoils[9].ToString();

            //for (int i = 0; i < readHoldingRegisters.Length; i++)
            //angleinput1.Text = readHoldingRegisters[9].ToString();
            //Console.WriteLine("Value of HoldingRegister " + (i + 1) + " " + readHoldingRegisters[i].ToString());
            //modbusClient.Disconnect();                                                //Disconnect from Server

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public TimeSpan SpinSpeed
        {
            get { return (TimeSpan)GetValue(SpinSpeedProperty); }
            set { SetValue(SpinSpeedProperty, value); }
        }

        public double Angle1
        {
            get { return (double)GetValue(AngleProperty1); }
            set { SetValue(AngleProperty1, value); }

        }

        public double Angle2
        {
            get { return (double)GetValue(AngleProperty2); }
            set { SetValue(AngleProperty2, value); }

        }

        public double Angle3
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty3, value); }

        }
        public double Angle4
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty4, value); }

        }
        public double Angle5
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty5, value); }

        }
        public double Angle6
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty6, value); }

        }
        public double Angle7
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty7, value); }

        }
        public double Angle8
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty8, value); }

        }
        public double Angle9
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty9, value); }

        }
        public double Angle10
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty10, value); }

        }
        public double Angle11
        {
            get { return (double)GetValue(AngleProperty3); }
            set { SetValue(AngleProperty11, value); }

        }




        public double xRpm1
        {
            get { return (double)GetValue(xRpmProperty1); }
            set { SetValue(xRpmProperty1, value); }

        }

        private void Bug_OnLoaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };

            second.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animation);

        }


        static float convertxRPM(float xrpm)
        {
            float xRpm;
            xRpm = xrpm / 1000;
            return xRpm;
        }
        static float convertyRPM(float yrpm)
        {
            float yRpm;
            yRpm = yrpm % 1000;
            return yRpm;
        }


        // 
        static int convert1KToDegree(int k)
        {

            switch (k)
            {
                case 1:
                    return 306;
                case 2:
                    return 342;
                case 3:
                    return 18;
                case 4:
                    return 54;
                case 5:
                    return 90;
                case 6:
                    return 126;
                case 7:
                    return 162;
                case 8:
                    return 198;

                default:
                    return 243;
            }

        }

        static float convert100ToDegree(float j)
        {
            float a;
            if (j < 250)
            {
                a = (float)(270 + ((j * 7.2) / 20));
            }
            else
            {
                a = (float)(((j * 7.2) / 20) - 90);
            }
            return a;
        }
    }
}
