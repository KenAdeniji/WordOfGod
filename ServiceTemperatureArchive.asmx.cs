using System;
using System.Collections.Generic;
using System.EnterpriseServices;

namespace WordEngineering
{

 /// <summary>ServiceTemperature</summary>
 [
  System.Web.Services.WebService
  (
   Description="A temperature conversion service.",
   Name="ServiceTemperature"
  )
 ]
 public class ServiceTemperature : System.Web.Services.WebService
 {
  ///<summary>CelsuisToFahrenheit</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="This method converts a temperature in " +
                "degrees Celsuis to a temperature in degrees Fahrenheit.",
    EnableSession=true,
    MessageName="CelsusisToFahrenheit",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public double CelsuisToFahrenheit
  (
   double celsuis
  )
  {
   double fahrenheit = UtilityTemperature.CelsuisToFahrenheit( celsuis );
   return ( fahrenheit );
  }

  ///<summary>CelsuisToKelvin</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="This method converts a temperature in " +
                "degrees Celsuis to a temperature in degrees Kelvin.",
    EnableSession=true,
    MessageName="CelsusisToKelvin",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public double CelsuisToKelvin
  (
   double celsuis
  )
  {
   double kelvin = UtilityTemperature.CelsuisToKelvin( celsuis );
   return ( kelvin );
  }

  ///<summary>FahrenheitToCelsuis</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="This method converts a temperature in " +
                "degrees Fahrenheit to a temperature in degrees Celsius.",
    EnableSession=true,
    MessageName="FahrenheitToCelsuis",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public double FahrenheitToCelsuis
  (
   double fahrenheit
  )
  {
   double celsuis = UtilityTemperature.FahrenheitToCelsuis( fahrenheit );
   return ( celsuis );
  }

  ///<summary>FahrenheitToKelvin</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="This method converts a temperature in " +
                "degrees Fahrenheit to a temperature in degrees Kelvin.",
    EnableSession=true,
    MessageName="FahrenheitToKelvin",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public double FahrenheitToKelvin
  (
   double fahrenheit
  )
  {
   double kelvin = UtilityTemperature.FahrenheitToKelvin( fahrenheit );
   return ( kelvin );
  }

  ///<summary>KelvinToCelsuis</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="This method converts a temperature in " +
                "degrees Kelvin to a temperature in degrees Celsuis.",
    EnableSession=true,
    MessageName="KelvinToCelsuis",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public double KelvinToCelsuis
  (
   double kelvin
  )
  {
   double celsuis = UtilityTemperature.KelvinToCelsuis( kelvin );
   return ( celsuis );
  }

  ///<summary>KelvinToFahrenheit</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="This method converts a temperature in " +
                "degrees Kelvin to a temperature in degrees Fahrenheit.",
    EnableSession=true,
    MessageName="KelvinToFahrenheit",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public double KelvinToFahrenheit
  (
   double kelvin
  )
  {
   double fahrenheit = UtilityTemperature.KelvinToFahrenheit( kelvin );
   return ( fahrenheit );
  }
  
  ///<summary>Metric</summary>
  [
   System.Web.Services.WebMethod
   (
    BufferResponse=true,
    CacheDuration=60,
    Description="Celsuis (Centigrade), Fahrenheit, Kelvin ",
    EnableSession=true,
    MessageName="Metric",
    TransactionOption=TransactionOption.RequiresNew
   )
  ]
  public List<string> Metric()
  {
   return ( UtilityTemperature.Metric() );
  }
  
 }
}