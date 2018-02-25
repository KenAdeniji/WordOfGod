using System;
using System.Collections;

namespace Test
{
	enum Title { Miss, Mrs, Mr, Dr, Sir }

	class FullName
	{
		Title title;
		string firstName;
		string lastName;

		public FullName
		(	
			Title title, 
			string firstName, 
			string lastName
		)
		{
			this.title = title;
			this.firstName = firstName;
			this.lastName = lastName;
		}

		public override int GetHashCode()
		{
			return (title.GetHashCode() + firstName.GetHashCode() + lastName.GetHashCode());
		}

		public override bool Equals(object obj)
		{
			return( this == (FullName)obj );	
		}

		public override string ToString()
		{
			return(title.ToString() + ' ' + firstName + ' ' + lastName);
		}

		public new static bool Equals(object obj1, object object2)
		{
			return(obj1 == object2);
		}

		public static bool operator ==(FullName obj1, FullName obj2)
		{
			if ( obj1.title == obj2.title && obj1.firstName == obj2.firstName && obj1.lastName == obj2.lastName )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator !=(FullName obj1, FullName obj2)
		{
			return !(obj1==obj2);
		}
	}

	class Person
	{
		FullName name;
		DateTime dob;	// Date of birth
		string ssn;		// Social security number
		string dln;		// Driver's licence number

		public Person
		(
			FullName name, 
			DateTime dob, 
			string ssn, 
			string dln
		)
		{
			this.name = name;
			this.dob = dob;
			this.ssn = ssn;
			this.dln = dln;
		}

		public override string ToString()
		{
			return 
				"Name: " + name.ToString() + 
				Environment.NewLine +
				"DOB: " + dob.ToShortDateString() + 
				Environment.NewLine +
				"SSN: " + ssn + Environment.NewLine +
				"DLN: " + dln.ToString();
		}
	}

	class Program
	{
		public static void Main() 
		{ 
			Hashtable people = new Hashtable();

			FullName name = new FullName(Title.Mr, "John", "Doe");
			people.Add(name, new Person(name, new DateTime(1977, 8, 7), "012-345-6789", "WA1234567890"));
			Console.WriteLine(people[name].ToString());
			
			System.Collections.SortedList sortedListFullName = new SortedList();
			sortedListFullName.Add("Doe John", new FullName(Title.Mr, "John", "Doe"));
			sortedListFullName.Add("Ipswich Jane", new FullName(Title.Miss, "Jane", "Ipswich"));
			sortedListFullName.Add("Donald Mary", new FullName(Title.Mrs, "Mary", "Donald"));
			sortedListFullName.Add("Smart Larry", new FullName(Title.Mr, "Larry", "Smart"));
			sortedListFullName.Add("Daly Peter", new FullName(Title.Mr, "Peter", "Daly"));

			for ( int i = 0; i < sortedListFullName.Count; i++ )  
			{
				System.Console.WriteLine( "\t{0}:\t{1}", sortedListFullName.GetKey(i), sortedListFullName.GetByIndex(i) );
			}
						
		}
	}
}