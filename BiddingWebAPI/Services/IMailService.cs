﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Services
{
    public interface IMailService
    {
        void SendVerificationLinkEmail(string name,string emailId, string activationcode, string activationUrl);
    }
}
