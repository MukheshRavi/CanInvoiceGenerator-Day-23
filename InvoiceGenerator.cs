// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kumar Kartikeya"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        public RideType rideType;
        ///Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly double COST_PER_KM;
        private readonly double MINIMUM_FARE;
        ///Default constructor
        public InvoiceGenerator() { }
        ///Parameterized  constructor
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;

            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_KM = 1;
            this.MINIMUM_FARE = 5;
        }
        /// <summary>
        /// This method returns total fare
        /// Given distance and time of ride
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_KM;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                if (distance <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                if (time <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid time");
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}