// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Mukhesh Attuluri"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        public RideType rideType;
        public double totalFare = 0;
        public double averageFare = 0;
        private RideRepository rideRepository;
        ///Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly double COST_PER_MIN;
        private readonly double MINIMUM_FARE;
        ///Parameterized  constructor
        public InvoiceGenerator(RideType rideType)
        {
            this.rideRepository = new RideRepository();
            this.rideType = rideType;

            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_MIN= 1;
            this.MINIMUM_FARE = 5;
        }
        /// <summary>
        /// UC1
        /// This method returns total fare
        /// Given distance and time of ride
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_MIN;
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
        /// <summary>
        /// UC2
        /// This method takes multiple Ride details and calculate fare
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(RideDetails[] rides)
        {
            try
            {
                foreach (RideDetails ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
                averageFare = totalFare / rides.Length;
            }
            catch
            {
                if (rides == null)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
            return new InvoiceSummary(rides.Length, totalFare, averageFare);
        }
        /// <summary>
        /// Adds the rides in dictionary with key as a user id 
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Null rides</exception>
        public void AddRides(string userId, RideDetails[] rides)
        {
            try
            {
                rideRepository.AddRides(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null rides");
                }
            }
        }
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
    }
}