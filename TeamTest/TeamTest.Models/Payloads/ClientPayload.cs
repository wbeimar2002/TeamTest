using System;
using System.Collections.Generic;
using System.Text;

namespace TeamTest.Models.Payloads
{
    public class ClientPayload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
