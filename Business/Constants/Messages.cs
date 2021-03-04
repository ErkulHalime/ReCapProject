using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Car added.";
        public static string BrandAdded = "Brand  added.";
        public static string ColorAdded = "Color added.";
        public static string CarNameInvalid = "Car's  name is invalid";
        public static string MaintenanceTime = "System is under maintenance";
        public static string CarListed = "Car listed";
        public static string BrandListed = "Brand listed";
        public static string ColorListed = "Color listed";

        public static string RentalAdded = "Car rental added";
        public static string RentalUpdated = "Car rental updated";
        public static string RentalDeleted = "Car rental deleted";
        public static string FailedRentalAddOrUpdate = "This car can not be rented";
        public static string ReturnedRental = "";

        public static string UserAdded = "User added";
        public static string UserUpdated = "User updated";
        public static string UserDeleted = "User deleted";

        public static string CustomerAdded = "Customer added";
        public static string CustomerUpdated = "Customer updated";
        public static string CustomerDeleted = "Customer deleted";

        public static string AddedCarImage = "The uploaded image for the car has been successfully added.";
        public static string DeletedCarImage = "The picture of the car was deleted successfully.";
        public static string UpdatedCarImage = "The uploaded image for the car has been successfully updated.";
        public static string FailedCarImageAdd = "A car cannot have more than 5 pictures";
        internal static string CarImageExists ="car image already exist";
        internal static string CarImageListed = "car image listed";
        internal static string CarExists = "already exist";

        public static string CarImageNotFound = "Car image can not found";
        public static string CarNotFound = "Car not found";
        public static string AuthorizationDenied = "You have no authority.";

        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "wrong password";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exist";
        public static string AccessTokenCreated = "created Token";
    }
}
