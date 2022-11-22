using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SearchNUpdate.Services;
using SearchNUpdate.Config;
using System.Linq;


namespace SearchNUpdate
{
    class Program
    {
        private static IConfiguration _appConfiguration;      
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] consentTypeValues = { "Member", "Advisor", "ThirdParty", "Unknown" };
            string[] consentReceiverValues = { "Receiver1", "Receiver2", "Receiver3" };
            string[] consentCategoryValues = { "DM Post", "DM Phone", "DM Email", "DM Sms", "DM Social", "DONT USE", "TEST" };
            string[] consentStatusValues = { "REGISTER", "REVOKE" };

            int newItems = rand.Next(5000);
            int exItems = rand.Next(2500);

            List<Consent> newConsentArray = new List<Consent>();
            for (int ctr = 0; ctr <= newItems; ctr++)
            {
                Consent tempConsent = new Consent()
                    { 
                        consentType = consentTypeValues[rand.Next(3)], 
                        consentReceiver = consentReceiverValues[rand.Next(3)],
                        consentCategory = consentCategoryValues[rand.Next(6)], 
                        consentStatus = consentStatusValues[rand.Next(2)] 
                    };

                newConsentArray.Add(tempConsent);
                Console.WriteLine("{0} {1} {2} {3}",tempConsent.consentType, tempConsent.consentReceiver,tempConsent.consentCategory,tempConsent.consentStatus);
            }
            
            List<Consent> exConsentArray = new List<Consent>();
            for (int ctr = 0; ctr <= exItems; ctr++)
            {
                Consent tempConsent = new Consent()
                    { 
                        consentType = consentTypeValues[rand.Next(3)], 
                        consentReceiver = consentReceiverValues[rand.Next(3)],
                        consentCategory = consentCategoryValues[rand.Next(6)], 
                        consentStatus = consentStatusValues[rand.Next(2)] 
                    };

                exConsentArray.Add(tempConsent);
                Console.WriteLine("{0} {1} {2} {3}",tempConsent.consentType, tempConsent.consentReceiver,tempConsent.consentCategory,tempConsent.consentStatus);
            }

            var firstNotSecond = exConsentArray.Except(newConsentArray).ToList();

            Console.WriteLine("Not found items are");
            for (int ctr = 0; ctr < firstNotSecond.Count; ctr++)
            {
                Consent tempConsent = firstNotSecond[ctr];
                Console.WriteLine("{0} {1} {2} {3}",tempConsent.consentType, tempConsent.consentReceiver,tempConsent.consentCategory,tempConsent.consentStatus);
            }
            Console.WriteLine( Equals(newConsentArray, exConsentArray));

        }

    }
}
