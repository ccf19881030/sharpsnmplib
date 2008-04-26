using System;
using System.IO;

// ASN.1 BER encoding library by Malcolm Crowe at the University of the West of Scotland
// See http://cis.paisley.ac.uk/crow-ci0
// This is version 0 of the library, please advise me about any bugs
// mailto:malcolm.crowe@paisley.ac.uk

// Restrictions: It is assumed that no encoding has a length greater than 2^31-1.
// UNIVERSAL TYPES
// Some of the more unusual Universal encodings are supported but not fully implemented
// Should you require these types, as an alternative to changing this code
// you can catch the exception that is thrown and examine the contents yourself.
// APPLICATION TYPES
// If you want to handle Application types systematically, you can derive a class from
// Universal, and provide the Creator and Creators methods for your class
// You will see an example of how to do this in the Snmplib
// CONTEXT AND PRIVATE TYPES
// Ad hoc coding can be used for these, as an alterative to derive a class as above.

namespace X690 // all references here are to ITU-X.690-12/97
{
	public abstract class BER
	{
		// internal representation of the encoding
		protected BERtag type; // BERtag class does encoding/decoding
		protected object val = null;
		// safety field
		protected bool e; // encode if true, decode if false
		// external representation of the contents octets
		protected byte[] b;
		protected uint len
		{
			get 
			{  // crash if b is null!
				return (uint)b.Length;
			}
		}
		public bool Encode { get { return e; }}
		protected byte ReadByte(Stream s)
		{
			int n = s.ReadByte();
			if (n==-1)
				throw(new Exception("BER end of file"));
			return (byte)n;
		}
		protected void WriteByte(Stream s,byte b)
		{
			s.WriteByte(b);
		}
	}




}