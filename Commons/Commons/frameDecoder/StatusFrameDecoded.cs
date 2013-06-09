using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons.frameDecoder
{
    public class StatusFrameDecoded : DeveicePayloadFrameDecoded
    {
        public bool StatusOnOff { get; private set; }
        public long UpTime { get; private set; }


        public override void Parse(string frame)
        {
            base.Parse(frame);

            try
            {
                string[] payload = Payload.Split(new string[] { DELIMITER }, 2, StringSplitOptions.None);
                StatusOnOff = int.Parse(payload[0]) == 1;
                UpTime      = long.Parse(payload[1]);
            }
            catch (Exception e)
            {
                throw new System.FormatException("No se pudo parsear " + frame, e); ;
            }
        }

        public override string ToString()
        {
            return String.Format(
                @"
                DeviceId:    [{0}]
                Payload:     [{1}]
                StatusOnOff: [{2}]
                UpTime:      [{3}]", DeviceId, Payload, StatusOnOff, UpTime);
        }
    }
}
