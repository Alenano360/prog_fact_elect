using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.PointOfService;

namespace Restaurante_BL
{
    public class POS
    {
        
        CashDrawer myCashDrawer;
        PosExplorer explorer;

        public POS()
        {
            explorer = new PosExplorer();
            DeviceInfo ObjDevicesInfo = explorer.GetDevice("CashDrawer");
            myCashDrawer = (CashDrawer)explorer.CreateInstance(ObjDevicesInfo);
        }

        public void OpenCashDrawer()
        {
            myCashDrawer.Open();
            myCashDrawer.Claim(1000);
            myCashDrawer.DeviceEnabled = true;
            myCashDrawer.OpenDrawer();
            myCashDrawer.DeviceEnabled = false;
            myCashDrawer.Release();
            myCashDrawer.Close();
        }
    }
}