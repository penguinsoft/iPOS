using System;
using System.Runtime.Serialization;

namespace iPOS.DCO
{
    [DataContract]
    public class BaseDRO
    {
        [DataMember]
        public ResponseStatus Status { get; set; }

        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public long TotalItemCount;

        [DataMember]
        public string Username;

    }

    public enum ResponseStatus
    {
        [EnumMember]
        Success = 1,

        [EnumMember]
        Failure = 2,

        [EnumMember]
        Exception = 3
    }
}
