using System.Reflection;

namespace dotnet_eight.Runtime;

public unsafe class PClass
{
    public delegate* unmanaged[Cdecl, SuppressGCTransition]<in int, void> _fp;
    public int* p;
    
    void M(int i)
    {
        p = &i;
    }
}

public class FunctionPointer
{
    public static void RunIt()
    {
        FieldInfo? fieldInfo = typeof(PClass).GetField(nameof(PClass._fp));

        Type? fpType = fieldInfo?.FieldType;
        
        // obtain function pointer for investment
        Console.WriteLine("Function Pointer: " + fpType?.IsFunctionPointer);

        Console.WriteLine("IsUnmanagedFunctionPointer: " + fpType?.IsUnmanagedFunctionPointer);

        Console.WriteLine("Return Type: " + fpType?.GetFunctionPointerReturnType());
    }
}