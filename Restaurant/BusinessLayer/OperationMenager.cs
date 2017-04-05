using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
   public class OperationMenager
    {
       public OperationMenager() { }
       private static volatile OperationMenager singleton;

      private static volatile Object lockObject = new Object();

       public static Object LockObject
       {
           get { return OperationMenager.lockObject; }
           set { OperationMenager.lockObject = value; }
       }

       public static OperationMenager Singleton
       {
           get {
               if (OperationMenager.singleton == null)
                { 
                lock (OperationMenager.lockObject)
                    {

                    if (OperationMenager.singleton == null)
                        {
                            OperationMenager.singleton = new OperationMenager();
                         }
                    }
               
                }
               return OperationMenager.singleton;
              }
        }

       private RestaurantEntities restaurant = new RestaurantEntities();

       public OperationResult execute(Operation operation)
       {
           return operation.execute(restaurant);
       }
      
    }
}