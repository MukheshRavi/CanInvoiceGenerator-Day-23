using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
   public class RideRepository
    {
        public Dictionary<string, List<RideDetails>> userDataSummary = new Dictionary<string, List<RideDetails>>();

        public RideDetails[] GetRides(string userId)
        {
            // See if the user is registered or not
            if (!userDataSummary.ContainsKey(userId))
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "User is not registered");

            // Throw exception if user has zero rides
            if (userDataSummary[userId].Count == 0)
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "User has no rides");

            // If user has rides then return the list of rides
            return userDataSummary[userId].ToArray();
        }

        /// <summary>
        /// UC 4 Adds the rides.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        public void AddRides(string userId, RideDetails[] rides)
        {
            bool rideList = this.userDataSummary.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<RideDetails> list = new List<RideDetails>();
                    list.AddRange(rides);
                    this.userDataSummary.Add(userId, list);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }
    }
}
