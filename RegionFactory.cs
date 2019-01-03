using LoRaTools.LoRaPhysical;
using LoRaTools.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoRaTools.Regions
{
    public static class RegionFactory
    {
        public static Region CurrentRegion
        {
            get; set;
        }

        static public void Create(Rxpk _rxpk)
        {
            //EU863-870
            if (_rxpk.freq < 870 && _rxpk.freq > 863)
            {
                CurrentRegion =  CreateEURegion();
            }//US902-928-->CN470-510
            else if(_rxpk.freq<=510 && _rxpk.freq >= 470)
            {
                CurrentRegion = CreateUSRegion();
            }
        }

        static Region CreateEURegion()
        {
            Region r = new Region(
                RegionEnum.EU,
                0x34,
                 ConversionHelper.StringToByteArray("C194C1"),
                 (frequency: 869.525, datr : 0),
                 1,
                 2,
                 5,
                 6,
                 16384,
                 64,
                 32,
                 (min : 1, max:3)

                );
            r.DRtoConfiguration.Add(0, (configuration: "SF12BW125", maxPyldSize: 59));
            r.DRtoConfiguration.Add(1, (configuration: "SF11BW125", maxPyldSize: 59));
            r.DRtoConfiguration.Add(2, (configuration: "SF10BW125", maxPyldSize: 59));
            r.DRtoConfiguration.Add(3, (configuration: "SF9BW125", maxPyldSize: 123));
            r.DRtoConfiguration.Add(4, (configuration: "SF8BW125", maxPyldSize: 230));
            r.DRtoConfiguration.Add(5, (configuration: "SF7BW125", maxPyldSize: 230));
            r.DRtoConfiguration.Add(6, (configuration: "SF7BW250", maxPyldSize: 230));
            r.DRtoConfiguration.Add(7, (configuration: "50", maxPyldSize: 230)); //USED FOR GFSK

            r.TXPowertoMaxEIRP.Add(0, "16");
            r.TXPowertoMaxEIRP.Add(1, "2");
            r.TXPowertoMaxEIRP.Add(2, "4");
            r.TXPowertoMaxEIRP.Add(3, "6");
            r.TXPowertoMaxEIRP.Add(4, "8");
            r.TXPowertoMaxEIRP.Add(5, "10");
            r.TXPowertoMaxEIRP.Add(6, "12");
            r.TXPowertoMaxEIRP.Add(7, "14");

            r.RX1DROffsetTable = new int[8, 6]{
            { 0,0,0,0,0,0},
            { 1,0,0,0,0,0},
            { 2,1,0,0,0,0},
            { 3,2,1,0,0,0},
            { 4,3,2,1,0,0},
            { 5,4,3,2,1,0},
            { 6,5,4,3,2,1},
            { 7,6,5,4,3,2} };
            return r;
        }

        static Region CreateUSRegion()
        {
            Region r = new Region(
                RegionEnum.US,
                0x34,
                 null, //no GFSK in US Band
                 (frequency: 505.3, datr: 0),
                 1,
                 2,
                 5,
                 6,
                 16384,
                 64,
                 32,
                 (min: 1, max: 3)

                );
            r.DRtoConfiguration.Add(0, (configuration: "SF12BW125", maxPyldSize: 59));
            r.DRtoConfiguration.Add(1, (configuration: "SF11BW125", maxPyldSize: 59));
            r.DRtoConfiguration.Add(2, (configuration: "SF10BW125", maxPyldSize: 59));
            r.DRtoConfiguration.Add(3, (configuration: "SF9BW125", maxPyldSize: 123));
            r.DRtoConfiguration.Add(4, (configuration: "SF8BW125", maxPyldSize: 250));
            r.DRtoConfiguration.Add(5, (configuration: "SF7BW125", maxPyldSize: 250));

            r.TXPowertoMaxEIRP.Add(0, "19.15");
            r.TXPowertoMaxEIRP.Add(1, "2");
            r.TXPowertoMaxEIRP.Add(2, "4");
            r.TXPowertoMaxEIRP.Add(3, "6");
            r.TXPowertoMaxEIRP.Add(4, "8");
            r.TXPowertoMaxEIRP.Add(5, "10");
            r.TXPowertoMaxEIRP.Add(6, "12");
            r.TXPowertoMaxEIRP.Add(7, "14");
       

            r.RX1DROffsetTable = new int[6, 6]{
            { 0,0,0,0,0,0},
            { 1,0,0,0,0,0},
            { 2,1,0,0,0,0},
            { 3,2,1,0,0,0},
            { 4,3,2,1,0,0},
            { 5,4,3,2,1,0},
            };
            return r;
        }
       
    }
}
