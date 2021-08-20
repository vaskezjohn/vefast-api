using System;
namespace vefast_src.Domain.Entities.Groups
{
    public class Groups : BaseEntity
    {
        public string group_name { get; set; }
        public string permission { get; set; }
    }
}
