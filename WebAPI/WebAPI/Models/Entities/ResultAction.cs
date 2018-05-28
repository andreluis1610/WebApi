using System.Collections.Generic;
using System.Runtime.Serialization;
using WebAPI.Models.DTO;

namespace WebAPI.Models.Entities
{
    [KnownType(typeof(UserDTO))]
    [KnownType(typeof(List<UserDTO>))]
    [DataContract(Name = "Result")]
    public class ResultAction
    {
        [DataMember]
        public object Result { get; set; }
        [DataMember]
        public bool IsOk { get; set; }
        [DataMember]
        public string Message { get; set; }

        public ResultAction()
        {
            Result = null;
            IsOk = false;
            Message = string.Empty;
        }
    }
}