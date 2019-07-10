using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.PointOfService;
using System.Printing;
using System.Runtime.InteropServices;
using System.IO;

namespace PuntoVentaBL
{
    public class POS
    {
        PosExplorer explorer = null;
        DeviceInfo _device;
        PosPrinter _oposPrinter;
        CashDrawer myCashDrawer;

        public POS()
        {
            explorer = new PosExplorer();
            DeviceInfo ObjDevicesInfo = explorer.GetDevice(DeviceType.CashDrawer);
            _device = explorer.GetDevice(DeviceType.PosPrinter);
            _oposPrinter = (PosPrinter)explorer.CreateInstance(_device);
            myCashDrawer = (CashDrawer)explorer.CreateInstance(ObjDevicesInfo);
        }
        //EPSON TM-T20II Receipt CD415 Cajón de Dinero CashDrawer
        public void OpenCashDrawer()
        {
            myCashDrawer.Open();
            myCashDrawer.Claim(1000);
            myCashDrawer.DeviceEnabled = true;
            myCashDrawer.OpenDrawer();
            myCashDrawer.DeviceEnabled = false;
            myCashDrawer.Release();
            myCashDrawer.Close();

            _oposPrinter.Open();
            _oposPrinter.Claim(10000);
            _oposPrinter.DeviceEnabled = true;
            
            Byte[] bytes = new Byte[] {27, 112, 48, 55, 121};

            //ASCIIEncoding ascii = new ASCIIEncoding();
            //String decoded = ascii.GetString(bytes, 6, 8);
            //Console.WriteLine(decoded);
            //_oposPrinter.PrintNormal(PrinterStation.Receipt, System.Text.ASCIIEncoding.ASCII.GetString(new byte() {27, 112, 48, 55, 121}));
            _oposPrinter.PrintNormal(PrinterStation.Receipt, System.Text.ASCIIEncoding.ASCII.GetString(bytes));
           
            //_oposPrinter.PrintNormal(PrinterStation.Receipt, "27, 112, 48, 55, 121");
        }


    }
}
