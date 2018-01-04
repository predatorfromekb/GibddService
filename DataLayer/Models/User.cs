using System;

namespace DataLayer.Models
{
    public class User
    {
        public AccessTypeCode AccessTypeCode { get; }
        public RoleCode RoleCode { get; }

        public User(AccessTypeCode accessTypeCode, RoleCode roleCode)
        {
            AccessTypeCode = accessTypeCode;
            RoleCode = roleCode;
        }
    }
}