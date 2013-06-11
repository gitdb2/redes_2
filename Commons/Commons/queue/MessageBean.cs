using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons.queue
{
    public enum MessageTypeEnum {STATUS, FAULT};

    [Serializable]
    public class MessageBean
    {
        public MessageTypeEnum MessageType { get; set; }
        public string Message { get; set; }
    }
}
