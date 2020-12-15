﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Common.Common
{
    [Serializable]
    public class AccountLogin
    {
        public int AccountID { get; set; }
        public string Email { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public int AccountType { get; set; }
    }
}
