using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Microsoft.AspNet.Identity;

namespace RentX.Controllers
{
    public class SMSController : TwilioController
    {
        ApplicationDbContext context;

        public SMSController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult SendSMSToRenterForPaymentRequest(Renter renter)
        {
            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + renter.PhoneNumber);
            var from = new PhoneNumber("+19285506141");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "You have a payment request for an item you are interested in.");
            return Content(message.Sid);

            
        }

        public ActionResult SendSMSToLeasorToNotifyRenterAddedToQueue(Leasor leasor)
        {
            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + leasor.PhoneNumber);
            var from = new PhoneNumber("+19285506141");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "You have a new renter in a queue.");
            return Content(message.Sid);

           
        }
        public ActionResult SendSMSToRenterForItemNowRented(Renter renter)
        {
            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + renter.PhoneNumber);
            var from = new PhoneNumber("+19285506141");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Your payment has been recieved, enjoy your item.");
            return Content(message.Sid);


        }

        public ActionResult SendSMSToLeasorToNotifyOfTransaction(Leasor leasor)
        {
            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + leasor.PhoneNumber);
            var from = new PhoneNumber("+19285506141");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "You have recieved a Payment for an item.");
            return Content(message.Sid);


        }

        public ActionResult SendSMSToRenterForRentPeriodEnding(Renter renter)
        {
            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + renter.PhoneNumber);
            var from = new PhoneNumber("+19285506141");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Your rental period has ended. Please return the Item.");
            return Content(message.Sid);


        }
    }
}