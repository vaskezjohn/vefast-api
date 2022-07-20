using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Constants
{
    public static class CustomClaimTypes
    {
        public const string PasswordExpiredAt = "password_expired_at";
        public const string PasswordExpiredAtLegacy = "passwordExpiredAt";
        public const string StatusId = "status_id";
        public const string CustomerStatus = "customer_status";
        public const string LastName = "last_name";
        public const string FirstName = "first_name";
        public const string Vkbur = "vkbur";
        public const string Werk1 = "werk1";
        public const string Werk2 = "werk2";
        public const string CanImpersonate = "can_impersonate";
        public const string IsImpersonating = "is_impersonating";
        public const string ImpersonatingSubject = "impersonating_subject";
        public const string Endpoint = "API_Endpoints";
    }
}
