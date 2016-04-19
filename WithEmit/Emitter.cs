using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace WithEmit
{
    public static class Emitter
    {
        //public static void Main(string[] args)
        //{
        //    //        Console.WriteLine("Hello World!");

        //    //     try
        //    //     {
        //    //Console.WriteLine( "Success: {0}", TryCreateEmptyType() );
        //    //     }
        //    //     catch ( Exception ex )
        //    //     {
        //    //Console.WriteLine( "Failed :{0}", ex );
        //    //     }

        //    TryCreateEmptyType();
        //}

        //private static TypeInfo TryCreateEmptyType()
        //{
        //    return CreateEmptyType( "FromConsole" );
        //}


        public static TypeInfo CreateTestType()
        {
            //  public static System.Reflection.Emit.AssemblyBuilder DefineDynamicAssembly(System.Reflection.AssemblyName name, System.Reflection.Emit.AssemblyBuilderAccess access) { return default(System.Reflection.Emit.AssemblyBuilder); }
            var asm = AssemblyBuilder.DefineDynamicAssembly( new AssemblyName( "HostAssembly" ), AssemblyBuilderAccess.RunAndCollect );
            var mod = asm.DefineDynamicModule( "HostAssembly.dll" );
            var type = mod.DefineType("WithEmit_TestType", TypeAttributes.Public | TypeAttributes.Class);
            var method = type.DefineMethod(
                "TestMethod",
                MethodAttributes.Public | MethodAttributes.Static,
                CallingConventions.Standard,
                typeof(string),
                new[] { typeof(int), typeof(double) });
            var ilg = method.GetILGenerator();
            ilg.Emit(OpCodes.Ldstr, "{0}-{1}");
            ilg.Emit(OpCodes.Ldarg_0);
            ilg.Emit(OpCodes.Box, typeof(int));
            ilg.Emit(OpCodes.Ldarg_1);
            ilg.Emit(OpCodes.Box, typeof(double));

            var stringType = typeof(string).GetTypeInfo();
            var parameterTypes = new[] {typeof(string), typeof(object), typeof(object)};
            var formatMethod = stringType.DeclaredMethods.First(mi =>
                (mi.Name == "Format") &&
                (mi.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes)));

            ilg.Emit(OpCodes.Call, formatMethod);
            ilg.Emit(OpCodes.Ret);

            return type.CreateTypeInfo();
        }
    }
}
