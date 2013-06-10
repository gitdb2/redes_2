using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace uy.edu.ort.obligatorio.Commons.frameDecoder
{
    public class FaultFrameDecoded : DeveicePayloadFrameDecoded
    {
        public int AlarmType { get; private set; }
        public int AlarmLevel { get; private set; }
        public DateTime AlarmDateTime { get; private set; }

        public override void Parse(string frame)
        {
            base.Parse(frame);

            try
            {
                string[] payload = Payload.Split(new string[] { DELIMITER }, 3, StringSplitOptions.None);

                AlarmType = int.Parse(payload[0]);
                AlarmLevel = int.Parse(payload[1]);
                AlarmDateTime = DateTime.ParseExact(payload[2],
                                          ParseConstants.DATE_TIME_FORMAT,
                                          CultureInfo.InvariantCulture);
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
                DeviceId:       [{0}]
                AlarmType:      [{1}]
                AlarmLevel:     [{2}]
                AlarmDateTime:  [{3}]", DeviceId, AlarmType, AlarmLevel, AlarmDateTime.ToString(ParseConstants.DATE_TIME_FORMAT));
        }

    }
}
