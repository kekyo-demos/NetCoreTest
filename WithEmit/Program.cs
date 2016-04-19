using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
			//        Console.WriteLine("Hello World!");

			//     try
			//     {
			//Console.WriteLine( "Success: {0}", TryCreateEmptyType() );
			//     }
			//     catch ( Exception ex )
			//     {
			//Console.WriteLine( "Failed :{0}", ex );
			//     }

			TryCreateEmptyType();

        }

	    private static TypeInfo TryCreateEmptyType()
	    {
		    return CreateEmptyType( "FromConsole" );
	    }


		public static TypeInfo CreateEmptyType( string name )
	    {
			//  public static System.Reflection.Emit.AssemblyBuilder DefineDynamicAssembly(System.Reflection.AssemblyName name, System.Reflection.Emit.AssemblyBuilderAccess access) { return default(System.Reflection.Emit.AssemblyBuilder); }
		    var asm = AssemblyBuilder.DefineDynamicAssembly( new AssemblyName( "HostAssembly" ), AssemblyBuilderAccess.RunAndCollect );
		    var mod = asm.DefineDynamicModule( "HostAssembly.dll" );
		    var type = mod.DefineType( name );
		    return type.CreateTypeInfo();
	    }
    }
}
