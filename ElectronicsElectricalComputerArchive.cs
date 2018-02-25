using System;
namespace WordEngineering
{
 ///<summary>ElectronicsElectricalComputer</summary>
 public class ElectronicsElectricalComputer
 {
  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( String[] argv )
  {
  }

  /// <summary>Current</summary>
  /// <remarks>System.Console.WriteLine("Current: {0}", Current( 100, 25 ) );</remarks> 
  public static double Current( double voltage, double resistance )
  {
   return ( voltage / resistance );
  }

  /// <summary>Power</summary>
  /// <remarks>System.Console.WriteLine("Power: {0}", Power( 100, 25 ) );</remarks> 
  public static double Power( double voltage, double resistance )
  {
   return ( voltage * voltage / resistance );
  }
  
  /// <summary>Resistance</summary>
  /// <remarks>System.Console.WriteLine("Resistance: {0}", Resistance( 100, 25 ) );</remarks> 
  public static double Resistance( double voltage, double current )
  {
   return ( voltage / current );
  }
  
  /// <summary>ResistorParallel</summary>
  /// <remarks>System.Console.WriteLine("Resistance: {0}", ResistorParallel( new double[] { 4, 6 } ) );</remarks> 
  public static double ResistorParallel( double[] resistor )
  {
   double resistance = 0;
   for( int index = 0; index < resistor.Length; ++index )
   {
   	resistance += 1 / resistor[index];
   }
   return ( 1 / resistance );
  }

  /// <summary>ResistorSeries</summary>
  /// <remarks>System.Console.WriteLine("Resistance: {0}", ResistorSeries( new double[] { 4, 6 } ) );</remarks> 
  public static double ResistorSeries( double[] resistor )
  {
   double resistance = 0;
   for( int index = 0; index < resistor.Length; ++index )
   {
   	resistance += resistor[index];
   }
   return ( resistance );
  }

  /// <summary>Voltage</summary>
  /// <remarks>System.Console.WriteLine("Voltage: {0}", Voltage( 25, 4 ) );</remarks> 
  public static double Voltage( double current, double resistance )
  {
   return ( current * resistance );
  }
  
 }
}
