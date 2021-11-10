using System;
using System.Collections.Generic;
using System.Linq;
using Fiftyville.DataAccess;
using Fiftyville.Model;
using Microsoft.EntityFrameworkCore;
using static Fiftyville.PrintUtil.Printer;

namespace Fiftyville {
    class Program {
        public static void Main(string[] args) {
            FiftyVilleContext ctx = new FiftyVilleContext();

            // Your LINQ expression goes here

            // Get any crime scene report from july 28th on "Chamberlin Street".
            var result1 = from crimeSceneReport in ctx.CrimeSceneReports
                where (crimeSceneReport.Day == 28 && crimeSceneReport.Month == 7 &&
                       crimeSceneReport.Street == "Chamberlin Street")
                select crimeSceneReport;

            // Take note of time of the crime "Theft of the CS50 duck took place at 10:15am".

            // Get all interviews made on july 28th.
            var result2 = from interview in ctx.Interviews
                where (interview.Day == 28 && interview.Month == 7)
                select interview;

            // We assume this are the interviews of interest to us.
            // ---------------------------------------------------------
            // Sometime within ten minutes of the theft, I saw the thief get into a car in the courthouse parking lot and drive away.
            // If you have security footage from the courthouse parking lot,
            // you might want to look for cars that left the parking lot in that time frame.
            // ---------------------------------------------------
            // I don't know the thief's name, but it was someone I recognized.
            // Earlier this morning, before I arrived at the courthouse,
            // I was walking by the ATM on Fifer Street and saw the thief there withdrawing some money.
            // ------------------------------------------
            // As the thief was leaving the courthouse, they called someone who talked to them for less than a minute.
            // In the call, I heard the thief say that they were planning to take the earliest flight out of Fiftyville tomorrow.
            // The thief then asked the person on the other end of the phone to purchase the flight ticket.


            // All the transactions made on july 28 on street fifer street.
            var result4 = from atmTransaction in ctx.AtmTransactions
                where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                       atmTransaction.AtmLocation == "Fifer Street")
                select atmTransaction;

            // Get the bank accounts of all transactions made on that day.
            var result5 = from bankAccount in ctx.BankAccounts
                where (from atmTransaction in ctx.AtmTransactions
                    where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                           atmTransaction.AtmLocation == "Fifer Street")
                    select atmTransaction.AccountNumber).Contains(bankAccount.AccountNumber)
                select bankAccount;

            // Get the people who own the transactions made on that day.
            var result6 = from person in ctx.People
                where (from bankAccount in ctx.BankAccounts
                    where (from atmTransaction in ctx.AtmTransactions
                        where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                               atmTransaction.AtmLocation == "Fifer Street")
                        select atmTransaction.AccountNumber).Contains(bankAccount.AccountNumber)
                    select bankAccount.PersonId).Contains(person.Id)
                select person;

            //   List of suspects.
            //   Id     | Name      | PhoneNumber    | PassportNumber | LicensePlate | 
            //   395717 | Bobby     | (826) 555-1652 | 9878712108     | 30G67EN      |
            //   396669 | Elizabeth | (829) 555-5269 | 7049073643     | L93JTIZ      |
            //   438727 | Victoria  | (338) 555-6650 | 9586786673     | 8X428L0      |
            //   449774 | Madison   | (286) 555-6063 | 1988161715     | 1106N58      |
            //   458378 | Roy       | (122) 555-4581 | 4408372428     | QX4YZN3      |
            //   467400 | Danielle  | (389) 555-5198 | 8496433585     | 4328GD8      |
            //   514354 | Russell   | (770) 555-1861 | 3592750733     | 322W7JE      |
            //   686048 | Ernest    | (367) 555-5533 | 5773159633     | 94KL13X      |
            //   948985 | Robert    | (098) 555-1164 | 8304650265     | I449449      |
            //   ----------------------------------------------------------------------

            // Get all calls made on that day and less then a minute (*info from the interview).
            var result7 = from phoneCall in ctx.PhoneCalls
                where (phoneCall.Day == 28 && phoneCall.Month == 7 && phoneCall.Year == 2020 && phoneCall.Duration < 60)
                select phoneCall;

            // Get all calls made by our suspects on 28th of july and less the a minute. 
            var result8 = from phoneCall in ctx.PhoneCalls
                where (from person in ctx.People
                          where (from bankAccount in ctx.BankAccounts
                              where (from atmTransaction in ctx.AtmTransactions
                                  where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                                         atmTransaction.AtmLocation == "Fifer Street")
                                  select atmTransaction.AccountNumber).Contains(bankAccount.AccountNumber)
                              select bankAccount.PersonId).Contains(person.Id)
                          select person.PhoneNumber).Contains(phoneCall.Caller) && phoneCall.Day == 28 &&
                      phoneCall.Month == 7 && phoneCall.Year == 2020 && phoneCall.Duration < 60
                select phoneCall;

            // Get the names of people who made less then a minute calls on the 28th of july and are our suspects.
            var result9 = from person in ctx.People
                // Same as result 8 query
                where (from phoneCall in ctx.PhoneCalls
                    where (from person in ctx.People
                              where (from bankAccount in ctx.BankAccounts
                                  where (from atmTransaction in ctx.AtmTransactions
                                      where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                                             atmTransaction.AtmLocation == "Fifer Street")
                                      select atmTransaction.AccountNumber).Contains(bankAccount.AccountNumber)
                                  select bankAccount.PersonId).Contains(person.Id)
                              select person.PhoneNumber).Contains(phoneCall.Caller) && phoneCall.Day == 28 &&
                          phoneCall.Month == 7 && phoneCall.Year == 2020 && phoneCall.Duration < 60
                    select phoneCall.Caller).Contains(person.PhoneNumber)
                select person;

            //    List of our new suspects.
            //    _____________________________________________________________________
            //    Id     | Name     | PhoneNumber    | PassportNumber | LicensePlate |
            //    395717 | Bobby    | (826) 555-1652 | 9878712108     | 30G67EN      |
            //    438727 | Victoria | (338) 555-6650 | 9586786673     | 8X428L0      |
            //    449774 | Madison  | (286) 555-6063 | 1988161715     | 1106N58      |
            //    514354 | Russell  | (770) 555-1861 | 3592750733     | 322W7JE      |
            //    686048 | Ernest   | (367) 555-5533 | 5773159633     | 94KL13X      |
            //   ---------------------------------------------------------------------


            // We know the theft took the car withing 10 minutes of the theft (*info from interview), and we know the theft took place at 10:15am.
            // We query for any entering or exiting of the courthouse around that time.
            var result10 = from courtHouseSecurityLog in ctx.CourtHouseSecurityLogs
                where (courtHouseSecurityLog.Day == 28 && courtHouseSecurityLog.Month == 7 &&
                       courtHouseSecurityLog.Year == 2020 && courtHouseSecurityLog.Hour == 10 &&
                       courtHouseSecurityLog.Minute < 25)
                select courtHouseSecurityLog;
            
            
            // We take all the license plate from result10 and merge them with our latest list of suspects from result 9.
            var result11 = from courtHouseSecurityLog in ctx.CourtHouseSecurityLogs
                // Same as result 9.
                where (from person in ctx.People
                          where (from phoneCall in ctx.PhoneCalls
                              where (from person in ctx.People
                                        where (from bankAccount in ctx.BankAccounts
                                            where (from atmTransaction in ctx.AtmTransactions
                                                where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                                                       atmTransaction.AtmLocation == "Fifer Street")
                                                select atmTransaction.AccountNumber).Contains(bankAccount.AccountNumber)
                                            select bankAccount.PersonId).Contains(person.Id)
                                        select person.PhoneNumber).Contains(phoneCall.Caller) && phoneCall.Day == 28 &&
                                    phoneCall.Month == 7 && phoneCall.Year == 2020 && phoneCall.Duration < 60
                              select phoneCall.Caller).Contains(person.PhoneNumber)
                          select person.LicensePlate).Contains(courtHouseSecurityLog.LicensePlate) &&
                      courtHouseSecurityLog.Day == 28 && courtHouseSecurityLog.Month == 7 &&
                      courtHouseSecurityLog.Year == 2020 && courtHouseSecurityLog.Hour == 10 &&
                      courtHouseSecurityLog.Minute < 25
                select courtHouseSecurityLog;

            // We get the people whose license plate we got from result11.
            var result12 = from person in ctx.People
                where (from courtHouseSecurityLog in ctx.CourtHouseSecurityLogs
                    where (from person in ctx.People
                              where (from phoneCall in ctx.PhoneCalls
                                  where (from person in ctx.People
                                            where (from bankAccount in ctx.BankAccounts
                                                where (from atmTransaction in ctx.AtmTransactions
                                                        where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                                                               atmTransaction.AtmLocation == "Fifer Street")
                                                        select atmTransaction.AccountNumber)
                                                    .Contains(bankAccount.AccountNumber)
                                                select bankAccount.PersonId).Contains(person.Id)
                                            select person.PhoneNumber).Contains(phoneCall.Caller) &&
                                        phoneCall.Day == 28 &&
                                        phoneCall.Month == 7 && phoneCall.Year == 2020 && phoneCall.Duration < 60
                                  select phoneCall.Caller).Contains(person.PhoneNumber)
                              select person.LicensePlate).Contains(courtHouseSecurityLog.LicensePlate) &&
                          courtHouseSecurityLog.Day == 28 && courtHouseSecurityLog.Month == 7 &&
                          courtHouseSecurityLog.Year == 2020 && courtHouseSecurityLog.Hour == 10 &&
                          courtHouseSecurityLog.Minute < 25
                    select courtHouseSecurityLog.LicensePlate).Contains(person.LicensePlate)
                select person;
            
            
            //   Two potential suspects Russel or Ernest.
            //    ____________________________________________________________________
            //    Id     | Name    | PhoneNumber    | PassportNumber | LicensePlate | 
            //    514354 | Russell | (770) 555-1861 | 3592750733     | 322W7JE      |
            //    686048 | Ernest  | (367) 555-5533 | 5773159633     | 94KL13X      |
            //    --------------------------------------------------------------------
            
            // We know the thief is taking the earliest flight tomorrow out of Fiftyville (*from interviews).
            // Find the earliest flight out of Fiftyville of tomorrow.

            var result13 = from flight in ctx.Flights
                where (from airport in ctx.Airports
                          where (airport.City == "Fiftyville")
                          select airport.Id).Contains(flight.OriginAirportId) && flight.Month == 7 &&
                      flight.Day == 29 &&
                      flight.Year == 2020
                select flight;
            
            // We can see that the earliest flight from Fiftyville is at 8:20
            // Next we find out who is boarding that plane.

            var result14 = from passenger in ctx.Passengers
                where (from flight in ctx.Flights
                    where (from airport in ctx.Airports
                              where (airport.City == "Fiftyville")
                              select airport.Id).Contains(flight.OriginAirportId) && flight.Month == 7 &&
                          flight.Day == 29 &&
                          flight.Year == 2020 && flight.Minute == 20 && flight.Hour == 8
                    select flight.Id).Contains(passenger.FlightId)
                select passenger;
            
            // Find if Ernest's or Russell passport id is in the list.
            var result15 = from passenger in ctx.Passengers
                where (from flight in ctx.Flights
                    where (from airport in ctx.Airports
                              where (airport.City == "Fiftyville")
                              select airport.Id).Contains(flight.OriginAirportId) && flight.Month == 7 &&
                          flight.Day == 29 &&
                          flight.Year == 2020 && flight.Minute == 20 && flight.Hour == 8
                    select flight.Id).Contains(passenger.FlightId) && (passenger.PassportNumber == 3592750733 || passenger.PassportNumber == 5773159633)
                select passenger;
            
            // We found Ernest's passport number. Ernest is our thief.
            
            // Find where Ernest is going to.
            var result16 = from airport in ctx.Airports
                where (from flight in ctx.Flights
                    where (from airport in ctx.Airports
                              where (airport.City == "Fiftyville")
                              select airport.Id).Contains(flight.OriginAirportId) && flight.Month == 7 &&
                          flight.Day == 29 &&
                          flight.Year == 2020 && flight.Minute == 20 && flight.Hour == 8
                    select flight.DestinationAirportId).Contains(airport.Id)
                select airport;
            
            // So Ernest is going to London.
            
            // Find out who Ernest call to book a flight.
            var result17 = from person in ctx.People
                where (from phoneCall in ctx.PhoneCalls
                    where (from person in ctx.People
                              where (from bankAccount in ctx.BankAccounts
                                  where (from atmTransaction in ctx.AtmTransactions
                                      where (atmTransaction.Day == 28 && atmTransaction.Month == 7 &&
                                             atmTransaction.AtmLocation == "Fifer Street")
                                      select atmTransaction.AccountNumber).Contains(bankAccount.AccountNumber)
                                  select bankAccount.PersonId).Contains(person.Id) && person.PassportNumber == 5773159633
                              select person.PhoneNumber).Contains(phoneCall.Caller) && phoneCall.Day == 28 &&
                          phoneCall.Month == 7 && phoneCall.Year == 2020 && phoneCall.Duration < 60
                    select phoneCall.Receiver).Contains(person.PhoneNumber)
                select person;
            
            // So Ernest's partner is Berthold.

            // pretty printing result
            PrettyPrint(result17.ToList());
        }
    }
}