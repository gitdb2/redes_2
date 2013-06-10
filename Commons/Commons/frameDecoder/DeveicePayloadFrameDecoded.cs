using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunicacion;

namespace uy.edu.ort.obligatorio.Commons.frameDecoder
{
    public class DeveicePayloadFrameDecoded
    {
        public string DeviceId { get; private set; }
        public string Payload { get; private set; }
     
        public const string DELIMITER = "|";

        public DeveicePayloadFrameDecoded() { }

        public virtual void Parse(string frame)
        {
            //deviceId|message....
            try
            {
                string[] payload = frame.Split(new string[] { DELIMITER }, 2, StringSplitOptions.None);

                DeviceId = payload[0];
                Payload = payload[1];
               
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
                DeviceId: [{0}]
                Payload: [{1}]", DeviceId, Payload);
        }

    }
}
