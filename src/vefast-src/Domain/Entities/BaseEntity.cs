using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        public Guid GetID()
        {
            return ID;
        }

        private DateTime _insertDate;
        private User.User _userInsert;
        private DateTime _updateDate;
        private User.User _updateUser;

        public DateTime InsertDate
        {
            get { return _insertDate; }
            set { _insertDate = value; }
        }
        public virtual User.User InsertUser
        {
            get { return _userInsert; }
            set { _userInsert = value; }
        }
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        public virtual User.User UpdateUser
        {
            get { return _updateUser; }
            set { _updateUser = value; }
        }
    }
}
