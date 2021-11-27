using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using orion_334.Model;

namespace orion_334.Services
{


    enum StateMachine
    {
        MACHINE_OFF, 
        MACHINE_ON,
        HYDRAULICS_PUMP,
        READY_HYDRAULICS_PUPM,
        W_OFFTEST,
        TEST
    }
    class LogicServices
    {
        StateMachine stateMachine;
        private Machine mc1;
        private Machine mc2;
        private Machine mc3;
        public LogicServices(Machine _mc1, Machine _mc2, Machine _mc3)
        {
            mc1 = _mc1;
            mc2 = _mc2;
            mc3 = _mc3;
            stateMachine = StateMachine.MACHINE_OFF;
        }

        private async void loopUpdateActionsStateMachine()
        {
            while (true)
            {
                Console.WriteLine(stateMachine);
                Console.WriteLine(Orionsystem.SW_power);
                switch (stateMachine )  // KIEM TRA CAC DIEU KIEN
                {
                    case StateMachine.MACHINE_OFF:
                        if (Orionsystem.SW_power == true)
                            stateMachine = StateMachine.MACHINE_ON;
                        break;
                    case StateMachine.MACHINE_ON:
                        if (Orionsystem.SW_power == false)
                            stateMachine = StateMachine.MACHINE_OFF;
                        break;
                    case StateMachine.HYDRAULICS_PUMP:
                        break;
                    case StateMachine.READY_HYDRAULICS_PUPM:
                        break;
                    case StateMachine.W_OFFTEST:
                        break;
                }
                switch (stateMachine)  // ACTIONS
                {
                    case StateMachine.MACHINE_OFF:
                        mc1.sig_mpa = true;
                        break;
                    case StateMachine.MACHINE_ON:
                        if (Orionsystem.SW_power == false)
                            stateMachine = StateMachine.MACHINE_OFF;
                        break;
                    case StateMachine.HYDRAULICS_PUMP:
                        break;
                    case StateMachine.READY_HYDRAULICS_PUPM:
                        break;
                    case StateMachine.W_OFFTEST:
                        break;
                }
                await Task.Delay(100);
            }
        }

        public void Subcribe()
        {
            Task control = Task.Run(() => loopUpdateActionsStateMachine());  // Khởi chạy loop services
        }
    }
}
